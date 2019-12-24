namespace CalamariBlog.Infrastructure.Configuration
{
    public class EmailSettings
    {
        public bool IsEnabled { get; set; }

        public SendGridSettings SendGrid { get; set; }

        public string SystemEmailAddress { get; set; }

        public string SystemEmailName { get; set; }

        public string RecipientEmailAddress { get; set; }
    }
}
