using CB.Blazor.Infrastructure.Cache;
using CB.Blazor.Infrastructure.Configuration;
using CB.Blazor.Infrastructure.Repositories.SquidexRepo.Contracts;
using CB.Blazor.Infrastructure.Repositories.SquidexRepo.Models;
using Microsoft.Extensions.Options;
using Squidex.ClientLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CB.Blazor.Infrastructure.Repositories.SquidexRepo
{
    public class SquidexRepo : ISquidexRepo
    {
        private readonly SquidexClient<PortfolioProjectEntity, PortfolioProjectData> _portfolioProjectsClient;
        private readonly SquidexClient<BlogPostEntity, BlogPostData> _blogPostClient;
        private readonly SquidexClient<SkillTypeEntity, SkillTypeData> _skillTypesClient;
        private readonly SquidexClient<GlobalEntity, GlobalData> _globalClient;
        private readonly SquidexClient<PortfolioEntity, PortfolioData> _portfolioClient;

        private readonly ICacheProvider _cache;

        public SquidexRepo(IOptions<SquidexConfig> appOptions, ICacheProvider cache)
        {
            var options = appOptions.Value;

            var clientManager =
                new SquidexClientManager(
                    options.Url,
                    options.AppName,
                    options.ClientId,
                    options.ClientSecret);

            _portfolioProjectsClient = clientManager.GetClient<PortfolioProjectEntity, PortfolioProjectData>("portfolio-projects");
            _blogPostClient = clientManager.GetClient<BlogPostEntity, BlogPostData>("blog-posts");
            _skillTypesClient = clientManager.GetClient<SkillTypeEntity, SkillTypeData>("skill-types");
            _globalClient = clientManager.GetClient<GlobalEntity, GlobalData>("global");
            _portfolioClient = clientManager.GetClient<PortfolioEntity, PortfolioData>("portfolio");

            _cache = cache;
        }

        public async Task<List<PortfolioProjectEntity>> GetPortfolioProjects(int page = 0, int pageSize = 3)
        {
            var data = await _portfolioProjectsClient.GetAsync(page * pageSize, pageSize);
            return data.Items;
        }

        public async Task<List<BlogPostEntity>> GetBlogPosts(int page = 0, int pageSize = 3)
        {
            var data = await _blogPostClient.GetAsync(page * pageSize, pageSize);
            return data.Items;
        }

        public async Task<List<SkillTypeEntity>> GetSkillTypes(int page = 0, int pageSize = 3)
        {
            var data = await _skillTypesClient.GetAsync(page * pageSize, pageSize);
            return data.Items;
        }

        public async Task<GlobalEntity> GetGlobal()
        {
            var data = await _globalClient.GetAsync();
            return data.Items.FirstOrDefault();
        }

        public async Task<PortfolioEntity> GetPortfolio()
        {
            var data = await _portfolioClient.GetAsync();
            return data.Items.FirstOrDefault();
        }
    }
}
