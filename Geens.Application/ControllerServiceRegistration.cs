using Geens.Features.Contrats.Services;
using Geens.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Geens.Application.Extensions
{
    public static class ControllerServiceRegistration
    {
        public static IServiceCollection ConfigureControllerServices(this IServiceCollection services)
        {
            services.AddScoped<IServiceDadresse, ServiceDadresse>();
            services.AddScoped<IServiceDenseignant, ServiceDenseignant>();

            return services;
        }
    }
}
