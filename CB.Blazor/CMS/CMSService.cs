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

        public async Task<BlogPost> GetBlogPost(string id)
        {
            var posts = await GetItemFromCache(CacheConstants.BlogPosts, () => _repo.GetBlogPosts());
            var post = posts.FirstOrDefault(p => p.Id == id);

            var skills = await GetItemFromCache(CacheConstants.SkillTypes, () => _repo.GetSkillTypes());
            var postSkills = skills.Where(s => post.Data.Skills.Contains(s.Id)).ToList();

            return _mapper.MapToBlogPost(post, postSkills);
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

        public async Task<Global> GetGlobal()
        {
            var config = await GetItemFromCache(CacheConstants.Global, () => _repo.GetGlobal());
            return _mapper.MapToGlobal(config);
        }

        public async Task<Portfolio> GetPortfolio()
        {
            var portfolio = await GetItemFromCache(CacheConstants.Portfolio, () => _repo.GetPortfolio());
            var portfolioProjects = await GetItemFromCache(CacheConstants.PortfolioProjects, () => _repo.GetPortfolioProjects());
            var skills = await GetItemFromCache(CacheConstants.SkillTypes, () => _repo.GetSkillTypes());

            var mappedProjects = new List<PortfolioProject>();
            foreach (var project in portfolioProjects)
            {
                var projectSkills = skills.Where(s => project.Data.Skills.Contains(s.Id)).ToList();
                mappedProjects.Add(_mapper.MapToPortfolioProject(project, projectSkills));
            }

            return _mapper.MapToPortfolio(portfolio, mappedProjects, skills);
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
