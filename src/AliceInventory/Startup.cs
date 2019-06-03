using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AliceInventory.Logger;

namespace AliceInventory
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

            // services.AddJaegerTracing_NotWorking(options => 
            //     {
            //         options.JaegerAgentHost = Configuration["JAEGER_AGENT_HOST"];
            //         options.ServiceName = "CustomJaegerService";
            //         options.LoggerFactory = new LoggerFactory();
            //     });
            services.AddJaegerTracing_Working();

            services.AddSingleton<Logic.IConfigurationService, Logic.ConfigurationService>();
            services.AddSingleton<Logic.Email.IAliceEmailService, Logic.Email.AliceEmailService>();
            services.AddSingleton<Logic.ICommandCache, Logic.CommandCache>();
            services.AddSingleton<Logic.IInputParserService, Logic.Parser.InputParserService>();
            services.AddSingleton<Data.IInventoryStorage, Data.DictionaryStorage>();
            services.AddSingleton<Logic.IInventoryDialogService, Logic.InventoryDialogService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
