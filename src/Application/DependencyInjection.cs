namespace Application
{
    using AutoMapper;
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;

    public class DependencyInjection
    {
        public static IServiceCollection AddApplication(IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
