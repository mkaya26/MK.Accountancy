using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Companies
{
    [Authorize]
    public class CompanyAppService : AccountancyAppService, ICompanyAppService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyAppService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public virtual async Task<SelectCompanyDto> CreateAsync(CreateCompanyDto input)
        {
            var entity = ObjectMapper.Map<CreateCompanyDto, Company>(input);
            await _companyRepository.InsertAsync(entity);
            //
            return ObjectMapper.Map<Company, SelectCompanyDto>(entity);
        }

        public virtual async Task<SelectCompanyDto> GetAsync(Guid id)
        {
            var entity = await _companyRepository.GetAsync(id, x => x.Id == id);
            //
            if (entity == null) return null;
            //
            return ObjectMapper.Map<Company, SelectCompanyDto>(entity);
        }
        public virtual async Task<SelectCompanyDto> GetAsync()
        {
            var entity = await _companyRepository.GetAsync();
            //
            if (entity == null) return null;
            //
            return ObjectMapper.Map<Company, SelectCompanyDto>(entity);
        }
        [NonAction]
        public Task<PagedResultDto<SelectCompanyDto>> GetListAsync(ListCompanyDto input)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<SelectCompanyDto> UpdateAsync(Guid id, UpdateCompanyDto input)
        {
            var entity = await _companyRepository.GetAsync(id, x => x.Id == id);
            //
            var mappedEntity = ObjectMapper.Map(input, entity);
            await _companyRepository.UpdateAsync(mappedEntity);
            return ObjectMapper.Map<Company, SelectCompanyDto>(mappedEntity);
        }
    }
}
