using DevExpress.Blazor;
using MK.Accountancy.Blazor.Services;
using MK.Accountancy.Companies;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MK.Accountancy.Blazor.Pages.Companies
{
    public partial class CompanyEditPage
    {
        protected int SelectedFilesCount { get; set; }
        private SelectCompanyDto _tempCompany;
        private string imgKey { get; set; }
        private string oldImageUrl { get; set; }
        protected override async Task OnParametersSetAsync()
        {
            AppService.Company = (await CrudService.GetAsync()) == null ? new SelectCompanyDto() : await CrudService.GetAsync();
            //
            if (!string.IsNullOrEmpty(AppService.Company.LogoUrl))
            {
                oldImageUrl = AppService.Company.LogoUrl;
            }
        }
        protected override void OnInitialized()
        {
            BaseCrudAppService = CrudService;
        }

        private async Task Save()
        {
            if(!string.IsNullOrEmpty(imgKey))
            {
                AppService.Company.LogoUrl = "/Files/" + imgKey + ".png";
                //
                string baseUrl = NavigationManager.BaseUri;
                //
                AppService.Company.FullLogoUrl = baseUrl + "Files/" + imgKey + ".png";
            }
            if (AppService.Company.Id != Guid.Empty)
            {
                _tempCompany = await UpdateAsync(AppService.Company.Id, ObjectMapper.Map<SelectCompanyDto, UpdateCompanyDto>(AppService.Company));
            }
            else
            {
                _tempCompany = await CreateAsync(ObjectMapper.Map<SelectCompanyDto, CreateCompanyDto>(AppService.Company));
            }
            AppService.HasChanged();
        }
        private async Task ClosingAsync(PopupClosingEventArgs args)
        {
            if (_tempCompany != null)
            {
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
        protected void SelectedFilesChanged(IEnumerable<UploadFileInfo> files)
        {
            SelectedFilesCount = files.ToList().Count;
            if (SelectedFilesCount > 0)
            {
                imgKey = files.FirstOrDefault().Guid.ToString();
                InvokeAsync(StateHasChanged);
            }
        }
        protected string GetUploadUrl(string url)
        {
            if (!string.IsNullOrEmpty(imgKey))
            {
                return NavigationManager.ToAbsoluteUri($"{url}?guid={imgKey}").AbsoluteUri;
            }
            return NavigationManager.ToAbsoluteUri(url).AbsoluteUri;
        }
        protected void FileUploaded(FileUploadEventArgs args)
        {
            if (!string.IsNullOrEmpty(imgKey))
            {
                AppService.Company.LogoUrl = "/Files/" + imgKey + ".png";
            }
            //
            InvokeAsync(StateHasChanged);
            //
            OldImageDelete();
        }
        private void OldImageDelete()
        {
            string filePath = "wwwroot" + oldImageUrl;
            //
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                //
                oldImageUrl = AppService.Company.LogoUrl;
            }
        }
    }
}
