using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TravelTeam.Web.Infrastructure.ServiceExtensions
{
    /// <summary>
    /// Swagger service extension.
    /// </summary>
    internal static class SwaggerServiceExtension
    {
        /// <summary>
        /// Add swagger services.
        /// </summary>
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(Setup);
            return services;
        }

        private static void Setup(SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "1.0.0",
                Title = "TravelTeam",
                Description = "API documentation for TravelTeam project.",
                Contact = new OpenApiContact
                {
                    Name = "Pavel Terentev",
                    Email = "pavel.terentyev@saritasa.com"
                }
            });
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Insert JWT token into the field.",
                Scheme = "bearer",
                BearerFormat = "JWT",
                Type = SecuritySchemeType.Http
            });

            options.IncludeXmlComments(GetAssemblyLocationByType(typeof(SwaggerServiceExtension)));
            options.IncludeXmlComments(GetAssemblyLocationByType(typeof(UseCases.Common.UserDto)));
        }

        private static string GetAssemblyLocationByType(Type type) =>
            Path.Combine(AppContext.BaseDirectory, $"{type.Assembly.GetName().Name}.xml");
    }
}
