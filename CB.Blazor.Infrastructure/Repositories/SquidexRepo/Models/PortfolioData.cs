using Newtonsoft.Json;
using Squidex.ClientLibrary;
using System.Collections.Generic;

namespace CB.Blazor.Infrastructure.Repositories.SquidexRepo.Models
{
    public class PortfolioData
    {
        [JsonConverter(typeof(InvariantConverter))]
        public string Biography { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public List<string> CV { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public List<string> Projects { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public List<string> Skills { get; set; }

        public PortfolioData()
        {
            Projects = new List<string>();
            Skills = new List<string>();
        }
    }
}
