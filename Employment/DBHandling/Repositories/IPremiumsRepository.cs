using System.Collections.Generic;
using System.Threading.Tasks;
using Employment.Models;

namespace Employment.DBHandling.Repositories
{
    /// <summary>
    /// Represents an interface for a premiums repository.
    /// </summary>
    public interface IPremiumsRepository
    {
        /// <summary>
        /// Gets all the premiums.
        /// </summary>
        /// <returns>All the premiums.</returns>
        public Task<List<Premium>> GetPremiums();

        /// <summary>
        /// Gets premiums by employees id.
        /// </summary>
        /// <param name="employeesId">The id of the employee who got the premium.</param>
        /// <returns>The premiums.</returns>
        public Task<List<Premium>> GetPremiums(uint employeesId);

        /// <summary>
        /// Gets a premium by id.
        /// </summary>
        /// <param name="id">The id of the premium to get.</param>
        /// <returns>The premium.</returns>
        public Task<Premium> GetPremium(int id);

        /// <summary>
        /// Adds a premium.
        /// </summary>
        /// <param name="premium">The premium to add.</param>
        public Task AddPremium(Premium premium);

        /// <summary>
        /// Updates a premium by id.
        /// </summary>
        /// <param name="id">The id of the premium to update.</param>
        /// <param name="premium">The updated premium.</param>
        public Task UpdatePremium(int id, Premium premium);

        /// <summary>
        /// Deletes a premium.
        /// </summary>
        /// <param name="id">The id of the premium to delete.</param>
        public Task DeletePremium(int id);
    }
}