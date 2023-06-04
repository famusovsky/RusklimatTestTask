using System.Collections.Generic;
using System.Threading.Tasks;
using Employment.Models;

namespace Employment.DBHandling.Repositories
{
    /// <summary>
    /// Represents an interface for a management repository.
    /// </summary>
    public interface IManagementRepository
    {
        /// <summary>
        /// Gets all the managers.
        /// </summary>
        /// <returns>All the managers.</returns>
        public Task<List<Manager>> GetManagers();

        /// <summary>
        /// Gets a manager by id.
        /// </summary>
        /// <param name="id">The id of the manager to get.</param>
        /// <returns>The manager.</returns>
        public Task<Manager> GetManager(uint id);

        /// <summary>
        /// Adds a manager.
        /// </summary>
        /// <param name="manager">The manager to add.</param>
        public Task AddManager(Manager manager);

        /// <summary>
        /// Updates a manager by id.
        /// </summary>
        /// <param name="id">The id of the manager to update.</param>
        /// <param name="manager">The updated manager.</param>
        public Task UpdateManager(uint id, Manager manager);

        /// <summary>
        /// Deletes a manager.
        /// </summary>
        /// <param name="id">The id of the manager to delete.</param>
        public Task DeleteManager(uint id);

        /// <summary>
        /// Gets the salary of a manager.
        /// </summary>
        /// <param name="id">The id of the manager to get the salary of.</param>
        /// <returns>The salary of the manager.</returns>
        public Task<uint> GetManagerSalary(uint id);

        /// <summary>
        /// Applies call processing to a manager.
        /// </summary>
        /// <param name="id">The id of the manager to apply call processing to.</param>
        /// <param name="count">The count of processed calls.</param>
        /// <param name="date">The date of the call processing.</param>
        public Task ApplyCallProcessing(uint id, uint count, System.DateOnly date);

        /// <summary>
        /// Gets the bonuses history for a given period.
        /// </summary>
        /// <param name="from">The start of the period.</param>
        /// <param name="to">The end of the period.</param>
        /// <returns>The bonuses history.</returns>
        public Task<List<Bonus>> GetBonusesHistory(System.DateOnly from, System.DateOnly to);

        /// <summary>
        /// Gets the bonuses history of a manager for a given period.
        /// </summary>
        /// <param name="id">The id of the manager to get the bonuses history of.</param>
        /// <param name="from">The start of the period.</param>
        /// <param name="to">The end of the period.</param>
        /// <returns>The bonuses history.</returns>
        public Task<List<Bonus>> GetBonusesHistory(uint id, System.DateOnly from, System.DateOnly to);

        /// <summary>
        /// Gets the processed calls history for a given period.
        /// </summary>
        /// <param name="from">The start of the period.</param>
        /// <param name="to">The end of the period.</param>
        /// <returns>The processed calls history.</returns>
        public Task<List<ProcessedCallsRecord>> GetProcessedCallsHistory(System.DateOnly from, System.DateOnly to);

        /// <summary>
        /// Gets the processed calls history of a manager for a given period.
        /// </summary>
        /// <param name="id">The id of the manager to get the processed calls history of.</param>
        /// <param name="from">The start of the period.</param>
        /// <param name="to">The end of the period.</param>
        /// <returns>The processed calls history.</returns>
        public Task<List<ProcessedCallsRecord>> GetProcessedCallsHistory(uint id, System.DateOnly from, System.DateOnly to);

        /// <summary>
        /// Gets the general count of processed calls of a manager for a given period.
        /// </summary>
        /// <param name="id">The id of the manager to get the general count of processed calls of.</param>
        /// <param name="from">The start of the period.</param>
        /// <param name="to">The end of the period.</param>
        /// <returns>The general count of processed calls.</returns>
        public Task<uint> GetCountOfProcessedCalls(uint id, System.DateOnly from, System.DateOnly to);
    }
}