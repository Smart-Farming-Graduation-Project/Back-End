using Croppilot.API;
using Croppilot.Core;
using Croppilot.Core.Exceptions;
using Croppilot.Date.Identity;
using Croppilot.Infrastructure;
using Croppilot.Infrastructure.Data;
using Croppilot.Infrastructure.Seeder;
using Croppilot.Services;
using Hangfire;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WatchDog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddInfrastructureDependencies(builder.Configuration).AddApiDependencies(builder.Configuration)
    .AddCoreDependencies().AddServicesDependencies(builder.Configuration);

var app = builder.Build();

app.UseHangfireDashboard(app.Configuration.GetValue<string>("HangfireSettings:DashboardPath"), new DashboardOptions
{
    DashboardTitle = app.Configuration.GetValue<string>("HangfireSettings:Title"),
});

using (var scope = app.Services.CreateScope())
{
    // Apply Migrations Automatically
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await dbContext.Database.MigrateAsync();

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
    await RoleSeeder.SeedAsync(roleManager);
    await UserSeeder.SeedAsync(userManager);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseWatchDogExceptionLogger();

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.UseWatchDog(opt =>
{
    opt.WatchPageUsername = app.Configuration.GetValue<string>("WatchDogSettings:WatchPageUsername");
    opt.WatchPagePassword = app.Configuration.GetValue<string>("WatchDogSettings:WatchPagePassword");
    // opt.Blacklist = "api/Authentication/SignIn";
    // //Prevent logging for SignIn endpoints ( it work but need to make all end points in Auth controller)
});

app.MapControllers();

app.Run();