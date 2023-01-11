using Microsoft.AspNetCore.Components;
using MK.Blazor.Core.Services;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Blazor.Services.Base
{
    public abstract class BaseService<TDataGridItem, TDataSource> : ICoreDataGridService<TDataGridItem>, ICoreEditPageService<TDataSource>, ICoreListPageService, ICoreMessageService, ICoreCommonService
        where TDataGridItem : class, IEntityDto<Guid>
        where TDataSource : class, new()
    {
        public ComponentBase DataGrid { get; set; }
        public IList<TDataGridItem> DataSource { get; set; }
        public IEnumerable<TDataGridItem> SelectedItems { get; set; }
        public bool ShowFilterRow { get; set; }
        public bool ShowGroupPanel { get; set; }
        public TDataGridItem SelectedItem { get; set; }
        public bool SelectFirstDataRow { get; set; }
        public bool IsLoaded { get; set; }
        public bool ToolbarCheckBoxVisible { get; set; }
        public bool IsActiveCards { get; set; }
        public string LoadingCaption { get; set; }
        public string LoadingText { get; set; }
        public bool IsPopupListPage { get; set; }
        public bool EditPageVisible { get; set; }
        public Action HasChanged { get; set; }
        public ComponentBase ActiveEditComponent { get; set; }
    }
}
