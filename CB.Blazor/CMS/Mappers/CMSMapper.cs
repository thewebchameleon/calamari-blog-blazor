using CB.Blazor.Infrastructure.Configuration;
using CB.Blazor.Infrastructure.Repositories.SquidexRepo.Models;
using CB.Blazor.CMS.Mappers.Contracts;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using CB.Blazor.Interface.CMS;

namespace CB.Blazor.CMS.Mappers
{
    public class CMSMapper : BaseMapper, ICMSMapper
    {
        public CMSMapper(IOptions<SquidexConfig> config) : base(config) { }

        public List<BlogCategory> MapToBlogCategories(List<BlogCategoryEntity> model)
        {
            var result = new List<BlogCategory>();
            foreach (var category in model)
            {
                result.Add(MapToBlogCategory(category));
            }
            return result;
        }

        public BlogCategory MapToBlogCategory(BlogCategoryEntity model)
        {
            var result = new BlogCategory()
            {
                Id = model.Id,
                Name = model.Data.Name,
                Icon = ResolveAssetURL(model.Data.Icons.FirstOrDefault())
            };
            return result;
        }

        public BlogPost MapToBlogPost(BlogPostEntity model, BlogCategoryEntity category, List<BlogPostTagEntity> tags)
        {
            var result = new BlogPost()
            {
                Id = model.Id,
                PublishedDate = model.Created.Date,
                Title = model.Data.Title,
                Body = model.Data.Body,
                Category = MapToBlogCategory(category),
                Tags = MapToBlogPostTags(tags)
            };
            return result;
        }

        public BlogPostTag MapToBlogPostTag(BlogPostTagEntity model)
        {
            var result = new BlogPostTag()
            {
                Id = model.Id,
                Name = model.Data.Name,
                Description = model.Data.Description
            };
            return result;
        }

        public List<BlogPostTag> MapToBlogPostTags(List<BlogPostTagEntity> model)
        {
            var result = new List<BlogPostTag>();
            foreach (var tag in model)
            {
                result.Add(MapToBlogPostTag(tag));
            }
            return result;
        }

        public GlobalConfig MapToGlobalConfig(GlobalConfigEntity model)
        {
            return new GlobalConfig()
            {
                HeartIconUrl = ResolveAssetURL(model.Data.HeartIcon.First()),
                ApplicationName = model.Data.Name
            };
        }

        public Portfolio MapToProfile(ProfileEntity model)
        {
            return new Portfolio()
            {
                Portrait = ResolveAssetURL(model.Data.Portrait.FirstOrDefault()),
                Title = model.Data.Title,
                Name = model.Data.Name,
                Body = model.Data.Body
            };
        }
    }
}
