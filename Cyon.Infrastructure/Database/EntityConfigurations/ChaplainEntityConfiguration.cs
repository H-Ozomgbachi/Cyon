using Cyon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cyon.Infrastructure.Database.EntityConfigurations
{
    public class ChaplainEntityConfiguration : IEntityTypeConfiguration<Chaplain>
    {
        public void Configure(EntityTypeBuilder<Chaplain> builder)
        {
            builder.Property(p => p.FullName).IsRequired().HasMaxLength(128);
            builder.Property(p => p.ImageUrl).IsRequired().HasMaxLength(256);
            builder.Property(p => p.StartYear).IsRequired().HasMaxLength(4);
            builder.Property(p => p.EndYear).IsRequired().HasMaxLength(7);
        }
    }
}
