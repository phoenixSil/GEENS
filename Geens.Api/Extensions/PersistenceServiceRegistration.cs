using Geens.Api.Datas;
using Geens.Api.Repertoires;
using Geens.Api.Repertoires.Contrats;
using Microsoft.EntityFrameworkCore;

namespace Geens.Api.Extensions
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IPointDaccess, PointDaccess>();

            services.AddScoped<IRepertoireDenseignant, RepertoireDenseignant>();
            services.AddScoped<IRepertoireDadresse, RepertoireDadresse>();

            return services;
        }
    }
}
