using PissaSalesAPI.Domain.Models;
using PizzaSalesAPI.Domain;
using PizzaSalesAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSalesAPI.Repository
{
    public class PizzaTypeRepository: GenericRepository<PizzaTypes>, IPizzaTypeRepository
    {
        public PizzaTypeRepository(PizzaSalesAPIContext dbContext):base(dbContext) { 
        }

    }
}
