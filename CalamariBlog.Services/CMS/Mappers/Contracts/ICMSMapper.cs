using CalamariBlog.Infrastructure.Repositories.SquidexRepo.Models;
using CalamariBlog.Models.CMS;

namespace CalamariBlog.Services.CMS.Mappers.Contracts
{
    public interface ICMSMapper
    {
        BlogPost MapToBlogPost(BlogPostEntity model, AuthorEntity author);

        Global MapToGlobal(GlobalEntity model);

        Project MapToProject(ProjectEntity model);
    }
}
