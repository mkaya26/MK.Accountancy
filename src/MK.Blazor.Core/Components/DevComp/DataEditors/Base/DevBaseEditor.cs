using DevExpress.Blazor;
using Microsoft.AspNetCore.Components;

namespace MK.Blazor.Core.Components.DevComp.DataEditors.Base
{
    public class DevBaseEditor : ComponentBase
    {
        public DataEditorClearButtonDisplayMode ClearButtonDisplayMode { get; set; }
        public int ColumnIndex { get; set; }
        public int ColumnSpan { get; set; }
        public string EditorCssClass { get; set; }
        public bool Enabled { get; set; }
        public string InputCssClass { get; set; }
        public string LayoutItemCssClass { get; set; }
        public string NullText { get; set; }
        public bool ReadOnly { get; set; }
        public int RowIndex { get; set; }
        public int RowSpan { get; set; }
        public bool Visible { get; set; }
    }
}
