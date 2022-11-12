using Geens.Api.Proxies.GdcProxys;
using Polly.Timeout;
using Polly;
using Geens.Api.Proxies.GdcProxys.Contrats;

namespace Geens.Api.Proxies.GdcProxys
{
    public static class GdcProxyExtensionsPartial
    {
        public static IServiceCollection ConfigureGdcProxyExtensions(this IServiceCollection service, IConfiguration configuration)
        {
            Random jitterer = new();

            service.Configure<GdcProxyOptions>(configuration.GetSection(GdcProxyOptions.Path));
            var gdcOptions = configuration.GetSection(GdcProxyOptions.Path).Get<GdcProxyOptions>();

            Console.WriteLine($"{gdcOptions.BaseAdress}/api/");

            service.AddHttpClient<IGdcProxy, GdcProxy>(options =>
            {
                options.BaseAddress = new Uri($"{gdcOptions.BaseAdress}/api/");
            })
            .AddTransientHttpErrorPolicy(
                bder => bder.Or<TimeoutRejectedException>().WaitAndRetryAsync(
                    5,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                        + TimeSpan.FromMilliseconds(jitterer.Next(0, 1000)),
                onRetry: (outcome, timespan, retryAttemp) =>
                {
                    var serviceProvider = service.BuildServiceProvider();
                    serviceProvider.GetService<ILogger<GdcProxy>>()?
                        .LogWarning($"Delaying for {timespan.TotalSeconds} seconds, then making retry {retryAttemp}");
                }
            ));
            return service;
        }
    }
}
