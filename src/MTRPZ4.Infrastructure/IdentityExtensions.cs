using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MTRPZ4.CoreDomain.Entities;

namespace MTRPZ4.Infrastructure
{
    public static class IdentityExtensions
    {
        public static void AddIdentityUser(this IServiceCollection service)
        {
            service.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDBContext>()
                .AddDefaultTokenProviders()
                .AddDefaultUI();
        }

        public static void ConfigurateIdentityOptions(this IServiceCollection service)
        {
            service.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireUppercase = false;
            });
        }
    }
}
