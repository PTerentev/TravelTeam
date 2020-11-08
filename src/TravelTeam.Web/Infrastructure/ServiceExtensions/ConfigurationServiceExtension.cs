using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TravelTeam.Domain.Options;

namespace TravelTeam.Web.Infrastructure.ServiceExtensions
{
    internal static class ConfigurationServiceExtension
    {
        public static IServiceCollection AddConfigurationOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.Name));

            return services;
        }
    }
}
