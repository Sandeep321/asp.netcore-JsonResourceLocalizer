using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using JsonResourceLocalizerLibrary.Localizers;
using JsonResourceLocalizerLibrary.Messages;
using Swashbuckle.AspNetCore.Swagger;

namespace JsonResourceLocalizer
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
            services.AddJsonLocalization(options => options.ResourcesPath = "Resources");
            services.AddMvc()
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                        factory.Create(typeof(Validation));
                }
                )
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //INJECT  Custom localizer
            services.AddTransient<IStringLocalizerService, StringLocalizerService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Version = "v1",
                    Title = "My API",
                    Description = "ASP.NET Core Web API with multiple resource files for localization",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Sandeep Kumar", Email = "sandeeptripathi01@gmail.com", Url = "" }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Add the supported cultures and set the defaults 
            var supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("en"),
                //Enable the cultures and add the respective resource files to get localization in that language
                new CultureInfo("es")
            };

            var options = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
            };

            app.UseRequestLocalization(options);

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
