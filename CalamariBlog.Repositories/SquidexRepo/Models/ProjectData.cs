using Newtonsoft.Json;
using Squidex.ClientLibrary;
using System.Collections.Generic;

namespace CalamariBlog.Infrastructure.Repositories.SquidexRepo.Models
{
    public class ProjectData
    {
        [JsonConverter(typeof(InvariantConverter))]
        public string Title { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "sub-title")]
        public string Subtitle { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "external-url")]
        public string ExternalUrl { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "body-html")]
        public string BodyHtml { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "image-thumbnail")]
        public List<string> ImageThumbnail { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "image-header")]
        public List<string> ImageHeader { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "meta-description")]
        public string MetaDescription { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public List<string> Tags { get; set; }

        public ProjectData()
        {
            ImageThumbnail = new List<string>();
            ImageHeader = new List<string>();
            Tags = new List<string>();
        }
    }
}
