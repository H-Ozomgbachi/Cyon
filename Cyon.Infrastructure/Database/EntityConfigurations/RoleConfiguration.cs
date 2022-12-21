using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cyon.Infrastructure.Database.EntityConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
            new IdentityRole
            {
                Name = "Member",
                NormalizedName = "MEMBER"
            },
            new IdentityRole
            {
                Name = "Executive",
                NormalizedName = "EXECUTIVE"
            },
            new IdentityRole
            {
                Name = "Super",
                NormalizedName = "SUPER"
            }
            );
        }
    }
}
