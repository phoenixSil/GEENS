using Geens.Data;
using Geens.Data.Context;
using Geens.Data.Repertoires;
using Geens.Features.Contrats.Repertoires;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MsCommun.Extensions;

namespace Geens.Data.Extensions
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSqlServerDbConfiguration<EnseignantDbContext>(configuration);

            services.AddScoped<IPointDaccess, PointDaccess>();

            services.AddScoped<IRepertoireDenseignant, RepertoireDenseignant>();
            services.AddScoped<IRepertoireDadresse, RepertoireDadresse>();

            return services;
        }
    }
}
