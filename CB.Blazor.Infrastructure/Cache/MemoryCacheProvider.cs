using CB.Blazor.Infrastructure.Configuration;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System;

namespace CB.Blazor.Infrastructure.Cache
{
    public class MemoryCacheProvider : ICacheProvider
    {
        private readonly IMemoryCache _cache;
        private readonly CacheConfig _config;

        public MemoryCacheProvider(IMemoryCache memoryCache, IOptions<CacheConfig> settings)
        {
            _cache = memoryCache;
            _config = settings.Value;
        }
        
        public bool TryGetItem<T>(string id, out T value)
        {
            if (_cache.TryGetValue(id, out value))
            {
                return true;
            }
            return false;
        }

        public T SetItem<T>(string key, T value)
        {
            return _cache.Set(key, value, TimeSpan.FromMinutes(_config.ExpiryTimeMinutes));
        }

        public void Clear(string key)
        {
            _cache.Remove(key);
        }
    }
}
