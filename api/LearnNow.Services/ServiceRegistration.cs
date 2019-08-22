using LearnNow.Services.Auth;
using LearnNow.Services.Interfaces;
using LearnNow.Services.User;
using Microsoft.Extensions.DependencyInjection;

namespace LearnNow.Services
{
    public static class ServiceRegistration
    {
        public static void ConfigureLearnNowServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
