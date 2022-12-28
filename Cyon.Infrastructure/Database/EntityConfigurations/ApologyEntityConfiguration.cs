using Cyon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cyon.Infrastructure.Database.EntityConfigurations
{
    public class ApologyEntityConfiguration : IEntityTypeConfiguration<Apology>
    {
        public void Configure(EntityTypeBuilder<Apology> builder)
        {
            builder.Property(x => x.For).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Reason).IsRequired().HasMaxLength(100);
        }
    }
}
