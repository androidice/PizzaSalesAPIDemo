using PizzaSalesAPI.Domain;
using PizzaSalesAPI.Domain.Models;
using PizzaSalesAPI.Repository.Interfaces;

namespace PizzaSalesAPI.Repository
{
    public class OrderDetailsRepository: GenericRepository<OrderDetails>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(PizzaSalesAPIContext dbContext) : base(dbContext)
        {
        }
    }
}
