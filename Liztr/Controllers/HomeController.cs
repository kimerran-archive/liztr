using Liztr.API;
using Liztr.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Liztr.Controllers
{
    [RoutePrefix("l")]
    public class HomeController : Controller
    {
        private LiztrCoreApi api;

        public HomeController(LiztrCoreApi API)
        {
            this.api = API;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}