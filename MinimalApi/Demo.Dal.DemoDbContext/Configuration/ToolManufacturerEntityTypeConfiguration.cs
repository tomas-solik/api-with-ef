using Demo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.Dal.DemoDbContext.Configuration
{
    public class ToolManufacturerEntityTypeConfiguration : IEntityTypeConfiguration<ToolManufacturer>
    {
        public void Configure(EntityTypeBuilder<ToolManufacturer> builder)
        {
            builder.HasMany(x => x.ToolModels);
        }
    }
}
