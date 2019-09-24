using CalamariBlog.Infrastructure.Repositories.SquidexRepo.Models;
using CalamariBlog.Infrastructure.Repositories.SquidexRepo.Models.Pages;
using CalamariBlog.Models.CMS;
using CalamariBlog.Models.CMS.Pages;

namespace CalamariBlog.Services.CMS.Mappers.Contracts
{
    public interface ICMSMapper
    {
        BlogPost MapToBlogPost(BlogPostEntity model, AuthorEntity author);

        Global MapToGlobal(GlobalEntity model);

        Project MapToProject(ProjectEntity model);

        PageAbout MapToPage_About(PageAboutEntity model);

        PageContact MapToPage_Contact(PageContactEntity model);

        PageIndex MapToPage_Index(PageIndexEntity model);

        PageProjects MapToPage_Projects(PageProjectsEntity model);
    }
}
