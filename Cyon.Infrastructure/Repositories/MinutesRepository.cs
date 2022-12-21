using Cyon.Domain.Entities;
using Cyon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cyon.Infrastructure.Repositories
{
    public class MinutesRepository : Repository<Minutes>, IMinutesRepository
    {
        public MinutesRepository(DbSet<Minutes> minutes) : base(minutes)
        {
        }
    }
}
