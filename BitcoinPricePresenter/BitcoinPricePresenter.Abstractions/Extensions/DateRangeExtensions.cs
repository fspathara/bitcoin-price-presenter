using BitcoinPricePresenter.Abstractions.Models;

namespace BitcoinPricePresenter.Abstractions.Extensions
{
    public static class DateRangeExtensions
    {
        public static bool IsValid(this DateRange dateRange)
        => dateRange.DateFrom.CompareTo(dateRange.DateTo) <= 0;
    }
}
