using AutoMapper;
using MK.Accountancy.BankAccounts;
using MK.Accountancy.BankDepartments;
using MK.Accountancy.Banks;
using MK.Accountancy.Currents;
using MK.Accountancy.Departments;
using MK.Accountancy.Expenses;
using MK.Accountancy.Invoices;
using MK.Accountancy.Parameters;
using MK.Accountancy.Receipts;
using MK.Accountancy.Safes;
using MK.Accountancy.Services;
using MK.Accountancy.SpecialCodes;
using MK.Accountancy.Stocks;
using MK.Accountancy.Stores;
using MK.Accountancy.Terms;
using MK.Accountancy.Units;
using System.Linq;

namespace MK.Accountancy;

public class AccountancyApplicationAutoMapperProfile : Profile
{
    public AccountancyApplicationAutoMapperProfile()
    {
        CreateMap<Bank, SelectBankDto>()
            .ForMember(x => x.SpecialCodeOneName, y => y.MapFrom(z => z.SpecialCodeOne.Name))
            .ForMember(x => x.SpecialCodeTwoName, y => y.MapFrom(z => z.SpecialCodeTwo.Name));
        CreateMap<Bank, BankListDto>()
            .ForMember(x => x.SpecialCodeOneName, y => y.MapFrom(z => z.SpecialCodeOne.Name))
            .ForMember(x => x.SpecialCodeTwoName, y => y.MapFrom(z => z.SpecialCodeTwo.Name));
        CreateMap<CreateBankDto, Bank>();
        CreateMap<UpdateBankDto, Bank>();
        CreateMap<SelectBankDto, CreateBankDto>();
        CreateMap<SelectBankDto, UpdateBankDto>();
        //
        CreateMap<BankDepartment, SelectBankDepartmentDto>()
            .ForMember(x => x.BankName, y => y.MapFrom(z => z.Bank.Name))
            .ForMember(x => x.SpecialCodeOneName, y => y.MapFrom(z => z.SpecialCodeOne.Name))
            .ForMember(x => x.SpecialCodeTwoName, y => y.MapFrom(z => z.SpecialCodeTwo.Name));
        CreateMap<BankDepartment, ListBankDepartmentDto>()
            .ForMember(x => x.BankName, y => y.MapFrom(z => z.Bank.Name))
            .ForMember(x => x.SpecialCodeOneName, y => y.MapFrom(z => z.SpecialCodeOne.Name))
            .ForMember(x => x.SpecialCodeTwoName, y => y.MapFrom(z => z.SpecialCodeTwo.Name));
        CreateMap<CreateBankDepartmentDto, BankDepartment>();
        CreateMap<UpdateBankDepartmentDto, BankDepartment>();
        CreateMap<SelectBankDepartmentDto, CreateBankDepartmentDto>();
        CreateMap<SelectBankDepartmentDto, UpdateBankDepartmentDto>();
        //
        CreateMap<BankAccount, SelectBankAccountDto>()
            .ForMember(x => x.BankName, y => y.MapFrom(z => z.BankDepartment.Bank.Name))
            .ForMember(x => x.BankDepartmentName, y => y.MapFrom(z => z.BankDepartment.Name))
            .ForMember(x => x.SpecialCodeOneName, y => y.MapFrom(z => z.SpecialCodeOne.Name))
            .ForMember(x => x.SpecialCodeTwoName, y => y.MapFrom(z => z.SpecialCodeTwo.Name));
        CreateMap<BankAccount, ListBankAccountDto>()
            .ForMember(x => x.BankName, y => y.MapFrom(z => z.BankDepartment.Bank.Name))
            .ForMember(x => x.BankDepartmentName, y => y.MapFrom(z => z.BankDepartment.Name))
            .ForMember(x => x.SpecialCodeOneName, y => y.MapFrom(z => z.SpecialCodeOne.Name))
            .ForMember(x => x.SpecialCodeTwoName, y => y.MapFrom(z => z.SpecialCodeTwo.Name));
        CreateMap<CreateBankAccountDto, BankAccount>();
        CreateMap<UpdateBankAccountDto, BankAccount>();
        CreateMap<SelectBankAccountDto, CreateBankAccountDto>();
        CreateMap<SelectBankAccountDto, UpdateBankAccountDto>();
        //
        CreateMap<Unit, SelectUnitDto>()
            .ForMember(x => x.SpecialCodeOneName, y => y.MapFrom(z => z.SpecialCodeOne.Name))
            .ForMember(x => x.SpecialCodeTwoName, y => y.MapFrom(z => z.SpecialCodeTwo.Name));
        CreateMap<Unit, ListUnitDto>()
            .ForMember(x => x.SpecialCodeOneName, y => y.MapFrom(z => z.SpecialCodeOne.Name))
            .ForMember(x => x.SpecialCodeTwoName, y => y.MapFrom(z => z.SpecialCodeTwo.Name));
        CreateMap<CreateUnitDto, Unit>();
        CreateMap<UpdateUnitDto, Unit>();
        CreateMap<SelectUnitDto, CreateUnitDto>();
        CreateMap<SelectUnitDto, UpdateUnitDto>();
        //
        CreateMap<Current, SelectCurrentDto>()
            .ForMember(x => x.SpecialCodeOneName, y => y.MapFrom(z => z.SpecialCodeOne.Name))
            .ForMember(x => x.SpecialCodeTwoName, y => y.MapFrom(z => z.SpecialCodeTwo.Name));
        CreateMap<Current, ListCurrentDto>()
            .ForMember(x => x.SpecialCodeOneName, y => y.MapFrom(z => z.SpecialCodeOne.Name))
            .ForMember(x => x.SpecialCodeTwoName, y => y.MapFrom(z => z.SpecialCodeTwo.Name));
        CreateMap<CreateCurrentDto, Current>();
        CreateMap<UpdateCurrentDto, Current>();
        CreateMap<SelectCurrentDto, CreateCurrentDto>();
        CreateMap<SelectCurrentDto, UpdateCurrentDto>();
        //
        CreateMap<Store, SelectStoreDto>()
            .ForMember(x => x.SpecialCodeOneName, y => y.MapFrom(z => z.SpecialCodeOne.Name))
            .ForMember(x => x.SpecialCodeTwoName, y => y.MapFrom(z => z.SpecialCodeTwo.Name));
        CreateMap<Store, ListStoreDto>()
            .ForMember(x => x.SpecialCodeOneName, y => y.MapFrom(z => z.SpecialCodeOne.Name))
            .ForMember(x => x.SpecialCodeTwoName, y => y.MapFrom(z => z.SpecialCodeTwo.Name))
            .ForMember(x => x.AmountInput, y => y.MapFrom(x => x.InvoiceDetails
                                           .Where(f => f.Invoice.InvoiceType == InvoiceType.Buy)
                                           .Sum(i => i.Quantity)))
            .ForMember(x => x.OutputAmount, y => y.MapFrom(x => x.InvoiceDetails
                                           .Where(f => f.Invoice.InvoiceType == InvoiceType.Sell)
                                           .Sum(i => i.Quantity)));
        CreateMap<CreateStoreDto, Store>();
        CreateMap<UpdateStoreDto, Store>();
        CreateMap<SelectStoreDto, CreateStoreDto>();
        CreateMap<SelectStoreDto, UpdateStoreDto>();
        //
        CreateMap<Term, SelectTermDto>();
        CreateMap<Term, ListTermDto>();
        CreateMap<CreateTermDto, Term>();
        CreateMap<UpdateTermDto, Term>();
        CreateMap<SelectTermDto,CreateTermDto>();
        CreateMap<SelectTermDto,UpdateTermDto>();
        //
        CreateMap<Invoice, SelectInvoiceDto>()
            .ForMember(x => x.CurrentName, y => y.MapFrom(z => z.Current.Name))
            .ForMember(x => x.TaxOffice, y => y.MapFrom(z => z.Current.TaxDepartment))
            .ForMember(x => x.TaxNumber, y => y.MapFrom(z => z.Current.TaxNumber))
            .ForMember(x => x.Address, y => y.MapFrom(z => z.Current.Address))
            .ForMember(x => x.Telephone, y => y.MapFrom(z => z.Current.Telephone))
            .ForMember(x => x.SpecialCodeOneName, y => y.MapFrom(z => z.SpecialCodeOne.Name))
            .ForMember(x => x.SpecialCodeTwoName, y => y.MapFrom(z => z.SpecialCodeTwo.Name));
        CreateMap<Invoice, ListInvoiceDto>()
            .ForMember(x => x.CurrentName, y => y.MapFrom(z => z.Current.Name))
            .ForMember(x => x.SpecialCodeOneName, y => y.MapFrom(z => z.SpecialCodeOne.Name))
            .ForMember(x => x.SpecialCodeTwoName, y => y.MapFrom(z => z.SpecialCodeTwo.Name));
        CreateMap<CreateInvoiceDto, Invoice>();
        CreateMap<UpdateInvoiceDto, Invoice>()
            .ForMember(x => x.InvoiceDetails, y => y.Ignore());
        CreateMap<SelectInvoiceDto, CreateInvoiceDto>();
        CreateMap<SelectInvoiceDto, UpdateInvoiceDto>();
        //
        CreateMap<InvoiceDetail, SelectInvoiceDetailDto>()
            .ForMember(x => x.StockCode, y => y.MapFrom(z => z.Stock.Code))
            .ForMember(x => x.StockName, y => y.MapFrom(z => z.Stock.Name))
            .ForMember(x => x.ServiceCode, y => y.MapFrom(z => z.Service.Code))
            .ForMember(x => x.ServiceName, y => y.MapFrom(z => z.Service.Name))
            .ForMember(x => x.ExpenceCode, y => y.MapFrom(z => z.Expense.Code))
            .ForMember(x => x.ExpenceName, y => y.MapFrom(z => z.Expense.Name))
            .ForMember(x => x.StoreCode, y => y.MapFrom(z => z.Store.Code))
            .ForMember(x => x.StoreName, y => y.MapFrom(z => z.Store.Name))
            .ForMember(x => x.UnitName, y => y.MapFrom(z =>
                            z.Stock != null ? z.Stock.Unit.Name :
                            z.Service != null ? z.Service.Unit.Name :
                            z.Expense != null ? z.Expense.Unit.Name :
                            null))
            .ForMember(x => x.ItemCode, y => y.MapFrom(z =>
                            z.Stock != null ? z.Stock.Code :
                            z.Service != null ? z.Service.Code :
                            z.Expense != null ? z.Expense.Code :
                            null))
            .ForMember(x => x.ItemName, y => y.MapFrom(z =>
                            z.Stock != null ? z.Stock.Name :
                            z.Service != null ? z.Service.Name :
                            z.Expense != null ? z.Expense.Name :
                            null));
        CreateMap<InvoiceDetailDto, InvoiceDetail>();
        CreateMap<SelectInvoiceDetailDto, InvoiceDetailDto>();
        CreateMap<SelectInvoiceDetailDto, SelectInvoiceDetailDto>();
        //
        CreateMap<Service, SelectServiceDto>()
            .ForMember(x => x.SpecialCodeOneName, y => y.MapFrom(z => z.SpecialCodeOne.Name))
            .ForMember(x => x.SpecialCodeTwoName, y => y.MapFrom(z => z.SpecialCodeTwo.Name))
            .ForMember(x => x.UnitName, y => y.MapFrom(z => z.Unit.Name));
        CreateMap<Service, ListServiceDto>()
            .ForMember(x => x.SpecialCodeOneName, y => y.MapFrom(z => z.SpecialCodeOne.Name))
            .ForMember(x => x.SpecialCodeTwoName, y => y.MapFrom(z => z.SpecialCodeTwo.Name))
            .ForMember(x => x.UnitName, y => y.MapFrom(z => z.Unit.Name))
            .ForMember(x => x.InService, y => y.MapFrom(x => x.InvoiceDetails
                                           .Where(f => f.Invoice.InvoiceType == InvoiceType.Buy)
                                           .Sum(i => i.Quantity)))
            .ForMember(x => x.OutService, y => y.MapFrom(x => x.InvoiceDetails
                                           .Where(f => f.Invoice.InvoiceType == InvoiceType.Sell)
                                           .Sum(i => i.Quantity)));
        CreateMap<CreateServiceDto, Service>();
        CreateMap<UpdateServiceDto, Service>();
        CreateMap<SelectServiceDto, CreateServiceDto>();
        CreateMap<SelectServiceDto, UpdateServiceDto>();
        //
        CreateMap<Safe, SelectSafeDto>()
            .ForMember(x => x.SpecialCodeOneName, y => y.MapFrom(z => z.SpecialCodeOne.Name))
            .ForMember(x => x.SpecialCodeTwoName, y => y.MapFrom(z => z.SpecialCodeTwo.Name));
        CreateMap<Safe, ListSafeDto>()
            .ForMember(x => x.SpecialCodeOneName, y => y.MapFrom(z => z.SpecialCodeOne.Name))
            .ForMember(x => x.SpecialCodeTwoName, y => y.MapFrom(z => z.SpecialCodeTwo.Name))
            .ForMember(x => x.Debt, y => y.MapFrom(x => x.ReceiptDetails
                                           .Where(f => f.DocumentStatu == DocumentStatu.Collected)
                                           .Sum(i => i.Price)))
            .ForMember(x => x.Receivable, y => y.MapFrom(x => x.ReceiptDetails
                                           .Where(f => f.DocumentStatu == DocumentStatu.Paid)
                                           .Sum(i => i.Price)));
        CreateMap<CreateSafeDto, Safe>();
        CreateMap<UpdateSafeDto, Safe>();
        CreateMap<SelectSafeDto, CreateSafeDto>();
        CreateMap<SelectSafeDto, UpdateSafeDto>();
        //
        CreateMap<Receipt, SelectReceiptDto>()
            .ForMember(x => x.CurrentCode, y => y.MapFrom(z => z.Current.Code))
            .ForMember(x => x.CurrentName, y => y.MapFrom(z => z.Current.Name))
            .ForMember(x => x.SafeName, y => y.MapFrom(z => z.Safe.Name))
            .ForMember(x => x.BankAccountName, y => y.MapFrom(z => z.BankAccount.Name))
            .ForMember(x => x.DepartmentName, y => y.MapFrom(z => z.Department.Name))
            .ForMember(x => x.SpecialCodeOneName, y => y.MapFrom(z => z.SpecialCodeOne.Name))
            .ForMember(x => x.SpecialCodeTwoName, y => y.MapFrom(z => z.SpecialCodeTwo.Name));
        CreateMap<Receipt, ListReceiptDto>()
            .ForMember(x => x.CurrentName, y => y.MapFrom(z => z.Current.Name))
            .ForMember(x => x.SafeName, y => y.MapFrom(z => z.Safe.Name))
            .ForMember(x => x.BankAccountName, y => y.MapFrom(z => z.BankAccount.Name))
            .ForMember(x => x.SpecialCodeOneName, y => y.MapFrom(z => z.SpecialCodeOne.Name))
            .ForMember(x => x.SpecialCodeTwoName, y => y.MapFrom(z => z.SpecialCodeTwo.Name));
        CreateMap<CreateReceiptDto, Receipt>();
        CreateMap<UpdateReceiptDto, Receipt>()
            .ForMember(x => x.ReceiptType, y => y.Ignore())
            .ForMember(x => x.ReceiptDetails, y => y.Ignore());
        CreateMap<SelectReceiptDto, CreateReceiptDto>();
        CreateMap<SelectReceiptDto, UpdateReceiptDto>();
        //
        CreateMap<ReceiptDetail, SelectReceiptDetailDto>()
            .ForMember(x => x.ChequeBankName, y => y.MapFrom(z => z.ChequeBank.Name))
            .ForMember(x => x.ChequeBankDepartmentName, y => y.MapFrom(z => z.ChequeBankDepartment.Name))
            .ForMember(x => x.SafeName, y => y.MapFrom(z => z.Safe.Name))
            .ForMember(x => x.BankAccountIdName, y => y.MapFrom(z => z.BankAccount.Name));
        CreateMap<ReceiptDetailDto, ReceiptDetail>();
        CreateMap<SelectReceiptDetailDto, ReceiptDetailDto>();
        CreateMap<SelectReceiptDetailDto, SelectReceiptDetailDto>();
        //
        CreateMap<Expense, SelectExpenseDto>()
            .ForMember(x => x.SpecialCodeOneName, y => y.MapFrom(z => z.SpecialCodeOne.Name))
            .ForMember(x => x.SpecialCodeTwoName, y => y.MapFrom(z => z.SpecialCodeTwo.Name))
            .ForMember(x => x.UnitName, y => y.MapFrom(z => z.Unit.Name));
        CreateMap<Expense, ListExpenseDto>()
            .ForMember(x => x.SpecialCodeOneName, y => y.MapFrom(z => z.SpecialCodeOne.Name))
            .ForMember(x => x.SpecialCodeTwoName, y => y.MapFrom(z => z.SpecialCodeTwo.Name))
            .ForMember(x => x.UnitName, y => y.MapFrom(z => z.Unit.Name))
            .ForMember(x => x.AmountInput, y => y.MapFrom(x => x.InvoiceDetails
                                           .Where(f => f.Invoice.InvoiceType == InvoiceType.Buy)
                                           .Sum(i => i.Quantity)))
            .ForMember(x => x.OutputAmount, y => y.MapFrom(x => x.InvoiceDetails
                                           .Where(f => f.Invoice.InvoiceType == InvoiceType.Sell)
                                           .Sum(i => i.Quantity)));
        CreateMap<CreateExpenseDto, Expense>();
        CreateMap<UpdateExpenseDto, Expense>();
        CreateMap<SelectExpenseDto, CreateExpenseDto>();
        CreateMap<SelectExpenseDto, UpdateExpenseDto>();
        //
        CreateMap<SpecialCode, SelectSpecialCodeDto>();
        CreateMap<SpecialCode, ListSpecialCodeDto>();
        CreateMap<CreateSpecialCodeDto, SpecialCode>();
        CreateMap<UpdateSpecialCodeDto, SpecialCode>();
        CreateMap<SelectSpecialCodeDto, CreateSpecialCodeDto>();
        CreateMap<SelectSpecialCodeDto, UpdateSpecialCodeDto>();
        //
        CreateMap<OrganizationParameter, SelectOrganizationParameterDto>()
    .ForMember(x => x.DepartmentName, y => y.MapFrom(z => z.Department.Name))
    .ForMember(x => x.TermName, y => y.MapFrom(z => z.Term.Name))
    .ForMember(x => x.StoryName, y => y.MapFrom(z => z.Store.Name));
        CreateMap<CreateOrganizationParameterDto, OrganizationParameter>();
        CreateMap<UpdateOrganizationParameterDto, OrganizationParameter>();
        //
        CreateMap<Stock, SelectStockDto>()
            .ForMember(x => x.SpecialCodeOneName, y => y.MapFrom(z => z.SpecialCodeOne.Name))
            .ForMember(x => x.SpecialCodeTwoName, y => y.MapFrom(z => z.SpecialCodeTwo.Name))
            .ForMember(x => x.UnitName, y => y.MapFrom(z => z.Unit.Name));
        CreateMap<Stock, ListStockDto>()
            .ForMember(x => x.SpecialCodeOneName, y => y.MapFrom(z => z.SpecialCodeOne.Name))
            .ForMember(x => x.SpecialCodeTwoName, y => y.MapFrom(z => z.SpecialCodeTwo.Name))
            .ForMember(x => x.UnitName, y => y.MapFrom(z => z.Unit.Name))
            .ForMember(x => x.InStock, y => y.MapFrom(x => x.InvoiceDetails
                                           .Where(f => f.Invoice.InvoiceType == InvoiceType.Buy)
                                           .Sum(i => i.Quantity)))
            .ForMember(x => x.OutStock, y => y.MapFrom(x => x.InvoiceDetails
                                           .Where(f => f.Invoice.InvoiceType == InvoiceType.Sell)
                                           .Sum(i => i.Quantity)));
        CreateMap<CreateStockDto, Stock>();
        CreateMap<UpdateStockDto, Stock>();
        CreateMap<SelectStockDto, CreateStockDto>();
        CreateMap<SelectStockDto, UpdateStockDto>();
        //
        CreateMap<Department, SelectDepartmentDto>();
        CreateMap<Department, ListDepartmentDto>();
        CreateMap<CreateDepartmentDto, Department>();
        CreateMap<UpdateDepartmentDto, Department>();
        CreateMap<SelectDepartmentDto, CreateDepartmentDto>();
        CreateMap<SelectDepartmentDto, UpdateDepartmentDto>();
    }
}
