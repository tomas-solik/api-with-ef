using Demo.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Dal.DemoDbContext
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
        {
        }

        public DbSet<ToolManufacturer> Manufacturers { get; set; }

        public DbSet<ToolModel> Models { get; set; }

        public DbSet<Tool> Tools { get; set; }

        public DbSet<TestPoint> TestPoints { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}