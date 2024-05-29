using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MTRPZ4.CoreDomain.Entities;
using MTRPZ4.Infrastructure;

namespace MTRPZ4.UI.Areas.Identity
{
    public static class IdentityExtensions
    {
        public static void AddIdentityUser(this IServiceCollection service)
        {
            service.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDBContext>();
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
