using System.Collections.Generic;
using ICH.Steward.Domain.Interfaces.Repositories;
using ICH.Steward.Domain.Repositories;
using ICH.Sugar;
using ICH.Sugar.Conn;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ICH.Steward.Domain
{
    public static  class ServiceExtensions
    {
        public static IServiceCollection AddService(this IServiceCollection services, IConfigurationRoot config)
        {
            services.ConfigurePOCO(config.GetSection("SugarOptions"), () => new List<SugarOptions>());
            services.ConfigurePOCO(config.GetSection("DBContext"), () => new DBContext());
            services.AddSingleton<SugarFactory>();
            services.AddTransient<IBaseUserRepository, BaseUserRepository>();
            return services;
        }
    }
}
