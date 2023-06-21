using DevExpress.Blazor;
using MK.Accountancy.Blazor.Services;
using MK.Accountancy.Companies;
using System;
using System.Threading.Tasks;

namespace MK.Accountancy.Blazor.Pages.Companies
{
    public partial class CompanyEditPage
    {
        private SelectCompanyDto _tempCompany;
        protected override async Task OnParametersSetAsync()
        {
            AppService.Company = (await CrudService.GetAsync()) == null ? new SelectCompanyDto() : await CrudService.GetAsync();
            _tempCompany = new SelectCompanyDto();
        }
        protected override void OnInitialized()
        {
            BaseCrudAppService = CrudService;
        }

        private async Task Save()
        {
            if (AppService.Company.Id != Guid.Empty)
            {
                _tempCompany = await UpdateAsync(AppService.Company.Id, ObjectMapper.Map<SelectCompanyDto, UpdateCompanyDto>(AppService.Company));
                //
                if(_tempCompany != null)
                {
                    AppService.Company = _tempCompany;
                }
            }
            else
            {
                _tempCompany = await CreateAsync(ObjectMapper.Map<SelectCompanyDto, CreateCompanyDto>(AppService.Company));
                //
                if (_tempCompany != null)
                {
                    AppService.Company = _tempCompany;
                }
            }
            //
            if (_tempCompany != null)
            {
                NavigationManager.NavigateTo("/", true);
                AppService.ShowCompanyEditPage = false;
                AppService.HasChanged();
            }
        }
        private async Task ClosingAsync(PopupClosingEventArgs args)
        {
            if (_tempCompany != null)
            {
                NavigationManager.NavigateTo("/", true);
                AppService.ShowCompanyEditPage = false;
                AppService.HasChanged();
            }
            else
            {
                args.Cancel = true;
            }
            //
            await Task.CompletedTask;
        }
    }
}
