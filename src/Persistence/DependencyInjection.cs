namespace Persistence
{
    using Application.Common.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Persistence.Context;

    public class DependencyInjection
    {
        public static IServiceCollection AddPersistence(IServiceCollection services, IConnectionString connection)
        {
            services.AddDbContext<PawContext>(options => options.UseSqlServer(connection.PawPath));
            services.AddDbContext<VolatileContext>(options => options.UseSqlServer(connection.VolatilePath));
            
            services.AddScoped(provider => provider.GetService<IVolatileContext>());
            services.AddScoped(provider => provider.GetService<IPawContext>());

            return services;
        }
    }
}
