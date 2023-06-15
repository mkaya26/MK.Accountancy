using Microsoft.EntityFrameworkCore;
using MK.Accountancy.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MK.Accountancy.Commons
{
    public class EfCoreCommonNoKeyRepository<TEntity> : EfCoreRepository<AccountancyDbContext, TEntity>, ICommonNoKeyRepository<TEntity> where TEntity : class, IEntity
    {
        public EfCoreCommonNoKeyRepository(IDbContextProvider<AccountancyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<IList<TEntity>> FromSqlRawAsync(string sql, params object[] parameters)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FromSqlRaw(sql, parameters).ToListAsync();
        }

        public async Task<TEntity> FromSqlRawSingleAsync(string sql, params object[] parameters)
        {
            var dbSet = await GetDbSetAsync();
            return (await dbSet.FromSqlRaw(sql, parameters).ToListAsync()).FirstOrDefault();
        }
    }
}
