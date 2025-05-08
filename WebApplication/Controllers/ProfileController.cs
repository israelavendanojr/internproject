using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models.Profile;

namespace WebApplication.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult profileView(string id)
        {
            // redirect to homepage if id passed is not string (checks if int readable)
            if (!int.TryParse(id, out int profileId))
            {
                return RedirectToAction("Index", "Home");
            }

            ProfileModel model = new ProfileModel(Int32.Parse(id));

            if (model == null)
            {
                return View("Profile", null);
            }

            return View("Profile", model);

        }
    }
}