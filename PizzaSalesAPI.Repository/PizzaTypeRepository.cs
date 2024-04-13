using PizzaSalesAPI.Domain;
using PizzaSalesAPI.Domain.Models;
using PizzaSalesAPI.Repository.Interfaces;

namespace PizzaSalesAPI.Repository
{
    public class PizzaTypeRepository: GenericRepository<PizzaTypes>, IPizzaTypeRepository
    {
        public PizzaTypeRepository(PizzaSalesAPIContext dbContext):base(dbContext) { 
        }

    }
}
