using Cyon.Domain.Entities;
using Cyon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cyon.Infrastructure.Repositories
{
    public class AgendumRepository : Repository<Agendum>, IAgendumRepository
    {
        public AgendumRepository(DbSet<Agendum> agenda) : base(agenda)
        {
        }
    }
}
