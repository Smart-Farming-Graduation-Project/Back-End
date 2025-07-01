using Croppilot.API;
using Croppilot.Core;
using Croppilot.Core.Exceptions;
using Croppilot.Date.Identity;
using Croppilot.Infrastructure;
using Croppilot.Infrastructure.Data;
using Croppilot.Infrastructure.Seeder;
using Croppilot.Services;
using Hangfire;
using HangfireBasicAuthenticationFilter;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WatchDog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"), sqlOptions =>
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(10),
            errorNumbersToAdd: null)));

builder.Services.AddResponseCaching();

//inject dependencies
builder.Services.AddInfrastructureDependencies(builder.Configuration).AddApiDependencies(builder.Configuration)
    .AddCoreDependencies().AddServicesDependencies(builder.Configuration);
builder.Services.AddHttpContextAccessor();
var app = builder.Build();

app.UseHangfireDashboard(app.Configuration.GetValue<string>("HangfireSettings:DashboardPath"), new DashboardOptions
{
    Authorization =
    [
        new HangfireCustomBasicAuthenticationFilter
        {
            User = app.Configuration.GetValue<string>("HangfireSettings:Username"),
            Pass = app.Configuration.GetValue<string>("HangfireSettings:Password")
        }
    ],
    DashboardTitle = app.Configuration.GetValue<string>("HangfireSettings:Title"),
});

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var dbContext = serviceProvider.GetRequiredService<AppDbContext>();


    if ((await dbContext.Database.GetPendingMigrationsAsync()).Any())
    {
        var strategy = dbContext.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () => { await dbContext.Database.MigrateAsync(); });
    }

    // Seed Roles and Users
    var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
    await RoleSeeder.SeedAsync(roleManager);
    await UserSeeder.SeedAsync(userManager, builder.Configuration);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlerMiddleware>();

//app.UseWatchDogExceptionLogger();

app.UseRouting();

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

// app.UseRateLimiter();
app.UseWatchDog(opt =>
{
    opt.WatchPageUsername = app.Configuration.GetValue<string>("WatchDogSettings:WatchPageUsername");
    opt.WatchPagePassword = app.Configuration.GetValue<string>("WatchDogSettings:WatchPagePassword");
    // opt.Blacklist = "api/Authentication/SignIn";
    // //Prevent logging for SignIn endpoints ( it work but need to make all end points in Auth controller)
});

app.MapControllers();
//.RequireRateLimiting(RateLimiters.ConcurrencyRateLimit);

app.Run();