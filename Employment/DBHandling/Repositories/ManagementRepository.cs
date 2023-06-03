using System.Linq;
using System.Collections.Generic;
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

        public List<Manager> GetManagers()
        {
            var managers = _context.Managers.ToList();
            if (managers.Count == 0)
            {
                throw new System.ArgumentException("No managers found.");
            }

            return managers;
        }

        public Manager GetManager(int id)
        {
            var manager = _context.Managers.Find(id);
            if (manager == null)
            {
                throw new System.ArgumentException($"Manager with id {id} not found.");
            }

            return manager;
        }

        public void AddManager(Manager manager)
        {
            if (manager.Id != 0)
            {
                var managerWithSameId = _context.Managers.Find(manager.Id);
                if (managerWithSameId != null)
                {
                    throw new System.ArgumentException($"Manager with id {manager.Id} already exists.");
                }
            }

            _context.Managers.Add(manager);
            _context.SaveChanges();
        }

        public void UpdateManager(int id, Manager manager)
        {
            var managerToUpdate = _context.Managers.Find(id);
            if (managerToUpdate == null)
            {
                throw new System.ArgumentException($"Manager with id {id} not found.");
            }

            managerToUpdate.Name = manager.Name;
            managerToUpdate.Salary = manager.Salary;
            managerToUpdate.ProcessedCallsCount = manager.ProcessedCallsCount;
            _context.SaveChanges();
        }

        public void DeleteManager(int id)
        {
            var managerToDelete = _context.Managers.Find(id);
            if (managerToDelete == null)
            {
                throw new System.ArgumentException($"Manager with id {id} not found.");
            }

            _context.Managers.Remove(managerToDelete);
            _context.SaveChanges();
        }

        public void ApplyCallProcessing(int id)
        {
            var manager = _context.Managers.Find(id);
            if (manager == null)
            {
                throw new System.ArgumentException($"Manager with id {id} not found.");
            }

            var bonus = manager.ProcessCall();
            _context.Bonuses.Add(bonus);
            _context.SaveChanges();
        }

        public List<Bonus> GetBonusesHistory()
        {
            var bonuses = _context.Bonuses.ToList();
            if (bonuses.Count == 0)
            {
                throw new System.ArgumentException("No bonuses found.");
            }

            return bonuses;
        }

        public List<Bonus> GetBonusesHistory(int id)
        {
            var bonuses = _context.Bonuses.ToList().Where(bonus => bonus.EmployeeId == id).ToList();
            if (bonuses.Count == 0)
            {
                throw new System.ArgumentException("No bonuses found.");
            }

            return bonuses;
        }
    }
}