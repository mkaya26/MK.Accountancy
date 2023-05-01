using MK.Accountancy.CommonDtos;
using System;
using Volo.Abp.Application.Dtos;

namespace MK.Accountancy.PaymentDocuments
{
    public class PaymentDocumentListParameterDto : PagedResultRequestDto, IActive, IEntityDto
    {
        public string Sql { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid TermId { get; set; }
        public bool MyDocument { get; set; }
        public string PaymentTypes { get; set; }
        public bool Active { get; set; }
    }
}
