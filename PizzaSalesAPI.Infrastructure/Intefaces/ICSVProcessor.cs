namespace PizzaSalesAPI.Infrastructure.Interfaces
{
    public interface ICSVProcessor
    {
        bool ImportData(string csvLine);
    }
}
