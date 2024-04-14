using Microsoft.Extensions.Primitives;
using PizzaSalesAPI.Domain.Models;
using PizzaSalesAPI.Infrastructure.Interfaces;
using PizzaSalesAPI.Repository.Interfaces;

namespace PizzaSalesAPI.Infrastructure
{
    public class PizzaTypeCSVProcessor: ICSVProcessor 
    {
        private readonly IUnitOfWork _unitOfWork;
        public PizzaTypeCSVProcessor(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public bool ImportData(string csvLine) {

            string lineItem = csvLine;
            int end_index = 0;

            //read first line item and identify the id field
            end_index = lineItem.IndexOf(",");
            string id = lineItem.Substring(0, end_index);

            //update the line item so that it can be processed next
            lineItem = lineItem.Substring(end_index + 1);

            //identify the name field
            end_index = lineItem.IndexOf(",");
            string name = lineItem.Substring(0, end_index);

            //update the line item so that it can be processed next
            lineItem = lineItem.Substring(end_index + 1);
            end_index = lineItem.IndexOf(",");

            string category = lineItem.Substring(0, end_index);
            string ingredients = lineItem.Substring(end_index + 1);

            var entity = _unitOfWork.PizzaTypeRepo.GetById(id).Result;
            if (entity != null) return true;

            _unitOfWork.PizzaTypeRepo.Add(new PizzaTypes()
            {
                Id = id,
                Name = name,
                Category = category,
                Ingredients = ingredients
            });

            return true;
        }
    }
}
