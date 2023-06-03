using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Employment.Models;
using Employment.Models.Management;

namespace Employment.DBHandling.Management
{
    /// <summary>
    /// Represents a database context for managers.
    /// </summary>
    public class ManagementDbContext : DbContext
    {
        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly IConfiguration _configuration;
        /// <summary>
        /// Gets or sets the managers in the database.
        /// </summary>
        public DbSet<Manager> Managers { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementDbContext"/> class.
        /// </summary>
        public ManagementDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            Database.EnsureCreated();

            Managers = Set<Manager>();
        }

        /// <summary>
        /// Configures the database context.
        /// </summary>
        /// <param name="optionsBuilder">The options builder.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}