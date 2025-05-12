using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profiles.Business
{
    public class ProfileCollection
    {

        public List<Profile> ProfileList;

        public ProfileCollection()
        {
            ProfileList = new List<Profile>()
            {
                new Profile()
                {
                    ID = 1,
                    FirstName = "Jim",
                    LastName = "Bob",
                    Company = "SPIE",
                    SPIERole = "SPIE Member",
                    JobTitle = "UX/UI Designer",
                    PictureFileName = "jimbob.jpg",
                    Username = "JimBob",
                    Password = "JimBobPassword"

                },
                new Profile()
                {
                    ID = 2,
                    FirstName = "Samantha",
                    LastName = "Johnson",
                    Company = "SPIE",
                    SPIERole = "SPIE Fellow",
                    JobTitle = "Optics & Photonics Researcher",
                    PictureFileName = "samanthajohnson.jpg",
                    Username = "SammyGirl",
                    Password = "SamSam"

                },
                new Profile()
                {
                    ID = 3,
                    FirstName = "Jackie",
                    LastName = "Zope",
                    Company = "NASA",
                    SPIERole = "SPIE Conference Chair",
                    JobTitle = "Astrophysicist",
                    PictureFileName = "jackiezope.jpg",
                    Username = "Jackstar123",
                    Password = "Password"
                },
                 new Profile()
                {
                    ID = 4,
                    FirstName = "Jonathon",
                    LastName = "Watkinson",
                    Company = "Blue Origins",
                    SPIERole = "SPIE Member",
                    JobTitle = "Embedded Optical Engineer",
                    PictureFileName = "jonathonwatkinson.jpg",
                    Username = "Jon",
                    Password = "Jon"
                }
            };
        }


        public Profile GetProfile(int ID)
        {
            var profile = ProfileList.FirstOrDefault(p => p.ID == ID);
            if (profile == null)
                return null;

            return profile;
        }

        public List<Profile> SearchProfiles(string query)
        {
            if (query == null)
                return new List<Profile>();

            
            return ProfileList
                .Where(p => p.FirstName.ToLower().Contains(query.ToLower()) ||
                            p.LastName.ToLower().Contains(query.ToLower()))
                .ToList();
        }

        // Method to validate the user credentials during login
        public Profile ValidateUser(string username, string password)
        {
            return ProfileList.FirstOrDefault(p => p.Username == username && p.Password == password);
        }

    }

}
