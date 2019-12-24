using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
using CalamariBlog.Services.Email.Contracts;
using CalamariBlog.Services.Email;
using Microsoft.AspNetCore.ResponseCompression;
using CalamariBlog.Infrastructure.Cache.Contracts;
using CalamariBlog.Services.Managers.Contracts;
using CalamariBlog.Services.Managers;

namespace CalamariBlog.Blazor
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            #region Configuration

            services.Configure<SquidexSettings>(_configuration.GetSection("Squidex"));
            services.Configure<CacheSettings>(_configuration.GetSection("Cache"));
            services.Configure<EmailSettings>(_configuration.GetSection("Email"));
            services.Configure<DisqusSettings>(_configuration.GetSection("Disqus"));

            #endregion

            #region Services

            // Infrastructure Services
            services.AddHttpClient();

            // Caching
            services.AddDistributedMemoryCache();
            services.AddSingleton<ICacheProvider, MemoryCacheProvider>();

            // Business Logic Services
            services.AddSingleton<ICMSMapper, CMSMapper>();

            services.AddSingleton<ICMSService, CMSService>();
            services.AddSingleton<IEmailService, EmailService>();

            // Business Logic Managers
            services.AddTransient<ICacheManager, CacheManager>();

            // Business Logic Service Repos
            services.AddSingleton<ISquidexRepo, SquidexRepo>();
            services.AddSingleton<ISendGridRepo, SendGridRepo>();

            #endregion

            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "image/svg+xml", "application/wasm" });
                options.EnableForHttps = true; // https://docs.microsoft.com/en-us/aspnet/core/performance/response-compression#compression-with-secure-protocol
            });
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

            app.UseResponseCompression();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
                endpoints.MapControllers();
            });
        }
    }
}
