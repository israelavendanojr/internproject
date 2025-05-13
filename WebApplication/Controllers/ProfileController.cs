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
            // Redirect to homepage if id passed is not string (checks if int readable)
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

        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            ProfileCollection profileCollection = new ProfileCollection();

            // Validate and get user credentials
            var userProfile = profileCollection.ValidateUser(username, password);

            if (userProfile != null)
            {
                // Login by storing user state in session
                Session["User"] = userProfile.Username;
                Session["UserProfileID"] = userProfile.ID;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult Logout()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int id)
        {
            ProfileCollection profileCollection = new ProfileCollection();

            // Ensure the user is logged in
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Profile");
            }

            
            var userProfile = profileCollection.GetProfile(id);
            if (userProfile == null || userProfile.Username != Session["User"].ToString())
            {
                return RedirectToAction("Index", "Home");
            }

            return View(userProfile); 
        }

        [HttpPost]
        public ActionResult Edit(int id, Profile profile)
        {
            ProfileCollection profileCollection = new ProfileCollection();

            if (ModelState.IsValid)
            {
                // Find and update the profile by ID
                Profile userProfile = profileCollection.GetProfile(id);
                if (userProfile != null)
                {
                    // Update the properties
                    userProfile.FirstName = profile.FirstName;
                    userProfile.LastName = profile.LastName;
                    userProfile.Company = profile.Company;
                    userProfile.SPIERole = profile.SPIERole;
                    userProfile.JobTitle = profile.JobTitle;
                    userProfile.PictureFileName = profile.PictureFileName;

                    return RedirectToAction("ProfileView", new { id = userProfile.ID });
                }
            }

            // Redirect to home is user could not be validated
            return RedirectToAction("Index", "Home");
        }


    }
}