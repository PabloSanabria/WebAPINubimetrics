using System.Collections.Generic;

namespace WebAPINubimetrics.Entity.DTO
{
    public class FilterDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<ValuesDTO> Values { get; set; }
    }
}
