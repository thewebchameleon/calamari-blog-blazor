using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CalamariBlog.Services.CMS.Contracts;
using CalamariBlog.Services.CMS;
using CalamariBlog.Services.CMS.Mappers.Contracts;
using CalamariBlog.Infrastructure.Configuration;
using CalamariBlog.Infrastructure.Cache;
using CalamariBlog.Infrastructure.Repositories.SquidexRepo.Contracts;
using CalamariBlog.Infrastructure.Repositories.SendGridRepo.Contracts;
using CalamariBlog.Infrastructure.Repositories.SquidexRepo;
using CalamariBlog.Infrastructure.Repositories.SendGridRepo;
using CalamariBlog.Services.CMS.Mappers;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using CalamariBlog.Services.Email.Contracts;
using CalamariBlog.Services.Email;

namespace CalamariBlog.Blazor
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

            #region Configuration

            services.Configure<SquidexConfig>(options => Configuration.GetSection("Squidex").Bind(options));
            services.Configure<CacheConfig>(options => Configuration.GetSection("Cache").Bind(options));
            services.Configure<EmailConfig>(options => Configuration.GetSection("Email").Bind(options));
            services.Configure<LoggingConfig>(options => Configuration.GetSection("Logging").Bind(options));

            #endregion

            #region Services

            // Infrastructure Services
      

            // Caching
            services.AddMemoryCache();
            services.AddSingleton<ICacheProvider, MemoryCacheProvider>();

            // Business Logic Services
            services.AddSingleton<ICMSMapper, CMSMapper>();

            services.AddSingleton<ICMSService, CMSService>();
            services.AddSingleton<IEmailService, EmailService>();

            // Business Logic Service Repos
            services.AddSingleton<ISquidexRepo, SquidexRepo>();
            services.AddSingleton<ISendGridRepo, SendGridRepo>();

            #endregion
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
