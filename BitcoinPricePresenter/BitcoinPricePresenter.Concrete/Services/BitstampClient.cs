using BitcoinPricePresenter.Abstractions.Models.Dtos;
using BitcoinPricePresenter.Abstractions.Services;
using System.Text.Json;

namespace BitcoinPricePresenter.Concrete.Services
{
    public class BitstampClient : BitcoinPriceClient<BitstampPriceModel>, IBitstampClient
    {
        public BitstampClient(HttpClient client,
            ISourcesConfigurationService sourcesConfigurationService)
            : base(client, sourcesConfigurationService)
        {
        }

        public Task<BitstampPriceModel> GetCurrentPriceAsync()
        => GetCurrentPriceAsync(SourceEnum.Bitstamp);

    }
}
