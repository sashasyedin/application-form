using ApplicationForm.Data;
using ApplicationForm.Data.Abstractions;
using ApplicationForm.Services;
using ApplicationForm.Services.Contracts;
using ApplicationForm.UI.Web.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationForm.UI.Web
{
    public class Startup
    {
        private const string connStrKey = "DefaultConnection";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime.
        /// Use this method to add services to the container.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Database context:
            var connStr = Configuration.GetConnectionString(connStrKey);
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connStr));
            services.AddScoped<IDbContext, ApplicationContext>();

            // Register application services:
            services.AddTransient<ISectorService, SectorService>();
            services.AddTransient<IUserService, UserService>();
        }

        /// <summary>
        /// This method gets called by the runtime.
        /// Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The environment.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseBrowserLink();

            app.UseStaticFiles();
            app.UseErrorLogging();
            app.UseMvc();
        }
    }
}
