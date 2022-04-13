using AutoMapper;
using MK.Accountancy.BankAccounts;
using MK.Accountancy.BankDepartments;
using MK.Accountancy.Banks;
using MK.Accountancy.Currents;
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
    }
}
