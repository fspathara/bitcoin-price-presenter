using BitcoinPricePresenter.Abstractions.Models.DbModels;
using BitcoinPricePresenter.Abstractions.Models.Queries;
using BitcoinPricePresenter.Data.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BitcoinPricePresenter.Data.Repositories
{
    public class PriceRepository : IPricesRepository
    {
        public async Task<List<PriceDbModel>> GetForPeriodAsync(GetPricesQuery query)
        {
            using var context = new RepositoryContext();
            var list = await context.Prices
                .Where(s => s.Timestamp >= query.DateRange.DateFrom && s.Timestamp <= query.DateRange.DateTo)
                .Skip((query.Page - 1) * query.Limit)
                .Take(query.Limit)
                .ToListAsync();
            return list;
        }

        public async Task<PriceDbModel> InsertPriceAsync(PriceDbModel price)
        {
            using var context = new RepositoryContext();

            await context.AddAsync(price);

            await context.SaveChangesAsync();

            return price;
        }
    }
}
