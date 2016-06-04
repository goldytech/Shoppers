using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SharedServices.DataAccess.Contracts;
using SharedServices.DataAccess.Repositories;
using PriceService;
using SharedServices.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace PriceServiceHost
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            var connection = @"Server=(localdb)\mssqllocaldb;Database=ShoppersDb;Trusted_Connection=True;";
            services.AddDbContext<AppDatabaseContext>(options => options.UseSqlServer(connection));
            services.AddScoped<IPriceRepository, PriceRepository>();
            services.AddTransient<IPriceService, PriceService.PriceService>();
            services.AddSingleton<IServiceUnitOfWork, ServiceUnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
