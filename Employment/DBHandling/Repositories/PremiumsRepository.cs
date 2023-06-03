using System.Linq;
using System.Collections.Generic;
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

        public Premium GetPremium(int id)
        {
            var premium = _context.Premiums.Find(id);
            if (premium == null)
            {
                throw new System.ArgumentException($"Premium with id {id} not found.");
            }

            return premium;
        }

        public void AddPremium(Premium premium)
        {
            if (premium.Id != 0)
            {
                var premiumWithSameId = _context.Premiums.Find(premium.Id);
                if (premiumWithSameId != null)
                {
                    throw new System.ArgumentException($"Premium with id {premium.Id} already exists.");
                }
            }

            _context.Premiums.Add(premium);
            _context.SaveChanges();
        }

        public void UpdatePremium(int id, Premium premium)
        {
            var premiumToUpdate = _context.Premiums.Find(id);
            if (premiumToUpdate == null)
            {
                throw new System.ArgumentException($"Premium with id {id} not found.");
            }

            premiumToUpdate.EmployeeId = premium.EmployeeId;
            premiumToUpdate.Volume = premium.Volume;

            _context.SaveChanges();
        }

        public void DeletePremium(int id)
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