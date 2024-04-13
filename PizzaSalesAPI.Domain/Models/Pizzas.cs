namespace PizzaSalesAPI.Domain.Models
{
    public class Pizzas: BaseEntity<string>
    {
        public string PizzaTypeId { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
       
        public PizzaTypes PizzaTypes { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
