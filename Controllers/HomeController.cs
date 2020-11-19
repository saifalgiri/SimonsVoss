using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimonsVoss.IService;
using SimonsVoss.Models;

namespace SimonsVoss.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBuildingService _buildingService;
        private readonly ILockService _lockService;
        private readonly IGroupService _groupService;
        private readonly IMediaService _mediaService;
        public HomeController(ILogger<HomeController> logger, IBuildingService buildingService,
            ILockService lockService, IGroupService groupService, IMediaService mediaService)
        {
            _logger = logger;
            _buildingService = buildingService;
            _lockService = lockService;
            _groupService = groupService;
            _mediaService = mediaService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(string searchText)
        {
            if (string.IsNullOrEmpty(searchText)) return View();

            var buildings = _buildingService.SearchBuilding(searchText);
            var locks = new List<LockViewModel>();
            if (buildings.Count() == 0)
            {
                locks = _lockService.SearchLocksByText(searchText);
            }

            var groups = _groupService.SearchGroup(searchText);
            var media = new List<MediaViewModel>();
            if (groups.Count() == 0)
            {
                 media = _mediaService.SearchMediaByText(searchText);
            }

            var result = new ModelViewData
            {
                BuildingList = buildings,
                GroupList = groups,
                LockList = locks,
                MediaList = media,
                SearchText = searchText
            };
            return View("Views/Home/Index.cshtml", result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
