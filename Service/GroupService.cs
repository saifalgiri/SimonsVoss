using SimonsVoss.IService;
using SimonsVoss.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonsVoss.Service
{
    public class GroupService : IGroupService
    {
        private readonly ISearchService _searchService;

        public GroupService(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public List<GroupViewModel> SearchGroup(string searchText)
        {
            var buildings = new List<GroupViewModel>();
            var locks = new List<MediaViewModel>();

            var load = _searchService.Search();
            var json = _searchService.Desrliaze<JsonData>(load);

            buildings = json.Groups.Where(r => r.Name?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true
            || r.Description?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true)
                .Select(x => new
                {
                    MatchGroup = x,
                    Sort = ((x.Name?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ? 0 : 1)
                            + (x.Description?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ? 0 : 1))
                })
                .OrderBy(s => s.Sort)
                .ThenBy(x => x.MatchGroup.Name)
                .ThenBy(x => x.MatchGroup.Description)
                .Select(newGroup => newGroup.MatchGroup)
                .ToList();
            return buildings;
        }

    }
}
