using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class PersonalDetails
    {
        //Field
        //static Field

        /*
            •	UserName
            •	Phone Number
        */

        //Property

        public string UserName { get; set; }

        public string MobileNumber { get; set; }



        //Constructors
        public PersonalDetails(string userName, string mobileNumber)
        {
            //Assiging values
            UserName = userName;
            MobileNumber = mobileNumber;
        }

        public PersonalDetails(string student)
        {
            string[] temp = student.Split(',');
            //Assiging values
            UserName = temp[1];
            MobileNumber = temp[2];
        }




    }
}