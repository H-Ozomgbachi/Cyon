using Cyon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cyon.Infrastructure.Database.EntityConfigurations
{
    public class OccupationEntityConfiguration : IEntityTypeConfiguration<Occupation>
    {
        public void Configure(EntityTypeBuilder<Occupation> builder)
        {
            builder.Property(x => x.JobTitle).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Company).IsRequired().HasMaxLength(100);
            builder.Property(x => x.IsStudent).HasDefaultValue(false);
            builder.Property(x => x.IsUnemployed).HasDefaultValue(false);
            builder.Property(x => x.CanDo).HasDefaultValue(string.Empty);
        }
    }
}
