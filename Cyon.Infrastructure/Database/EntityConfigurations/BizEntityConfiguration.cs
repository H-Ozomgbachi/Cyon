using Cyon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cyon.Infrastructure.Database.EntityConfigurations
{
    public class BizEntityConfiguration : IEntityTypeConfiguration<Biz>
    {
        public void Configure(EntityTypeBuilder<Biz> builder)
        {
            builder.Property(x => x.BusinessName).IsRequired().HasMaxLength(256);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(11);
            builder.Property(x => x.EmailAddress).IsRequired().HasMaxLength(256);
            builder.Property(x => x.PhysicalAddress).IsRequired().HasMaxLength(256);
        }
    }
}
