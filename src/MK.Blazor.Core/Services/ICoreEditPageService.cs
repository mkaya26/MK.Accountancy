namespace MK.Blazor.Core.Services
{
    public interface ICoreEditPageService<TDataSource>
    {
        public TDataSource DataSource { get; set; }
    }
}
