using PizzaSalesAPI.Infrastructure.Interfaces;
using PizzaSalesAPI.Repository.Interfaces;
using PizzaSalesAPI.Domain.Models;

namespace PizzaSalesAPI.Infrastructure
{
    public class OrderDetailsCSVProcessor: ICSVProcessor
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderDetailsCSVProcessor(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool ImportData(string csvLine) 
        {
            string lineItem = csvLine;
            int end_index = 0;

            int id = 0;
            int orderId = 0;
            int quantity = 0;

            end_index = lineItem.IndexOf(",");
            int.TryParse(lineItem.Substring(0, end_index), out id);

            lineItem = lineItem.Substring(end_index + 1);

            end_index = lineItem.IndexOf(",");
            int.TryParse(lineItem.Substring(0, end_index), out orderId);

            lineItem = lineItem.Substring(end_index + 1);

            end_index = lineItem.IndexOf(",");
            string pizzaId = lineItem.Substring(0, end_index);

            lineItem = lineItem.Substring(end_index + 1);
            int.TryParse(lineItem, out quantity);

            this._unitOfWork.OrderDetailsRepo.Add(new OrderDetails() {
                Id = id,
                OrderId = orderId,
                PizzaId = pizzaId,
                Quantity = quantity
            });
 
            return true;
        }
    }
}
