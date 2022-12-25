
using Geens.Features.Proxies.GdcProxys;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Geens.Features
{
    public static class ConfigureServiceProxyExtension
    {
        public static IServiceCollection AjoutterCoucheDesProxies(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureGdcProxyExtensions(configuration);

            return services;
        }
    }
}
