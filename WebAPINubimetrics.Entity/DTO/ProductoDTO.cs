using Newtonsoft.Json;

namespace WebAPINubimetrics.Entity.DTO
{
    public class ProductoDTO
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("site_id")]
        public string SiteId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("price")]
        public float Price { get; set; }

        [JsonProperty("seller")]
        public SellerDTO Seller { get; set; }

        [JsonProperty("permalink")]
        public string PermaLink { get; set; }
    }
}
