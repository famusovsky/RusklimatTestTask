using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Employment.DBHandling.Management
{
    /// <summary>
    /// Represents a database context for managers employees.
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
        public DbSet<Models.Management.Manager> Managers { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmploymentContext"/> class.
        /// </summary>
        public ManagementDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            Database.EnsureCreated();
        }

        /// <summary>
        /// Configures the database context.
        /// </summary>
        /// <param name="optionsBuilder">The options builder.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO: set up host, port, database, username and password needed to connect to the database
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
            // optionsBuilder.LogTo(System.Console.WriteLine);
        }
    }
}