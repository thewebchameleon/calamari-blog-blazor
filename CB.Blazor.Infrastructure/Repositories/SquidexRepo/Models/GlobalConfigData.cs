using Newtonsoft.Json;
using Squidex.ClientLibrary;
using System.Collections.Generic;

namespace CB.Blazor.Infrastructure.Repositories.SquidexRepo.Models
{
    public class GlobalConfigData
    {
        [JsonConverter(typeof(InvariantConverter))]
        public List<string> HeartIcon { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public string Name { get; set; }

        public GlobalConfigData()
        {
            HeartIcon = new List<string>();
        }
    }
}
