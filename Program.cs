using System;
using System.IO;
using Employment.WebAPI;
using Employment.DBHandling;
using Employment.DBHandling.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var app = WebApplication
    .CreateBuilder()
    .Build();

app.MapGet("/", () => "Hello World!");

try
{
    var employmentDbContext = new EmploymentDbContext(configuration);

    var managementRepository = new ManagementRepository(employmentDbContext);
    var premiumsRepository = new PremiumsRepository(employmentDbContext);

    ManagersAPIConfigurator.Configure(app, managementRepository);
    PremiumsAPIConfigurator.Configure(app, premiumsRepository);
}
catch(System.Exception e)
{
    System.Console.WriteLine("Error while configuring API: " + e.Message);
    return;
}

app.Run();
