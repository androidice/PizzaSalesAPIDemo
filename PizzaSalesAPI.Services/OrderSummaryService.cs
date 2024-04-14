using PizzaSalesAPI.Services.Interfaces;
using PizzaSalesAPI.Contracts;
using PizzaSalesAPI.Contracts.Output;
using PizzaSalesAPI.Contracts.Input;
using PizzaSalesAPI.Repository.Interfaces;
using System.Data;
using Microsoft.Data.SqlClient;

namespace PizzaSalesAPI.Services
{
    public class OrderSummaryService: IOrderSummaryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderSummaryService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public OrderSummary GetMonthlyOrderSummary(MonthlyOrderSummaryRequest request) {

            OrderSummary orderSummary = new OrderSummary();
            DateTime startDate = new DateTime(request.Year, request.Month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);

            orderSummary.OrderDetails = _unitOfWork.OrderDetailsRepo.GetData(@"
                    select od.Id, o.OrderDate, od.PizzaId, p.Price, pt.[Name], od.Quantity from OrderDetails od
                    inner join Orders o 
                    on o.Id = od.OrderId
                    inner join Pizzas p
                    on od.PizzaId = p.Id
                    inner join PizzaTypes pt
                    on p.PizzaTypeId = pt.Id
                    where cast(o.OrderDate as date) between @startDate and @endDate
            ",
            new SqlParameter("startDate", SqlDbType.DateTime) { Value = startDate},
            new SqlParameter("endDate", SqlDbType.DateTime) { Value = endDate }
            ).AsEnumerable()
            .Select(row => 
                OrderDetails.Create(
                 row.Field<int>(nameof(OrderDetails.Id)),
                 row.Field<DateTime>(nameof(OrderDetails.OrderDate)),
                 row.Field<string>(nameof(OrderDetails.PizzaId)),
                 row.Field<decimal>(nameof(OrderDetails.Price)),
                 row.Field<string>(nameof(OrderDetails.Name)),
                 row.Field<int>(nameof(OrderDetails.Quantity))
               )
            ).ToArray();

            orderSummary.TotalPrice = orderSummary.OrderDetails.Sum(c => c.Price);
            orderSummary.TotalQuantity = orderSummary.OrderDetails.Sum(c => c.Quantity);

            return orderSummary;
        }
    }
}
