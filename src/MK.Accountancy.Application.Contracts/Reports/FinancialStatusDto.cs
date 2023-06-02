using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Reports
{
    public class FinancialStatusDto : IEntityDto
    {
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
