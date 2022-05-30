using MK.Accountancy.CommonDtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace MK.Accountancy.Stocks
{
    public class StockAppService : AccountancyAppService, IStockAppService
    {
        private readonly IStockRepository _stockRepository;
        private readonly StockManager _stockManager;

        public StockAppService(IStockRepository stockRepository, StockManager stockManager)
        {
            _stockRepository = stockRepository;
            _stockManager = stockManager;
        }

        public virtual async Task<SelectStockDto> CreateAsync(CreateStockDto input)
        {
            await _stockManager.CheckCreateAsync(input.Code, input.SpecialCodeOneId, input.SpecialCodeTwoId, input.UnitId);
            //
            var entity = ObjectMapper.Map<CreateStockDto, Stock>(input);
            await _stockRepository.InsertAsync(entity);
            return ObjectMapper.Map<Stock, SelectStockDto>(entity);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await _stockManager.CheckDeleteAsync(id);
            await _stockRepository.DeleteAsync(id);
        }

        public virtual async Task<SelectStockDto> GetAsync(Guid id)
        {
            var entity = await _stockRepository.GetAsync(id, x => x.Id == id, i => i.Unit, i => i.SpecialCodeOne, i => i.SpecialCodeTwo);
            return ObjectMapper.Map<Stock,SelectStockDto>(entity);
        }

        public virtual Task<string> GetCodeAsync(CodeParameterDto input)
        {
            return _stockRepository.GetCodeAsync(x => x.Code, f => f.Active == input.Active);
        }

        public virtual async Task<PagedResultDto<ListStockDto>> GetListAsync(StockListParameterDto input)
        {
            var entities = await _stockRepository.GetPagedListAsync(input.SkipCount, input.MaxResultCount,
                f => f.Active == input.Active,
                s => s.Code);
            var totalCount = await _stockRepository.CountAsync(f => f.Active == input.Active);
            //
            return new PagedResultDto<ListStockDto>(totalCount, ObjectMapper.Map<List<Stock>, List<ListStockDto>>(entities));
        }

        public virtual async Task<SelectStockDto> UpdateAsync(Guid id, UpdateStockDto input)
        {
            var entity = await _stockRepository.GetAsync(id, x => x.Id == id);
            //
            await _stockManager.CheckUpdateAsync(id, input.Code, entity, input.SpecialCodeOneId, input.SpecialCodeTwoId, input.UnitId);
            //
            var mappedEntity = ObjectMapper.Map(input,entity);
            //
            await _stockRepository.UpdateAsync(mappedEntity);
            //
            return ObjectMapper.Map<Stock, SelectStockDto>(mappedEntity);

        }
    }
}
