using CalamariBlog.Infrastructure.Configuration;
using Microsoft.Extensions.Options;

namespace CalamariBlog.Services.CMS
{
    public abstract class BaseMapper
    {
        protected readonly SquidexSettings _config;

        public BaseMapper(IOptions<SquidexSettings> config)
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
