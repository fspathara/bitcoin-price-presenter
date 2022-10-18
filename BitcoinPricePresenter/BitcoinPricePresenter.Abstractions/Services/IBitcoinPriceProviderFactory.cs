namespace BitcoinPricePresenter.Abstractions.Services
{
    public interface IBitcoinPriceProviderFactory
    {
        IBitcoinPriceProvider GetForSource(SourceEnum source);
    }
}
