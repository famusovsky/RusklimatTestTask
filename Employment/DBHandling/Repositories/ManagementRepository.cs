using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Employment.Models;
using System;

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

        public async Task<Manager> GetManager(uint id)
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
        public async Task UpdateManager(uint id, Manager manager)
        {
            var managerToUpdate = await _context.Managers.FindAsync(id);
            if (managerToUpdate == null)
            {
                throw new System.ArgumentException($"Manager with id {id} not found.");
            }

            managerToUpdate.Name = manager.Name;
            managerToUpdate.DefaultSalary = manager.DefaultSalary;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteManager(uint id)
        {
            var managerToDelete = await _context.Managers.FindAsync(id);
            if (managerToDelete == null)
            {
                throw new System.ArgumentException($"Manager with id {id} not found.");
            }

            _context.Managers.Remove(managerToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<uint> GetManagerSalary(uint id)
        {
            var manager = await _context.Managers.FindAsync(id);
            if (manager == null)
            {
                throw new System.ArgumentException($"Manager with id {id} not found.");
            }

            var defaultSalary = manager.DefaultSalary;
            var bonuses = await _context.Bonuses.Where(bonus => bonus.EmployeeId == id).ToListAsync();
            foreach (var bonus in bonuses)
            {
                defaultSalary += ((uint)bonus.Category);
            }
            return defaultSalary;
        }

        public async Task ApplyCallProcessing(uint id, uint count, DateOnly date)
        {
            var manager = await _context.Managers.FindAsync(id);
            if (manager == null)
            {
                throw new System.ArgumentException($"Manager with id {id} not found.");
            }

            var forCurrentMonth = await _context.ProcessedCalls.Where(processedCall => processedCall.EmployeeId == id && processedCall.Date.Month == date.Month).ToListAsync();
            uint countForCurrentMonth = (uint)forCurrentMonth.Count;
            for (int i = 0; i < count; i++)
            {
                countForCurrentMonth++;
                var bonusCategory = Manager.GetBonusCategory(countForCurrentMonth);
                var bonus = new Bonus
                {
                    EmployeeId = id,
                    Category = bonusCategory
                };
                await _context.Bonuses.AddAsync(bonus);
            }

            var processedCallsOld = await _context.ProcessedCalls.FirstOrDefaultAsync(processedCall => processedCall.EmployeeId == id && processedCall.Date == date);
            if (processedCallsOld != null)
            {
                processedCallsOld.Count += count;
            }
            else
            {
                var processedCallsNew = new ProcessedCallsRecord
                {
                    EmployeeId = id,
                    Count = count,
                    Date = date
                };
                await _context.ProcessedCalls.AddAsync(processedCallsNew);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<Bonus>> GetBonusesHistory(DateOnly from, DateOnly to)
        {
            var allBonuses = await _context.Bonuses.ToListAsync();
            var bonuses = allBonuses.Where(bonus => bonus.CreationDate >= from && bonus.CreationDate <= to).ToList();
            if (bonuses.Count == 0)
            {
                throw new System.ArgumentException("No bonuses found.");
            }

            return bonuses;
        }

        public async Task<List<Bonus>> GetBonusesHistory(uint id, DateOnly from, DateOnly to)
        {
            var allBonuses = await GetBonusesHistory(from, to);
            var bonuses = allBonuses.Where(bonus => bonus.EmployeeId == id).ToList();
            if (bonuses.Count == 0)
            {
                throw new System.ArgumentException("No bonuses found.");
            }

            return bonuses;
        }

        public async Task<List<ProcessedCallsRecord>> GetProcessedCallsHistory(DateOnly from, DateOnly to)
        {
            var allProcessedCalls = await _context.ProcessedCalls.ToListAsync();
            var processedCalls = allProcessedCalls.Where(processedCall => processedCall.Date >= from && processedCall.Date <= to).ToList();
            if (processedCalls.Count == 0)
            {
                throw new System.ArgumentException("No processed calls found.");
            }

            return processedCalls;
        }

        public async Task<List<ProcessedCallsRecord>> GetProcessedCallsHistory(uint id, DateOnly from, DateOnly to)
        {
            var allProcessedCalls = await GetProcessedCallsHistory(from, to);
            var processedCalls = allProcessedCalls.Where(processedCall => processedCall.EmployeeId == id).ToList();
            if (processedCalls.Count == 0)
            {
                throw new System.ArgumentException("No processed calls found.");
            }

            return processedCalls;
        }

        public async Task<uint> GetCountOfProcessedCalls(uint id, System.DateOnly from, System.DateOnly to)
        {
            var processedCalls = await GetProcessedCallsHistory(id, from, to);
            uint count = 0;

            foreach (var processedCall in processedCalls)
            {
                count += processedCall.Count;
            }

            return count;
        }
    }
}