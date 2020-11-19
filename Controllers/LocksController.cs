using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimonsVoss.IService;
using SimonsVoss.Models;

namespace SimonsVoss.Controllers
{
    public class LocksController : Controller
    {
        // GET: LocksController
        private readonly ILockService _lockService;
        public LocksController(ILockService lockService)
        {
            _lockService = lockService;
        }
        public ActionResult Index(string Id, string searchText)
        {
            if (string.IsNullOrEmpty(Id)) return View();
            var list = new List<LockViewModel>();
            if(!string.IsNullOrEmpty(Id))
            {
                Guid id = Guid.Parse(Id);
                list = _lockService.AllLocksById(id, searchText);
            }
            return View(list);
        }
    }
}
