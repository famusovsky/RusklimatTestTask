using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Employment.Models;

namespace Employment.DBHandling.Repositories
{
    /// <summary>
    /// Represents a premiums repository.
    /// </summary>
    public class PremiumsRepository : IPremiumsRepository
    {
        /// <summary>
        /// The DataBase context.
        /// </summary>
        private readonly EmploymentDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="PremiumsRepository"/> class.
        /// </summary>
        public PremiumsRepository(EmploymentDbContext context)
        {
            _context = context;
        }

        public async Task<List<Premium>> GetPremiums()
        {
            var premiums = await _context.Premiums.ToListAsync();
            if (premiums.Count == 0)
            {
                throw new System.ArgumentException("No premiums found.");
            }

            return premiums;
        }

        public async Task<List<Premium>> GetPremiums(uint employeesId)
        {
            var premiums = await _context.Premiums.Where(premium => premium.EmployeeId == employeesId).ToListAsync();
            if (premiums.Count == 0)
            {
                throw new System.ArgumentException($"No premiums found for employee with id {employeesId}.");
            }

            return premiums;
        }

        public async Task<Premium> GetPremium(int id)
        {
            var premium = await _context.Premiums.FindAsync(id);
            if (premium == null)
            {
                throw new System.ArgumentException($"Premium with id {id} not found.");
            }

            return premium;
        }

        public async Task AddPremium(Premium premium)
        {
            if (premium.Id != 0)
            {
                var premiumWithSameId = await _context.Premiums.FindAsync(premium.Id);
                if (premiumWithSameId != null)
                {
                    throw new System.ArgumentException($"Premium with id {premium.Id} already exists.");
                }
            }

            await _context.Premiums.AddAsync(premium);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePremium(int id, Premium premium)
        {
            var premiumToUpdate = await _context.Premiums.FindAsync(id);
            if (premiumToUpdate == null)
            {
                throw new System.ArgumentException($"Premium with id {id} not found.");
            }

            premiumToUpdate.EmployeeId = premium.EmployeeId;
            premiumToUpdate.Volume = premium.Volume;

            await _context.SaveChangesAsync();
        }

        public async Task DeletePremium(int id)
        {
            var PremiumToDelete = await _context.Premiums.FindAsync(id);
            if (PremiumToDelete == null)
            {
                throw new System.ArgumentException($"Premium with id {id} not found.");
            }

            _context.Premiums.Remove(PremiumToDelete);
            await _context.SaveChangesAsync();
        }
    }
}