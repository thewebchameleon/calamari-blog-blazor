using CB.Blazor.Infrastructure.Configuration;
using Microsoft.Extensions.Options;

namespace CB.Blazor.CMS
{
    public abstract class BaseMapper
    {
        protected readonly SquidexConfig _config;

        public BaseMapper(IOptions<SquidexConfig> config)
        {
            _config = config.Value;
        }

        public string ResolveAssetURL(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return string.Empty;
            }
            return $"{_config.Url}/api/assets/{id}";
        }
    }
}
