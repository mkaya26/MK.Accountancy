using MK.Accountancy.BankAccounts;
using MK.Accountancy.Banks;

namespace MK.Accountancy.SpecialCodes
{
    public class SpecialCode : FullAuditedAggregateRoot<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public SpecialCodeType SpecialCodeType { get; set; }
        public CardType CardType { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public ICollection<BankAccount> SpecialCodeOneBankAccounts { get; set; }
        public ICollection<BankAccount> SpecialCodeTwoBankAccounts { get; set; }
        public ICollection<Bank> SpecialCodeOneBanks { get; set; }
        public ICollection<Bank> SpecialCodeTwoBanks { get; set; }
    }
}
