using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SimonsVoss.Models.LockViewModel;

namespace SimonsVoss.Models
{
    public class JsonData
    {
        [JsonProperty("buildings")]
        public List<BuildingViewModel> Buildings { get; set; }
        [JsonProperty("locks")]
        public List<LockViewModel> Locks { get; set; }
        [JsonProperty("groups")]
        public List<GroupViewModel> Groups { get; set; }
        [JsonProperty("media")]
        public List<MediaViewModel> Media { get; set; }
    }
}
