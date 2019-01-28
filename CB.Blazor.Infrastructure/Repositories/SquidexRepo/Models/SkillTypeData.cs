using Newtonsoft.Json;
using Squidex.ClientLibrary;
using System.Collections.Generic;

namespace CB.Blazor.Infrastructure.Repositories.SquidexRepo.Models
{
    public class SkillTypeData
    {
        [JsonConverter(typeof(InvariantConverter))]
        public string Name { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "blazorise-colour")]
        public string BlazoriseColour { get; set; }
    }
}
