using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TravelTeam.Domain.Options;

namespace TravelTeam.Web.Infrastructure.ServiceExtensions
{
    /// <summary>
    /// Configuration service extensions.
    /// </summary>
    internal static class ConfigurationServiceExtension
    {
        /// <summary>
        /// Add configuration options.
        /// </summary>
        public static IServiceCollection AddConfigurationOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.Name));

            return services;
        }
    }
}
