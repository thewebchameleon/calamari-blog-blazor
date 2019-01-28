using Newtonsoft.Json;
using Squidex.ClientLibrary;
using System.Collections.Generic;

namespace CB.Blazor.Infrastructure.Repositories.SquidexRepo.Models
{
    public class PortfolioProjectData
    {
        [JsonConverter(typeof(InvariantConverter))]
        public string Name { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public string Description { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "external-url")]
        public string ExternalUrl { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public List<string> Image { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public List<string> Skills { get; set; }

        public PortfolioProjectData()
        {
            Skills = new List<string>();
            Image = new List<string>();
        }
    }
}
