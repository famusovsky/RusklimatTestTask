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
        public Task<Manager> GetManager(int id);

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
        public Task UpdateManager(int id, Manager manager);

        /// <summary>
        /// Deletes a manager.
        /// </summary>
        /// <param name="id">The id of the manager to delete.</param>
        public Task DeleteManager(int id);

        /// <summary>
        /// Gets the salary of a manager.
        /// </summary>
        /// <param name="id">The id of the manager to get the salary of.</param>
        /// <returns>The salary of the manager.</returns>
        public Task<uint> GetManagerSalary(int id);

        /// <summary>
        /// Applies call processing to a manager.
        /// </summary>
        /// <param name="id">The id of the manager to apply call processing to.</param>
        public Task ApplyCallProcessing(int id);

        /// <summary>
        /// Gets the bonuses history.
        /// </summary>
        /// <returns>The bonuses history.</returns>
        public Task<List<Bonus>> GetBonusesHistory();

        /// <summary>
        /// Gets the bonuses history of a manager.
        /// </summary>
        /// <param name="id">The id of the manager to get the bonuses history of.</param>
        /// <returns>The bonuses history.</returns>
        public Task<List<Bonus>> GetBonusesHistory(int id);
    }
}