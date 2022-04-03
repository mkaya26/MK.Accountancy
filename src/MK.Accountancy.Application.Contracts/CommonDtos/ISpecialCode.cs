using System;

namespace MK.Accountancy.CommonDtos
{
    public interface ISpecialCode
    {
        public Guid? SpecialCodeOneId { get; set; }
        public string SpecialCodeOneName { get; set; }
        public Guid? SpecialCodeTwoId { get; set; }
        public string SpecialCodeTwoName { get; set; }
    }
}
