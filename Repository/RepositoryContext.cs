using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        //To add initial values to the database for testing, this code is injected
        //Refer to Configuration Folder to see how the data was initialized and set.
        //------------------------------------------------------------------------
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }
        //--------------------------------------------------------------------------

        public DbSet<Employee>  Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
