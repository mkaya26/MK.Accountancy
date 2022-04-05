using MK.Accountancy.CommonDtos;
using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Receipts
{
    public class ReceiptDetailListParameterDto : PagedResultRequestDto,IEntityDto,IActive
    {
        public Guid EntityId { get; set; }
        public PaymentType PaymentType { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid TermId { get; set; }
        public bool Active { get; set; }
    }
}
