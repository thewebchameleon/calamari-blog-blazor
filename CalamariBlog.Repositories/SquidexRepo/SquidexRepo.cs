using CalamariBlog.Infrastructure.Cache;
using CalamariBlog.Infrastructure.Configuration;
using CalamariBlog.Infrastructure.Repositories.SquidexRepo.Contracts;
using CalamariBlog.Infrastructure.Repositories.SquidexRepo.Models;
using CalamariBlog.Infrastructure.Repositories.SquidexRepo.Models.Pages;
using Microsoft.Extensions.Options;
using Squidex.ClientLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalamariBlog.Infrastructure.Repositories.SquidexRepo
{
    public class SquidexRepo : ISquidexRepo
    {
        private readonly SquidexClient<ProjectEntity, ProjectData> _portfolioProjectsClient;
        private readonly SquidexClient<BlogPostEntity, BlogPostData> _blogPostClient;
        private readonly SquidexClient<GlobalEntity, GlobalData> _globalClient;
        private readonly SquidexClient<AuthorEntity, AuthorData> _authorsClient;

        private readonly SquidexClient<PageAboutEntity, PageAboutData> _pageAboutClient;
        private readonly SquidexClient<PageContactEntity, PageContactData> _pageContactClient;
        private readonly SquidexClient<PageIndexEntity, PageIndexData> _pageIndexClient;
        private readonly SquidexClient<PageProjectsEntity, PageProjectsData> _pageProjectsClient;
        private readonly SquidexClient<PageSearchResultsEntity, PageSearchResultsData> _pageSearchResultsClient;

        public SquidexRepo(IOptions<SquidexConfig> appOptions)
        {
            var options = appOptions.Value;

            var clientManager =
                new SquidexClientManager(
                    options.Url,
                    options.AppName,
                    options.ClientId,
                    options.ClientSecret);

            _portfolioProjectsClient = clientManager.GetClient<ProjectEntity, ProjectData>(CacheConstants.SquidexSchemas.Projects);
            _blogPostClient = clientManager.GetClient<BlogPostEntity, BlogPostData>(CacheConstants.SquidexSchemas.BlogPosts);
            _globalClient = clientManager.GetClient<GlobalEntity, GlobalData>(CacheConstants.SquidexSchemas.Global);
            _authorsClient = clientManager.GetClient<AuthorEntity, AuthorData>(CacheConstants.SquidexSchemas.Authors);

            _pageAboutClient = clientManager.GetClient<PageAboutEntity, PageAboutData>(CacheConstants.SquidexSchemas.Pages.About);
            _pageContactClient = clientManager.GetClient<PageContactEntity, PageContactData>(CacheConstants.SquidexSchemas.Pages.Contact);
            _pageIndexClient = clientManager.GetClient<PageIndexEntity, PageIndexData>(CacheConstants.SquidexSchemas.Pages.Index);
            _pageProjectsClient = clientManager.GetClient<PageProjectsEntity, PageProjectsData>(CacheConstants.SquidexSchemas.Pages.Projects);
            _pageSearchResultsClient = clientManager.GetClient<PageSearchResultsEntity, PageSearchResultsData>(CacheConstants.SquidexSchemas.Pages.SearchResults);
        }

        public async Task<List<ProjectEntity>> GetProjects(int page, int pageSize)
        {
            var data = await _portfolioProjectsClient.GetAsync(new ODataQuery() { Skip = page * pageSize, Top = pageSize });
            return data.Items;
        }

        public async Task<List<BlogPostEntity>> GetBlogPosts(int page, int pageSize)
        {
            var data = await _blogPostClient.GetAsync(new ODataQuery() { Skip = page * pageSize, Top = pageSize });
            return data.Items;
        }

        public async Task<GlobalEntity> GetGlobal()
        {
            var data = await _globalClient.GetAsync();
            return data.Items.FirstOrDefault();
        }

        public async Task<List<AuthorEntity>> GetAuthors()
        {
            var data = await _authorsClient.GetAsync();
            return data.Items;
        }

        public async Task<PageAboutEntity> GetPage_About()
        {
            var data = await _pageAboutClient.GetAsync();
            return data.Items.FirstOrDefault();
        }

        public async Task<PageContactEntity> GetPage_Contact()
        {
            var data = await _pageContactClient.GetAsync();
            return data.Items.FirstOrDefault();
        }

        public async Task<PageIndexEntity> GetPage_Index()
        {
            var data = await _pageIndexClient.GetAsync();
            return data.Items.FirstOrDefault();
        }

        public async Task<PageProjectsEntity> GetPage_Projects()
        {
            var data = await _pageProjectsClient.GetAsync();
            return data.Items.FirstOrDefault();
        }

        public async Task<PageSearchResultsEntity> GetPage_SearchResults()
        {
            var data = await _pageSearchResultsClient.GetAsync();
            return data.Items.FirstOrDefault();
        }
    }
}
