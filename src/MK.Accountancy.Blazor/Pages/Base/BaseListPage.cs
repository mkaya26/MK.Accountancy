using MK.Accountancy.Abstract;
using MK.Accountancy.Blazor.Services.Base;
using MK.Accountancy.CommonDtos;
using MK.Accountancy.Localization;
using MK.Blazor.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public string CreatePolicy { get; set; }
        public string UpdatePolicy { get; set; }
        public string DeletePolicy { get; set; }
        public string PrintPolicy { get; set; }
        public string ReservePolicy { get; set; }

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

        protected virtual async Task GetListDataSourceAsync()
        {
            BaseService.ListDataSource = (await GetListAsync(new TGetListInput
            {
                Active = BaseService.IsActiveCards
            })).Items.ToList();
            //
            BaseService.IsLoaded = true;
        }

        protected override async Task OnParametersSetAsync()
        {
            await GetListDataSourceAsync();
            BaseService.HasChanged = StateHasChanged;
        }

        protected override void OnAfterRender(bool firstRender)
        {
            BaseService.ShowListPage(firstRender);
        }

        protected virtual async Task DeleteAsync()
        {
            BaseService.SelectFirstDataRow = false;
            //
            await BaseService.ConfirmMessage(L["DeleteConfirmMessage"], async () =>
            {
                await DeleteAsync(BaseService.SelectedItem.Id);
                //
                var deletedEntityIndex = BaseService.ListDataSource.FindIndex(x => x.GetEntityId() == BaseService.SelectedItem.GetEntityId());
                await GetListDataSourceAsync();
                //
                BaseService.HasChanged();
                //
                if(BaseService.ListDataSource.Count > 0)
                {
                    BaseService.SelectedItem = BaseService.ListDataSource.SetSelectedItem(deletedEntityIndex);
                }
            }, L["DeleteConfirmMessageTitle"]);
        }
        protected virtual async Task BeforeInsertAsync()
        {
            BaseService.DataSource = new TGetOutputDto();

            var code = typeof(TGetOutputDto).GetProperty("Code");
            var active = typeof(TGetOutputDto).GetProperty("Active");

            if (code != null)
                code.SetValue(BaseService.DataSource, await GetCodeAsync(
                    new TGetCodeInput { Active = BaseService.IsActiveCards }));

            if (active != null)
                active.SetValue(BaseService.DataSource, BaseService.IsActiveCards);

            BaseService.ShowEditPage();

        }

        protected virtual async Task BeforeUpdateAsync()
        {
            //if (!BaseService.IsGrantedUpdate)
            //{
            //    BaseService.SelectFirstDataRow = false;
            //    return;
            //}

            if (BaseService.ListDataSource.Count == 0) return;

            BaseService.SelectFirstDataRow = false;
            BaseService.DataSource = await GetAsync(BaseService.SelectedItem.Id);
            BaseService.EditPageVisible = true;
            await InvokeAsync(BaseService.HasChanged);
        }

        protected virtual async Task OnSubmit()
        {
            TGetOutputDto result;

            if (BaseService.DataSource.Id == Guid.Empty)
            {
                var createInput = ObjectMapper.Map<TGetOutputDto, TCreateInput>(
                    BaseService.DataSource);

                result = await CreateAsync(createInput);
            }
            else
            {
                var updateInput = ObjectMapper.Map<TGetOutputDto, TUpdateInput>(
                    BaseService.DataSource);

                result = await UpdateAsync(BaseService.DataSource.Id, updateInput);
            }

            if (result == null) return;

            var savedEntityIndex = BaseService.ListDataSource.FindIndex(
                x => x.Id == BaseService.DataSource.Id);

            await GetListDataSourceAsync();
            BaseService.HideEditPage();

            if (BaseService.DataSource.Id == Guid.Empty)
                BaseService.DataSource.Id = result.Id;

            if (savedEntityIndex > -1)
                BaseService.SelectedItem = BaseService.ListDataSource.
                    SetSelectedItem(savedEntityIndex);
            else
                BaseService.SelectedItem = BaseService.ListDataSource.
                    GetEntityById(BaseService.DataSource.Id);
        }

        public virtual async Task PrintAsync()
        {
            if (BaseService.ListDataSource.Count == 0) return;
            //
            BaseService.SelectFirstDataRow = false;
            //
            BaseService.DataSource = await GetAsync(BaseService.SelectedItem.Id);
            //
            BaseService.ShowReportSelectBox = true;
            await InvokeAsync(BaseService.HasChanged);
        }
    }
}
