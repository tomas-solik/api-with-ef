using Demo.Dal.DemoDbContext.Configuration;
using Demo.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Dal.DemoDbContext
{
    public sealed class DemoDbContext : DbContext
    {
        #region Constructor

        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
        {
        }

        #endregion

        #region OnConfiguring

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        #endregion

        #region DbSet configuration

        public DbSet<ToolManufacturer> Manufacturers { get; set; }

        public DbSet<ToolModel> Models { get; set; }

        public DbSet<Tool> Tools { get; set; }

        public DbSet<TestPoint> TestPoints { get; set; }

        public DbSet<User> Users { get; set; }

        #endregion

        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());
            new TestPointEntityTypeConfiguration().Configure(modelBuilder.Entity<TestPoint>());
            //new ToolEntityTypeConfiguration().Configure(modelBuilder.Entity<Tool>());
            //new ToolModelEntityTypeConfiguration().Configure(modelBuilder.Entity<ToolModel>());
            //new ToolManufacturerEntityTypeConfiguration().Configure(modelBuilder.Entity<ToolManufacturer>());
        }

        #endregion
    }
}