using Newtonsoft.Json;
using Squidex.ClientLibrary;
using System.Collections.Generic;

namespace CalamariBlog.Infrastructure.Repositories.SquidexRepo.Models.Pages
{
    public class PageAboutData
    {
        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "cv-url")]
        public List<string> CVUrl { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "image-header-about")]
        public List<string> ImageHeaderAbout { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "biography-html")]
        public string BiographyHtml { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "meta-description")]
        public string MetaDescription { get; set; }

        public PageAboutData()
        {
            CVUrl = new List<string>();
            ImageHeaderAbout = new List<string>();
        }
    }
}
