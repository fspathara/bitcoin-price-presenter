using System.Text.Json.Serialization;

namespace BitcoinPricePresenter.Abstractions.Models.Dtos
{
    public class BitfinexPriceModel
    {
        [JsonPropertyName("last_price")]
        public string Price { get; set; }
        [JsonPropertyName("low")]
        public string LowestPrice { get; set; }
        [JsonPropertyName("high")]
        public string HighestPrice { get; set; }
        [JsonPropertyName("timestamp")]
        public string Timestamp { get; set; }
    }

}
