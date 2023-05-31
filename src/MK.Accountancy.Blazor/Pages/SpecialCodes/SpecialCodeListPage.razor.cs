using MK.Accountancy.SpecialCodes;
using System.Linq;
using System.Threading.Tasks;

namespace MK.Accountancy.Blazor.Pages.SpecialCodes
{
    public partial class SpecialCodeListPage
    {
        protected override async Task GetListDataSourceAsync()
        {
            var listDataSource = (await GetListAsync(new SpecialCodeListParameterDto
            {
                SpecialCodeType = Service.SpecialCodeType,
                CardType = Service.CardType,
                Active = Service.IsActiveCards
            }))?.Items.ToList();
            //
            Service.IsLoaded = true;
            //
            if (listDataSource != null)
                Service.ListDataSource = listDataSource;
        }

        protected override async Task BeforeInsertAsync()
        {
            Service.DataSource = new SelectSpecialCodeDto
            {
                Code = await GetCodeAsync(new SpecialCodeParameterDto
                {
                    SpecialCodeType = Service.SpecialCodeType,
                    CardType = Service.CardType,
                    Active = Service.IsActiveCards
                }),
                SpecialCodeType = Service.SpecialCodeType,
                CardType = Service.CardType,
                Active = Service.IsActiveCards
            };
            //
            Service.ShowEditPage();
        }
    }
}
