using Newtonsoft.Json;
using Squidex.ClientLibrary;
using System.Collections.Generic;

namespace CB.Blazor.Infrastructure.Repositories.SquidexRepo.Models
{
    public class BlogPostData
    {
        [JsonConverter(typeof(InvariantConverter))]
        public string Title { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public string Body { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public List<string> Categories { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public List<string> Tags { get; set; }

        public BlogPostData()
        {
            Tags = new List<string>();
            Categories = new List<string>();
        }
    }
}
