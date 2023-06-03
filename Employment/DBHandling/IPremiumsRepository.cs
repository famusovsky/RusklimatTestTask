using System.Collections.Generic;
using Employment.Models;

namespace Employment.DBHandling
{
    /// <summary>
    /// Represents an interface for a premiums repository.
    /// </summary>
    public interface IPremiumsRepository
    {
        /// <summary>
        /// Gets all the premiums.
        /// </summary>
        public List<Premium> GetPremiums();

        /// <summary>
        /// Gets premiums by employees id.
        /// </summary>
        /// <param name="employeesId">The id of the employee who got the premium.</param>
        public List<Premium> GetPremiums(uint employeesId);

        /// <summary>
        /// Gets a premium by id.
        /// </summary>
        /// <param name="id">The id of the premium to get.</param>
        public Premium GetPremium(uint id);

        /// <summary>
        /// Adds a premium.
        /// </summary>
        /// <param name="premium">The premium to add.</param>
        public void AddPremium(Premium premium);

        /// <summary>
        /// Updates a premium by id.
        /// </summary>
        /// <param name="id">The id of the premium to update.</param>
        /// <param name="premium">The updated premium.</param>
        public void UpdatePremium(uint id, Premium premium);

        /// <summary>
        /// Deletes a premium.
        /// </summary>
        /// <param name="id">The id of the premium to delete.</param>
        public void DeletePremium(uint id);
    }
}