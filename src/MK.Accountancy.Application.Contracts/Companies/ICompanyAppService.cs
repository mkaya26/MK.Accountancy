using MK.Accountancy.Abstract;

namespace MK.Accountancy.Companies
{
    public interface ICompanyAppService : ICrudAppService<SelectCompanyDto,SelectCompanyDto,ListCompanyDto,CreateCompanyDto,UpdateCompanyDto>
    {
    }
}
