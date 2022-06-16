using DataCentre.Api.Contracts;
using DataCentre.Api.Entity.Models;
using DataCentre.Api.LoggerService;
using DataCentre.Api.PreProcess;
using DataCentre.Api.Repository.Wrapper;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

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
            services.AddSingleton<IConfiguration>(config);
        }
        public static void ConfigureLocalization(this IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.Configure<RequestLocalizationOptions>(
                options => 
                {
                    var supportedCultures = new List<CultureInfo>
                    {
                        new CultureInfo("en-US"),
                        new CultureInfo("zh-TW")
                    };
                    options.DefaultRequestCulture = new RequestCulture(culture: "zh-TW", uiCulture:"zh-TW");
                    options.SupportedCultures = supportedCultures;
                    //options.RequestCultureProviders = new[] { new RouteDataRequestCultureProvider {In} };
                });
            services.Configure<RouteOptions>(options => 
            {
                options.ConstraintMap.Add("culture", typeof(LanguageRouteConstraint));
            });
        }
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options => { 
                
            });
            services.Configure<IISServerOptions>(options => {
                options.AllowSynchronousIO = true;
            });
            services.Configure<KestrelServerOptions>(options => {
                options.AllowSynchronousIO = true;
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
    public class LanguageRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {

            if (!values.ContainsKey("culture"))
                return false;

            var culture = values["culture"].ToString();
            return culture == "en" || culture == "de";
        }
    }
}
