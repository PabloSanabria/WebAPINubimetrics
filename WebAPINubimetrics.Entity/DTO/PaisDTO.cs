using System.Collections.Generic;

namespace WebAPINubimetrics.Entity.DTO
{
    public class PaisDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Locale { get; set; }
        public string Currency_Id { get; set; }
        public string Decimal_Separator { get; set; }
        public string Thousands_Separator { get; set; }
        public string Time_Zone { get; set; }
        public LocationDTO Geo_Information { get; set; }
        public List<StatesDTO> States { get; set; }


    }
}
