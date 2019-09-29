using CalamariBlog.Services.CMS.Contracts;
using CalamariBlog.Services.CMS.Mappers.Contracts;
using CalamariBlog.Infrastructure.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalamariBlog.Infrastructure.Repositories.SquidexRepo.Contracts;
using CalamariBlog.Models.CMS;
using CalamariBlog.Models.CMS.Pages;
using CalamariBlog.Models.ServiceModels;
using CalamariBlog.Infrastructure.Extensions;

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

        public async Task<BlogPost> GetBlogPost(string slug)
        {
            var posts = await GetItemFromCache(CacheConstants.SquidexSchemas.BlogPosts, () => _repo.GetBlogPosts());
            var post = posts.FirstOrDefault(p => p.Data.Slug == slug);

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
                result.Add(await GetBlogPost(post.Data.Slug));
            }
            return result;
        }

        public async Task<Global> GetGlobal()
        {
            var config = await GetItemFromCache(CacheConstants.SquidexSchemas.Global, () => _repo.GetGlobal());
            return _mapper.MapToGlobal(config);
        }

        public async Task<PageAbout> GetPage_About()
        {
            var config = await GetItemFromCache(CacheConstants.SquidexSchemas.Pages.About, () => _repo.GetPage_About());
            return _mapper.MapToPage_About(config);
        }

        public async Task<PageContact> GetPage_Contact()
        {
            var config = await GetItemFromCache(CacheConstants.SquidexSchemas.Pages.Contact, () => _repo.GetPage_Contact());
            return _mapper.MapToPage_Contact(config);
        }

        public async Task<PageIndex> GetPage_Index()
        {
            var config = await GetItemFromCache(CacheConstants.SquidexSchemas.Pages.Index, () => _repo.GetPage_Index());
            return _mapper.MapToPage_Index(config);
        }

        public async Task<PageProjects> GetPage_Projects()
        {
            var config = await GetItemFromCache(CacheConstants.SquidexSchemas.Pages.Projects, () => _repo.GetPage_Projects());
            return _mapper.MapToPage_Projects(config);
        }

        public async Task<PageSearchResults> GetPage_SearchResults()
        {
            var config = await GetItemFromCache(CacheConstants.SquidexSchemas.Pages.SearchResults, () => _repo.GetPage_SearchResults());
            return _mapper.MapToPage_SearchResults(config);
        }

        public async Task<Project> GetProject(string slug)
        {
            var projects = await GetItemFromCache(CacheConstants.SquidexSchemas.Projects, () => _repo.GetProjects());
            var project = projects.FirstOrDefault(p => p.Data.Slug == slug);

            return _mapper.MapToProject(project);
        }

        public async Task<List<Project>> GetProjects()
        {
            var projects = await GetItemFromCache(CacheConstants.SquidexSchemas.Projects, () => _repo.GetProjects());

            var result = new List<Project>();
            foreach (var project in projects)
            {
                result.Add(await GetProject(project.Data.Slug));
            }
            return result;
        }

        public async Task<List<SearchResultItem>> GetSearch(GetSearchRequest request)
        {
            var results = new List<SearchResultItem>();

            var blogPosts = await GetBlogPosts();
            var filteredBlogPosts = blogPosts.Where(p =>
            p.Title.Contains(request.Keyword)
            || p.Subtitle.Contains(request.Keyword)
            || p.Tags.Contains(request.Keyword)
            || p.BodyHtml.Contains(request.Keyword)
            || p.Author.Name.Contains(request.Keyword));

            results.AddRange(filteredBlogPosts.Select(p => new SearchResultItem()
            {
                Type = SearchResultItemTypeEnum.BlogPost,
                Title = p.Title,
                Author = p.Author,
                Subtitle = p.Subtitle,
                Tags = p.Tags,
                PublishedDate = p.PublishedDate,
                Url = $"post/{p.Slug}",
                CreatedDate = p.CreatedDate,
                UpdatedDate = p.UpdatedDate
            }).ToList());

            var projects = await GetProjects();
            var filteredProjects = projects.Where(p =>
            p.Title.Contains(request.Keyword)
            || p.Subtitle.Contains(request.Keyword)
            || p.Tags.Contains(request.Keyword)
            || p.BodyHtml.Contains(request.Keyword));

            results.AddRange(filteredProjects.Select(p => new SearchResultItem()
            {
                Type = SearchResultItemTypeEnum.BlogPost,
                Title = p.Title,
                Subtitle = p.Subtitle,
                Tags = p.Tags,
                Url = $"project/{p.Slug}",
                CreatedDate = p.CreatedDate,
                UpdatedDate = p.UpdatedDate,
                ImageThumbnailUrl = p.ImageThumbnailUrl
            }).ToList());

            results = results.Shuffle();

            return results;
        }

        public async Task<List<SearchResultItem>> GetSearchByTagName(GetSearchByTagNameRequest request)
        {
            var results = new List<SearchResultItem>();

            var blogPosts = await GetBlogPosts();
            var filteredBlogPosts = blogPosts.Where(p => p.Tags.Contains(request.Tag));

            results.AddRange(filteredBlogPosts.Select(p => new SearchResultItem()
            {
                Type = SearchResultItemTypeEnum.BlogPost,
                Title = p.Title,
                Author = p.Author,
                Subtitle = p.Subtitle,
                Tags = p.Tags,
                Url = $"post/{p.Slug}",
                PublishedDate = p.PublishedDate,
                CreatedDate = p.CreatedDate,
                UpdatedDate = p.UpdatedDate
            }).ToList());

            var projects = await GetProjects();
            var filteredProjects = projects.Where(p => p.Tags.Contains(request.Tag));

            results.AddRange(filteredProjects.Select(p => new SearchResultItem()
            {
                Type = SearchResultItemTypeEnum.Project,
                Title = p.Title,
                Subtitle = p.Subtitle,
                Tags = p.Tags,
                Url = $"project/{p.Slug}",
                CreatedDate = p.CreatedDate,
                UpdatedDate = p.UpdatedDate,
                ImageThumbnailUrl = p.ImageThumbnailUrl
            }).ToList());

            results = results.Shuffle();

            return results;
        }

        public async Task<List<TagCloudItem>> GetTagCloud()
        {
            var tags = new List<TagCloudItem>();

            var blogPosts = await GetBlogPosts();
            var flattedBlogPostTags = blogPosts.SelectMany(p => p.Tags);

            var projects = await GetProjects();
            var flattedProjectTags = projects.SelectMany(p => p.Tags);

            tags = flattedBlogPostTags.Concat(flattedProjectTags).GroupBy(p => p).Select(p =>
            new TagCloudItem
            {
                Tag = p.Key,
                Count = p.Count()
            }).ToList();

            tags = tags.Shuffle(); // randomise order

            return tags;
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
