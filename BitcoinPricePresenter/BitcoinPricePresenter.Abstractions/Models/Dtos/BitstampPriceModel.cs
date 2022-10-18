using System.Text.Json.Serialization;

namespace BitcoinPricePresenter.Abstractions.Models.Dtos
{
    public class BitstampPriceModel
    {
        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }
        [JsonPropertyName("open")]
        public decimal Price { get; set; }
        [JsonPropertyName("high")]
        public decimal HighestPrice { get; set; }
        [JsonPropertyName("low")]
        public string LowestPrice { get; set; }
        [JsonPropertyName("percent_change_24")]
        public decimal PercentChange24h { get; set; }
    }

}
