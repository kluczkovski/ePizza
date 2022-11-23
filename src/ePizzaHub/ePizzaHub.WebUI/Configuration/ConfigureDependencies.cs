using System;
using ePizzaHub.Services.Configuration;
using ePizzaHub.Services.Implementations;
using ePizzaHub.Services.Interfaces;
using ePizzaHub.WebUI.Helpers;
using ePizzaHub.WebUI.Interfaces;

namespace ePizzaHub.WebUI.Configuration
{
    public static class ConfigureDependencies
    {
       public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddTransient<IUserAccessor, UserAccessor>();
        }
    }
}

