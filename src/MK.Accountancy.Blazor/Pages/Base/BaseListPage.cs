using MK.Accountancy.Abstract;
using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.CommonDtos;
using MK.Accountancy.Localization;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Components;

namespace MK.Accountancy.Blazor.Pages.Base
{
    public abstract class BaseListPage<TGetOutputDto, TGetListOutputDto, TGetListInput, TCreateInput, TUpdateInput, TGetCodeInput> : AbpComponentBase
        where TGetOutputDto : class, IEntityDto<Guid>, new()
        where TGetListOutputDto : class, IEntityDto<Guid>
        where TGetListInput : class, IEntityDto, IActive, new()
        where TCreateInput : class, IEntityDto, new()
        where TUpdateInput : class, IEntityDto, new()
        where TGetCodeInput : class, IEntityDto, IActive, new()
    {
        public BaseListPage()
        {
            LocalizationResource = typeof(AccountancyResource);
        }

        #region Services
        protected ICrudAppService<TGetOutputDto, TGetListOutputDto, TGetListInput, TCreateInput, TUpdateInput, TGetCodeInput> BaseCrudAppService { get; set; }

        public BaseService<TGetListOutputDto,TGetOutputDto> BaseService { get; set; }
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

        protected async Task<PagedResultDto<TGetListOutputDto>> GetListAsync(TGetListInput input)
        {
            try
            {
                return await BaseCrudAppService.GetListAsync(input);
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

        protected async Task DeleteAsync(Guid id)
        {
            try
            {
                await BaseCrudAppService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex);
            }
        }

        protected async Task<string> GetCodeAsync(TGetCodeInput input)
        {
            try
            {
                return await BaseCrudAppService.GetCodeAsync(input);
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
