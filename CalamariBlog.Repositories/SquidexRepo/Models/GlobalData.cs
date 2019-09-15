using Newtonsoft.Json;
using Squidex.ClientLibrary;
using System.Collections.Generic;

namespace CalamariBlog.Infrastructure.Repositories.SquidexRepo.Models
{
    public class GlobalData
    {
        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "site-name")]
        public string SiteName { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public string Heading { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "sub-heading")]
        public string Subheading { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "email-address")]
        public string EmailAddress { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "link-github")]
        public string LinkGithub { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "link-twitter")]
        public string LinkTwitter { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "link-facebook")]
        public string LinkFacebook { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "link-linkedin")]
        public string LinkLinkedIn { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "cv-url")]
        public List<string> CVUrl { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "image-header-contact")]
        public List<string> ImageHeaderContact { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "image-header-index")]
        public List<string> ImageHeaderIndex { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "image-header-projects")]
        public List<string> ImageHeaderProjects { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "image-header-about")]
        public List<string> ImageHeaderAbout { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "image-favicon")]
        public List<string> ImageFavicon { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "biography-html")]
        public string BiographyHtml { get; set; }

        public GlobalData()
        {
            ImageFavicon = new List<string>();
            ImageHeaderContact = new List<string>();
            ImageHeaderIndex = new List<string>();
            ImageHeaderProjects = new List<string>();
            ImageHeaderAbout = new List<string>();
            CVUrl = new List<string>();
        }
    }
}
