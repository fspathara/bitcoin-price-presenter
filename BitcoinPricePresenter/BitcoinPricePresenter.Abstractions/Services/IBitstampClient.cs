using BitcoinPricePresenter.Abstractions.Models.Dtos;

namespace BitcoinPricePresenter.Abstractions.Services
{
    public interface IBitstampClient
    {
        Task<BitstampPriceModel> GetCurrentPriceAsync();
    }
}
