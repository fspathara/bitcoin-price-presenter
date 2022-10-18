namespace BitcoinPricePresenter.Abstractions.Configuration
{
    public class SourceSpecificConfiguration
    {
        public string BaseUrl { get; set; } = string.Empty;

        public string GetPriceUrl { get; set; } = string.Empty;
    }
}
