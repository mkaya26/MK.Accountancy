using AutoMapper;
using MK.Accountancy.BankAccounts;
using MK.Accountancy.BankDepartments;
using MK.Accountancy.Banks;
using MK.Accountancy.Currents;
using MK.Accountancy.Invoices;
using MK.Accountancy.Stores;
using MK.Accountancy.Terms;
using MK.Accountancy.Units;

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
            .ForMember(x => x.SpecialCodeTwoName, y => y.MapFrom(z => z.SpecialCodeTwo.Name));
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
        CreateMap<InvoiceDetail, SelectInvoiceDetailDto>();
        CreateMap<InvoiceDetail, ListInvoiceDetailDto>();
        CreateMap<CreateInvoiceDetailDto, Term>();
        CreateMap<UpdateTermDto, Term>();
    }
}
