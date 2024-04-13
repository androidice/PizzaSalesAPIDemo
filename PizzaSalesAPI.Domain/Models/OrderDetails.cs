namespace PizzaSalesAPI.Domain.Models
{
    public class OrderDetails: BaseEntity<int>
    {
        public int OrderId { get; set; }
        public string PizzaId { get; set; }
        public int Quantity { get; set; }

        public Orders Orders { get; set; }
        public Pizzas Pizzas { get; set; }
    }
}
