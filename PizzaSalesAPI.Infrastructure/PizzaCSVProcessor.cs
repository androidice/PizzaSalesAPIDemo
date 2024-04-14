using PizzaSalesAPI.Infrastructure.Interfaces;
using PizzaSalesAPI.Repository.Interfaces;
using PizzaSalesAPI.Domain.Models;

namespace PizzaSalesAPI.Infrastructure
{
    public class PizzaCSVProcessor: ICSVProcessor
    {
        private readonly IUnitOfWork _unitOfWork;
        public PizzaCSVProcessor(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool ImportData(string csvLine)
        {
            string lineItem = csvLine;
            int end_index = 0;

            end_index = lineItem.IndexOf(",");
            string id = lineItem.Substring(0, end_index);

            lineItem = lineItem.Substring(end_index + 1);

            end_index = lineItem.IndexOf(",");
            string pizzaTypeId = lineItem.Substring(0, end_index);
            lineItem = lineItem.Substring(end_index + 1);

            end_index = lineItem.IndexOf(",");
            string size = lineItem.Substring(0, end_index);
            lineItem = lineItem.Substring(end_index + 1);

            decimal price = 0;
            decimal.TryParse(lineItem, out price);

            var entity = _unitOfWork.PizzaRepo.GetById(id).Result;
            if (entity != null) return true;

            _unitOfWork.PizzaRepo.Add(new Pizzas()
            {
                Id = id,
                PizzaTypeId = pizzaTypeId,
                Size = size,
                Price = price
            });

            return true;
        }
    }
}
