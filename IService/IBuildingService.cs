using SimonsVoss.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonsVoss.IService
{
    public interface IBuildingService
    {
        List<BuildingViewModel> SearchBuilding(string searchText);
    }
}
