using Cyon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cyon.Infrastructure.Database.EntityConfigurations
{
    public class AttendanceTypeEntityConfiguration : IEntityTypeConfiguration<AttendanceType>
    {
        public void Configure(EntityTypeBuilder<AttendanceType> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100);
        }
    }
}
