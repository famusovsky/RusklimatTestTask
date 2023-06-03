using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Employment.DBHandling.Repositories;
using Employment.Models;

namespace Employment.WebAPI
{
    /// <summary>
    /// This class is responsible for configuring the API endpoints for the Managers module ("*/managers").
    /// </summary>
    public static class ManagersAPIConfigurator
    {
        /// <summary>
        /// Configures the API endpoints for the Management module ("*/managers")
        /// </summary>
        /// <param name="routeBuilder">The route builder.</param>
        /// <param name="repository">The database repository.</param>
        public static void Configure(IEndpointRouteBuilder routeBuilder, IManagementRepository repository)
        {
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
                    return Results.BadRequest(new { message = e.Message + " " + e.InnerException?.Message });
                }
            });

            routeBuilder.MapGet("/managers/{id}", (int id) =>
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
                    return Results.BadRequest(new { message = e.Message + " " + e.InnerException?.Message });
                }
            });
            
            routeBuilder.MapGet("/managers/bonuses", () =>
            {
                try
                {
                    var bonuses = repository.GetBonusesHistory();

                    return Results.Json(bonuses);
                }
                catch (System.ArgumentException e)
                {
                    return Results.NotFound(new { message = e.Message });
                }
                catch (System.Exception e)
                {
                    return Results.BadRequest(new { message = e.Message + " " + e.InnerException?.Message });
                }
            });

            routeBuilder.MapGet("/managers/bonuses/{id}", (int id) =>
            {
                try
                {
                    var bonuses = repository.GetBonusesHistory(id);

                    return Results.Json(bonuses);
                }
                catch (System.ArgumentException e)
                {
                    return Results.NotFound(new { message = e.Message });
                }
                catch (System.Exception e)
                {
                    return Results.BadRequest(new { message = e.Message + " " + e.InnerException?.Message });
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
                    return Results.BadRequest(new { message = e.Message + " " + e.InnerException?.Message });
                }
            });

            routeBuilder.MapPost("/managers/{id}/call", (int id) =>
            {
                try
                {
                    repository.ApplyCallProcessing(id);

                    return Results.Ok(new { message = $"Manager {id} processed call successfully." });
                }
                catch (System.ArgumentException e)
                {
                    return Results.NotFound(new { message = e.Message });
                }
                catch (System.Exception e)
                {
                    return Results.BadRequest(new { message = e.Message + " " + e.InnerException?.Message });
                }
            });

            routeBuilder.MapPut("/managers/{id}", (int id, Manager manager) =>
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
                    return Results.BadRequest(new { message = e.Message + " " + e.InnerException?.Message });
                }
            });

            routeBuilder.MapDelete("/managers/{id}", (int id) =>
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
                    return Results.BadRequest(new { message = e.Message + " " + e.InnerException?.Message });
                }
            });
        }
    }
}
