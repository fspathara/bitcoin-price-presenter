using BitcoinPricePresenter.Abstractions.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace BitcoinPricePresenter.Data
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {

        }

        public DbSet<PriceDbModel> Prices { get; set; }
    }
}
