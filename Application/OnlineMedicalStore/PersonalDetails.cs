using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class PersonalDetails
    {
        /*
            •	Name
            •	Age
            •	City
            •	PhoneNumber
        */

        public string Name { get; set; }

        public int Age { get; set; }

        public string City { get; set; }

        public string MobileNumber { get; set; }

        //Constutors
        public PersonalDetails(string name, int age, string city, string mobileNumber)
        {
            Name = name;
            Age = age;
            City = city;
            MobileNumber = mobileNumber;
        }

    }
}