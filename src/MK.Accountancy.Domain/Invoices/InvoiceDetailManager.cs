using MK.Accountancy.Expenses;
using MK.Accountancy.Extensions;
using MK.Accountancy.Services;
using MK.Accountancy.Stocks;
using MK.Accountancy.Stores;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace MK.Accountancy.Invoices
{
    public class InvoiceDetailManager : DomainService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IExpenseRepository _expenseRepository;
        private readonly IStoreRepository _storeRepository;

        public InvoiceDetailManager(IStockRepository stockRepository, IServiceRepository serviceRepository, IExpenseRepository expenseRepository, IStoreRepository storeRepository)
        {
            _stockRepository = stockRepository;
            _serviceRepository = serviceRepository;
            _expenseRepository = expenseRepository;
            _storeRepository = storeRepository;
        }

        public async Task CheckCreateAsync(Guid? stockId,Guid? serviceId,Guid? expenseId,Guid? storeId)
        {
            await _stockRepository.EntityAnyAsync(stockId, f => f.Id == stockId);
            await _serviceRepository.EntityAnyAsync(serviceId, f => f.Id == serviceId);
            await _expenseRepository.EntityAnyAsync(expenseId, f => f.Id == expenseId);
            await _storeRepository.EntityAnyAsync(storeId, f => f.Id == storeId);
        }

        public async Task CheckUpdateAsync(Guid? stockId, Guid? serviceId, Guid? expenseId, Guid? storeId)
        {
            await _stockRepository.EntityAnyAsync(stockId, f => f.Id == stockId);
            await _serviceRepository.EntityAnyAsync(serviceId, f => f.Id == serviceId);
            await _expenseRepository.EntityAnyAsync(expenseId, f => f.Id == expenseId);
            await _storeRepository.EntityAnyAsync(storeId, f => f.Id == storeId);
        }
    }
}
