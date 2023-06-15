namespace MK.Accountancy.Reports
{
    public class IncomeExpenseBalance : IEntity
    {
        public decimal Income { get; set; } 
        public decimal Expense { get; set; } 
        public decimal Balance { get; set; }

        public object[] GetKeys()
        {
            throw new NotImplementedException();
        }
    }
}
