using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Video.Abstract;
using Video.Service;

namespace YoutubeClient
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<IVideoService, YoutubeService>();
            services.AddScoped<IProviderConfigurator, YoutubeConfigurator>();

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Video.Service.dll");
            var serviceAssembly = typeof(YoutubeService).Assembly;
            //var serviceAssembly = Assembly.LoadFile(path);
            var serviceTypes = serviceAssembly.GetTypes().Where(n => n.IsClass
                && typeof(IServiceDependency).IsAssignableFrom(n)).ToList();

            foreach (var serviceType in serviceTypes)
            {
                var i = serviceType.GetInterfaces().First();
                services.AddScoped(i, serviceType);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
