using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonsVoss.Models
{
    public class ModelViewData
    {
        public List<BuildingViewModel> BuildingList { get; set; }
        public List<GroupViewModel> GroupList { get; set; }

        public List<LockViewModel> LockList { get; set; }
        public List<MediaViewModel> MediaList { get; set; }
        public string SearchText { get; set; }
    }
}
