using DevExpress.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MK.Accountancy.Localization;
using MK.Blazor.Core.Helpers;
using MK.Blazor.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Components.Messages;
using Volo.Abp.Guids;
using Volo.Abp.ObjectMapping;

namespace MK.Accountancy.Blazor.Services.Base
{
    public abstract class BaseService<TDataGridItem, TDataSource> : ICoreDataGridService<TDataGridItem>, ICoreEditPageService<TDataSource>, ICoreListPageService, ICoreMessageService, ICoreCommonService
        where TDataGridItem : class, IEntityDto<Guid>
        where TDataSource : class, new()
    {
        public IStringLocalizerFactory StringLocalizerFactory { get; set; }
        public IUiMessageService MessageService { get; set; }
        public IGuidGenerator GuidGenerator { get; set; }
        public IObjectMapper ObjectMapper { get; set; }
        public ComponentBase DataGrid { get; set; }
        public IList<TDataGridItem> ListDataSource { get; set; }
        public IEnumerable<TDataGridItem> SelectedItems { get; set; }
        public bool ShowFilterRow { get; set; }
        public bool ShowGroupPanel { get; set; }
        public TDataGridItem SelectedItem { get; set; }
        public bool SelectFirstDataRow { get; set; }
        public bool IsLoaded { get; set; }
        public bool ToolbarCheckBoxVisible { get; set; } = true;
        public bool IsActiveCards { get; set; } = true;
        public string LoadingCaption => L["PleaseWait"];
        public string LoadingText => L["Loading"];
        public bool IsPopupListPage { get; set; }
        public bool EditPageVisible { get; set; }
        public Action HasChanged { get; set; }
        public ComponentBase ActiveEditComponent { get; set; }
        public bool ShowSelectionCheckBox { get; set; }
        public TDataSource DataSource { get; set; }
        public Guid PopupListPageFocusedRowId { get; set; }
        public IList<string> ExcludeListItem { get; set; }
        public string SelectedReportName { get; set; }
        public string BaseReportFolder { get; set; } = nameof(Reports);
        public string ReportFolder { get; set; } 
        public bool ShowReportSelectBox { get; set; }
        public bool IsGrantedCreate { get; set; }
        public bool IsGrantedUpdate { get; set; }
        public bool IsGrantedDelete { get; set; }
        public bool IsGrantedPrint { get; set; }
        public bool IsGrantedReserve { get; set; }

        public async Task ConfirmMessage(string message, Action action, string title = null)
        {
            var confirmed = await MessageService.Confirm(message, title);
            if (confirmed)
                action();
        }

        public void ShowListPage(bool firstRender)
        {
            if (firstRender)
            {
                SelectFirstDataRow = true;
                return;
            }

            if(PopupListPageFocusedRowId != Guid.Empty)
            {
                SelectFirstDataRow = false;
                SelectedItem = ListDataSource.GetEntityById(PopupListPageFocusedRowId);
                PopupListPageFocusedRowId = Guid.Empty;
            }

            if(SelectFirstDataRow)
            {
                var item = ListDataSource.FirstOrDefault();
                if(item != null && !ShowSelectionCheckBox)
                {
                    SetDataRowSelected(item);
                }
            }
            else
            {
                SetDataRowSelected(SelectedItem);
            }
        }

        public void SetDataRowSelected(TDataGridItem item)
        {
            ((DxDataGrid<TDataGridItem>)DataGrid).SetDataRowSelected(item, true);
        }

        public void ShowEditPage()
        {
            SelectFirstDataRow = false;
            EditPageVisible = true;
            HasChanged();
        }

        public void HideEditPage()
        {
            EditPageVisible = false;
            HasChanged();
        }

        public void HideListPage()
        {
            IsPopupListPage = false;
            ShowSelectionCheckBox = false;
            SelectedItems = null;
            ((DxTextBox)ActiveEditComponent)?.FocusAsync();
        }

        public virtual void SelectEntity(IEntityDto targetEntity)
        {
            
        }

        public virtual void BeforeShowPopupListPage(params object[] parameters)
        {
            ToolbarCheckBoxVisible = false;
            IsPopupListPage = true;
            //
            if(parameters.Length > 0)
            {
                PopupListPageFocusedRowId = parameters[0] == null ? Guid.Empty : (Guid)parameters[0];
            }
        }

        public virtual void ButtonEditDeleteKeyDown(IEntityDto entity, string fieldName)
        {

        }

        public void SetDataRowSelected(bool first)
        {
            ((DxDataGrid<TDataGridItem>)DataGrid).SetDataRowSelected(
                first ? ListDataSource.FirstOrDefault() :
                ListDataSource.LastOrDefault(), true);
        }

        public virtual void FillTable<TItem>(ICoreMoventService<TItem> moventService, Action hasChanged)
        {
        }

        public virtual void AddSelectedItems()
        {
        }

        #region Localizer
        private IStringLocalizer _localizer;
        public IStringLocalizer L 
        {
            get 
            {
                if (_localizer == null)
                    _localizer = StringLocalizerFactory.Create(typeof(AccountancyResource));
                return _localizer;
            } 
        }
        #endregion
    }
}
