using Newtonsoft.Json;
using Squidex.ClientLibrary;
using System.Collections.Generic;

namespace CB.Blazor.Infrastructure.Repositories.SquidexRepo.Models
{
    public class GlobalData
    {
        [JsonConverter(typeof(InvariantConverter))]
        public string SiteName { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public string Subheading { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public string EmailAddress { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public string AuthorImage { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public string BackgroundImage { get; set; }
    }
}
