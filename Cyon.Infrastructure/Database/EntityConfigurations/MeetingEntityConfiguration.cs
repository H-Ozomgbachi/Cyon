using Cyon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cyon.Infrastructure.Database.EntityConfigurations
{
    public class MeetingEntityConfiguration : IEntityTypeConfiguration<Meeting>
    {
        public void Configure(EntityTypeBuilder<Meeting> builder)
        {
            builder.HasMany(x => x.Agenda).WithOne(x => x.Meeting).OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.ProposedDurationInMinutes).IsRequired();
        }
    }
}
