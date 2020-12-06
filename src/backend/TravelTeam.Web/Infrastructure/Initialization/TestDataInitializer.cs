using System.Threading.Tasks;
using Extensions.Hosting.AsyncInitialization;
using Microsoft.AspNetCore.Identity;
using TravelTeam.DataAccess;
using TravelTeam.Domain.Entities;

namespace TravelTeam.Web.Infrastructure.Initialization
{
    internal class TestDataInitializer : IAsyncInitializer
    {
        private const string AdminEmail = "sandman10@yandex.ru";
        private const string AdminPassword = "qwerty";

        private readonly ApplicationDbContext applicationDbContext;
        private readonly UserManager<ApplicationUser> userManager;

        public TestDataInitializer(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager)
        {
            this.applicationDbContext = applicationDbContext;
            this.userManager = userManager;
        }

        public async Task InitializeAsync()
        {
            await SeedUsers();
        }

        private async Task SeedUsers()
        {
            if (await userManager.FindByEmailAsync(AdminEmail) != null)
            {
                return;
            }

            var admin = new ApplicationUser()
            {
                UserName = "sandman",
                Email = AdminEmail
            };
            await userManager.CreateAsync(admin, AdminPassword);

            var fake1 = new ApplicationUser()
            {
                UserName = "dasdadsad",
                Email = "test@mail.ru"
            };
            await userManager.CreateAsync(fake1, "dasdadsadsa");
        }
    }
}
