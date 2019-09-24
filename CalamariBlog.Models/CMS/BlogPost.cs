using System;
using System.Collections.Generic;

namespace CalamariBlog.Models.CMS
{
    public class BlogPost
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public Author Author { get; set; }

        public DateTime PublishedDate { get; set; }

        public string BodyHtml { get; set; }

        public string ImageHeaderUrl { get; set; }

        public List<string> Tags { get; set; }

        public string MetaDescription { get; set; }

        public BlogPost()
        {
            Tags = new List<string>();
        }
    }
}
