namespace MK.Blazor.Core.Services
{
    public interface ICoreMoventService<TDataGridItem> : ICoreDataGridService<TDataGridItem>,ICoreEditPageService<TDataGridItem>,ICoreListPageService,ICoreMessageService,ICoreCommonService
    {
        public TDataGridItem TempDataSource { get; set; }
        void GetTotal();
        void BeforeUpdate();
        void BeforeInsert();
        Task DeleteAsync();
        void OnSubmit();
        void InsertOrUpdate();
        void Calc(object value, string propertyName);
    }
}
