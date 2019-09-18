using CalamariBlog.Services.CMS.Contracts;
using CalamariBlog.Services.CMS.Mappers.Contracts;
using CalamariBlog.Infrastructure.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalamariBlog.Infrastructure.Repositories.SquidexRepo.Contracts;
using CalamariBlog.Models.CMS;

namespace CalamariBlog.Services.CMS
{
    public class CMSService : ICMSService
    {
        #region Instance Fields

        private readonly ISquidexRepo _repo;
        private readonly ICMSMapper _mapper;
        private readonly ICacheProvider _cache;

        #endregion

        #region Constructors

        public CMSService(ISquidexRepo repo, ICMSMapper mapper, ICacheProvider cache)
        {
            _repo = repo;
            _mapper = mapper;
            _cache = cache;
        }

        #endregion

        #region Public Methods

        public async Task<BlogPost> GetBlogPost(string id)
        {
            var posts = await GetItemFromCache(CacheConstants.SquidexSchemas.BlogPosts, () => _repo.GetBlogPosts());
            var post = posts.FirstOrDefault(p => p.Id == id);

            var authors = await GetItemFromCache(CacheConstants.SquidexSchemas.Authors, () => _repo.GetAuthors());
            var author = authors.FirstOrDefault(a => a.Id == post.Data.Author.First());

            return _mapper.MapToBlogPost(post, author);
        }

        public async Task<List<BlogPost>> GetBlogPosts()
        {
            var posts = await GetItemFromCache(CacheConstants.SquidexSchemas.BlogPosts, () => _repo.GetBlogPosts());

            var result = new List<BlogPost>();
            foreach (var post in posts)
            {
                result.Add(await GetBlogPost(post.Id));
            }
            return result;
        }

        public async Task<Global> GetGlobal()
        {
            var config = await GetItemFromCache(CacheConstants.SquidexSchemas.Global, () => _repo.GetGlobal());
            return _mapper.MapToGlobal(config);
        }

        public async Task<Project> GetProject(string id)
        {
            var projects = await GetItemFromCache(CacheConstants.SquidexSchemas.Projects, () => _repo.GetProjects());
            var project = projects.FirstOrDefault(p => p.Id == id);

            return _mapper.MapToProject(project);
        }

        public async Task<List<Project>> GetProjects()
        {
            var projects = await GetItemFromCache(CacheConstants.SquidexSchemas.Projects, () => _repo.GetProjects());

            var result = new List<Project>();
            foreach (var project in projects)
            {
                result.Add(await GetProject(project.Id));
            }
            return result;
        }

        #endregion

        #region Private Methods

        private async Task<T> GetItemFromCache<T>(string key, Func<Task<T>> repoCallback)
        {
            if (_cache.TryGetItem(key, out T item))
            {
                return item;
            }

            item = await repoCallback();
            _cache.SetItem(key, item);
            return item;
        }

        #endregion
    }
}
