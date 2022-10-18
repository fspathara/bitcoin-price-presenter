using BitcoinPricePresenter.Abstractions.Configuration;

namespace BitcoinPricePresenter.Abstractions.Services
{
    public interface ISourcesConfigurationService
    {
        SourcesConfiguration GetAll();

        SourceSpecificConfiguration GetConfigurationForSource(string configuration);
    }
}
