using Demo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.Dal.DemoDbContext.Configuration
{
    public class ToolEntityTypeConfiguration : IEntityTypeConfiguration<Tool>
    {
        public void Configure(EntityTypeBuilder<Tool> builder)
        {
            builder.HasOne(x => x.Model);
            builder.HasMany(x => x.TestPoints);
        }
    }
}
