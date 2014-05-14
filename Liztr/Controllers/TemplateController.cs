using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Liztr.Controllers
{
    /// <summary>
    /// Handle the partial templates used by Angular JS routing
    /// </summary>
    [RoutePrefix("partials")]
    public class TemplateController : Controller
    {

        [Route("event/all")]
        public ActionResult EventAll()
        {
            return View();
        }

        [Route("event/create")]
        public ActionResult EventCreate()
        {
            return View();
        }

        [Route("event/reg")]
        public ActionResult EventReg()
        {
            return View();
        }

        [Route("event/pre")]
        public ActionResult EventPre()
        {
            return View();
        }

        [Route("event/edit")]
        public ActionResult EventEdit()
        {
            return View();
        }
    }
}