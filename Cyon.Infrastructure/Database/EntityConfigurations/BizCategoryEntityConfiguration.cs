using Cyon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cyon.Infrastructure.Database.EntityConfigurations
{
    public class BizCategoryEntityConfiguration : IEntityTypeConfiguration<BizCategory>
    {
        public void Configure(EntityTypeBuilder<BizCategory> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        }
    }
}
