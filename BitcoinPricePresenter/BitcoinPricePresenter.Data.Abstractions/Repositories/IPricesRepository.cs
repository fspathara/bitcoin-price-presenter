using BitcoinPricePresenter.Abstractions.Models.DbModels;
using BitcoinPricePresenter.Abstractions.Models.Queries;

namespace BitcoinPricePresenter.Data.Abstractions.Repositories
{
    public interface IPricesRepository
    {
        Task InsertPriceAsync(PriceDbModel price);

        Task<IEnumerable<PriceDbModel>> GetForPeriodAsync(PriceGetQuery query);
    }
}
