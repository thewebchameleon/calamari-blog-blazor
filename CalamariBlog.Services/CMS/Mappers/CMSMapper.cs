using CalamariBlog.Services.CMS.Mappers.Contracts;
using CalamariBlog.Infrastructure.Configuration;
using CalamariBlog.Infrastructure.Repositories.SquidexRepo.Models;
using CalamariBlog.Models.CMS;
using Microsoft.Extensions.Options;
using System.Linq;
using CalamariBlog.Infrastructure.Repositories.SquidexRepo.Models.Pages;
using CalamariBlog.Models.CMS.Pages;

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
                LinkFacebook = model.Data.LinkFacebook,
                LinkGithub = model.Data.LinkGithub,
                LinkTwitter = model.Data.LinkTwitter,
                LinkLinkedIn = model.Data.LinkLinkedIn,
                ImageFavicon = ResolveAssetURL(model.Data.ImageFavicon.First())
            };
        }

        public PageAbout MapToPage_About(PageAboutEntity model)
        {
            return new PageAbout()
            {
                BiographyHtml = model.Data.BiographyHtml,
                CVUrl = ResolveAssetURL(model.Data.CVUrl.First()),
                ImageHeaderAbout = ResolveAssetURL(model.Data.ImageHeaderAbout.First()),
                MetaDescription = model.Data.MetaDescription
            };
        }

        public PageContact MapToPage_Contact(PageContactEntity model)
        {
            return new PageContact()
            {
                EmailAddress = model.Data.EmailAddress,
                MetaDescription = model.Data.MetaDescription,
                ImageHeaderContact = ResolveAssetURL(model.Data.ImageHeaderContact.First())
            };
        }

        public PageIndex MapToPage_Index(PageIndexEntity model)
        {
            return new PageIndex()
            {
                ImageHeaderIndex = ResolveAssetURL(model.Data.ImageHeaderIndex.First()),
                MetaDescription = model.Data.MetaDescription,
                Heading = model.Data.Heading,
                Subheading = model.Data.Subheading
            };
        }

        public PageProjects MapToPage_Projects(PageProjectsEntity model)
        {
            return new PageProjects()
            {
                ImageHeaderProjects = ResolveAssetURL(model.Data.ImageHeaderProjects.First()),
                MetaDescription = model.Data.MetaDescription
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
