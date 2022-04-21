using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;

namespace RAS.WebApi.Configurations
{
    public static class SettingsConfiguration
    {
        public static IServiceCollection AddAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var azureADAuthentication = new PublicClientApplicationOptions();
            configuration.Bind("AzureADSettings", azureADAuthentication);
            services.AddSingleton(azureADAuthentication);

            //var jwtSettings = new JwtTokenSettings();
            //configuration.Bind(nameof(jwtSettings), jwtSettings);
            //services.AddSingleton(jwtSettings);

            return services;
        }
    }
}
