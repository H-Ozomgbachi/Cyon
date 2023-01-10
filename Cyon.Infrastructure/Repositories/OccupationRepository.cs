using Cyon.Domain.Common;
using Cyon.Domain.Entities;
using Cyon.Domain.Repositories;
using Cyon.Infrastructure.Database;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Cyon.Infrastructure.Repositories
{
    public class OccupationRepository : Repository<Occupation>, IOccupationRepository
    {
        private readonly DbSet<Occupation> _occupations;
        private readonly DapperContext _dapperContext;

        public OccupationRepository(DbSet<Occupation> occupations, DapperContext dapperContext) : base(occupations)
        {
            _occupations = occupations;
            _dapperContext = dapperContext;
        }

        public async Task<Occupation> GetOccupationByUserId(Guid userId)
        {
            Occupation occupation = await _occupations.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == userId);
            return occupation;
        }

        public async Task<IEnumerable<Occupation>> PeopleWithSimilarOccupation(string jobKeyWord, Pagination pagination, Guid userId)
        {
            string sp1 = "Sp_GetPeopleWithSimilarOccupation";
            var parameters = new DynamicParameters();
            parameters.Add("UserId", userId, DbType.Guid, ParameterDirection.Input);
            parameters.Add("JobKeyWord", jobKeyWord, DbType.String, ParameterDirection.Input);
            parameters.Add("Skip", pagination.Skip, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Limit", pagination.Limit, DbType.Int32, ParameterDirection.Input);

            using var connection = _dapperContext.CreateConnection();
            var occupations = await connection.QueryAsync<Occupation, User, Occupation>(sp1, (occupation, user) =>
            {
                occupation.User = user;
                return occupation;
            }, parameters, commandType: CommandType.StoredProcedure);

            return occupations;
        }
    }
}
