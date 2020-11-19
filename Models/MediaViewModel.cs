using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonsVoss.Models
{
    public class MediaViewModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("groupId")]
        public Guid GroupId { get; set; }
        public string GroupName { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("owner")]
        public string Owner { get; set; }
        [JsonProperty("description")]
        public string? Description { get; set; }
        [JsonProperty("serialNumber")]
        public string SerialNumber { get; set; }
    }
}
