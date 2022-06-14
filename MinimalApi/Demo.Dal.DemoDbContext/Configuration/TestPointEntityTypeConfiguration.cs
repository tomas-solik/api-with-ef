using Demo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.Dal.DemoDbContext.Configuration
{
    public class TestPointEntityTypeConfiguration : IEntityTypeConfiguration<TestPoint>
    {
        public void Configure(EntityTypeBuilder<TestPoint> builder)
        {
            builder.Property(x => x.TargetTorque).HasPrecision(18,8);
            builder.Property(x => x.TargetAngle).HasPrecision(18, 8);
        }
    }
}
