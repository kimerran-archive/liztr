using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Liztr.Controllers
{
    [RoutePrefix("u")]
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}