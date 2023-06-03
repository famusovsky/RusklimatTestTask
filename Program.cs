using System.IO;
using Employment.WebAPI;
using Employment.DBHandling;
using Employment.WebAPI.Management;
using Employment.DBHandling.Management;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var app = WebApplication
    .CreateBuilder()
    .Build();

app.MapGet("/", () => "Hello World!");

ConfigureManagement(configuration, app);

ConfigurePremiums(configuration, app);

app.Run();

void ConfigureManagement(IConfiguration configuration, IEndpointRouteBuilder app)
{
    var managementDbContext = new ManagementDbContext(configuration);

    var managementRepository = new ManagementRepository(managementDbContext);

    ManagersAPIConfigurator.Configure(app, managementRepository);
}

void ConfigurePremiums(IConfiguration configuration, IEndpointRouteBuilder app)
{
    var premiumsContext = new PremiumsDbContext(configuration);

    var premiumsRepository = new PremiumsRepository(premiumsContext);

    PremiumsAPIConfigurator.Configure(app, premiumsRepository);
}