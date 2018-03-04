using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileService.Models
{
    public class Account
    {
        private List<int> _steadyMedsOwned;

        public Account()
        {
            _steadyMedsOwned = new List<int>();
        }

        public int AccountId { get; set; }
        public string Name { get; set; }
        public List<int> SteadyMedsOwned { get { return _steadyMedsOwned; } set { _steadyMedsOwned = value; } }

    }
}
