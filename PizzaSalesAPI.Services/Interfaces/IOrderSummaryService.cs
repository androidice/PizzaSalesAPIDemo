using PizzaSalesAPI.Contracts.Input;
using PizzaSalesAPI.Contracts.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaSalesAPI.Services.Interfaces
{
    public interface IOrderSummaryService
    {
        OrderSummary GetMonthlyOrderSummary(MonthlyOrderSummaryRequest request);
    }
}
