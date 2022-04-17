using AutoMapper;
using MK.Accountancy.BankAccounts;
using MK.Accountancy.BankDepartments;
using MK.Accountancy.Banks;
using MK.Accountancy.Currents;
using MK.Accountancy.Invoices;
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
        //
        CreateMap<Unit, SelectUnitDto>()
            .ForMember(x => x.SpecialCodeOneName, y => y.MapFrom(z => z.SpecialCodeOne.Name))
            .ForMember(x => x.SpecialCodeTwoName, y => y.MapFrom(z => z.SpecialCodeTwo.Name));
        CreateMap<Unit, ListUnitDto>()
            .ForMember(x => x.SpecialCodeOneName, y => y.MapFrom(z => z.SpecialCodeOne.Name))
            .ForMember(x => x.SpecialCodeTwoName, y => y.MapFrom(z => z.SpecialCodeTwo.Name));
        CreateMap<CreateUnitDto, Unit>();
        CreateMap<UpdateUnitDto, Unit>();
        //
        CreateMap<Current, SelectCurrentDto>()
            .ForMember(x => x.SpecialCodeOneName, y => y.MapFrom(z => z.SpecialCodeOne.Name))
            .ForMember(x => x.SpecialCodeTwoName, y => y.MapFrom(z => z.SpecialCodeTwo.Name));
        CreateMap<Current, ListCurrentDto>()
            .ForMember(x => x.SpecialCodeOneName, y => y.MapFrom(z => z.SpecialCodeOne.Name))
            .ForMember(x => x.SpecialCodeTwoName, y => y.MapFrom(z => z.SpecialCodeTwo.Name));
        CreateMap<CreateCurrentDto, Current>();
        CreateMap<UpdateCurrentDto, Current>();
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
        //
        CreateMap<Term, SelectTermDto>();
        CreateMap<Term, ListTermDto>();
        CreateMap<CreateTermDto, Term>();
        CreateMap<UpdateTermDto, Term>();
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
    }
}
