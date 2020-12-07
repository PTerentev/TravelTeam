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
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            }, new string[] { }
                    }
                });

            options.IncludeXmlComments(GetAssemblyLocationByType(typeof(SwaggerServiceExtension)));
            options.IncludeXmlComments(GetAssemblyLocationByType(typeof(UseCases.Common.UserDto)));
        }

        private static string GetAssemblyLocationByType(Type type) =>
            Path.Combine(AppContext.BaseDirectory, $"{type.Assembly.GetName().Name}.xml");
    }
}
