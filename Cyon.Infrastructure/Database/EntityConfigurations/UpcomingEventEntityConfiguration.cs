using Cyon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cyon.Infrastructure.Database.EntityConfigurations
{
    public class UpcomingEventEntityConfiguration : IEntityTypeConfiguration<UpcomingEvent>
    {
        public void Configure(EntityTypeBuilder<UpcomingEvent> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.ImageUrl).IsRequired();
        }
    }
}
