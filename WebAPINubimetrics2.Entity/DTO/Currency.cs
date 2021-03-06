using Newtonsoft.Json;

namespace WebAPINubimetrics2.Entity.DTO
{
    public class Currency
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string Description { get; set; }

        [JsonProperty("decimal_places")]
        public int DecimalPlaces { get; set; }
        public CurrencyConversion ToDolar { get; set; }
    }
}
