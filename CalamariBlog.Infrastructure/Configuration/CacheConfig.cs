namespace CalamariBlog.Infrastructure.Configuration
{
    public class CacheConfig
    {
        public int ExpiryTimeMinutes { get; set; }

        public bool IsEnabled { get; set; }
    }
}
