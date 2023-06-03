using System.Collections.Generic;
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
        public List<Manager> GetManagers();

        /// <summary>
        /// Gets a manager by id.
        /// </summary>
        /// <param name="id">The id of the manager to get.</param>
        /// <returns>The manager.</returns>
        public Manager GetManager(int id);

        /// <summary>
        /// Adds a manager.
        /// </summary>
        /// <param name="manager">The manager to add.</param>
        public void AddManager(Manager manager);

        /// <summary>
        /// Updates a manager by id.
        /// </summary>
        /// <param name="id">The id of the manager to update.</param>
        /// <param name="manager">The updated manager.</param>
        public void UpdateManager(int id, Manager manager);

        /// <summary>
        /// Deletes a manager.
        /// </summary>
        /// <param name="id">The id of the manager to delete.</param>
        public void DeleteManager(int id);

        /// <summary>
        /// Gets the salary of a manager.
        /// </summary>
        /// <param name="id">The id of the manager to get the salary of.</param>
        /// <returns>The salary of the manager.</returns>
        public uint GetManagerSalary(int id);

        /// <summary>
        /// Applies call processing to a manager.
        /// </summary>
        /// <param name="id">The id of the manager to apply call processing to.</param>
        public void ApplyCallProcessing(int id);

        /// <summary>
        /// Gets the bonuses history.
        /// </summary>
        /// <returns>The bonuses history.</returns>
        public List<Bonus> GetBonusesHistory();

        /// <summary>
        /// Gets the bonuses history of a manager.
        /// </summary>
        /// <param name="id">The id of the manager to get the bonuses history of.</param>
        /// <returns>The bonuses history.</returns>
        public List<Bonus> GetBonusesHistory(int id);
    }
}