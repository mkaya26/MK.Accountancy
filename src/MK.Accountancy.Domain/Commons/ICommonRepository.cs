using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace MK.Accountancy.Commons
{
    public interface ICommonRepository<TEntity> : IRepository<TEntity,Guid>
        where TEntity : class, IEntity<Guid>
    {
        Task<TEntity> GetAsync();
        Task<TEntity> GetAsync(object id, Expression<Func<TEntity, bool>> predicate = null);
        Task<TEntity> GetAsync(object id, Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includes);
        Task<List<TEntity>> GetPagedListAsync<TKey>(int skipCount, int maxResultCount, Expression<Func<TEntity, bool>> predicate = null,
          Expression<Func<TEntity, TKey>> orderBy = null);
        Task<List<TEntity>> GetPagedListAsync<TKey>(int skipCount, int maxResultCount, Expression<Func<TEntity, bool>> predicate = null,
          Expression<Func<TEntity, TKey>> orderBy = null,
          params Expression<Func<TEntity, object>>[] inncludes);
        Task<List<TEntity>> GetPagedLastListAsync<TKey>(int skipCount, int maxResultCount, Expression<Func<TEntity, bool>> predicate = null,
          Expression<Func<TEntity, TKey>> orderBy = null,
          params Expression<Func<TEntity, object>>[] inncludes);
        Task<string> GetCodeAsync(Expression<Func<TEntity, string>> propertySelector, Expression<Func<TEntity, bool>> predicate = null);
        Task<IList<TEntity>> FromSqlRawAsync(string sql, params object[] parameters);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null);
    }
}
