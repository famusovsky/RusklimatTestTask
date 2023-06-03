using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Employment.DBHandling.Repositories;
using Employment.Models;

namespace Employment.WebAPI
{
    /// <summary>
    /// This class is responsible for configuring the API endpoints for the Premiums module.
    /// </summary>
    public static class PremiumsAPIConfigurator
    {
        /// <summary>
        /// Configures the API endpoints for the Premiums module ("*/premiums")
        /// </summary>
        /// <param name="routeBuilder">The route builder.</param>
        /// <param name="repository">The database repository.</param>
        public static void Configure(IEndpointRouteBuilder routeBuilder, IPremiumsRepository repository)
        {
            ConfigurePremiumsCRUD(routeBuilder, repository);
        }

        /// <summary>
        /// Configures the API endpoints for the CRUD operations on the Premiums repository.
        /// </summary>
        /// <param name="routeBuilder">The route builder.</param>
        /// <param name="repository">The premiums repository.</param>
        public static void ConfigurePremiumsCRUD(IEndpointRouteBuilder routeBuilder, IPremiumsRepository repository)
        {
            routeBuilder.MapGet("/premiums", async () =>
            {
                try
                {
                    var premiums = await repository.GetPremiums();

                    return Results.Json(premiums);
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

            routeBuilder.MapGet("/premiums/{id}", async (int id) =>
            {
                try
                {
                    var premium = await repository.GetPremium(id);

                    return Results.Json(premium);
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

            routeBuilder.MapGet("/premiums/e/{id}", async (uint id) =>
            {
                try
                {
                    var premiums = await repository.GetPremiums(id);

                    return Results.Json(premiums);
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

            routeBuilder.MapPost("/premiums", async (Premium premium) =>
            {
                try
                {
                    await repository.AddPremium(premium);

                    return Results.Created($"/premiums/{premium.Id}", new { Message = $"Premium {premium.Id} created successfully." });
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

            routeBuilder.MapPut("/premiums/{id}", async (int id, Premium premium) =>
            {
                try
                {
                    await repository.UpdatePremium(id, premium);

                    return Results.Accepted($"/premiums/{id}", new { Message = $"Premium {id} updated successfully." });
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

            routeBuilder.MapDelete("/premiums/{id}", async (int id) =>
            {
                try
                {
                    await repository.DeletePremium(id);

                    return Results.Accepted($"/premiums/{id}", new { Message = $"Premium {id} deleted successfully." });
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
