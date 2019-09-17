using System;

namespace CalamariBlog.Models.CMS
{
    public class Project
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string ExternalUrl { get; set; }

        public string ImageThumbnailUrl { get; set; }

        public string ImageHeaderUrl { get; set; }

        public string BodyHtml { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
