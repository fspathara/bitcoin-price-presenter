namespace BitcoinPricePresenter.Abstractions
{
    public static class DatetimeExtensions
    {
        public static DateTime FromUnixTimestamp(this long unixTimestamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds((double)unixTimestamp).ToLocalTime();
            return dateTime;
        }

    }
}
