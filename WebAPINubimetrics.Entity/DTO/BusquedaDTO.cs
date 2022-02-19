using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebAPINubimetrics.Entity.DTO
{
    public class BusquedaDTO
    {

        [JsonProperty("site_id")]
        public string SiteId { get; set; }

        [JsonProperty("country_default_time_zone")]
        public string CountryDefaultTimeZone { get; set; }
        public string Query { get; set; }
        public PagingDTO Paging { get; set; }
        public List<ProductoDTO> Results { get; set; }
        public SortDTO Sort { get; set; }

        [JsonProperty("available_sorts")]
        public List<SortDTO> AvailableSorts { get; set; }
        public List<FilterDTO> Filters { get; set; }

        [JsonProperty("available_filters")]
        public List<FilterDTO> AvailableFilters { get; set; }
    }
}
