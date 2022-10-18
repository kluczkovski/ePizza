using System;
using ePizzaHub.Services.Configuration;
using ePizzaHub.Services.Implementations;
using ePizzaHub.Services.Interfaces;

namespace ePizzaHub.WebUI.Configuration
{
    public static class ConfigureDependencies
    {
       public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();

        }
    }
}

