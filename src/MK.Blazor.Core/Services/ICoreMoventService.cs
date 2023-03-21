namespace MK.Blazor.Core.Services
{
    public interface ICoreMoventService<TDataGridItem> : ICoreDataGridService<TDataGridItem>,ICoreEditPageService<TDataGridItem>,ICoreListPageService,ICoreMessageService,ICoreCommonService
    {
        void GetTotal();
        void BeforeUpdate();
        void BeforeInsert();
        Task DeleteAsync();
    }
}
