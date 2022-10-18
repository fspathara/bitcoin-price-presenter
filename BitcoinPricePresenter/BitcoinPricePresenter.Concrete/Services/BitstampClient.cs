using BitcoinPricePresenter.Abstractions.Models.Dtos;
using BitcoinPricePresenter.Abstractions.Services;
using System.Text.Json;

namespace BitcoinPricePresenter.Concrete.Services
{
    public class BitstampClient : BitcoinPriceClient<BitstampPriceModel>, IBitstampClient
    {
        protected readonly HttpClient HttpClient;
        protected readonly ISourcesConfigurationService SourcesConfigurationService;

        public BitstampClient(HttpClient client,
            ISourcesConfigurationService sourcesConfigurationService)
        //protected BitstampClient(HttpClient httpClient, ISourcesConfigurationService sourcesConfigurationService)
            : base(client, sourcesConfigurationService)
        {
            //HttpClient = client;
            //SourcesConfigurationService = sourcesConfigurationService;
        }

        public Task<BitstampPriceModel> GetCurrentPriceAsync()
        => GetCurrentPriceAsync(SourceEnum.Bitstamp);

    }
}
