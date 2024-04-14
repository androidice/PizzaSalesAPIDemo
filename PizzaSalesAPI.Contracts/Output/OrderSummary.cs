namespace PizzaSalesAPI.Contracts.Output
{
    public class OrderSummary
    {
        public OrderDetails[] OrderDetails { get; set; }
        public decimal TotalPrice { get; set; }
        public int TotalQuantity { get; set; }
    }
}
