using Newtonsoft.Json;

namespace WebAPINubimetrics2.Entity.DTO
{
    public class CurrencyConversion
    {
        [JsonProperty("currency_base")]
        public string CurrencyBase { get; set; }

        [JsonProperty("currency_quote")]
        public string CurrencyQuote { get; set; }
        public float Ratio { get; set; }
        public float Rate { get; set; }

        [JsonProperty("inv_rate")]
        public float InvRate { get; set; }

        [JsonProperty("creation_date")]
        public string CreationDate { get; set; }

        [JsonProperty("valid_until")]
        public string ValidUntil { get; set; }
    }
}
