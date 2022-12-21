using Cyon.Domain.Entities;
using Cyon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cyon.Infrastructure.Repositories
{
    public class ChaplainRepository : Repository<Chaplain>, IChaplainRepository
    {
        public ChaplainRepository(DbSet<Chaplain> chaplains) : base(chaplains)
        {
        }
    }
}
