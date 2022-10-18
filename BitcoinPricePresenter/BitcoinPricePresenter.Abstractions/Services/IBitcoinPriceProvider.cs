using BitcoinPricePresenter.Abstractions.Models.Dtos;

namespace BitcoinPricePresenter.Abstractions.Services
{
    public interface IBitcoinPriceProvider
    {
        Task<PriceModel> GetCurrentPriceAsync();
    }
}
