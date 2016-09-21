using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using wwwmy.Interfaces.Repositories;
using wwwmy.DataLayer;
using wwwmy.Core;
using wwwmy.Core.Interfaces;
using wwwmy.Config;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace wwwmy
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

            services.AddSingleton<ITestRepo, TestRepo>();

            //Логгирование
            services.AddSingleton<ICustomLogger>(new NLogLogger("nlog.config"));
            
            # region Настройки appsettings
            services.AddOptions();
            services.Configure<TestConfig>(Configuration.GetSection("TestConfig"));
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, ICustomLogger customLog)
        {
            app.UseStaticFiles(); //INFO: изменение каталогов и тд http://goo.gl/YGycfT
            // добавляем поддержку каталога node_modules
            
            //TODO: https://goo.gl/HBPtBh в большинстве случаев для библиотек из node_modules используют минификацию/бандлинг с помощью Grunt/Gulp с последующим копированием в папку wwwroot, поэтому не придется прибегать к проекции запросов на каталог node_modules.
            app.UseFileServer(new FileServerOptions()
            {
                FileProvider = new PhysicalFileProvider(
                    System.IO.Path.Combine(env.ContentRootPath, "node_modules")
                ),
                RequestPath = "/lib",
                EnableDirectoryBrowsing = false
            });

            app.UseStatusCodePages(); //status code error pages
            
            if(env.IsDevelopment())
            {
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug();

                app.UseDeveloperExceptionPage(); //страница исключений при разработке
            } else
            {
                app.UseExceptionHandler("/error"); //Страница-ошибка с логгированием необработанных исключений
            }            

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Main}/{action=Index}/{id?}");
            });
        }
    }
}
