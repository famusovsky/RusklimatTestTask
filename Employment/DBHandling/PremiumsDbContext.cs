using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Employment.Models;

namespace Employment.DBHandling
{
    /// <summary>
    /// Represents a database context for premiums.
    /// </summary>
    public class PremiumsDbContext : DbContext
    {
        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Gets or sets the premiums in the database.
        /// </summary>
        public DbSet<Premium> Premiums { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PremiumsDbContext"/> class.
        /// </summary>
        public PremiumsDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            Database.EnsureCreated();

            Premiums = Set<Premium>();
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