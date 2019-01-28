using System.Collections.Generic;

namespace CB.Blazor.Interface.CMS
{
    public class Portfolio
    {
        public string Biography { get; set; }

        public string CVUrl { get; set; }

        public List<PortfolioProject> Projects { get; set; }

        public List<SkillType> Skills { get; set; }

        public Portfolio()
        {
            Projects = new List<PortfolioProject>();
            Skills = new List<SkillType>();
        }
    }
}
