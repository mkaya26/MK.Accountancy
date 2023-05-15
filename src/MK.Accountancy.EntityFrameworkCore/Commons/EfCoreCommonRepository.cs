using Microsoft.EntityFrameworkCore;
using MK.Accountancy.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MK.Accountancy.Commons
{
    public class EfCoreCommonRepository<TEntity> : EfCoreRepository<AccountancyDbContext, TEntity, Guid>,
        ICommonRepository<TEntity> where TEntity : class, IEntity<Guid>
    {
        public EfCoreCommonRepository(IDbContextProvider<AccountancyDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            var dbSet = await GetDbSetAsync();
            return predicate == null ?
                await dbSet.AnyAsync() :
                await dbSet.AnyAsync(predicate);
        }

        public async Task<IList<TEntity>> FromSqlRawAsync(string sql, params object[] parameters)
        {
            try
            {
                var context = await GetDbContextAsync();
                return await context.Set<TEntity>().FromSqlRaw(sql, parameters).ToListAsync();
            }
            catch(Exception ex)
            {
                Trace.WriteLine(ex);
            }
            return default;
        }

        public async Task<TEntity> GetAsync(object id, Expression<Func<TEntity, bool>> predicate = null)
        {
            var queryable = await WithDetailsAsync();
            //
            TEntity entity;
            //
            if (predicate != null)
            {
                entity = await queryable.FirstOrDefaultAsync(predicate);
                if (entity == null)
                    throw new EntityNotFoundException(typeof(TEntity), id);
                return entity;
            }
            entity = await queryable.FirstOrDefaultAsync();
            if (entity == null)
                throw new EntityNotFoundException(typeof(TEntity), id);
            return entity;
        }

        public async Task<TEntity> GetAsync(object id, Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includes)
        {
            var queryable = await WithDetailsAsync(includes);
            //
            TEntity entity;
            //
            if(predicate != null)
            {
                entity = await queryable.FirstOrDefaultAsync(predicate);
                if (entity == null)
                    throw new EntityNotFoundException(typeof(TEntity), id);
                return entity;
            }
            entity = await queryable.FirstOrDefaultAsync();
            if (entity == null)
                throw new EntityNotFoundException(typeof(TEntity), id);
            return entity;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includes)
        {
            var queryable = await WithDetailsAsync(includes);
            //
            if (predicate != null)
                return await queryable.FirstOrDefaultAsync(predicate);
            return await queryable.FirstOrDefaultAsync();
        }

        public async Task<string> GetCodeAsync(Expression<Func<TEntity, string>> propertySelector, Expression<Func<TEntity, bool>> predicate = null)
        {
            static string CreateNewCode(string code)
            {
                var number = "";
                foreach (var charcacter in code)
                {
                    if(char.IsDigit(charcacter))
                    {
                        number += charcacter;
                    }
                    else
                    {
                        number = "";
                    }
                }
                var newNumber = number == "" ? "1" : (long.Parse(number) + 1).ToString();
                var diffirence = code.Length - newNumber.Length;
                if (diffirence < 0)
                    diffirence = 0;
                var newCode = code.Substring(0, diffirence);
                newCode += newNumber;
                return newCode;
            }
            //
            var dbSet = await GetDbSetAsync();
            var maxCode = predicate == null ?
                await dbSet.MaxAsync(propertySelector) :
                await dbSet.Where(predicate).MaxAsync(propertySelector);
            return maxCode == null ? "0000000000000001" : CreateNewCode(maxCode);
        }

        public async Task<List<TEntity>> GetPagedLastListAsync<TKey>(int skipCount, int maxResultCount, Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, TKey>> orderBy = null, params Expression<Func<TEntity, object>>[] inncludes)
        {
            var queryable = await WithDetailsAsync(inncludes);
            //
            if (predicate != null)
                queryable = queryable.Where(predicate);
            if (orderBy != null)
                queryable = queryable.OrderByDescending(orderBy);
            return await queryable.Skip(skipCount).Take(maxResultCount).ToListAsync();
        }

        public async Task<List<TEntity>> GetPagedListAsync<TKey>(int skipCount, int maxResultCount, Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, TKey>> orderBy = null)
        {
            var queryable = await WithDetailsAsync();
            //
            if (predicate != null)
                queryable = queryable.Where(predicate);
            if (orderBy != null)
                queryable = queryable.OrderBy(orderBy);
            return await queryable.Skip(skipCount).Take(maxResultCount).ToListAsync();
        }

        public async Task<List<TEntity>> GetPagedListAsync<TKey>(int skipCount, int maxResultCount, Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, TKey>> orderBy = null, params Expression<Func<TEntity, object>>[] inncludes)
        {
            var queryable = await WithDetailsAsync(inncludes);
            //
            if (predicate != null)
                queryable = queryable.Where(predicate);
            if (orderBy != null)
                queryable = queryable.OrderBy(orderBy);
            return await queryable.Skip(skipCount).Take(maxResultCount).ToListAsync();
        }
    }
}
