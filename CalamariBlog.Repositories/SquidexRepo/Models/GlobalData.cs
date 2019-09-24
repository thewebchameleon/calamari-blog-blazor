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
        [JsonProperty(PropertyName = "image-favicon")]
        public List<string> ImageFavicon { get; set; }

        public GlobalData()
        {
            ImageFavicon = new List<string>();
        }
    }
}
