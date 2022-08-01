using DevExpress.Blazor;
using DevExpress.Blazor.Base;

namespace MK.Blazor.Core.Components.DevComp.DataEditors.Base
{
    public class DevBaseEditor : DxComponentBase
    {
        public DataEditorClearButtonDisplayMode ClearButtonDisplayMode { get; set; } = DataEditorClearButtonDisplayMode.Auto;
        public int ColumnIndex { get; set; }
        public int ColumnSpan { get; set; }
        public string EditorCssClass { get; set; }
        public bool Enabled { get; set; } = true;
        public string InputCssClass { get; set; }
        public string LayoutItemCssClass { get; set; }
        public string NullText { get; set; }
        public bool ReadOnly { get; set; }
        public int RowIndex { get; set; }
        public int RowSpan { get; set; }
        public bool Visible { get; set; } = true;
    }
}
