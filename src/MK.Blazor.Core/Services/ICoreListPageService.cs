namespace MK.Blazor.Core.Services
{
    public interface ICoreListPageService
    {
        public bool ToolbarCheckBoxVisible { get; set; }
        public bool IsActiveCards { get; set; }
        public string LoadingCaption { get; set; }
        public string LoadingText { get; set; }
        public bool IsPopupListPage { get; set; }
        public bool EditPageVisible { get; set; }
    }
}
