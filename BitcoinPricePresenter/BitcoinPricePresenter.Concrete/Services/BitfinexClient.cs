using BitcoinPricePresenter.Abstractions.Models.Dtos;
using BitcoinPricePresenter.Abstractions.Services;

namespace BitcoinPricePresenter.Concrete.Services
{
    public class BitfinexClient : BitcoinPriceClient<BitfinexPriceModel>, IBitfinexClient
    {
        public BitfinexClient(HttpClient httpClient, ISourcesConfigurationService sourcesConfigurationService)
            : base(httpClient, sourcesConfigurationService)
        {
        }

        public Task<BitfinexPriceModel> GetCurrentPriceAsync()
            => GetCurrentPriceAsync(SourceEnum.Bitfinex);
    }
}
