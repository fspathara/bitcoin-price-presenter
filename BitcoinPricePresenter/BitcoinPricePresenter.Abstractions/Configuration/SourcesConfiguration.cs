namespace BitcoinPricePresenter.Abstractions.Configuration
{
    public class SourcesConfiguration
    {
        public Dictionary<string, SourceSpecificConfiguration> Sources { get; set; }
    }
}
