using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MK.Accountancy.Localization;
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
        public IStringLocalizerFactory StringLocalizerFactory { get; set; }
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
