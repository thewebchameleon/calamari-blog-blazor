using CalamariBlog.Models.CMS;
using System;
using System.Collections.Generic;

namespace CalamariBlog.Models.ServiceModels
{
    public class SearchResultItem
    {
        public SearchResultItemTypeEnum Type { get; set; }

        public string Url { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public Author Author { get; set; }

        public List<string> Tags { get; set; }

        public DateTime? PublishedDate { get; set; }

        public string ImageThumbnailUrl { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public SearchResultItem()
        {
            Tags = new List<string>();
        }
    }

    public enum SearchResultItemTypeEnum
    {
        Undefined = 0,
        BlogPost = 1,
        Project = 2
    }
}
