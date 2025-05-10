using System;
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