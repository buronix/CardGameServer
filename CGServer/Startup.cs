using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ServiceStack;
using ServiceStack.Host.Handlers;
using System.Net.Mime;

namespace CGServer
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            /**
            services.AddTransient<IFoo, Foo>()
                .AddScoped<IScoped, Scoped>()
                .AddSingleton<IBar>(c => new Bar { Name = "bar" });
             **/
            services.AddLogging();
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
            app.UseStaticFiles();
            GameServiceHost gsHost = new GameServiceHost
            {
                AppSettings = new NetCoreAppSettings(Configuration) // Use **appsettings.json** and config sources
            };
            app.UseServiceStack(gsHost);
            //app.Use(new RequestInfoHandler());
            
        }
    }
}
