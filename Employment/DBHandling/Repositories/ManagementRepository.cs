using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Employment.Models;

namespace Employment.DBHandling.Repositories
{
    /// <summary>
    /// Represents a management repository.
    /// </summary>
    public class ManagementRepository : IManagementRepository
    {
        /// <summary>
        /// The DataBase context.
        /// </summary>
        private readonly EmploymentDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementRepository"/> class.
        /// </summary>
        public ManagementRepository(EmploymentDbContext context)
        {
            _context = context;
        }

        public async Task<List<Manager>> GetManagers()
        {
            var managers = await _context.Managers.ToListAsync();
            if (managers.Count == 0)
            {
                throw new System.ArgumentException("No managers found.");
            }

            return managers;
        }

        public async Task<Manager> GetManager(int id)
        {
            var manager = await _context.Managers.FindAsync(id);
            if (manager == null)
            {
                throw new System.ArgumentException($"Manager with id {id} not found.");
            }

            return manager;
        }

        public async Task AddManager(Manager manager)
        {
            if (manager.Id != 0)
            {
                var managerWithSameId = await _context.Managers.FindAsync(manager.Id);
                if (managerWithSameId != null)
                {
                    throw new System.ArgumentException($"Manager with id {manager.Id} already exists.");
                }
            }

            await _context.Managers.AddAsync(manager);
            await _context.SaveChangesAsync();
        }

        // TODO: update not all of the manager's properties, but only needed
        public async Task UpdateManager(int id, Manager manager)
        {
            var managerToUpdate = await _context.Managers.FindAsync(id);
            if (managerToUpdate == null)
            {
                throw new System.ArgumentException($"Manager with id {id} not found.");
            }

            managerToUpdate.Name = manager.Name;
            managerToUpdate.Salary = manager.Salary;
            managerToUpdate.ProcessedCallsCount = manager.ProcessedCallsCount;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteManager(int id)
        {
            var managerToDelete = await _context.Managers.FindAsync(id);
            if (managerToDelete == null)
            {
                throw new System.ArgumentException($"Manager with id {id} not found.");
            }

            _context.Managers.Remove(managerToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<uint> GetManagerSalary(int id)
        {
            var manager = await _context.Managers.FindAsync(id);
            if (manager == null)
            {
                throw new System.ArgumentException($"Manager with id {id} not found.");
            }

            return manager.Salary;
        }

        public async Task ApplyCallProcessing(int id)
        {
            var manager = await _context.Managers.FindAsync(id);
            if (manager == null)
            {
                throw new System.ArgumentException($"Manager with id {id} not found.");
            }

            var bonus = await manager.ProcessCallAsync();
            await _context.Bonuses.AddAsync(bonus);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Bonus>> GetBonusesHistory()
        {
            var bonuses = await _context.Bonuses.ToListAsync();
            if (bonuses.Count == 0)
            {
                throw new System.ArgumentException("No bonuses found.");
            }

            return bonuses;
        }

        public async Task<List<Bonus>> GetBonusesHistory(int id)
        {
            var allBonuses = await _context.Bonuses.ToListAsync();
            var bonuses = allBonuses.Where(bonus => bonus.EmployeeId == id).ToList();
            if (bonuses.Count == 0)
            {
                throw new System.ArgumentException("No bonuses found.");
            }

            return bonuses;
        }
    }
}