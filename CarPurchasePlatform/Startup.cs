using CarPurchasePlatform.Abstractions;
using CarPurchasePlatform.Algorithms;
using CarPurchasePlatform.Repositories;
using CarPurchasePlatform.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Radzen;
using Radzen.Blazor.GridColumnVisibilityChooser.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPurchasePlatform
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddSingleton<IManufacturerRepository, InMemoryManufacturerRepository>();
            services.AddSingleton<IModelRepository, InMemoryModelRepository>();

            services.AddSingleton<IManufacturerService, DefaultManufacturerService>();
            services.AddSingleton<IModelService, DefaultModelService>();

            services.AddSingleton<IYearRepository, InMemoryYearRepository>();
            services.AddSingleton<IYearService, DefaultYearService>();

            services.AddSingleton<IWebServiceRepository, JsonWebServiceRepository>();
            services.AddSingleton<IWebServiceService, DefaultWebServiceService>();

            services.AddSingleton<IWebServiceSchemaRepository, InMemoryWebServiceSchemaRepository>();
            services.AddSingleton<IWebServiceSchemaService, DefaultWebServiceSchemaService>();

            services.AddSingleton<ILoggerService, ConsoleLoggerService>();

            services.AddScoped<DialogService>();
            services.AddScoped<NotificationService>();

            services.AddScoped<IPlanningAlgorithm, BackwardChainingAlgorithm>();
            services.AddScoped<IPlanExecutionerService, DefaultPlanExecutionerService>();

            services.ConfigureColumnVisibility();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
