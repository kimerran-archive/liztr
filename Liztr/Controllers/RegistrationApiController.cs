using Liztr.API;
using Liztr.Data.Models;
using Liztr.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Liztr.Controllers
{
    [RoutePrefix("api")]
    public class RegistrationApiController : Controller
    {
        private LiztrCoreApi api;

        public RegistrationApiController(LiztrCoreApi API)
        {
            this.api = API;
        }

        [HttpPost]
        [Route("reg/{eventid}")]
        public ActionResult Save(Registration r, int eventid)
        {
            // event ID is required
            if (eventid == 0) return new HttpNotFoundResult();

            Event e = api.ReadEvent(eventid);
            r.Event = e;

            var res = api.CreateRegistration(r);
            return EventResult(res);

        }

        private JsonResult EventResult(Object e)
        {
            var isOwnedByLoggedInUser = true;

            return Json(Utility.CreateJson(
                status: (e == null) ? false : true,
                result: e,
                allowed: isOwnedByLoggedInUser
            ), JsonRequestBehavior.AllowGet);
        }
     
    }
}