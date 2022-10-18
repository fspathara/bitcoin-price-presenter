namespace BitcoinPricePresenter.Abstractions.Models.ViewModels
{
    public class PriceViewModel
    {
        public decimal Price { get; set; }

        public DateTime Timestamp { get; set; }

        public SourceEnum Source { get; set; }

    }
}
