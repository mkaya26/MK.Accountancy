using MK.Accountancy.Exceptions;
using MK.Accountancy.SpecialCodes;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace MK.Accountancy.Extensions
{
    public static class EntityAsyncExtensions
    {
        public static async Task CodeAnyAsync<TEntity>(this IReadOnlyRepository<TEntity> repository, string code, Expression<Func<TEntity, bool>> predicate, bool check = true) where TEntity : class, IEntity
        {
            if (check && await repository.AnyAsync(predicate))
                throw new DuplicateCodeException(code);
        }

        public static async Task EntityAnyAsync<TEntity>(this IReadOnlyRepository<TEntity> repository, object id, Expression<Func<TEntity,bool>> predicate, bool check = true)
            where TEntity : class, IEntity
        {
            if (check && id != null)
            {
                var anyAsync = await repository.AnyAsync(predicate);
                if (!anyAsync)
                    throw new EntityNotFoundException(typeof(TEntity), id);
            }
        }

        public static async Task EntityAnyAsync(this IReadOnlyRepository<SpecialCode> repository, Guid? id, SpecialCodeType specialCodeType, CardType cardType,bool check = true)
        {
            if (check && id != null)
            {
                var anyAsync = await repository.AnyAsync(x => x.Id == id && 
                                    x.SpecialCodeType == specialCodeType && 
                                    x.CardType == cardType);
                if (!anyAsync)
                    throw new EntityNotFoundException(typeof(SpecialCode), id);
            }
        }

        public static async Task RelationalEntityAnyAsync<TEntity>(this IReadOnlyRepository<TEntity> repository, Expression<Func<TEntity,bool>> predicate) where TEntity : class, IEntity
        {
            var anyAsync = await repository.AnyAsync(predicate);
            if (anyAsync)
                throw new CannotBeDeletedException();
        }
    }
}
