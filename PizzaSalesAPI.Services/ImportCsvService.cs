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
            try
            {
              File.ReadAllLines(location)
                        .Skip(1)
                        .Select(lineItem =>  csvProcessor.ImportData(lineItem))
                        .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogMessage(ex.Message);
                throw ex;
            }
        }
    }
}
