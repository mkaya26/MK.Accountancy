using AutoMapper;
using MK.Accountancy.Banks;

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
    }
}
