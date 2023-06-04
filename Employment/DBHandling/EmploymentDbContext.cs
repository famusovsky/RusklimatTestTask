using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Employment.Models;

namespace Employment.DBHandling
{
    /// <summary>
    /// Represents a database context for managers.
    /// </summary>
    public class EmploymentDbContext : DbContext
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
        /// Gets or sets the premiums in the database.
        /// </summary>
        public DbSet<Premium> Premiums { get; set; }

        /// <summary>
        /// Gets or sets the processed calls records in the database.
        /// </summary>
        public DbSet<ProcessedCallsRecord> ProcessedCalls { get; set; }

        /// <summary>
        /// Gets or sets the bonuses in the database.
        /// </summary>
        public DbSet<Bonus> Bonuses { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmploymentDbContext"/> class.
        /// </summary>
        public EmploymentDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            Database.EnsureCreated();

            Managers = Set<Manager>();
            Premiums = Set<Premium>();
            ProcessedCalls = Set<ProcessedCallsRecord>();
            Bonuses = Set<Bonus>();
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