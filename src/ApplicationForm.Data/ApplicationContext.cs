using ApplicationForm.Data.Abstractions;
using ApplicationForm.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApplicationForm.Data
{
    /// <summary>
    /// Represents a database context.
    /// </summary>
    public class ApplicationContext : DbContext, IDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationContext"/> class.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Sector> Sectors { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
