using Cyon.Domain.Entities;
using Cyon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cyon.Infrastructure.Repositories
{
    public class ApologyRepository : Repository<Apology>, IApologyRepository
    {
        public ApologyRepository(DbSet<Apology> apologies) : base(apologies)
        {
        }
    }
}
