﻿using Microsoft.AspNetCore.Components;

namespace MK.Blazor.Core.Services
{
    public interface ICoreDataGridService<TDataGridItem>
    {
        public ComponentBase DataGrid { get; set; }
        public IList<TDataGridItem> DataSource { get; set; }
        public IEnumerable<TDataGridItem> SelectedItems { get; set; }
        public bool ShowFilterRow { get; set; }
        public bool ShowGroupPanel { get; set; }
        public TDataGridItem SelectedItem { get; set; }
        public bool SelectFirstDataRow { get; set; }
    }
}
