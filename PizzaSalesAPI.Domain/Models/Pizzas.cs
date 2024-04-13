using Microsoft.EntityFrameworkCore;

namespace PissaSalesAPI.Domain.Models
{
    public class Pizzas: BaseEntity<string>
    {
        public string PizzaTypeId { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
       
        public PizzaTypes PizzaTypes { get; set; }
    }
}
