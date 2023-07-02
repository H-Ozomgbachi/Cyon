using Cyon.Domain.Entities;
using Cyon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cyon.Infrastructure.Repositories
{
    public class UpcomingEventRepository : Repository<UpcomingEvent>, IUpcomingEventRepository
    {
        public UpcomingEventRepository(DbSet<UpcomingEvent> upcomingEvents) : base(upcomingEvents)
        {
        }
    }
}
