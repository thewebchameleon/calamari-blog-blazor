using CB.Blazor.Infrastructure.Repositories.SquidexRepo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CB.Blazor.Infrastructure.Repositories.SquidexRepo.Contracts
{
    public interface ISquidexRepo
    {
        Task<List<PortfolioProjectEntity>> GetPortfolioProjects(int page = 0, int pageSize = 3);

        Task<List<BlogPostEntity>> GetBlogPosts(int page = 0, int pageSize = 3);

        Task<List<SkillTypeEntity>> GetSkillTypes(int page = 0, int pageSize = 3);

        Task<GlobalEntity> GetGlobal();

        Task<PortfolioEntity> GetPortfolio();
    }
}
