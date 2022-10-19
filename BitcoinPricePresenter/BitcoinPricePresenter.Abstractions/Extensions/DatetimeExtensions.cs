using System.Globalization;

namespace BitcoinPricePresenter.Abstractions
{
    public static class DatetimeExtensions
    {
        public static readonly DateTime unixStart = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime FromUnixTimestamp(this long unixTimestamp)
        {
            var dateTime = unixStart.AddSeconds(unixTimestamp).ToUniversalTime();
            return dateTime;
        }

        public static long ToTimestamp(this string utcTimestamp)
        {
            var decimalNumber = decimal.Parse(utcTimestamp, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, CultureInfo.InvariantCulture);
            return (long)Math.Truncate(decimalNumber);
        }
    }
}
