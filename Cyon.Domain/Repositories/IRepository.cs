using System.Linq.Expressions;

namespace Cyon.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entitiesToAdd);
        Task UpdateAsync(TEntity entity);
        Task UpdateRangeAsync(IEnumerable<TEntity> entitiesToUpdate);
        Task<TEntity> GetByIdAsync(Guid id, IEnumerable<string> entitiesToInclude = null);
        Task<IEnumerable<TEntity>> GetAllAsync(IEnumerable<Expression<Func<TEntity, bool>>> predicates = null, IEnumerable<string> entitiesToInclude = null);
        Task<TEntity> GetFirstMatchAsync(IEnumerable<Expression<Func<TEntity, bool>>> predicates = null, IEnumerable<string> entitiesToInclude = null);
        Task<IEnumerable<TEntity>> GetAllAsync(int skip, int limit, IEnumerable<string> entitiesToInclude = null, IEnumerable<Expression<Func<TEntity, bool>>> predicates = null);
        void Delete(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<int> Count(IEnumerable<Expression<Func<TEntity, bool>>> predicates = null);
        Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
