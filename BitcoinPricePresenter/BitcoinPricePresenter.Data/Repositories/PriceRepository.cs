using BitcoinPricePresenter.Abstractions.Models.DbModels;
using BitcoinPricePresenter.Abstractions.Models.Queries;
using BitcoinPricePresenter.Data.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BitcoinPricePresenter.Data.Repositories
{
    public class PriceRepository : IPricesRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public PriceRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<List<PriceDbModel>> GetForPeriodAsync(GetPricesQuery query)
        {
            var list = await _repositoryContext.Prices
                .Where(s => s.Timestamp >= query.DateRange.DateFrom && s.Timestamp <= query.DateRange.DateTo)
                .Skip((query.Page - 1) * query.Limit)
                .Take(query.Limit)
                .ToListAsync();
            return list;
        }

        public async Task<PriceDbModel> InsertPriceAsync(PriceDbModel price)
        {
            await _repositoryContext.AddAsync(price);

            await _repositoryContext.SaveChangesAsync();

            return price;
        }
    }
}
