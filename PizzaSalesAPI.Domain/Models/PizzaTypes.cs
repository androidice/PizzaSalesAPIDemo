using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PissaSalesAPI.Domain.Models
{
    public class PizzaTypes: BaseEntity<string>
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Ingredients { get; set; }

        public ICollection<Pizzas> Pizzas { get; set; }
    }
}
