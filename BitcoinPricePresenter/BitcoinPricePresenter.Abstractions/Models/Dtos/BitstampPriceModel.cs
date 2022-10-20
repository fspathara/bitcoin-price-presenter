using System.Text.Json.Serialization;

namespace BitcoinPricePresenter.Abstractions.Models.Dtos
{
    public class BitstampPriceModel
    {
        [JsonPropertyName("timestamp")]
        public string Timestamp { get; set; }
        [JsonPropertyName("open")]
        public string Price { get; set; }
        [JsonPropertyName("high")]
        public string HighestPrice { get; set; }
        [JsonPropertyName("low")]
        public string LowestPrice { get; set; }
        [JsonPropertyName("percent_change_24")]
        public string PercentChange24h { get; set; }
    }

}
