using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using System.Linq;
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
        /// <param name="context">The database context.</param>
        public static void Configure(IEndpointRouteBuilder routeBuilder, ManagementDbContext context)
        {
            routeBuilder.MapGet("/", () => new { Message = "Hello, World!" });

            ConfigureManagersCRUD(routeBuilder, context);
        }

        /// <summary>
        /// Configures the API endpoints for the CRUD operations on the Managers table.
        /// </summary>
        /// <param name="routeBuilder">The route builder.</param>
        /// <param name="context">The database context.</param>
        public static void ConfigureManagersCRUD(IEndpointRouteBuilder routeBuilder, ManagementDbContext context)
        {
            routeBuilder.MapGet("/managers", () => context.Managers.ToList());

            routeBuilder.MapGet("/managers/{id}", (uint id) => context.Managers.Find(id));

            routeBuilder.MapPost("/managers", (Manager manager) =>
            {
                try
                {
                    context.Managers.Add(manager);
                    context.SaveChanges();
                    return new { Message = $"Manager {manager.Id} added successfully." };
                }
                catch (System.Exception e)
                {
                    return new { Message = e.Message };
                }
            });

            routeBuilder.MapPut("/managers/{id}", (uint id, Manager manager) =>
            {
                try
                {
                    var managerToUpdate = context.Managers.Find(id);
                    managerToUpdate.Name = manager.Name;
                    managerToUpdate.Salary = manager.Salary;
                    managerToUpdate.ProcessedCallsCount = manager.ProcessedCallsCount;
                    context.SaveChanges();

                    return new { Message = $"Manager {managerToUpdate.Id} updated successfully." };
                }
                catch (System.Exception e)
                {
                    return new { Message = e.Message };
                }
            });

            routeBuilder.MapDelete("/managers/{id}", (uint id) =>
            {
                try
                {
                    var managerToDelete = context.Managers.Find(id);
                    context.Managers.Remove(managerToDelete);
                    context.SaveChanges();
                    return new { Message = $"Manager {managerToDelete.Id} deleted successfully." };
                }
                catch (System.Exception e)
                {
                    return new { Message = e.Message };
                }
            });
        }
    }
}
