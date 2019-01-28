using System.Collections.Generic;

namespace CB.Blazor.Interface.CMS
{
    public class PortfolioProject
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ExternalUrl { get; set; }

        public string ImageUrl { get; set; }

        public List<SkillType> Skills { get; set; }

        public PortfolioProject()
        {
            Skills = new List<SkillType>();
        }
    }
}
