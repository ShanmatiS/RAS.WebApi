using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RAS.WebApi.Configurations
{
    public static class ConnectionConfigurations
    {
        public static IServiceCollection AddConnectionProvider(this IServiceCollection services,
           IConfiguration configuration)
        {
            //var connection = configuration.GetConnectionString("SQLConnection");
            //services.AddDbContextPool<DataContext>(options => options.UseSqlServer(connection));
            return services;
        }
    }
}
