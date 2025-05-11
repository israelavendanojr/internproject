using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models.Profile;
using Profiles.Business;

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

        public ActionResult Search(string query)
        {

            if (string.IsNullOrWhiteSpace(query))
            {
                return RedirectToAction("Index", "Home");
            }

            ProfileCollection profileCollection = new ProfileCollection();
            var results = profileCollection.SearchProfiles(query);

            return View("ProfileSearch", results);
        }

    }
}