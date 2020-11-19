using SimonsVoss.IService;
using SimonsVoss.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonsVoss.Service
{
    public class LockService : ILockService
    {
        private readonly ISearchService _searchService;
        public LockService(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public List<LockViewModel> SearchLocksByText(string searchText)
        {
            var load = _searchService.Search();
            var json = _searchService.Desrliaze<JsonData>(load);

            var locks = json.Locks.Where(r => r.Name?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true
            || r.SerialNumber?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true
            || r.Floor?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true
            || r.RoomNumber?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true
            || r.Description?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true)
                .Join
                (json.Buildings,
                locks => locks.BuildingId,
                builds => builds.Id,
                (locks, builds) => new LockViewModel
                {
                    Id = locks.Id,
                    Name = locks.Name,
                    BuildingId = locks.BuildingId,
                    Type = locks.Type,
                    BuildingName = builds.Name,
                    SerialNumber = locks.SerialNumber,
                    Floor = locks.Floor,
                    RoomNumber = locks.RoomNumber,
                    Description = locks.Description
                }
                )
            .Select(lc => new
            {
                MatchLock = lc,
                Sort = ((lc.Name?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ? 0 : 1)
                            + (lc.SerialNumber?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ? 0 : 1)
                            + (lc.Floor?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ? 0 : 1)
                            + (lc.RoomNumber?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ? 0 : 1)
                            + (lc.Description?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ? 0 : 1))
            })
                .OrderBy(s => s.Sort)
                .ThenBy(x => x.MatchLock.Name)
                .ThenBy(x => x.MatchLock.SerialNumber)
                .ThenBy(x => x.MatchLock.Floor)
                .ThenBy(x => x.MatchLock.RoomNumber)
                .ThenBy(x => x.MatchLock.Description)
                .Select(newlock => newlock.MatchLock).ToList();

            return locks;
        }

        public List<LockViewModel> AllLocksById(Guid buildingId, string searchText)
        {
            var load = _searchService.Search();
            var json = _searchService.Desrliaze<JsonData>(load);
            return json.Locks.Where(x => x.BuildingId == buildingId).Join
                (json.Buildings,
                locks => locks.BuildingId,
                builds => builds.Id,
                (locks, builds) => new LockViewModel
                {
                    Id = locks.Id,
                    Name = locks.Name,
                    BuildingId = locks.BuildingId,
                    Type = locks.Type,
                    BuildingName = builds.Name,
                    SerialNumber = locks.SerialNumber,
                    Floor = locks.Floor,
                    RoomNumber = locks.RoomNumber,
                    Description = locks.Description
                }
                )
                .Select(lc => new
                {
                    MatchLock = lc,
                    Sort = ((lc.Name?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ? 0 : 1)
                            + (lc.SerialNumber?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ? 0 : 1)
                            + (lc.Floor?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ? 0 : 1)
                            + (lc.RoomNumber?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ? 0 : 1)
                            + (lc.Description?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ? 0 : 1))
                })
                .OrderBy(s => s.Sort)
                .ThenBy(x => x.MatchLock.Name)
                .ThenBy(x => x.MatchLock.SerialNumber)
                .ThenBy(x => x.MatchLock.Floor)
                .ThenBy(x => x.MatchLock.RoomNumber)
                .ThenBy(x => x.MatchLock.Description)
                .Select(newlock => newlock.MatchLock).ToList();
        }

    }
}
