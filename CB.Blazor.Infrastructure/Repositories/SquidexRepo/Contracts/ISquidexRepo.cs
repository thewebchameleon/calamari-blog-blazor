using CB.Blazor.Infrastructure.Repositories.SquidexRepo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CB.Blazor.Infrastructure.Repositories.SquidexRepo.Contracts
{
    public interface ISquidexRepo
    {
        Task<List<BlogCategoryEntity>> GetBlogCategories(int page = 0, int pageSize = 3);

        Task<List<BlogPostEntity>> GetBlogPosts(int page = 0, int pageSize = 3);

        Task<List<BlogPostTagEntity>> GetBlogPostTags(int page = 0, int pageSize = 3);

        Task<GlobalConfigEntity> GetGlobalConfig();

        Task<ProfileEntity> GetProfile();
    }
}
