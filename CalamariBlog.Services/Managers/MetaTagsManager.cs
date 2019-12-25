using CalamariBlog.Models.JavascriptModels;
using CalamariBlog.Services.Managers.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace CalamariBlog.Services.Managers
{
    public class MetaTagsManager : IMetaTagsManager
    {
        private readonly IJSRuntime _jSRuntime;
        private readonly NavigationManager _navigationManager;

        public MetaTagsManager(IJSRuntime jSRuntime, NavigationManager navigationManager)
        {
            _jSRuntime = jSRuntime;
            _navigationManager = navigationManager;
        }

        public async Task SetMetaTags(SetMetaTagsRequest request)
        {
            await _jSRuntime.InvokeAsync<string>("SetMetaTags", new SetMetaTagsRequest()
            {
                Title = request.Title ?? "Calamari Blog",
                Description = request.Description ?? "A lightweight blogging client using Squidex",
                Image = request.Image,
                Type = request.Type ?? "website",
                Url = request.Url ?? _navigationManager.Uri
            });
        }
    }
}
