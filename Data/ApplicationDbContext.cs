using customer_datagrid_backend.Models;
using Microsoft.EntityFrameworkCore;
using TableManagementAPI.Models;

namespace customer_datagrid_backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Corporation> Corporations { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Record> Records { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Corporation>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<District>().HasIndex(d => d.Name).IsUnique();
        }
    }

}
