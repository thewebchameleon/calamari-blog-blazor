using Newtonsoft.Json;
using Squidex.ClientLibrary;
using System;
using System.Collections.Generic;

namespace CalamariBlog.Infrastructure.Repositories.SquidexRepo.Models
{
    public class BlogPostData
    {
        [JsonConverter(typeof(InvariantConverter))]
        public string Slug { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public string Title { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "sub-title")]
        public string SubTitle { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public List<string> Author { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "publish-date")]
        public DateTime PublishDate { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "body-html")]
        public string BodyHtml { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        public List<string> Tags { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "image-header")]
        public List<string> ImageHeader { get; set; }

        [JsonConverter(typeof(InvariantConverter))]
        [JsonProperty(PropertyName = "meta-description")]
        public string MetaDescription { get; set; }

        public BlogPostData()
        {
            Tags = new List<string>();
            ImageHeader = new List<string>();
            Author = new List<string>();
        }
    }
}