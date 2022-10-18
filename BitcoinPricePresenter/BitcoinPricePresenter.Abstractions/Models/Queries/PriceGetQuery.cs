namespace BitcoinPricePresenter.Abstractions.Models.Queries
{
    public class PriceGetQuery
    {
        public DateRange DateRange { get; set; } = new();

        public int StartIndex { get; set; }

        public int Limit { get; set; }
    }
}
