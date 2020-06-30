namespace Application.Common.Register_Services
{
    using Application.Services.Common.Identity;
    using Application.Services.Interfaces.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class ServiceRegister
    {
        public ServiceRegister(IServiceCollection services)
        {
            services.AddScoped<IUserQueries, UserQueries>();
        }
    }
}
