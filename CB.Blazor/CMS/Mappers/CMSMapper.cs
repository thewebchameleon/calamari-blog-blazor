using CB.Blazor.CMS.Mappers.Contracts;
using CB.Blazor.Infrastructure.Configuration;
using CB.Blazor.Infrastructure.Repositories.SquidexRepo.Models;
using CB.Blazor.Interface.CMS;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace CB.Blazor.CMS.Mappers
{
    public class CMSMapper : BaseMapper, ICMSMapper
    {
        public CMSMapper(IOptions<SquidexConfig> config) : base(config) { }

        public BlogPost MapToBlogPost(BlogPostEntity model, List<SkillTypeEntity> skills)
        {
            var result = new BlogPost()
            {
                Id = model.Id,
                PublishedDate = model.Created.Date,
                ImageUrl = ResolveAssetURL(model.Data.Image.First()),
                Title = model.Data.Title,
                Body = model.Data.Body,
                Skills = MapToSkills(skills)
            };
            return result;
        }

        public Global MapToGlobal(GlobalEntity model)
        {
            return new Global()
            {
                SiteName = model.Data.SiteName,
                AuthorImage = ResolveAssetURL(model.Data.AuthorImage),
                BackgroundImage = ResolveAssetURL(model.Data.BackgroundImage),
                EmailAddress = model.Data.EmailAddress,
                SubHeading = model.Data.Subheading
            };
        }

        public Portfolio MapToPortfolio(PortfolioEntity model, List<PortfolioProject> projects, List<SkillTypeEntity> skills)
        {
            return new Portfolio()
            {
                Biography = model.Data.Biography,
                CVUrl = ResolveAssetURL(model.Data.CV.First()),
                Projects = projects,
                Skills = MapToSkills(skills)
            };
        }

        private List<SkillType> MapToSkills(List<SkillTypeEntity> model)
        {
            var skills = new List<SkillType>();
            foreach (var skill in model)
            {
                skills.Add(new SkillType()
                {
                    Name = skill.Data.Name,
                    Colour = skill.Data.BlazoriseColour
                });
            }
            return skills;
        }

        public PortfolioProject MapToPortfolioProject(PortfolioProjectEntity model, List<SkillTypeEntity> skills)
        {
            return new PortfolioProject()
            {
                Name = model.Data.Name,
                Description = model.Data.Description,
                ExternalUrl = model.Data.ExternalUrl,
                ImageUrl = ResolveAssetURL(model.Data.Image.First()),
                Id = model.Id,
                Skills = MapToSkills(skills)
            };
        }
    }
}
