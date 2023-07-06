using Cyon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cyon.Infrastructure.Database.EntityConfigurations
{
    public class DecisionResponseEntityTypeConfiguration : IEntityTypeConfiguration<DecisionResponse>
    {
        public void Configure(EntityTypeBuilder<DecisionResponse> builder)
        {
            builder.Property(x => x.Response).IsRequired().HasMaxLength(100);
        }
    }
}
