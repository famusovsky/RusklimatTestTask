using Employment.WebAPI;
using Employment.DBHandling;
using Employment.DBHandling.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

// For normal conversion of DateTime to TIMESTAMP WITHOUT TIME ZONE
System.AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Get app's configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(System.IO.Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var builder = WebApplication.CreateBuilder();

// Add Swagger to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure WebApi
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

// Configure swagger.
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = "swagger";
});

app.Run();
