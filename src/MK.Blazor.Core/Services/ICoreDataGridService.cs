using Microsoft.AspNetCore.Components;

namespace MK.Blazor.Core.Services
{
    public interface ICoreDataGridService<TDataGridItem>
    {
        public ComponentBase DataGrid { get; set; }
        public IList<TDataGridItem> ListDataSource { get; set; }
        public IEnumerable<TDataGridItem> SelectedItems { get; set; }
        public bool ShowFilterRow { get; set; }
        public bool ShowGroupPanel { get; set; }
        public TDataGridItem SelectedItem { get; set; }
        public bool SelectFirstDataRow { get; set; }
        public bool IsLoaded { get; set; }
        public bool ShowSelectionCheckBox { get; set; }
        public IList<string> ExcludeListItem { get; set; }
        void ShowListPage(bool firstRender);
        void SetDataRowSelected(TDataGridItem item);
        void SetDataRowSelected(bool first);
        void FillTable<TItem>(ICoreMoventService<TItem> moventService, Action hasChanged);
        void AddSelectedItems();
    }
}
