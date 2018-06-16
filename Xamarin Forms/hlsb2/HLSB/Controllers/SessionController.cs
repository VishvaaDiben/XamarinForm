using HLSB.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace HLSB.Controllers
{
    public class SessionController : Controller
    {
        //GET: api/Session
        public JsonResult GetUser(long? id)
        {
            var sessionData = (SessionDto)System.Web.HttpContext.Current.Session["sessionData"];

            if (sessionData != null)
                return Json(new { data = sessionData}, JsonRequestBehavior.AllowGet);

            return Json(new { data = "null" }, JsonRequestBehavior.AllowGet);
        }

        public void LogoutUser(long? id)
        {
            System.Web.HttpContext.Current.Session.Abandon();
        }

    }
}
