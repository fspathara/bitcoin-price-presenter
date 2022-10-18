namespace BitcoinPricePresenter.Abstractions.Models.DbModels
{
    public class PriceDbModel
    {
        public SourceEnum Source { get; set; }

        public DateTime Timestamp { get; set; }

        public decimal Price { get; set; }
    }
}
