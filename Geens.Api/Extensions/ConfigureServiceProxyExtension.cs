
using Geens.Api.Proxies.GdcProxys;

namespace Geens.Api.Extensions
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
