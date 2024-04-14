namespace PizzaSalesAPI.Contracts.Input
{
    public class MonthlyOrderSummaryRequest
    {
        public int Month { get; set; }// month: Jan = 1 - Dec = 12
        public int Year { get; set; }
    }
}
