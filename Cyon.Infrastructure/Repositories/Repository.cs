using Cyon.Domain.Entities;
using Cyon.Domain.Repositories;
using Cyon.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Cyon.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbSet<TEntity> _entities;

        public Repository(DbSet<TEntity> entities)
        {
            _entities = entities;
        }

        public async Task AddAsync(TEntity entity) => await _entities.AddAsync(entity);

        public async Task AddRangeAsync(IEnumerable<TEntity> entitiesToAdd) => await _entities.AddRangeAsync(entitiesToAdd);

        public async virtual Task<int> Count(IEnumerable<Expression<Func<TEntity, bool>>> predicates = null) => await _entities.Filter(predicates).CountAsync();

        public void Delete(TEntity entity) => _entities.Remove(entity);
        public void DeleteRange(IEnumerable<TEntity> entitiesToDelete) => _entities.RemoveRange(entitiesToDelete);

        public async Task DeleteAsync(TEntity entity) => await Task.Run(() => Delete(entity));

        public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate) => await _entities.AnyAsync(predicate);

        public async Task<IEnumerable<TEntity>> GetAllAsync(IEnumerable<Expression<Func<TEntity, bool>>> predicates = null, IEnumerable<string> entitiesToInclude = null) => await _entities.AsNoTracking().Filter(predicates).Include(entitiesToInclude).ToListAsync();

        public async Task<TEntity> GetFirstMatchAsync(IEnumerable<Expression<Func<TEntity, bool>>> predicates = null, IEnumerable<string> entitiesToInclude = null) => await _entities.AsNoTracking().Filter(predicates).Include(entitiesToInclude).FirstOrDefaultAsync();

        public async Task<IEnumerable<TEntity>> GetAllAsync(int skip, int limit, IEnumerable<string> entitiesToInclude = null, IEnumerable<Expression<Func<TEntity, bool>>> predicates = null) => await _entities.AsNoTracking().Skip(skip).Take(limit).Include(entitiesToInclude).Filter(predicates).ToListAsync();

        public async Task<TEntity> GetByIdAsync(Guid id, IEnumerable<string> entitiesToInclude = null) => await _entities.AsNoTracking().Include(entitiesToInclude).FirstOrDefaultAsync(e => e.Id == id);

        public async Task UpdateAsync(TEntity entity) => await Task.Run(() => { _entities.Update(entity); });

        public async Task UpdateRangeAsync(IEnumerable<TEntity> entitiesToUpdate) => await Task.Run(() => {_entities.UpdateRange(entitiesToUpdate); });
    }
}
