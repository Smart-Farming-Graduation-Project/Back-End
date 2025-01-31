using Croppilot.API;
using Croppilot.Core;
using Croppilot.Infrastructure;
using Croppilot.Infrastructure.Data;
using Croppilot.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddInfrastructureDependencies(builder.Configuration).AddApiDependencies()
    .AddCoreDependencies().AddServicesDependencies(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//todo: authentication should add after cors remove this after implement authentication
app.UseCors();

app.UseExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();