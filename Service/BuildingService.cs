using SimonsVoss.IService;
using SimonsVoss.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonsVoss.Service
{
    public class BuildingService : IBuildingService
    {
        private readonly ISearchService _searchService;

        public BuildingService(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public List<BuildingViewModel> SearchBuilding(string searchText)
        {
            var buildings = new List<BuildingViewModel>();
            var locks = new List<LockViewModel>();

            var load = _searchService.Search();
            var json = _searchService.Desrliaze<JsonData>(load);

            buildings = json.Buildings.Where(r => r.Name?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true
            || r.Shrotcut?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true
            || r.Description?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true)
                .Select(x => new
                {
                    MatchBuilding = x,
                    Sort = ((x.Name?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ? 0 : 1)
                            + (x.Shrotcut?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ? 0 : 1)
                            + (x.Description?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ? 0 : 1))
                })
                .OrderBy(s => s.Sort)
                .ThenBy(x => x.MatchBuilding.Name)
                .ThenBy(x => x.MatchBuilding.Shrotcut)
                .ThenBy(x => x.MatchBuilding.Description)
                .Select(newBuilding => newBuilding.MatchBuilding)
                .ToList();
            return buildings;
        }
    }
}
