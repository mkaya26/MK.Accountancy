namespace MK.Accountancy.Receipts
{
    public enum DocumentStatu : byte
    {
        InPortfolio = 1,
        Payable = 2,
        Endorsed = 3,
        Collected = 4,
        Paid = 5
    }
}
