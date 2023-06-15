using MK.Accountancy.Receipts;

namespace MK.Accountancy.Reports
{
    public class PaymentDocumentsDistribution : IEntity
    {
        public PaymentType PaymentType { get; set; }
        public decimal Amount { get; set; }
        public object[] GetKeys()
        {
            throw new NotImplementedException();
        }
    }
}
