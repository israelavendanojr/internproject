﻿using System;
using Profiles.Business;

namespace WebApplication.Models.Profile
{
    public class ProfileModel
    {
        public string FullName;
        public string SPIERole;
        public string Company;
        public string JobTitle;
        public string PictureFileName;

        // Additional info for user accounts, in production user info would be much less available and more secure, but for proof of concept we will ignore things such as password hashing, username validation, etc
        public string Username;
        public string Password;
        public ProfileModel(int ID)
        {
            ProfileCollection collection = new ProfileCollection();
            Profiles.Business.Profile userProfile = collection.GetProfile(ID);

            if (userProfile == null)
            {
                FullName = "Not Found";
                SPIERole = "Not Available";
                Company = "Not Available";
                JobTitle = "Not Available";
                PictureFileName = "jimbob.jpg";
            }
            else
            {
                FullName = userProfile.FirstName + " " + userProfile.LastName;
                SPIERole = userProfile.SPIERole;
                Company = userProfile.Company;
                JobTitle = userProfile.JobTitle;
                PictureFileName = userProfile.PictureFileName;

            }
        }
    }
}