using Newtonsoft.Json;
using Squidex.ClientLibrary;
using System.Collections.Generic;

namespace CalamariBlog.Infrastructure.Repositories.SquidexRepo.Models.Pages
{
    public class PageContactData
    {
        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "email-address")]
        public string EmailAddress { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "image-header-contact")]
        public List<string> ImageHeaderContact { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "meta-description")]
        public string MetaDescription { get; set; }

        public PageContactData()
        {
            ImageHeaderContact = new List<string>();
        }
    }
}
