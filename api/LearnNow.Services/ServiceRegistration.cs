using LearnNow.Services.Abstract;
using LearnNow.Services.Interfaces;
using LearnNow.Services.User;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnNow.Services
{
    public static class ServiceRegistration
    {
        public static void ConfigureLearnNowServices (this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
