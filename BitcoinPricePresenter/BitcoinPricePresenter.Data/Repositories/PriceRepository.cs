using BitcoinPricePresenter.Abstractions.Models.DbModels;
using BitcoinPricePresenter.Abstractions.Models.Queries;
using BitcoinPricePresenter.Data.Abstractions.Repositories;

namespace BitcoinPricePresenter.Data.Repositories
{
    public class PriceRepository : IPricesRepository
    {
        public Task<IEnumerable<PriceDbModel>> GetForPeriodAsync(PriceGetQuery query)
        {
            return new ValueTask<IEnumerable<PriceDbModel>>().AsTask();
        }

        public Task InsertPriceAsync(PriceDbModel price)
        {
            return Task.CompletedTask;
        }
    }
}
