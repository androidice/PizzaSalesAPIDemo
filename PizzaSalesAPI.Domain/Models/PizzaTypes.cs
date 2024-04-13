namespace PizzaSalesAPI.Domain.Models
{
    public class PizzaTypes: BaseEntity<string>
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Ingredients { get; set; }

        public ICollection<Pizzas> Pizzas { get; set; }
    }
}
