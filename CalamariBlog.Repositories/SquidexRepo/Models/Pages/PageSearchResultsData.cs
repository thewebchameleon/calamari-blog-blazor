using Newtonsoft.Json;
using Squidex.ClientLibrary;
using System.Collections.Generic;

namespace CalamariBlog.Infrastructure.Repositories.SquidexRepo.Models.Pages
{
    public class PageSearchResultsData
    {
        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "image-header-search-results")]
        public List<string> ImageHeaderSearchResults { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "meta-description")]
        public string MetaDescription { get; set; }

        public PageSearchResultsData()
        {
            ImageHeaderSearchResults = new List<string>();
        }
    }
}
