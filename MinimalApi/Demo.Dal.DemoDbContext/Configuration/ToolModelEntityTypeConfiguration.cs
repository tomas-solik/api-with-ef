using Demo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.Dal.DemoDbContext.Configuration
{
    public class ToolModelEntityTypeConfiguration : IEntityTypeConfiguration<ToolModel>
    {
        public void Configure(EntityTypeBuilder<ToolModel> builder)
        {
            builder.HasOne(x => x.Manufacturer);
            builder.HasMany(x => x.Tools);
        }
    }
}
