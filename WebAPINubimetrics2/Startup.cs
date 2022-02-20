using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using WebAPINubimetrics.BusinessLogic;
using WebAPINubimetrics.Interface;
using WebAPINubimetrics2.BusinessLogic;
using WebAPINubimetrics2.Interface;

namespace WebAPINubimetrics2
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

            services.AddTransient<IBSExternalServices, BSExternalService>();
            services.AddTransient<IBSCurrency, BSCurrencyService>();
            services.AddTransient<IBSConexionApi, BSConexionApiService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "WebAPINubimetrics2",
                        Description = "Challenge Nubimetrics",
                        Contact = new OpenApiContact
                        {
                            Name = "Pablo Sanabria",
                            Email = "pablosanabria_1986@hotmail.com",
                            Url = new Uri("https://www.linkedin.com/in/pablo-ezequiel-sanabria-b56112a3/"),
                        }
                    });
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPINubimetrics2 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
