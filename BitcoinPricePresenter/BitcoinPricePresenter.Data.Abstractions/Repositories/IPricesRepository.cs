using BitcoinPricePresenter.Abstractions.Models.DbModels;
using BitcoinPricePresenter.Abstractions.Models.Queries;

namespace BitcoinPricePresenter.Data.Abstractions.Repositories
{
    public interface IPricesRepository
    {
        Task<PriceDbModel> InsertPriceAsync(PriceDbModel price);

        Task<List<PriceDbModel>> GetForPeriodAsync(PriceGetQuery query);
    }
}
