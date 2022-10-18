using BitcoinPricePresenter.Abstractions.Models.Dtos;

namespace BitcoinPricePresenter.Abstractions.Services
{
    public interface IBitfinexClient
    {
        Task<BitfinexPriceModel> GetCurrentPriceAsync();
    }
}
