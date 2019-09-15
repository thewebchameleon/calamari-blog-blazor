using Newtonsoft.Json;
using Squidex.ClientLibrary;

namespace CalamariBlog.Infrastructure.Repositories.SquidexRepo.Models
{
    public class AuthorData
    {
        [JsonConverter(typeof(InvariantConverter))]
        public string Name { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public string Link { get; set; }
    }
}
