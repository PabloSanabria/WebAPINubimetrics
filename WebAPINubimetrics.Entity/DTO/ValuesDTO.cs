using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebAPINubimetrics.Entity.DTO
{
    public class ValuesDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        
        [JsonProperty("path_from_root")]
        public List<PathFromRootDTO> PathFromRoot { get; set; }

        public int Results { get; set; }
        
    }
}
