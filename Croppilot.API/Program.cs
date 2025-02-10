using Croppilot.API;
using Croppilot.Core;
using Croppilot.Date.Identity;
using Croppilot.Infrastructure;
using Croppilot.Infrastructure.Data;
using Croppilot.Infrastructure.Seeder;
using Croppilot.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddInfrastructureDependencies(builder.Configuration).AddApiDependencies()
	.AddCoreDependencies().AddServicesDependencies(builder.Configuration);
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
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

app.UseHttpsRedirection();
app.UseCors();

app.UseExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();