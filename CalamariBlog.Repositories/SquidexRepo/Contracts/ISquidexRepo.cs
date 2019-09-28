using CalamariBlog.Infrastructure.Repositories.SquidexRepo.Models;
using CalamariBlog.Infrastructure.Repositories.SquidexRepo.Models.Pages;
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

        Task<PageAboutEntity> GetPage_About();

        Task<PageContactEntity> GetPage_Contact();

        Task<PageIndexEntity> GetPage_Index();

        Task<PageProjectsEntity> GetPage_Projects();

        Task<PageSearchResultsEntity> GetPage_SearchResults();
    }
}
