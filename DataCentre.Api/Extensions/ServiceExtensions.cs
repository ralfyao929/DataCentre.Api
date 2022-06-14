using DataCentre.Api.Contracts;
using DataCentre.Api.Entity.Models;
using DataCentre.Api.LoggerService;
using DataCentre.Api.PreProcess;
using DataCentre.Api.Repository.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace DataCentre.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) 
        {
            services.AddCors(option => 
            {
                option.AddPolicy("Cors",
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()); ;
            });
        }
        public static void ConfigureConstants(this IServiceCollection services, IConfiguration config)
        {
            Utility.Utility.key = config["key"];
        }
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options => { 
                
            });
        }
        public static void ConfigureLoggerServices(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }
        public static void ConfigureFilterServices(this IServiceCollection services)
        {
            services.AddScoped<JwtAuthActionFilter>();
        }

        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            //services.AddSingleton<DapperContext>(o => o.);
            //var connectionString = config.GetConnectionString("mysqlconnection");
            services.AddScoped<DapperContext>();
            //services.AddDbContext<RepositoryContext>(o => o.UseMySql(connectionString, MySqlServerVersion.LatestSupportedServerVersion));
        }
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
