using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SimonsVoss.Models.LockViewModel;

namespace SimonsVoss.Models
{
    public class BuildingViewModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("shortcut")]
        public string Shrotcut { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        public List<LockViewModel> Locks { get; set; }
    }
}
