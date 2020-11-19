using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonsVoss.Models
{
    public class LockViewModel
    {
            [JsonProperty("id")]
            public Guid Id { get; set; }
            [JsonProperty("buildingId")]
            public Guid BuildingId { get; set; }
            public string BuildingName { get; set; }
            [JsonProperty("type")]
            public string Type { get; set; }
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("description")]
            public string Description { get; set; }
            [JsonProperty("serialNumber")]
            public string SerialNumber { get; set; }
            [JsonProperty("floor")]
            public string Floor { get; set; }
            [JsonProperty("roomNumber")]
            public string RoomNumber { get; set; }
        }
    
}
