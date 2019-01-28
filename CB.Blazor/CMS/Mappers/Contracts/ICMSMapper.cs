using CB.Blazor.Infrastructure.Repositories.SquidexRepo.Models;
using System.Collections.Generic;
using CB.Blazor.Interface.CMS;

namespace CB.Blazor.CMS.Mappers.Contracts
{
    public interface ICMSMapper
    {
        BlogPost MapToBlogPost(BlogPostEntity model, List<SkillTypeEntity> skills);

        Global MapToGlobal(GlobalEntity model);

        PortfolioProject MapToPortfolioProject(PortfolioProjectEntity model, List<SkillTypeEntity> skills);

        Portfolio MapToPortfolio(PortfolioEntity model, List<PortfolioProject> projects, List<SkillTypeEntity> skills);
    }
}
