using Cyon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cyon.Infrastructure.Database.EntityConfigurations
{
    public class OrganisationFinanceEntityConfiguration : IEntityTypeConfiguration<OrganisationFinance>
    {
        public void Configure(EntityTypeBuilder<OrganisationFinance> builder)
        {
            builder.Property(x => x.Description).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Amount).HasPrecision(10, 2);
            builder.Property(x => x.FinanceType).IsRequired().HasMaxLength(12);
        }
    }
}
