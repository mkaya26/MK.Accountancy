using MK.Accountancy.Abstract;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Components;

namespace MK.Accountancy.Blazor.Pages.Base
{
    public abstract class BaseUpdatePage<TGetOutputDto, TGetListOutputDto, TGetListInput, TCreateInput, TUpdateInput> : AbpComponentBase
        where TGetOutputDto : class, IEntityDto
        where TGetListOutputDto : class, IEntityDto
        where TGetListInput : class, IEntityDto
        where TCreateInput : class, IEntityDto
        where TUpdateInput : class, IEntityDto
    {
        #region Services
        protected ICrudAppService<TGetOutputDto, TGetListOutputDto, TGetListInput, TCreateInput, TUpdateInput> BaseCrudAppService { get; set; }
        #endregion

        #region Crud Functions
        protected async Task<TGetOutputDto> GetAsync(Guid id)
        {
            try
            {
                return await BaseCrudAppService.GetAsync(id);
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex);
            }
            return default;
        }

        protected async Task<TGetOutputDto> CreateAsync(TCreateInput input)
        {
            try
            {
                return await BaseCrudAppService.CreateAsync(input);
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex);
            }
            return default;
        }

        protected async Task<TGetOutputDto> UpdateAsync(Guid id, TUpdateInput input)
        {
            try
            {
                return await BaseCrudAppService.UpdateAsync(id, input);
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex);
            }
            return default;
        }
        #endregion
    }
}
