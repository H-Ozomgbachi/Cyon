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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ChaplainEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new AnnouncementEntityConfiguration());
            modelBuilder.ApplyConfiguration(new MeetingEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AttendanceTypeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentEntityConfiguration());
        }
    }
}
