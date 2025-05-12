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

        // Display login page
        public ActionResult Login()
        {
            return View("Login");
        }

        // Handle login logic
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            // Create an instance of ProfileCollection
            ProfileCollection profileCollection = new ProfileCollection();

            // Validate the user credentials using the ValidateUser method
            var userProfile = profileCollection.ValidateUser(username, password);

            if (userProfile != null)
            {
                // Simulate user login by storing user data in session
                Session["User"] = userProfile.Username;

                // Redirect to the profile page or home page
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // If login fails, return to login page with an error message
                ViewBag.ErrorMessage = "Invalid username or password.";
                return View();
            }
        }

        // Handle logout
        public ActionResult Logout()
        {
            Session["User"] = null;  // Clear session data
            return RedirectToAction("Index", "Home");  // Redirect to the home page
        }
    }
}