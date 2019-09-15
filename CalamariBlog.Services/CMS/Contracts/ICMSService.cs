using CalamariBlog.Models.CMS;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CalamariBlog.Services.CMS.Contracts
{
    public interface ICMSService
    {
        Task<List<BlogPost>> GetBlogPosts();

        Task<BlogPost> GetBlogPost(string id);

        Task<Global> GetGlobal();

        Task<List<Project>> GetProjects();

        Task<Project> GetProject(string id);
    }
}
