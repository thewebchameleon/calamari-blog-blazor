namespace CalamariBlog.Infrastructure.Cache
{
    /// <summary>
    /// Theses should match the schema keys defined in Squidex
    /// </summary>
    public class CacheConstants
    {
        public class SquidexSchemas
        {
            public const string Projects = "projects";
            public const string BlogPosts = "blog-posts";
            public const string Global = "global";
            public const string Authors = "authors";

            public class Pages
            {
                public const string Projects = "page-projects";
                public const string Contact = "page-contact";
                public const string About = "page-about";
                public const string Index = "page-index";
            }
        }
    }
}
