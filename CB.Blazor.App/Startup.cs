using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;
using CB.Blazor.CMS.Contracts;
using CB.Blazor.CMS;
using CB.Blazor.Infrastructure.Configuration;
using CB.Blazor.CMS.Mappers;
using CB.Blazor.Infrastructure.Repositories.SquidexRepo;
using CB.Blazor.CMS.Mappers.Contracts;
using CB.Blazor.Infrastructure.Repositories.SquidexRepo.Contracts;
using CB.Blazor.Infrastructure.Cache;
using Microsoft.Extensions.Configuration;
using Blazorise.Bootstrap;
using Blazorise;
using System.Linq;
using System.Net.Http;
using System;
using Microsoft.AspNetCore.Blazor.Services;

namespace CB.Blazor.App
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Since Blazor is running on the server, we can use an application service

            Configuration = services.BuildServiceProvider().GetService<IConfiguration>();

            services.Configure<SquidexConfig>(options => Configuration.GetSection("Squidex").Bind(options));
            services.Configure<CacheConfig>(options => Configuration.GetSection("Cache").Bind(options));
            services.Configure<EmailConfig>(options => Configuration.GetSection("Email").Bind(options));
            services.Configure<LoggingConfig>(options => Configuration.GetSection("Logging").Bind(options));

            //blazorise
            services.AddBootstrapProviders().AddIconProvider(IconProvider.FontAwesome);

            //cache
            services.AddMemoryCache();
            services.AddSingleton<ICacheProvider, MemoryCacheProvider>();

            services.AddSingleton<ICMSMapper, CMSMapper>();
            services.AddSingleton<ISquidexRepo, SquidexRepo>();
            services.AddSingleton<ICMSService, CMSService>();

            // Server Side Blazor doesn't register HttpClient by default
            if (!services.Any(x => x.ServiceType == typeof(HttpClient)))
            {
                // Setup HttpClient for server side in a client side compatible fashion
                services.AddScoped<HttpClient>(s =>
                {
                    // Creating the URI helper needs to wait until the JS Runtime is initialized, so defer it.
                    var uriHelper = s.GetRequiredService<IUriHelper>();
                    return new HttpClient
                    {
                        BaseAddress = new Uri(uriHelper.GetBaseUri())
                    };
                });
            }
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
