using CalamariBlog.Models.JavascriptModels;
using System.Threading.Tasks;

namespace CalamariBlog.Services.Managers.Contracts
{
    public interface IMetaTagsManager
    {
        Task SetMetaTags(SetMetaTagsRequest request);
    }
}
