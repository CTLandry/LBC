using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace LBC.Web.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LBC API", Version = "v1" });
            });

            services.AddAuthentication(o =>
            {
                o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
                .AddCookie()
                .AddFacebook(fb =>
                {
                    fb.AppId = Configuration["FacebookAppId"];
                    fb.AppSecret = Configuration["FacebookAppSecret"];
                    fb.SaveTokens = true;
                })
                .AddGoogle(g =>
                {
                    g.ClientId = Configuration["GoogleClientId"];
                    g.ClientSecret = Configuration["GoogleClientSecret"];
                    g.SaveTokens = true;
                })
                .AddMicrosoftAccount(ms =>
                {
                    ms.ClientId = Configuration["MicrosoftClientId"];
                    ms.ClientSecret = Configuration["MicrosoftClientSecret"];
                    ms.SaveTokens = true;
                });
              
        }

       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "LBC API V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
