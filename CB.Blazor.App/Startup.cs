using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;
using CB.Blazor.Infrastructure.Configuration;
using Microsoft.Extensions.Configuration;
using Blazorise.Bootstrap;
using Blazorise;

namespace CB.Blazor.App
{
    public class Startup
    {
        

        public void ConfigureServices(IServiceCollection services)
        {
            //blazorise
            services.AddBootstrapProviders().AddIconProvider(IconProvider.FontAwesome);
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
