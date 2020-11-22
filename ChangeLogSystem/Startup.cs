using System;
using ChangeLogSystem.Api.Common;
using ChangeLogSystem.Api.Extensions;
using ChangeLogSystem.Data.Models;
using ChangeLogSystem.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.Extensions.Hosting.Internal;
using AutoMapper;
using ChangeLogSystem.Api.Map;

namespace ChangeLogSystem
{
    public class Startup
    {
        private IServiceProvider serviceProvider;

        public Startup(IWebHostEnvironment hostingEnvironment)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                 .SetBasePath(hostingEnvironment.ContentRootPath)
                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                 .AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                 .AddEnvironmentVariables();

            Configuration = configurationBuilder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIOC(Configuration);
            serviceProvider = services.BuildServiceProvider();

            AppSettings appSettings = serviceProvider.GetService<IOptions<AppSettings>>().Value;
            ConnectionStrings connectionStrings = serviceProvider.GetService<IOptions<ConnectionStrings>>().Value;

            services.AddDbContext<ChangeLogDbContext>(optionsAction =>
            {
                optionsAction.UseSqlServer(connectionStrings.ChangeLogDb);
            });

            services
               .AddCors(setupAction =>
               {
                   setupAction.AddPolicy(Constants.ALLOW_SPECIFIC_ORIGIN, configurePolicy =>
                   {
                       configurePolicy
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .WithOrigins(appSettings.Api.Cors.AllowedOrigins.ToArray());
                   });
               });

            services.AddJwtBearerAuthentication(appSettings);
            services.AddControllers()
               .AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Microsoft.Extensions.Hosting.IHostApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            applicationLifetime.ApplicationStarted.Register(OnApplicationStarted);

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void OnApplicationStarted()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile(new ConfigureMapping());
                config.AddProfile(new Domain.Map.ConfigureMapping());
            });

            Mapper.AssertConfigurationIsValid();
        }
    }
}