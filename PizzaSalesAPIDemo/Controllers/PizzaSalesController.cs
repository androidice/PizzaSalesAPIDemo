using Microsoft.AspNetCore.Mvc;
using PizzaSalesAPI.Infrastructure;
using PizzaSalesAPI.Repository;
using PizzaSalesAPI.Repository.Interfaces;
using PizzaSalesAPI.Services.Interfaces;


namespace PizzaSalesAPIDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaSalesController : ControllerBase
    {
        private readonly IImportCsvService _importCSVService;
        private readonly IUnitOfWork _unitOfWork;
        private IConfiguration Configuration;

        public PizzaSalesController(IConfiguration _configuration, 
                                    IImportCsvService importCSVService,
                                    IUnitOfWork unitOfWork)
        {
            _importCSVService= importCSVService;
            _unitOfWork = unitOfWork;
            Configuration = _configuration;
        }

        [HttpPost]
        [Route("Import")]
        public IActionResult Import() {
            string basePath = Configuration.GetValue<string>("FileLocations:CSV_ARCHIVE");
             //_importCSVService.ImportData(Path.Combine(basePath, "pizza_types.csv"), new PizzaTypeCSVProcessor(_unitOfWork));
             _importCSVService.ImportData(Path.Combine(basePath, "pizzas.csv"), new PizzaCSVProcessor(_unitOfWork));

            return Ok();
        }
    }
}
