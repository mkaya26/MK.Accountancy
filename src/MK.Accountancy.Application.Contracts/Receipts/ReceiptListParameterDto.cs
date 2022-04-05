using MK.Accountancy.CommonDtos;
using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.Receipts
{
    public class ReceiptListParameterDto : PagedResultRequestDto,IEntityDto,IActive
    {
        public ReceiptType ReceiptType { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid TermId { get; set; }
        public bool Active { get; set; }
    }
}
