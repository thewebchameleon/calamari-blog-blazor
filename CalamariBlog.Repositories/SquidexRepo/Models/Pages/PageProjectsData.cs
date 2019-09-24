using Newtonsoft.Json;
using Squidex.ClientLibrary;
using System.Collections.Generic;

namespace CalamariBlog.Infrastructure.Repositories.SquidexRepo.Models.Pages
{
    public class PageProjectsData
    {
        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "image-header-projects")]
        public List<string> ImageHeaderProjects { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "meta-description")]
        public string MetaDescription { get; set; }

        public PageProjectsData()
        {
            ImageHeaderProjects = new List<string>();
        }
    }
}
