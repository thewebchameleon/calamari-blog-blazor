using System;
using System.Collections.Generic;
using System.Text;

namespace CB.Blazor.Infrastructure.Configuration
{
    public class EmailConfig
    {
        public bool IsEnabled { get; set; }

        public string APIKey { get; set; }

        public string SystemEmailAddress { get; set; }

        public string SystemEmailName { get; set; }

        public string AdminEmailAddress { get; set; }
    }
}
