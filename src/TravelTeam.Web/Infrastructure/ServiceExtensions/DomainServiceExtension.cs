using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TravelTeam.Abstractions.Data;
using TravelTeam.DataAccess;
using TravelTeam.Domain.Entities;

namespace TravelTeam.Web.Infrastructure.ServiceExtensions
{
    internal static class DomainServiceExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<IApplicationDbContext, ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase("develop");
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            var passwordSettings = new PasswordOptions();
            configuration.Bind("PasswordSettings", passwordSettings);

            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password = passwordSettings;
            });

            return services;
        }
    }
}
