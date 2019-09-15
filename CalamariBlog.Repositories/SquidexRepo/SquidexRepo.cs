using CalamariBlog.Infrastructure.Cache;
using CalamariBlog.Infrastructure.Configuration;
using CalamariBlog.Infrastructure.Repositories.SquidexRepo.Contracts;
using CalamariBlog.Infrastructure.Repositories.SquidexRepo.Models;
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

            _portfolioProjectsClient = clientManager.GetClient<ProjectEntity, ProjectData>("projects");
            _blogPostClient = clientManager.GetClient<BlogPostEntity, BlogPostData>("blog-posts");
            _globalClient = clientManager.GetClient<GlobalEntity, GlobalData>("global");
            _authorsClient = clientManager.GetClient<AuthorEntity, AuthorData>("authors");

            _cache = cache;
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
    }
}
