using System;
using System.Collections.Generic;

namespace CB.Blazor.Interface.CMS
{
    public class BlogPost
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string ImageUrl { get; set; }

        public DateTime PublishedDate { get; set; }

        public List<SkillType> Skills { get; set; }

        public BlogPost()
        {
            Skills = new List<SkillType>();
        }
    }
}
