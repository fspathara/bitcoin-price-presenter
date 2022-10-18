using System.Text.Json.Serialization;

namespace BitcoinPricePresenter.Abstractions.Models.Dtos
{
    public class BitfinexPriceModel
    {
        [JsonPropertyName("last_price")]
        public decimal Price { get; set; }
        [JsonPropertyName("low")]
        public string LowestPrice { get; set; }
        [JsonPropertyName("high")]
        public decimal HighestPrice { get; set; }
        [JsonPropertyName("timestamp")]
        public double Timestamp { get; set; }
    }

}
