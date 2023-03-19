namespace MK.Blazor.Core.Services
{
    public interface ICoreMoventService<TDataGridItem> : ICoreDataGridService<TDataGridItem>,ICoreEditPageService<TDataGridItem>,ICoreListPageService,ICoreMessageService,ICoreCommonService
    {
    }
}
