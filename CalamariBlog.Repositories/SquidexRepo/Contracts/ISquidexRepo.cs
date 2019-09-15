using CalamariBlog.Infrastructure.Repositories.SquidexRepo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CalamariBlog.Infrastructure.Repositories.SquidexRepo.Contracts
{
    public interface ISquidexRepo
    {
        Task<List<ProjectEntity>> GetProjects(int page = 0, int pageSize = 999);

        Task<List<BlogPostEntity>> GetBlogPosts(int page = 0, int pageSize = 999);

        Task<GlobalEntity> GetGlobal();

        Task<List<AuthorEntity>> GetAuthors();
    }
}
