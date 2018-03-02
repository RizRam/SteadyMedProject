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



        private void LoadCollection()
        {

        }



    }
}
