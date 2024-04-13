using PizzaSalesAPI.Domain;
using PizzaSalesAPI.Domain.Models;
using PizzaSalesAPI.Repository.Interfaces;

namespace PizzaSalesAPI.Repository
{
    public class OrderRepository: GenericRepository<Orders>, IOrderRepository
    {
        public OrderRepository(PizzaSalesAPIContext dbContext) : base(dbContext)
        {
        }
    }
}
