using CB.Blazor.Interface.CMS;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CB.Blazor.CMS.Contracts
{
    public interface ICMSService
    {
        Task<List<BlogPost>> GetBlogPosts();

        Task<BlogPost> GetBlogPost(string id);

        Task<Portfolio> GetPortfolio();

        Task<Global> GetGlobal();
    }
}
