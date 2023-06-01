using Employment.Models;
using Microsoft.EntityFrameworkCore;

namespace Employment.DataBase
{
    /// <summary>
    /// Represents a database context for managing employees.
    /// </summary>
    public class EmploymentContext : DbContext
    {
        /// <summary>
        /// Gets or sets the employees in the database.
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmploymentContext"/> class.
        /// </summary>
        public EmploymentContext() => Database.EnsureCreated();

        /// <summary>
        /// Configures the database context.
        /// </summary>
        /// <param name="optionsBuilder">The options builder.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO: set up host, port, database, username and password needed to connect to the database
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Employment;Username=postgres;Password=postgres");
        }
    }
}