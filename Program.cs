using System;
using Employment.DBHandling;
using Employment.DBHandling.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EmploymentDbContext>();

builder.Services.AddScoped<IManagementRepository, ManagementRepository>();
builder.Services.AddScoped<IPremiumsRepository, PremiumsRepository>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
