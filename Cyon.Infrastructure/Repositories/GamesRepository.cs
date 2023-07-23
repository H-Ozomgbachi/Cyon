using Cyon.Domain.Entities;
using Cyon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cyon.Infrastructure.Repositories
{
    public class GamesRepository : Repository<TreasureHuntResult>, IGamesRepository
    {
        public GamesRepository(DbSet<TreasureHuntResult> entities) : base(entities)
        {
        }
    }
}
