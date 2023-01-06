using Cyon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cyon.Infrastructure.Database.EntityConfigurations
{
    public class UserFinanceEntityConfiguration : IEntityTypeConfiguration<UserFinance>
    {
        public void Configure(EntityTypeBuilder<UserFinance> builder)
        {
            builder.Property(x => x.Description).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DateModified).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Amount).IsRequired().HasPrecision(10, 2);
        }
    }
}
