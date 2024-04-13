using PizzaSalesAPI.Infrastructure.Interfaces;
using PizzaSalesAPI.Infrastructure.Utitities;
using PizzaSalesAPI.Services.Interfaces;

namespace PizzaSalesAPI.Services
{
    public class ImportCsvService: IImportCsvService
    {
        private ILogger _logger;
        public ImportCsvService(ILogger logger) {
            _logger = logger;
        }
        public void ImportData(string location, ICSVProcessor csvProcessor)
        {
            File.ReadAllLines(location)
                         .Skip(1)
                         .Select(lineItem => csvProcessor.ImportData(lineItem))
                         .ToList();
        }
    }
}
