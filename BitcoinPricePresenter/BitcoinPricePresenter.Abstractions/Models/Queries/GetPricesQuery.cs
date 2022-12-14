namespace BitcoinPricePresenter.Abstractions.Models.Queries
{
    public class GetPricesQuery
    {
        public DateRange DateRange { get; set; } = new();

        public int Page { get; set; } = 1;

        public int Limit { get; set; } = 10;
    }
}
