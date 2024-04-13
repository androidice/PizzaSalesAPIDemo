namespace PizzaSalesAPI.Repository.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IPizzaRepository PizzaRepo { get; }
        IPizzaTypeRepository PizzaTypeRepo { get; }
        IOrderRepository OrderRepo { get; }
        IOrderDetailsRepository OrderDetailsRepo { get; }
        int Save();
    }
}
