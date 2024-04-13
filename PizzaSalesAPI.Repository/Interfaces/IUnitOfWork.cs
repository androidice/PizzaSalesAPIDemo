using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSalesAPI.Repository.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IPizzaRepository PizzaRepo { get; }
        IPizzaTypeRepository PizzaTypeRepo { get; }
        int Save();
    }
}
