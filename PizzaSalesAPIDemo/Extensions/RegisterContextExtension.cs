using Microsoft.EntityFrameworkCore;
using PizzaSalesAPI.Domain;

namespace PizzaSalesAPIDemo.Extensions
{
    public static class RegisterContextExtension
    {
        public static IServiceCollection RegisterContext(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<PizzaSalesAPIContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

            return services;
        }
    }
}
