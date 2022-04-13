using MK.Accountancy.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace MK.Accountancy.Stores
{
    public class StoreAppService : AccountancyAppService, IStoreAppService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly StoreManager _storeManager;

        public StoreAppService(IStoreRepository storeRepository, StoreManager storeManager)
        {
            _storeRepository = storeRepository;
            _storeManager = storeManager;
        }

        public virtual async Task<SelectStoreDto> CreateAsync(CreateStoreDto input)
        {
            await _storeManager.CheckCreateAsync(input.Code, input.SpecialCodeOneId, input.SpecialCodeTwoId, input.DepartmentId);
            //
            var entity = ObjectMapper.Map<CreateStoreDto, Store>(input);
            await _storeRepository.InsertAsync(entity);
            return ObjectMapper.Map<Store,SelectStoreDto>(entity);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await _storeManager.CheckDeleteAsync(id);
            //
            await _storeRepository.DeleteAsync(id);
        }

        public virtual async Task<SelectStoreDto> GetAsync(Guid id)
        {
            var entity = await _storeRepository.GetAsync(id, f => f.Id == id, i => i.SpecialCodeOne, i => i.SpecialCodeTwo);
            return ObjectMapper.Map<Store, SelectStoreDto>(entity);
        }

        public virtual async Task<string> GetCodeAsync(StoreCodeParameterDto input)
        {
            return await _storeRepository.GetCodeAsync(p => p.Code, f => f.Active == input.Active && f.DepartmentId == input.DepartmentId);
        }

        public virtual async Task<PagedResultDto<ListStoreDto>> GetListAsync(StoreListParameterDto input)
        {
            var entities = await _storeRepository.GetPagedListAsync(
                input.SkipCount,
                input.MaxResultCount,
                f => f.Active == input.Active &&
                     f.DepartmentId == input.DepartmentId,
                s => s.Code);
            //
            var totalCount = await _storeRepository.CountAsync(f => f.Active == input.Active &&
     f.DepartmentId == input.DepartmentId);
            //
            var mappedEntityDtos = ObjectMapper.Map<List<Store>,List<ListStoreDto>>(entities);
            //
            mappedEntityDtos.ForEach(x =>
            {
                x.AmountInput = x.InvoiceDetails.Where(f => f.InvoiceDto.InvoiceType == InvoiceType.Buy).Sum(f => f.Quantity);
                x.OutputAmount = x.InvoiceDetails.Where(f => f.InvoiceDto.InvoiceType == InvoiceType.Sell).Sum(f => f.Quantity);
            });
            //
            return new PagedResultDto<ListStoreDto>(totalCount, mappedEntityDtos);
        }

        public async Task<SelectStoreDto> UpdateAsync(Guid id, UpdateStoreDto input)
        {
            var entity = await _storeRepository.GetAsync(id, f => f.Id == id);
            await _storeManager.CheckUpdateAsync(id, input.Code, entity, input.SpecialCodeOneId, input.SpecialCodeTwoId);
            //
            var mappedEntity = ObjectMapper.Map(input, entity);
            await _storeRepository.UpdateAsync(mappedEntity);
            //
            return ObjectMapper.Map<Store, SelectStoreDto>(mappedEntity);
        }
    }
}
