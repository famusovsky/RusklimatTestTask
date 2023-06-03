using System.IO;
using Employment.DBHandling.Management;
using Employment.WebAPI.Management;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var managementDbContext = new ManagementDbContext(configuration);

var managementRepository = new ManagementRepository(managementDbContext);

var app = WebApplication
    .CreateBuilder()
    .Build();

APIConfigurator.Configure(app, managementRepository);

app.Run();