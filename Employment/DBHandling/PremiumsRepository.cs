using System.Linq;
using System.Collections.Generic;
using Employment.Models;

namespace Employment.DBHandling
{
    /// <summary>
    /// Represents a premiums repository.
    /// </summary>
    public class PremiumsRepository : IPremiumsRepository
    {
        /// <summary>
        /// The DataBase context.
        /// </summary>
        private readonly PremiumsDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="PremiumsRepository"/> class.
        /// </summary>
        public PremiumsRepository(PremiumsDbContext context)
        {
            _context = context;
        }

        public List<Premium> GetPremiums()
        {
            var premiums = _context.Premiums.ToList();
            if (premiums.Count == 0)
            {
                throw new System.ArgumentException("No premiums found.");
            }
            
            return premiums;
        }

        public List<Premium> GetPremiums(uint employeesId)
        {
            var premiums = _context.Premiums.Where(premium => premium.EmployeeId == employeesId).ToList();
            if (premiums.Count == 0)
            {
                throw new System.ArgumentException($"No premiums found for employee with id {employeesId}.");
            }
            
            return premiums;
        }

        public Premium GetPremium(uint id)
        {
            var premium = _context.Premiums.Find(id);
            if (premium == null)
            {
                throw new System.ArgumentException($"Premium with id {id} not found.");
            }

            return premium;
        }

        public void AddPremium(Premium Premium)
        {
            var premiumWithSameId = _context.Premiums.Find(Premium.Id);
            if (premiumWithSameId != null)
            {
                throw new System.ArgumentException($"Premium with id {Premium.Id} already exists.");
            }

            _context.Premiums.Add(Premium);
            _context.SaveChanges();
        }

        public void UpdatePremium(uint id, Premium Premium)
        {
            var premiumToUpdate = _context.Premiums.Find(id);
            if (premiumToUpdate == null)
            {
                throw new System.ArgumentException($"Premium with id {id} not found.");
            }

            premiumToUpdate.EmployeeId = Premium.EmployeeId;
            premiumToUpdate.Volume = Premium.Volume;

            _context.SaveChanges();
        }

        public void DeletePremium(uint id)
        {
            var PremiumToDelete = _context.Premiums.Find(id);
            if (PremiumToDelete == null)
            {
                throw new System.ArgumentException($"Premium with id {id} not found.");
            }

            _context.Premiums.Remove(PremiumToDelete);
            _context.SaveChanges();
        }
    }
}