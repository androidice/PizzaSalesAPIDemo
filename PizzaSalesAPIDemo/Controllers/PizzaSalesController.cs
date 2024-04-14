using Microsoft.AspNetCore.Mvc;
using PizzaSalesAPI.Contracts.Input;
using PizzaSalesAPI.Contracts.Output;
using PizzaSalesAPI.Infrastructure;
using PizzaSalesAPI.Repository.Interfaces;
using PizzaSalesAPI.Services.Interfaces;
using ILogger = PizzaSalesAPI.Infrastructure.Utitities.ILogger;

namespace PizzaSalesAPIDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaSalesController : ControllerBase
    {
        private readonly IImportCsvService _importCSVService;
        private readonly IOrderSummaryService _orderSummaryService;
        private readonly IUnitOfWork _unitOfWork;
        private IConfiguration Configuration;
        private ILogger _logger;

        public PizzaSalesController(IConfiguration _configuration, 
                                    IImportCsvService importCSVService,
                                    IOrderSummaryService orderSummaryService,
                                    IUnitOfWork unitOfWork,
                                    ILogger logger)
        {
            _importCSVService = importCSVService;
            _orderSummaryService = orderSummaryService;
            _unitOfWork = unitOfWork;
            _logger = logger;

            Configuration = _configuration;
        }

        [HttpPost]
        [Route("Import")]
        public IActionResult Import() {
            string basePath = Configuration.GetValue<string>("FileLocations:CSV_ARCHIVE");
            try {
                _importCSVService.ImportData(Path.Combine(basePath, "pizza_types.csv"), new PizzaTypeCSVProcessor(_unitOfWork));
                _importCSVService.ImportData(Path.Combine(basePath, "pizzas.csv"), new PizzaCSVProcessor(_unitOfWork));
                _importCSVService.ImportData(Path.Combine(basePath, "orders.csv"), new OrdersCSVProcessor(_unitOfWork));
                _importCSVService.ImportData(Path.Combine(basePath, "order_details.csv"), new OrderDetailsCSVProcessor(_unitOfWork));
                this._unitOfWork.Save();
            }
            catch(Exception ex)
            {
                _logger.LogMessage(ex.Message);
                throw;
            }
            return Ok();
        }

        [HttpGet]
        [Route("GetMonthlyOrderSummary/{year}/{month}")]
        public IActionResult GetMonthlyOrderSummary(int year, int month) {
            OrderSummary orderSummary =  _orderSummaryService.GetMonthlyOrderSummary(new MonthlyOrderSummaryRequest() { Year = year, Month = month });
            return Ok(orderSummary);
        }
    }
}
