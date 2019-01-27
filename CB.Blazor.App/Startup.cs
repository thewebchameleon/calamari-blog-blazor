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

            //blazorise
            services.AddBootstrapProviders().AddIconProvider(IconProvider.FontAwesome);

            //cache
            services.AddSingleton<ICacheProvider, MemoryCacheProvider>();

            services.AddSingleton<ICMSMapper, CMSMapper>();
            services.AddSingleton<ISquidexRepo, SquidexRepo>();
            services.AddSingleton<ICMSService, CMSService>();
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
