using Employment.DBHandling;
using Employment.DBHandling.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add Db context and repositories to the container.
builder.Services.AddDbContext<EmploymentDbContext>();
builder.Services.AddScoped<IManagementRepository, ManagementRepository>();
builder.Services.AddScoped<IPremiumsRepository, PremiumsRepository>();

// Add controllers to the container.
builder.Services.AddControllers();

// Add Swagger to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build and configure Web Application.
var app = builder.Build();
app.UseHttpsRedirection();
app.MapControllers();

// Configure swagger.
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = "swagger";
});

app.Run();