using System;
using System.Collections.Generic;

namespace CalamariBlog.Models.CMS
{
    public class Project
    {
        public string Slug { get; set; }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string ExternalUrl { get; set; }

        public string ImageThumbnailUrl { get; set; }

        public string ImageHeaderUrl { get; set; }

        public string BodyHtml { get; set; }

        public string MetaDescription { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<string> Tags { get; set; }

        public Project()
        {
            Tags = new List<string>();
        }
    }
}
