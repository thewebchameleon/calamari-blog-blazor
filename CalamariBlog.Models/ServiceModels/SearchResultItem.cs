using CalamariBlog.Models.CMS;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalamariBlog.Models.ServiceModels
{
    public class SearchResultItem
    {
        public string Url { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public Author Author { get; set; }

        public List<string> Tags { get; set; }

        public DateTime? PublishedDate { get; set; }

        public SearchResultItem()
        {
            Tags = new List<string>();
        }
    }
}
