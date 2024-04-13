using PizzaSalesAPI.Infrastructure.Interfaces;
using PizzaSalesAPI.Repository.Interfaces;
using PizzaSalesAPI.Domain.Models;

namespace PizzaSalesAPI.Infrastructure
{
    public class OrdersCSVProcessor: ICSVProcessor
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrdersCSVProcessor(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool ImportData(string csvLine) 
        {
            string lineItem = csvLine;
            const string DATE_TIME_FORMAT = "yyyy-MM-dd,HH:mm:ss";
            int end_index = 0;

            int orderId = 0;
            end_index = lineItem.IndexOf(",");
            int.TryParse(lineItem.Substring(0, end_index), out orderId);

            lineItem = lineItem.Substring(end_index + 1);
            DateTime orderDate = DateTime.ParseExact(lineItem, DATE_TIME_FORMAT, System.Globalization.CultureInfo.InvariantCulture);

            this._unitOfWork.OrderRepo.Add(new Orders()
            {
                Id = orderId,
                OrderDate = orderDate
            });

            return true;
        }
    }
}
