using Newtonsoft.Json;

namespace WebAPINubimetrics.Entity.DTO
{
    public class PagingDTO
    {
        public int Total { get; set; }

        [JsonProperty("primary_results")]
        public int PrimaryResults { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}
