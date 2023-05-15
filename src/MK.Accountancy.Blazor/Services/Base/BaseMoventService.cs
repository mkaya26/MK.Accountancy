using DevExpress.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MK.Accountancy.Localization;
using MK.Accountancy.Migrations;
using MK.Blazor.Core.Helpers;
using MK.Blazor.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Components.Messages;
using Volo.Abp.Guids;

namespace MK.Accountancy.Blazor.Services.Base
{
    public abstract class BaseMoventService<TDataGridItem> : ICoreMoventService<TDataGridItem>
    {
        public IUiMessageService MessageService { get; set; }
        public IGuidGenerator GuidGenerator { get; set; }
        public IStringLocalizerFactory StringLocalizerFactory { get; set; }
        public ComponentBase DataGrid { get; set; }
        public IList<TDataGridItem> ListDataSource { get; set; }
        public IEnumerable<TDataGridItem> SelectedItems { get; set; }
        public bool ShowFilterRow { get; set; }
        public bool ShowGroupPanel { get; set; }
        public TDataGridItem SelectedItem { get; set; }
        public bool SelectFirstDataRow { get; set; }
        public bool IsLoaded { get; set; }
        public bool ShowSelectionCheckBox { get; set; }
        public TDataGridItem DataSource { get; set; }
        public bool ToolbarCheckBoxVisible { get; set; }
        public bool IsActiveCards { get; set; }
        public TDataGridItem TempDataSource { get; set; }

        public IList<string> ExcludeListItem { get; set; }
        public string LoadingCaption => throw new NotImplementedException();

        public string LoadingText => throw new NotImplementedException();

        public bool IsPopupListPage { get; set; }
        public bool EditPageVisible { get; set; }
        public Guid PopupListPageFocusedRowId { get; set; }
        public Action HasChanged { get; set; }
        public ComponentBase ActiveEditComponent { get; set; }

        public void BeforeShowPopupListPage(params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public void ButtonEditDeleteKeyDown(IEntityDto entity, string fieldName)
        {
            throw new NotImplementedException();
        }

        public async Task ConfirmMessage(string message, Action action, string title = null)
        {
            var confirmed = await MessageService.Confirm(message, title);
            if (confirmed)
                action();
        }

        public void HideEditPage()
        {
            EditPageVisible = false;
            HasChanged();
        }

        public void HideListPage()
        {
            throw new NotImplementedException();
        }

        public void SelectEntity(IEntityDto targetEntity)
        {
            throw new NotImplementedException();
        }

        public void SetDataRowSelected(TDataGridItem item)
        {
            ((DxDataGrid<TDataGridItem>)DataGrid).SetDataRowSelected(item, true);
        }

        public void SetDataRowSelected(bool first)
        {
            ((DxDataGrid<TDataGridItem>)DataGrid).SetDataRowSelected(
    first ? ListDataSource.FirstOrDefault() :
    ListDataSource.LastOrDefault(), true);
        }

        public void ShowEditPage()
        {
            throw new NotImplementedException();
        }

        public void ShowListPage(bool firstRender)
        {
            throw new NotImplementedException();
        }

        public void FillTable<TItem>(ICoreMoventService<TItem> moventService, Action hasChanged)
        {
            throw new NotImplementedException();
        }

        public virtual void GetTotal()
        {

        }

        public virtual void BeforeUpdate()
        {
            DataSource = SelectedItem;
            EditPageVisible = true;
        }

        public virtual void BeforeInsert()
        {

        }

        public virtual async Task DeleteAsync()
        {
            await ConfirmMessage(L["DeleteConfirmMessage"], async () =>
            {
                var deletedEntityIndex = ListDataSource.FindIndex(x => x.GetEntityId() == SelectedItem.GetEntityId());
                //
                ListDataSource.Remove(SelectedItem);
                //
                await ((DxDataGrid<TDataGridItem>)DataGrid).Refresh();
                //
                SelectedItem = ListDataSource.SetSelectedItem(deletedEntityIndex);
                SetDataRowSelected(SelectedItem);
                GetTotal();
                //
                HasChanged();
                //
            }, L["DeleteConfirmMessageTitle"]);
        }

        public virtual void OnSubmit() { }

        public virtual void InsertOrUpdate() 
        {
            if(((IEntityDto<Guid>)DataSource).Id == Guid.Empty)
            {
                ((IEntityDto<Guid>)DataSource).Id = GuidGenerator.Create();
                ListDataSource.Add(DataSource);
            }
            else
            {
                var itemIndex = ListDataSource.FindIndex(x => ((IEntityDto<Guid>)x).Id == ((IEntityDto<Guid>)SelectedItem).Id);
                //
                ListDataSource[itemIndex] = DataSource;
            }
            //
            EditPageVisible = false;
            SetDataRowSelected(DataSource);
            //
            GetTotal();
        }

        public virtual void Calc(object value, string propertyName) { }

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
