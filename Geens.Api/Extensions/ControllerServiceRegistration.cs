using Geens.Api.Services.Contrats;
using Geens.Api.Services;

namespace Geens.Api.Extensions
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
