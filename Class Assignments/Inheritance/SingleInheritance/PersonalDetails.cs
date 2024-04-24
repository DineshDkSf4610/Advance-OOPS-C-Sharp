using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleInheritance
{
    //Enum Declaration

    public enum Gender { Select, Male, Female, Transgender }
    public class PersonalDetails
    {
        //Field
        //Static Field
        private static int s_userID = 1000;

        //Properties
        public string UserID { get; } // Read only Propery

        public string Name { get; set; }

        public string FatherName { get; set; }

        public Gender Gender { get; set; }

        public string PhoneNumber { get; set; }

        //Construtors

        public PersonalDetails(string name, string fatherName, Gender gender, string phoneNumber)
        {
            //Auto Incrementation
            s_userID++;
            //Assiging value
            UserID = "UID" + s_userID;
            Name = name;
            FatherName = fatherName;
            Gender = gender;
            PhoneNumber = phoneNumber;
        }

        public PersonalDetails(string userID, string name, string fatherName, Gender gender, string phoneNumber)
        {
            UserID = userID;
            Name = name;
            FatherName = fatherName;
            Gender = gender;
            PhoneNumber = phoneNumber;
        }
    }
}
