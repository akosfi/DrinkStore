using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DrinkStore.DAL;
using Microsoft.EntityFrameworkCore;
using BLL.Services;
using DrinkStore.BLL.Services;
using System.Security.Claims;
using RiskFirst.Hateoas;
using RiskFirst.Hateoas.Models;
using DrinkStore.BLL.DTOs;
using DrinkStore.API.Utilities;
using DrinkStore.Auth.Constants;
using System.Diagnostics;

namespace DrinkStore.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string AllowedClientOrigin = nameof(AllowedClientOrigin);


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(AllowedClientOrigin,
                builder =>
                {
                    builder
                    .WithOrigins(Configuration["ClientURL"])
                    .AllowCredentials()
                    .AllowAnyHeader();
                });

            });

            services.AddDbContext<DrinkStoreContext>(o =>
                o.UseNpgsql(Configuration["ConnectionStrings:pgConnection"]));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.Authority = Configuration["OAuthURL"];
                o.Audience = "resourceapi";
                o.RequireHttpsMetadata = false;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("admin", policy           => policy.RequireClaim(ClaimTypes.Role, Roles.Admin).RequireClaim(ClaimTypes.Role, Roles.Consumer));
                options.AddPolicy("consumer", policy        => policy.RequireClaim(ClaimTypes.Role, Roles.Consumer));
            });

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IOrderService, OrderService>();

            services.AddControllers();

            services.AddHateoas();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /*----*/
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("index.html");
            app.UseDefaultFiles(options);

            app.UseStaticFiles();
            /*----*/
            app.UseCors(AllowedClientOrigin);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
