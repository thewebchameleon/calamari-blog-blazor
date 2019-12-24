namespace CalamariBlog.Infrastructure.Configuration
{
    public sealed class SquidexSettings
    {
        public string AppName { get; set; }

        public string Url { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string WebHookAssetSecret { get; set; }

        public string WebHookContentSecret { get; set; }
    }
}
