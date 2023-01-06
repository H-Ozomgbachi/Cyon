using Cyon.Domain.Entities;
using Cyon.Infrastructure.Database.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cyon.Infrastructure.Database
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Chaplain> Chaplains { get; set; }
        public DbSet<Minutes> Minutes { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Agendum> Agenda { get; set; }
        public DbSet<AttendanceType> AttendanceTypes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<AttendanceRegister> AttendanceRegisters { get; set; }
        public DbSet<Apology> Apologies { get; set; }
        public DbSet<DeactivateRequest> DeactivateRequests { get; set; }
        public DbSet<UserFinance> UserFinances { get; set; }
        public DbSet<OrganisationFinance> OrganisationFinances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ChaplainEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AnnouncementEntityConfiguration());
            modelBuilder.ApplyConfiguration(new MeetingEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AttendanceTypeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OccupationEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ApologyEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserFinanceEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrganisationFinanceEntityConfiguration());
        }
    }
}
