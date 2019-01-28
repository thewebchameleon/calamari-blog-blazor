using Newtonsoft.Json;
using Squidex.ClientLibrary;
using System.Collections.Generic;

namespace CB.Blazor.Infrastructure.Repositories.SquidexRepo.Models
{
    public class GlobalData
    {
        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "site-name")]
        public string SiteName { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public string Subheading { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "email-address")]
        public string EmailAddress { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "author-image")]
        public List<string> AuthorImage { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "background-image")]
        public List<string> BackgroundImage { get; set; }
    }
}
