using CB.Blazor.CMS.Contracts;
using CB.Blazor.CMS.Mappers.Contracts;
using CB.Blazor.Infrastructure.Cache;
using CB.Blazor.Infrastructure.Repositories.SquidexRepo.Contracts;
using CB.Blazor.Interface.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CB.Blazor.CMS
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

        public async Task<List<BlogCategory>> GetBlogCategories()
        {
            var categories = await GetItemFromCache(CacheConstants.BlogCategories, () => _repo.GetBlogCategories());
            return _mapper.MapToBlogCategories(categories);
        }

        public async Task<BlogCategory> GetBlogCategory(string id)
        {
            var categories = await GetItemFromCache(CacheConstants.BlogCategories, () => _repo.GetBlogCategories());
            var category = categories.FirstOrDefault(c => c.Id == id);
            return _mapper.MapToBlogCategory(category);
        }

        public async Task<BlogPost> GetBlogPost(string id)
        {
            var posts = await GetItemFromCache(CacheConstants.BlogPosts, () => _repo.GetBlogPosts());
            var post = posts.FirstOrDefault(p => p.Id == id);

            var categories = await GetItemFromCache(CacheConstants.BlogCategories, () => _repo.GetBlogCategories());
            var category = categories.Where(c => post.Data.Categories.Contains(c.Id)).FirstOrDefault();

            var tags = await GetItemFromCache(CacheConstants.BlogPostTags, () => _repo.GetBlogPostTags());
            tags = tags.Where(t => post.Data.Tags.Contains(t.Id)).ToList();

            return _mapper.MapToBlogPost(post, category, tags);
        }

        public async Task<List<BlogPost>> GetBlogPosts()
        {
            var posts = await GetItemFromCache(CacheConstants.BlogPosts, () => _repo.GetBlogPosts());

            var result = new List<BlogPost>();
            foreach (var post in posts)
            {
                result.Add(await GetBlogPost(post.Id));
            }
            return result;
        }

        public async Task<List<BlogPost>> GetBlogPostsByCategoryID(string id)
        {
            var posts = await GetItemFromCache(CacheConstants.BlogPosts, () => _repo.GetBlogPosts());

            posts = posts.Where(p => p.Data.Categories.Contains(id)).ToList();

            var result = new List<BlogPost>();
            foreach (var post in posts)
            {
                result.Add(await GetBlogPost(post.Id));
            }
            return result;
        }

        public async Task<List<BlogPostTag>> GetBlogPostTags()
        {
            var tags = await GetItemFromCache(CacheConstants.BlogPostTags, () => _repo.GetBlogPostTags());

            var result = new List<BlogPostTag>();
            result.AddRange(await GetBlogPostTags(tags.Select(t => t.Id).ToList()));
            return result;
        }

        public async Task<List<BlogPostTag>> GetBlogPostTags(List<string> tagIds)
        {
            var result = new List<BlogPostTag>();
            var tags = await GetItemFromCache(CacheConstants.BlogPostTags, () => _repo.GetBlogPostTags());

            foreach (var tagId in tagIds)
            {
                var tag = tags.FirstOrDefault(t => t.Id == tagId);
                result.Add(_mapper.MapToBlogPostTag(tag));
            }
            return result;
        }

        public async Task<GlobalConfig> GetGlobalConfig()
        {
            var config = await GetItemFromCache(CacheConstants.GlobalConfig, () => _repo.GetGlobalConfig());
            return _mapper.MapToGlobalConfig(config);
        }

        public async Task<Portfolio> GetPortfolio()
        {
            var profile = await GetItemFromCache(CacheConstants.Portfolio, () => _repo.GetPortfolio());
            return _mapper.MapToProfile(profile);
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
