namespace PizzaSalesAPI.Domain.Models
{
    public class Orders: BaseEntity<int>
    {
        public DateTime OrderDate { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
