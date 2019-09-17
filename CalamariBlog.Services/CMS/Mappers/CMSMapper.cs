using CalamariBlog.Services.CMS.Mappers.Contracts;
using CalamariBlog.Infrastructure.Configuration;
using CalamariBlog.Infrastructure.Repositories.SquidexRepo.Models;
using CalamariBlog.Models.CMS;
using Microsoft.Extensions.Options;
using System.Linq;

namespace CalamariBlog.Services.CMS.Mappers
{
    public class CMSMapper : BaseMapper, ICMSMapper
    {
        public CMSMapper(IOptions<SquidexConfig> config) : base(config) { }

        public BlogPost MapToBlogPost(BlogPostEntity model, AuthorEntity author)
        {
            var result = new BlogPost()
            {
                Id = model.Id,
                PublishedDate = model.Data.PublishDate,
                ImageHeaderUrl = ResolveAssetURL(model.Data.ImageHeader.First()),
                Title = model.Data.Title,
                Tags = model.Data.Tags,
                SubTitle = model.Data.SubTitle,
                BodyHtml = model.Data.BodyHtml,
                Author = new Author()
                {
                    Name = author.Data.Name,
                    Link = author.Data.Link
                }
            };

            return result;
        }

        public Global MapToGlobal(GlobalEntity model)
        {
            return new Global()
            {
                SiteName = model.Data.SiteName,
                CVUrl = ResolveAssetURL(model.Data.CVUrl.First()),
                LinkFacebook = model.Data.LinkFacebook,
                LinkGithub = model.Data.LinkGithub,
                LinkTwitter = model.Data.LinkTwitter,
                EmailAddress = model.Data.EmailAddress,
                SubHeading = model.Data.Subheading,
                Heading = model.Data.Heading,
                LinkLinkedIn = model.Data.LinkLinkedIn,
                BiographyHtml = model.Data.BiographyHtml,
                ImageFavicon = ResolveAssetURL(model.Data.ImageFavicon.First()),
                ImageHeaderAbout = ResolveAssetURL(model.Data.ImageHeaderAbout.First()),
                ImageHeaderContact = ResolveAssetURL(model.Data.ImageHeaderContact.First()),
                ImageHeaderIndex = ResolveAssetURL(model.Data.ImageHeaderIndex.First()),
                ImageHeaderProjects = ResolveAssetURL(model.Data.ImageHeaderProjects.First())
            };
        }

        public Project MapToProject(ProjectEntity model)
        {
            return new Project()
            {
                Title = model.Data.Title,
                BodyHtml = model.Data.BodyHtml,
                ExternalUrl = model.Data.ExternalUrl,
                ImageHeaderUrl = ResolveAssetURL(model.Data.ImageHeader.First()),
                ImageThumbnailUrl = ResolveAssetURL(model.Data.ImageThumbnail.First()),
                Subtitle = model.Data.Subtitle,
                Id = model.Id,
                CreatedDate = model.Created.Date
            };
        }
    }
}
