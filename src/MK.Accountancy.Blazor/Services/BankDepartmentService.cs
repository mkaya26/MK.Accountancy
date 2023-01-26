using MK.Accountancy.BankDepartments;
using MK.Accountancy.Blazor.Services.Base;
using System;
using Volo.Abp.DependencyInjection;

namespace MK.Accountancy.Blazor.Services
{
    public class BankDepartmentService : BaseService<ListBankDepartmentDto,SelectBankDepartmentDto>,IScopedDependency
    {
        public Guid BankId { get; set; }
        public override void BeforeShowPopupListPage(params object[] parameters)
        {
            ToolbarCheckBoxVisible = parameters.Length == 1;
            //
            IsPopupListPage = true;
            BankId = (Guid)parameters[0];
            PopupListPageFocusedRowId = parameters.Length > 1 && parameters[1] != null ? (Guid)parameters[1] : Guid.Empty;
        }
    }
}
