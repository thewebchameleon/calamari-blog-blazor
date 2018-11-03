using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CB.Blazor.Infrastructure.Configuration;
using CB.Blazor.Infrastructure.Cache;
using CB.Blazor.CMS.Mappers.Contracts;
using CB.Blazor.Infrastructure.Repositories.SquidexRepo.Contracts;
using CB.Blazor.CMS.Contracts;
using CB.Blazor.CMS;
using CB.Blazor.CMS.Mappers;
using CB.Blazor.Infrastructure.Repositories.SquidexRepo;

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
