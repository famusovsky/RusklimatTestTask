using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Employment.DBHandling.Management;
using Employment.Models.Management;

namespace Employment.WebAPI.Management
{
    /// <summary>
    /// This class is responsible for configuring the API endpoints for the Management module.
    /// </summary>
    public static class APIConfigurator
    {
        /// <summary>
        /// Configures the API endpoints for the Management module.
        /// </summary>
        /// <param name="routeBuilder">The route builder.</param>
        /// <param name="repository">The database repository.</param>
        public static void Configure(IEndpointRouteBuilder routeBuilder, IManagementRepository repository)
        {
            routeBuilder.MapGet("/", () => new { Message = "Hello, World!" });

            ConfigureManagersCRUD(routeBuilder, repository);
        }

        /// <summary>
        /// Configures the API endpoints for the CRUD operations on the managers repository.
        /// </summary>
        /// <param name="routeBuilder">The route builder.</param>
        /// <param name="repository">The managers repository.</param>
        public static void ConfigureManagersCRUD(IEndpointRouteBuilder routeBuilder, IManagementRepository repository)
        {
            routeBuilder.MapGet("/managers", () =>
            {
                try
                {
                    var managers = repository.GetManagers();

                    return Results.Json(managers);
                }
                catch (System.ArgumentException e)
                {
                    return Results.NotFound(new { message = e.Message });
                }
                catch (System.Exception e)
                {
                    return Results.BadRequest(new { message = e.Message });
                }
            });

            routeBuilder.MapGet("/managers/{id}", (uint id) =>
            {
                try
                {
                    var manager = repository.GetManager(id);

                    return Results.Json(manager);
                }
                catch (System.ArgumentException e)
                {
                    return Results.NotFound(new { message = e.Message });
                }
                catch (System.Exception e)
                {
                    return Results.BadRequest(new { message = e.Message });
                }
            });

            routeBuilder.MapPost("/managers", (Manager manager) =>
            {
                try
                {
                    repository.AddManager(manager);

                    return Results.Created($"/managers/{manager.Id}", new { Message = $"Manager {manager.Id} created successfully." });
                }
                catch (System.ArgumentException e)
                {
                    return Results.Conflict(new { message = e.Message });
                }
                catch (System.Exception e)
                {
                    return Results.BadRequest(new { message = e.Message });
                }
            });

            routeBuilder.MapPut("/managers/{id}", (uint id, Manager manager) =>
            {
                try
                {
                    repository.UpdateManager(id, manager);

                    return Results.Accepted($"/managers/{id}", new { Message = $"Manager {id} updated successfully." });
                }
                catch (System.ArgumentException e)
                {
                    return Results.NotFound(new { message = e.Message });
                }
                catch (System.Exception e)
                {
                    return Results.BadRequest(new { message = e.Message });
                }
            });

            routeBuilder.MapDelete("/managers/{id}", (uint id) =>
            {
                try
                {
                    repository.DeleteManager(id);

                    return Results.Accepted($"/managers/{id}", new { Message = $"Manager {id} deleted successfully." });
                }
                catch (System.ArgumentException e)
                {
                    return Results.NotFound(new { message = e.Message });
                }
                catch (System.Exception e)
                {
                    return Results.BadRequest(new { message = e.Message });
                }
            });
        }
    }
}
