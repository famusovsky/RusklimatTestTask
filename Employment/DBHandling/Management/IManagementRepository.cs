using System.Collections.Generic;
using Employment.Models.Management;

namespace Employment.DBHandling.Management
{
    /// <summary>
    /// Represents an interface for a management repository.
    /// </summary>
    public interface IManagementRepository
    {
        /// <summary>
        /// Gets all the managers.
        /// </summary>
        public List<Manager> GetManagers();

        /// <summary>
        /// Gets a manager by id.
        /// </summary>
        /// <param name="id">The id of the manager to get.</param>
        public Manager GetManager(uint id);

        /// <summary>
        /// Adds a manager by id.
        /// </summary>
        /// <param name="id">The id of the manager to add.</param>
        public void AddManager(Manager manager);

        /// <summary>
        /// Updates a manager by id.
        /// </summary>
        /// <param name="id">The id of the manager to update.</param>
        public void UpdateManager(uint id, Manager manager);

        /// <summary>
        /// Deletes a manager.
        /// </summary>
        /// <param name="id">The id of the manager to delete.</param>
        public void DeleteManager(uint id);
    }
}