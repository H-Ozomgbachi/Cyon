using Cyon.Domain.Entities;
using Cyon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cyon.Infrastructure.Repositories
{
    public class OccupationRepository : Repository<Occupation>, IOccupationRepository
    {
        private readonly DbSet<Occupation> _occupations;

        public OccupationRepository(DbSet<Occupation> occupations) : base(occupations)
        {
            _occupations = occupations;
        }

        public async Task<Occupation> GetOccupationByUserId(Guid userId)
        {
            Occupation occupation = await _occupations.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == userId);
            return occupation;
        }
    }
}
