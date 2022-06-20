using MK.Accountancy.CommonDtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace MK.Accountancy.Departments
{
    public class DepartmentAppService : AccountancyAppService, IDepartmentAppService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly DepartmentManager _departmentManager;

        public DepartmentAppService(IDepartmentRepository departmentRepository, DepartmentManager departmentManager)
        {
            _departmentRepository = departmentRepository;
            _departmentManager = departmentManager;
        }

        public virtual async Task<SelectDepartmentDto> CreateAsync(CreateDepartmentDto input)
        {
            await _departmentManager.CheckCreateAsync(input.Code);
            //
            var entity = ObjectMapper.Map<CreateDepartmentDto, Department>(input);
            await _departmentRepository.InsertAsync(entity);
            return ObjectMapper.Map<Department, SelectDepartmentDto>(entity);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await _departmentManager.CheckDeleteAsync(id);
            //
            await _departmentRepository.DeleteAsync(id);
        }

        public virtual async Task<SelectDepartmentDto> GetAsync(Guid id)
        {
            var entity = await _departmentRepository.GetAsync(id, f => f.Id == id);
            return ObjectMapper.Map<Department, SelectDepartmentDto>(entity);
        }

        public virtual async Task<string> GetCodeAsync(CodeParameterDto input)
        {
            return await _departmentRepository.GetCodeAsync(x => x.Code, f => f.Active == input.Active);
        }

        public virtual async Task<PagedResultDto<ListDepartmentDto>> GetListAsync(DepartmentListParameterDto input)
        {
            var entities = await _departmentRepository.GetPagedListAsync(
                                                        input.SkipCount,
                                                        input.MaxResultCount,
                                                        f => f.Active == input.Active,
                                                        o => o.Code
                                                        );
            var totalCount = await _departmentRepository.CountAsync(f => f.Active == input.Active);
            return new PagedResultDto<ListDepartmentDto>(
                totalCount,
                ObjectMapper.Map<List<Department>, List<ListDepartmentDto>>(entities));
        }

        public virtual async Task<SelectDepartmentDto> UpdateAsync(Guid id, UpdateDepartmentDto input)
        {
            var entity = await _departmentRepository.GetAsync(id, f => f.Id == id);
            //
            await _departmentManager.CheckUpdateAsync(id, input.Code, entity);
            //
            var mappedEntity = ObjectMapper.Map(input, entity);
            await _departmentRepository.UpdateAsync(mappedEntity);
            return ObjectMapper.Map<Department, SelectDepartmentDto>(mappedEntity);
        }
    }
}
