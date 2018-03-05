using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

//Author: Rizky
//Encapsulates basic user information like name for every user of application.
namespace SteadyMedApiGateway.Models
{
    public class User
    {
        //Id of the user
        [DisplayName("ID")]
        public int ID { get; set; }

        //User's first name
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        //User's last name
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        //User's middle name
        [DisplayName("MiddleName")]
        public string MiddleName { get; set; }

        //User's age
        [DisplayName("Age")]
        public int Age { get; set; }

        //User's email address
        [DisplayName("Email")]
        public string Email { get; set; }

        //User's address
        [DisplayName("Address")]
        public string Address1 { get; set; }

        //User's address line 2
        [DisplayName("Address 2")]
        public string Address2 { get; set; }

        //User's city
        [DisplayName("City")]
        public string City { get; set; }

        //User's state
        public string State { get; set; }

        //User's zipcode
        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }
    }
}
