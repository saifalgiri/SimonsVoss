using SimonsVoss.IService;
using SimonsVoss.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonsVoss.Service
{
    public class MediaService : IMediaService
    {
        private readonly ISearchService _searchService;

        public MediaService(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public List<MediaViewModel> SearchMediaByText(string searchText)
        {
            var load = _searchService.Search();
            var json = _searchService.Desrliaze<JsonData>(load);

            var result = json.Media.Where(r => r.Owner?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true
            || r.SerialNumber?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true
            || r.Description?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true)
                .Join
                (json.Groups,
                media => media.GroupId,
                groups => groups.Id,
                (media, groups) => new MediaViewModel
                {
                    Id = media.Id,
                    GroupId = media.GroupId,
                    GroupName = groups.Name,
                    Type = media.Type,
                    Owner = media.Owner,
                    SerialNumber = media.SerialNumber,
                    Description = media.Description
                }
                )
            .Select(md => new
            {
                MatchMedia = md,
                Sort = ((md.Owner?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ? 0 : 1)
                            + (md.GroupName?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ? 0 : 1)
                            + (md.SerialNumber?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ? 0 : 1)
                            + (md.Description?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ? 0 : 1)
                            + (md.Type?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ? 0 : 1))
            })
                .OrderBy(s => s.Sort)
                .ThenBy(x => x.MatchMedia.Owner)
                .ThenBy(x => x.MatchMedia.GroupName)
                .ThenBy(x => x.MatchMedia.SerialNumber)
                .ThenBy(x => x.MatchMedia.Description)
                .ThenBy(x => x.MatchMedia.Type)
                .Select(newMedai => newMedai.MatchMedia).ToList();

            return result;
        }

        public List<MediaViewModel> AllMediaById(Guid groupId, string searchText)
        {
            var load = _searchService.Search();
            var json = _searchService.Desrliaze<JsonData>(load);
            return json.Media.Where(x => x.GroupId == groupId)
                .Join
                (json.Groups,
                media => media.GroupId,
                groups => groups.Id,
                (media, groups) => new MediaViewModel
                {
                    Id = media.Id,
                    GroupId = media.GroupId,
                    GroupName = groups.Name,
                    Type = media.Type,
                    Owner = media.Owner,
                    SerialNumber = media.SerialNumber,
                    Description = media.Description
                })
                 .Select(md => new
                 {
                     MatchMedia = md,
                     Sort = ((md.Owner?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ? 0 : 1)
                            + (md.GroupName?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ? 0 : 1)
                            + (md.SerialNumber?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ? 0 : 1)
                            + (md.Description?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ? 0 : 1)
                            + (md.Type?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ? 0 : 1))
                 })
                .OrderBy(s => s.Sort)
                .ThenBy(x => x.MatchMedia.Owner)
                .ThenBy(x => x.MatchMedia.GroupName)
                .ThenBy(x => x.MatchMedia.SerialNumber)
                .ThenBy(x => x.MatchMedia.Description)
                .ThenBy(x => x.MatchMedia.Type)
                .Select(newMedai => newMedai.MatchMedia).ToList();
        }

    }
}
