using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimonsVoss.IService;
using SimonsVoss.Models;

namespace SimonsVoss.Controllers
{
    public class MediaController : Controller
    {
        // GET: LocksController
        private readonly IMediaService _mediaService;
        public MediaController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }
        public ActionResult Index(string Id, string searchText)
        {
            var list = new List<MediaViewModel>();
            if (!string.IsNullOrEmpty(Id))
            {
                Guid id = Guid.Parse(Id);
                list = _mediaService.AllMediaById(id, searchText);
            }
            return View(list);
        }

    }
}