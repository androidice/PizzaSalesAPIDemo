using PizzaSalesAPI.Infrastructure.Utitities;
using PizzaSalesAPI.Repository;
using PizzaSalesAPI.Repository.Interfaces;
using PizzaSalesAPI.Services;
using PizzaSalesAPI.Services.Interfaces;

namespace PizzaSalesAPIDemo.Extensions
{
    public static class AddServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services) { 
            services.AddTransient<IImportCsvService, ImportCsvService>();

            services.AddTransient<PizzaSalesAPI.Infrastructure.Utitities.ILogger, Logger>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IPizzaTypeRepository, PizzaTypeRepository>();
            services.AddTransient<IPizzaRepository, PizzaRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderDetailsRepository, OrderDetailsRepository>();

            return services;
        }
    }
}
