using Cyon.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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
        public DbSet<YearProgramme> YearProgrammes { get; set; }
        public DbSet<UpcomingEvent> UpcomingEvents { get; set; }
        public DbSet<Decision> Decisions { get; set; }
        public DbSet<DecisionResponse> DecisionResponses { get; set; }
        public DbSet<TreasureHuntResult> TreasureHuntResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}