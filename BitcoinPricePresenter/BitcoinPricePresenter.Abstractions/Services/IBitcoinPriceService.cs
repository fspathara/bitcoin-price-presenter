using BitcoinPricePresenter.Abstractions.Models.Queries;
using BitcoinPricePresenter.Abstractions.Models.ViewModels;

namespace BitcoinPricePresenter.Abstractions.Services
{
    public interface IBitcoinPriceService
    {
        Task<PriceViewModel> GetCurrentPriceFromSourceAsync(SourceEnum source);

        Task<List<PriceViewModel>> GetPrices(GetPricesQuery query);
    }
}
