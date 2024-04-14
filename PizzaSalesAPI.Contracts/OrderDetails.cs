namespace PizzaSalesAPI.Contracts
{
    public class OrderDetails
    {
        public int Id { get; }
        public DateTime OrderDate { get; }
        public string PizzaId { get; }
        public decimal Price { get; }
        public string Name { get; }
        public int Quantity { get; }

        private OrderDetails(int id, DateTime orderDate, string pizzaId, decimal price, string name, int quantity) 
        {
            Id = id;
            OrderDate = orderDate;
            PizzaId = pizzaId;
            Price = price;
            Name = name;
            Quantity = quantity;
        }

        public static OrderDetails Create(int id, DateTime orderDate, string pizzaId, decimal price, string name, int quantity)
            => new OrderDetails(id, orderDate, pizzaId, price, name, quantity);
    }
}
