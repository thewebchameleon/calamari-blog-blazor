using CB.Blazor.CMS;
using CB.Blazor.CMS.Contracts;
using CB.Blazor.CMS.Mappers;
using CB.Blazor.CMS.Mappers.Contracts;
using CB.Blazor.Email;
using CB.Blazor.Email.Contracts;
using CB.Blazor.Infrastructure.Cache;
using CB.Blazor.Infrastructure.Configuration;
using CB.Blazor.Infrastructure.Logging;
using CB.Blazor.Infrastructure.Repositories.SendGridRepo;
using CB.Blazor.Infrastructure.Repositories.SendGridRepo.Contracts;
using CB.Blazor.Infrastructure.Repositories.SquidexRepo;
using CB.Blazor.Infrastructure.Repositories.SquidexRepo.Contracts;
using Microsoft.AspNetCore.Blazor.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Linq;
using System.Net.Mime;

namespace CB.Blazor.Server
{
    public class Startup
    {
        public Startup()
        {
            Log.Logger = new LoggerConfiguration()
              .Enrich.FromLogContext()
              .WriteTo.Console()
              .CreateLogger();
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCaching();
            services.AddMvc();

            Configuration = services.BuildServiceProvider().GetService<IConfiguration>();

            services.Configure<SquidexConfig>(options => Configuration.GetSection("Squidex").Bind(options));
            services.Configure<CacheConfig>(options => Configuration.GetSection("Cache").Bind(options));
            services.Configure<EmailConfig>(options => Configuration.GetSection("Email").Bind(options));
            services.Configure<LoggingConfig>(options => Configuration.GetSection("Logging").Bind(options));

            services.AddResponseCompression(options =>
            {
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                {
                    MediaTypeNames.Application.Octet,
                    WasmMediaTypeNames.Application.Wasm,
                });
            });

            services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));

            //cache
            services.AddMemoryCache();
            services.AddSingleton<ICacheProvider, MemoryCacheProvider>();

            services.AddSingleton<ILoggerService, LoggerService>();
            services.AddSingleton<ICMSMapper, CMSMapper>();
            services.AddSingleton<ISquidexRepo, SquidexRepo>();
            services.AddSingleton<ISendGridRepo, SendGridRepo>();
            services.AddSingleton<ICMSService, CMSService>();
            services.AddSingleton<IEmailService, EmailService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseResponseCompression();
            app.UseResponseCaching();

            app.Use(async (context, next) =>
            {
                // For GetTypedHeaders, add: using Microsoft.AspNetCore.Http;
                context.Response.GetTypedHeaders().CacheControl =
                    new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromHours(8)
                    };
                context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
                    new string[] { "Accept-Encoding" };

                await next();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller}/{action}/{id?}");
            });

            app.UseBlazor<App.Startup>();
        }
    }
}
