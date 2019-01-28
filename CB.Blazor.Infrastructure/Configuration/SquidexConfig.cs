namespace CB.Blazor.Infrastructure.Configuration
{
    public sealed class SquidexConfig
    {
        public string AppName { get; set; }

        public string Url { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string WebHookAssetSecret { get; set; }

        public string WebHookContentSecret { get; set; }
    }
}
