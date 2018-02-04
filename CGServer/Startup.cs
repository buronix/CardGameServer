using CG.Logging.log4Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ServiceStack;
using ServiceStack.Logging;
using System.Collections.Generic;
using System.Reflection;

namespace CG.Server
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;
        private static readonly ILog log = LogManager.GetLogger(typeof(Startup));

        public void ConfigureServices(IServiceCollection services)
        {
            /**
            services.AddTransient<IFoo, Foo>()
                .AddScoped<IScoped, Scoped>()
                .AddSingleton<IBar>(c => new Bar { Name = "bar" });
             **/
            services.AddRouting();
            services.AddMvcCore();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            loggerFactory.AddProvider(new Log4NetProvider());

            NetCoreAppSettings appSettings = new NetCoreAppSettings(Configuration);
            List<Assembly> services = new List<Assembly>();
            var configServices = Configuration.GetSection("Services");
            //string[] configServices = appSettings.Get<string[]>("Services");
            foreach(var cService in configServices.GetChildren())
            {
                Assembly serviceAssembly = Assembly.Load(cService.Value);
                services.Add(serviceAssembly);
                log.Info("Service: "+cService.Key+":"+cService.Value+" | Assembly: " + serviceAssembly.FullName);
            }
            /*
            Console.WriteLine("----------AppDomain Assemblies Startup--------------");
            foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
            {
                Console.WriteLine("AppDomain Assembly: " + a.FullName);
            }
            app.UseStaticFiles();
            Assembly.GetExecutingAssembly().GetReferencedAssemblies().PrintDump();
            IEnumerable<Assembly> services = Assembly.GetExecutingAssembly()
                .GetReferencedAssemblies()
                //.Where(x => x.FullName.Contains("CG.Services"))
                .Select(x => );
            Console.WriteLine("----------GetExecutingAssembly Assemblies Startup--------------");
            foreach (Assembly a in services)
            {
                Console.WriteLine("GetExecutingAssembly: " + a.FullName);
            }
            */

            ServerAppHost serverAppHost = new ServerAppHost(services.ToArray())
            {
                AppSettings = appSettings// Use **appsettings.json** and config sources
            };
            app.UseServiceStack(serverAppHost);
            //app.Use(new RequestInfoHandler());
            
        }
    }
}
