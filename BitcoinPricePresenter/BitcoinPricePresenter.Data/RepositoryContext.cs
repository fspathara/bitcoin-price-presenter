using BitcoinPricePresenter.Abstractions.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace BitcoinPricePresenter.Data
{
    public class RepositoryContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "PricesDb");
        }

        public DbSet<PriceDbModel> Prices { get; set; }
    }
}
