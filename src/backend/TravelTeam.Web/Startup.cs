using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TravelTeam.Abstractions.Infrastructure;
using TravelTeam.Infrastructure.Authentication;
using TravelTeam.Web.Infrastructure;
using TravelTeam.Web.Infrastructure.Initialization;
using TravelTeam.Web.Infrastructure.Middlewares;
using TravelTeam.Web.Infrastructure.ServiceExtensions;

namespace TravelTeam.Web
{
    /// <summary>
    /// Startup class.
    /// </summary>
    public class Startup
    {
        private readonly IConfiguration configuration;

        /// <summary>
        /// Constructor.
        /// </summary>
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerServices();
            services.AddDomainServices(configuration);
            services.AddAuthenticationServices(configuration);
            services.AddConfigurationOptions(configuration);
            services.AddAsyncInitializer<TestDataInitializer>();
            services.AddCorsPolicy();
            services.AddAutoMapper(typeof(UseCases.Common.UserDto).Assembly);
            services.AddMediatR(typeof(UseCases.Common.UserDto).Assembly);
            services.AddScoped<IAccessTokenGenerationService, JwtAccessTokenGenerationService>();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.ShowExtensions();
                options.SwaggerEndpoint("/swagger/v1/swagger.json?v=1", "API Documentation");
                options.EnableValidator();
                options.DisplayOperationId();
            });

            if (env.EnvironmentName.Equals("Development", System.StringComparison.InvariantCultureIgnoreCase))
            {
                app.UseCors(CorsPolicyNames.DevCorsPolicyName);
            }

            app.UseMiddleware<ApiExceptionMiddleware>();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
