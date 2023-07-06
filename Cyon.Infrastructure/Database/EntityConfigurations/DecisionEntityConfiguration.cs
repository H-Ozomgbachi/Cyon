using Cyon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cyon.Infrastructure.Database.EntityConfigurations
{
    public class DecisionEntityConfiguration : IEntityTypeConfiguration<Decision>
    {
        public void Configure(EntityTypeBuilder<Decision> builder)
        {
            builder.Property(x => x.Question).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Options).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Result).IsRequired().HasMaxLength(100);
        }
    }
}
