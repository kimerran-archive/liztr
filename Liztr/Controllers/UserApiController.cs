using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Liztr.Data.Models;
namespace Liztr.Controllers
{
    [RoutePrefix("api")]
    public class UserApiController : Controller
    {
        [Route("user/{id}")]
        [HttpGet]
        public ActionResult CheckAccess()
        {
            User u = (User) Session["Current.User"];

            var isAllowed = (u == null) ? false : true;

            return Json(new
            {
                allowed = isAllowed
            },JsonRequestBehavior.AllowGet);
        }
	}
}