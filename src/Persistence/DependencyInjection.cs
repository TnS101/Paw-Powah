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
            services.AddDbContextPool<PawContext>(options => options.UseSqlServer(connection.DefaultPath));
            services.AddDbContextPool<VolatileContext>(options => options.UseSqlServer(connection.VolatilePath));

            services.AddScoped(provider => provider.GetService<IPawContext>());
            services.AddScoped(provider => provider.GetService<IVolatileContext>());

            return services;
        }
    }
}
