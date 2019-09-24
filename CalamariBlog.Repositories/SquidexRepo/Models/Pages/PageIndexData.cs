using Newtonsoft.Json;
using Squidex.ClientLibrary;
using System.Collections.Generic;

namespace CalamariBlog.Infrastructure.Repositories.SquidexRepo.Models.Pages
{
    public class PageIndexData
    {
        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "image-header-index")]
        public List<string> ImageHeaderIndex { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "meta-description")]
        public string MetaDescription { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public string Heading { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "sub-heading")]
        public string Subheading { get; set; }

        public PageIndexData()
        {
            ImageHeaderIndex = new List<string>();
        }
    }
}
