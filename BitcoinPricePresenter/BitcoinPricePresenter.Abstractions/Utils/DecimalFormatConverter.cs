using System.Text.Json;
using System.Text.Json.Serialization;

namespace BitcoinPricePresenter.Abstractions.Utils
{
    public class DecimalFormatConverter : JsonConverter<decimal>
    {
        public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("N2"));
        }
    }
}
