using HLSB.Models;
using HLSB.Models.Dto;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HLSB.DAL;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web.Mvc;

namespace HLSB.Controllers
{
    public class AuthenticationController : Controller
    {
        private HlsbContext db = new HlsbContext();

        //POST: Authentication/User
        public async Task<JsonResult> ValidateUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { data = "null" }, JsonRequestBehavior.AllowGet);
            }

            var result = await db.Users
                .FirstOrDefaultAsync(x => String.Equals(x.EmailAddress, user.EmailAddress) && String.Equals(x.Password, user.Password));

            if (result != null)
            {
                SessionDto dto = new SessionDto
                {
                    UserId = result.UserId,
                    FirstName = result.FirstName,
                    LastName = result.LastName
                };

                System.Web.HttpContext.Current.Session["sessionData"] = dto;

                return Json(new { data = dto }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { data = "null"}, JsonRequestBehavior.AllowGet);

        }
    }
}
