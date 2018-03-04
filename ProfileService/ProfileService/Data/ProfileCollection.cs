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
            Profile p1 = new Profile();


            _collection.Add(p1.UserID, p1);
        }



    }
}
