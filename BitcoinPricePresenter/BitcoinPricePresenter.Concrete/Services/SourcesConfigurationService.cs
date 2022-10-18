using BitcoinPricePresenter.Abstractions.Configuration;
using BitcoinPricePresenter.Abstractions.Services;
using Microsoft.Extensions.Options;

namespace BitcoinPricePresenter.Concrete.Services
{
    public class SourcesConfigurationService : ISourcesConfigurationService
    {
        private readonly SourcesConfiguration _sourcesConfiguration;

        public SourcesConfigurationService(IOptions<SourcesConfiguration> sourcesConfiguration)
        {
            _sourcesConfiguration = sourcesConfiguration.Value;
        }

        public SourcesConfiguration GetAll() => _sourcesConfiguration;
         

        public SourceSpecificConfiguration GetConfigurationForSource(string configuration)
        {
            if(!_sourcesConfiguration.Sources.ContainsKey(configuration))
                throw new ArgumentOutOfRangeException(nameof(configuration));

            return _sourcesConfiguration.Sources[configuration];
        }
    }
}
