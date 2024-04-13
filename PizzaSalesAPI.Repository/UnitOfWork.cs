using PizzaSalesAPI.Domain;
using PizzaSalesAPI.Repository.Interfaces;

namespace PizzaSalesAPI.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        public readonly PizzaSalesAPIContext _dbContext;
        public IPizzaRepository PizzaRepo { get; }
        public IPizzaTypeRepository PizzaTypeRepo { get; }
        public IOrderRepository OrderRepo { get; }
        public IOrderDetailsRepository OrderDetailsRepo { get; }

        public UnitOfWork(PizzaSalesAPIContext dbContext, 
                          IPizzaTypeRepository pizzaTypeRepo,
                          IPizzaRepository pizzaRepo,
                          IOrderRepository orderRepo,
                          IOrderDetailsRepository orderDetailsRepo)
        {
            _dbContext = dbContext;
            PizzaTypeRepo = pizzaTypeRepo;
            PizzaRepo = pizzaRepo;  
            OrderRepo = orderRepo;
            OrderDetailsRepo = orderDetailsRepo;
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
