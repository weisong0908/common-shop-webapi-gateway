using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonShop.WebApiGateway.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using AutoMapper;
using CommonShop.WebApiGateway.Mappings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using CommonShop.WebApiGateway.Requirements;

namespace CommonShop.WebApiGateway
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Common Shop - Web API Gateway", Version = "v1" });
            });

            services.AddCors(setupAction =>
            {
                setupAction.AddPolicy("web client", configurePolicy =>
                {
                    configurePolicy
                        .WithOrigins(Configuration.GetSection("Security:AllowedOrigins").Get<string[]>())
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = Configuration["Authentication:Authority"];
                options.Audience = Configuration["Authentication:Audience"];
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("read:products", policy => policy.Requirements.Add(new HasPermissionRequirement("read:products", Configuration["Authentication:Authority"])));
                options.AddPolicy("write:products", policy => policy.Requirements.Add(new HasPermissionRequirement("write:products", Configuration["Authentication:Authority"])));
            });

            services.AddSingleton<IAuthorizationHandler, HasPermissionHandler>();

            services.AddHttpClient("sales service", configureClient =>
            {
                configureClient.BaseAddress = new Uri(Configuration["Services:Sales"]);
            });
            services.AddScoped<ISalesService, SalesService>();
            services.AddScoped<IWarehouseService, WarehouseService>();

            services.AddAutoMapper(configAction => configAction.AddProfile<MappingProfile>(), typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsStaging())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CommonShop.WebApiGateway v1"));
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("web client");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
