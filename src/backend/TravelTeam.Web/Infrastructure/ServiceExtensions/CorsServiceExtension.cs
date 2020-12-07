using Microsoft.Extensions.DependencyInjection;

namespace TravelTeam.Web.Infrastructure.ServiceExtensions
{
    /// <summary>
    /// CORS policy extension.
    /// </summary>
    internal static class CorsServiceExtension
    {
        /// <summary>
        /// Add CORS policy.
        /// </summary>
        public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: CorsPolicyNames.DevCorsPolicyName,
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin();
                                      builder.AllowAnyHeader();
                                      builder.AllowAnyMethod();
                                  });
            });

            return services;
        }
    }
}
