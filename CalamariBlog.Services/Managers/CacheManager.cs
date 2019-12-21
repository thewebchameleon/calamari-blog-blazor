using CalamariBlog.Infrastructure.Cache;
using CalamariBlog.Infrastructure.Cache.Contracts;
using CalamariBlog.Infrastructure.Repositories.SquidexRepo.Contracts;
using CalamariBlog.Infrastructure.Repositories.SquidexRepo.Models;
using CalamariBlog.Infrastructure.Repositories.SquidexRepo.Models.Pages;
using CalamariBlog.Services.Managers.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CalamariBlog.Services.Managers
{
    public class CacheManager : ICacheManager
    {
        #region Instance Fields

        private readonly ICacheProvider _cacheProvider;
        private readonly ISquidexRepo _squidexRepo;

        #endregion

        #region Constructor

        public CacheManager(
            ICacheProvider cacheProvider,
            ISquidexRepo squidexRepo
        )
        {
            _cacheProvider = cacheProvider;
            _squidexRepo = squidexRepo;
        }

        #endregion

        #region Public Methods

        public async Task<List<AuthorEntity>> GetAuthors()
        {
            if (_cacheProvider.TryGet(CacheConstants.SquidexSchemas.Authors, out List<AuthorEntity> items))
            {
                return items;
            }

            items = await _squidexRepo.GetAuthors();
            _cacheProvider.Set(CacheConstants.SquidexSchemas.Authors, items);

            return items;
        }

        public async Task<List<BlogPostEntity>> GetBlogPosts(int page = 0, int pageSize = 999)
        {
            if (_cacheProvider.TryGet(CacheConstants.SquidexSchemas.BlogPosts, out List<BlogPostEntity> items))
            {
                return items;
            }

            items = await _squidexRepo.GetBlogPosts(page, pageSize);
            _cacheProvider.Set(CacheConstants.SquidexSchemas.BlogPosts, items);

            return items;
        }

        public async Task<GlobalEntity> GetGlobal()
        {
            if (_cacheProvider.TryGet(CacheConstants.SquidexSchemas.Global, out GlobalEntity item))
            {
                return item;
            }

            item = await _squidexRepo.GetGlobal();
            _cacheProvider.Set(CacheConstants.SquidexSchemas.Global, item);

            return item;
        }

        public async Task<PageAboutEntity> GetPage_About()
        {
            if (_cacheProvider.TryGet(CacheConstants.SquidexSchemas.Pages.About, out PageAboutEntity item))
            {
                return item;
            }

            item = await _squidexRepo.GetPage_About();
            _cacheProvider.Set(CacheConstants.SquidexSchemas.Pages.About, item);

            return item;
        }

        public async Task<PageContactEntity> GetPage_Contact()
        {
            if (_cacheProvider.TryGet(CacheConstants.SquidexSchemas.Pages.Contact, out PageContactEntity item))
            {
                return item;
            }

            item = await _squidexRepo.GetPage_Contact();
            _cacheProvider.Set(CacheConstants.SquidexSchemas.Pages.Contact, item);

            return item;
        }

        public async Task<PageIndexEntity> GetPage_Index()
        {
            if (_cacheProvider.TryGet(CacheConstants.SquidexSchemas.Pages.Index, out PageIndexEntity item))
            {
                return item;
            }

            item = await _squidexRepo.GetPage_Index();
            _cacheProvider.Set(CacheConstants.SquidexSchemas.Pages.Index, item);

            return item;
        }

        public async Task<PageProjectsEntity> GetPage_Projects()
        {
            if (_cacheProvider.TryGet(CacheConstants.SquidexSchemas.Pages.Projects, out PageProjectsEntity item))
            {
                return item;
            }

            item = await _squidexRepo.GetPage_Projects();
            _cacheProvider.Set(CacheConstants.SquidexSchemas.Pages.Projects, item);

            return item;
        }

        public async Task<PageSearchResultsEntity> GetPage_SearchResults()
        {
            if (_cacheProvider.TryGet(CacheConstants.SquidexSchemas.Pages.SearchResults, out PageSearchResultsEntity item))
            {
                return item;
            }

            item = await _squidexRepo.GetPage_SearchResults();
            _cacheProvider.Set(CacheConstants.SquidexSchemas.Pages.SearchResults, item);

            return item;
        }

        public async Task<List<ProjectEntity>> GetProjects(int page = 0, int pageSize = 999)
        {
            if (_cacheProvider.TryGet(CacheConstants.SquidexSchemas.Projects, out List<ProjectEntity> items))
            {
                return items;
            }

            items = await _squidexRepo.GetProjects(page, pageSize);
            _cacheProvider.Set(CacheConstants.SquidexSchemas.Projects, items);

            return items;
        }

        #endregion
    }
}
