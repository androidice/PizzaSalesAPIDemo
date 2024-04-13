using Microsoft.AspNetCore.Mvc;
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
        private readonly IUnitOfWork _unitOfWork;
        private IConfiguration Configuration;
        private ILogger _logger;

        public PizzaSalesController(IConfiguration _configuration, 
                                    IImportCsvService importCSVService,
                                    IUnitOfWork unitOfWork,
                                    ILogger logger)
        {
            _importCSVService = importCSVService;
            _unitOfWork = unitOfWork;
            Configuration = _configuration;
            _logger = logger;   
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
    }
}
