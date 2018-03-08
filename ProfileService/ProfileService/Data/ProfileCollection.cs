using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProfileService.Models;

namespace ProfileService.Data
{
    //Abstract Data Type that holds Profile objects
    public class ProfileCollection
    {
        //internal data structure
        private Dictionary<int, Profile> _collection;

        public ProfileCollection()
        {
            _collection = new Dictionary<int, Profile>();
            LoadCollection();
        }

        public IEnumerable<Profile> GetAll()
        {
            return _collection.Values;
        }

        public Profile GetProfile(int id)
        {
            return _collection.GetValueOrDefault(id);
        }

        public bool AddProfile(Profile profile)
        {
            return _collection.TryAdd(profile.UserID, profile);
        }

        public void RemoveProfile(Profile profile)
        {
            _collection.Remove(profile.UserID);
        }

        private void LoadCollection()
        {
            Profile profile = new Profile();
            profile.UserID = 1;
            profile.Name = "Polly Smith";           


            Patient p1 = new Patient
            {
                FirstName = "Michael",
                LastName = "Jordan",
                //Email = "justin@example.com",
                ID = 2,
                PhysicianID = 1
            };

            Patient p2 = new Patient
            {
                FirstName = "Mike",
                LastName = "Tyson",
                //Email = "riz@example.com",
                ID = 3,
                PhysicianID = 1
            };


            Patient p3 = new Patient
            {
                FirstName = "Captain",
                LastName = "America",
                //Email = "daniel@example.com",
                ID = 4,
                PhysicianID = 1
            };

            profile.Patients.Add(p1);
            profile.Patients.Add(p2);
            profile.Patients.Add(p3);

            _collection.Add(profile.UserID, profile);
        }
    }
}
