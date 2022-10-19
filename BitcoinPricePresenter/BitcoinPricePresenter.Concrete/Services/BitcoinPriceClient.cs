using BitcoinPricePresenter.Abstractions.Models.Dtos;
using BitcoinPricePresenter.Abstractions.Services;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BitcoinPricePresenter.Concrete.Services
{
    public abstract class BitcoinPriceClient<TResponse>
    {
        protected readonly HttpClient HttpClient;
        protected readonly ISourcesConfigurationService SourcesConfigurationService;

        private static readonly Lazy<JsonSerializerOptions> options = new Lazy<JsonSerializerOptions>(() =>
        {
            var options = new JsonSerializerOptions();
            return options;
        });
        public BitcoinPriceClient(HttpClient httpClient, ISourcesConfigurationService sourcesConfigurationService)
        {
            HttpClient = httpClient;
            SourcesConfigurationService = sourcesConfigurationService;
        }

        public virtual async Task<TResponse> GetCurrentPriceAsync(SourceEnum source)
        {
            var configuration = SourcesConfigurationService.GetConfigurationForSource(source.ToString());
            var response = await HttpClient.GetAsync(configuration.GetPriceUrl, CancellationToken.None);
            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync();
            var price = await JsonSerializer.DeserializeAsync<TResponse>(stream, options.Value);

            if (price is null)
            {
                throw new InvalidCastException($"Could not parse {nameof(BitstampClient)} response to {nameof(BitstampPriceModel)}");
            }

            return price;
        }
    }
}
