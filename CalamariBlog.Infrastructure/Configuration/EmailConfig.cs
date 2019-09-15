namespace CalamariBlog.Infrastructure.Configuration
{
    public class EmailConfig
    {
        public bool IsEnabled { get; set; }

        public SendGridConfig SendGrid { get; set; }

        public string SystemEmailAddress { get; set; }

        public string SystemEmailName { get; set; }

        public string RecipientEmailAddress { get; set; }
    }
}
