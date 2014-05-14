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
    public class EventApiController : Controller
    {
        private LiztrCoreApi api;

        public EventApiController(LiztrCoreApi API)
        {
            this.api = API;
        }

        [HttpGet]
        [Route("event")]
        public ActionResult GetAll()
        {
            var res = api.QueryAllEvents();

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("event/{id}")]
        public ActionResult Get(int Id)
        {
            var res = (Id == 0) ? new Event() : api.ReadEvent(Id);

            res.StartDateString = res.StartDate.ToShortDateString();
            res.EndDateString = res.EndDate.ToShortDateString();

            return EventResult(res);
        }

        [HttpPost]
        [Route("event/{id}")]
        public ActionResult Save(Event e, int id)
        {
            //cannot post if not logged in
            User cur_user = (User)Session["Current_User"];
            e.OwnedBy = cur_user;


            var res = id == 0 ? api.CreateEvent(e) : api.UpdateEvent(e);

            return EventResult(res);
        }

        [HttpDelete]
        [Route("event/{id}")]
        public ActionResult Delete(Event e, int id)
        {
            var res = api.DeleteEvent(e);

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