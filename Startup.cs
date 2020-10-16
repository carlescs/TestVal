using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using TestVal.Localization;
using TestVal.Util;
using TestVal.Validation;

namespace TestVal
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
            services.AddLocalization();
            services.AddSingleton<StringStore>()
                .AddSingleton<IValidationAttributeAdapterProvider, TestAttributeAdapterProvider>()
                .AddSingleton<IStringLocalizerFactory,MyStringLocalizerFactory>();
            services.AddControllersWithViews().AddDataAnnotationsLocalization(setup =>
            {
                setup.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(type);
            });
            services.AddApplicationInsightsTelemetry(Configuration["APPINSIGHTS_INSTRUMENTATIONKEY"]);
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRequestLocalization(options =>
            {
                options.SupportedCultures=new List<CultureInfo>
                {
                    new CultureInfo("en"),
                    new CultureInfo("de")
                };
                options.DefaultRequestCulture=new RequestCulture("en");
                options.AddInitialRequestCultureProvider(new QueryStringRequestCultureProvider()
                    {QueryStringKey = "lang"});
            });
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
