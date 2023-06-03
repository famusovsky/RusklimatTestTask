using System.Linq;
using System.Collections.Generic;
using Employment.Models.Management;

namespace Employment.DBHandling.Management
{
    /// <summary>
    /// Represents a management repository.
    /// </summary>
    public class ManagementRepository : IManagementRepository
    {
        /// <summary>
        /// The DataBase context.
        /// </summary>
        private readonly ManagementDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementRepository"/> class.
        /// </summary>
        public ManagementRepository(ManagementDbContext context)
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

        public Manager GetManager(uint id)
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
            var managerWithSameId = _context.Managers.Find(manager.Id);
            if (managerWithSameId != null)
            {
                throw new System.ArgumentException($"Manager with id {manager.Id} already exists.");
            }

            _context.Managers.Add(manager);
            _context.SaveChanges();
        }

        public void UpdateManager(uint id, Manager manager)
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

        public void DeleteManager(uint id)
        {
            var managerToDelete = _context.Managers.Find(id);
            if (managerToDelete == null)
            {
                throw new System.ArgumentException($"Manager with id {id} not found.");
            }

            _context.Managers.Remove(managerToDelete);
            _context.SaveChanges();
        }
    }
}