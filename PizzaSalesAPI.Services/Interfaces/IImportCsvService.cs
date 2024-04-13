using PizzaSalesAPI.Infrastructure.Interfaces;

namespace PizzaSalesAPI.Services.Interfaces
{
    public interface IImportCsvService
    {
        void ImportData(string location, ICSVProcessor csvProcessor);
    }
}
