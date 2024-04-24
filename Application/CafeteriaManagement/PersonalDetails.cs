using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaManagement
{
    //Enum Declaration
    public enum Gender { Select, Male, Female, Transgender }
    public class PersonalDetails
    {
        /*
        •	Name
        •	FatherName
        •	Gender {Enum - Select, Male, Female, Transgender}
        •	Mobile
        •	MailID
        */

        //Field
        //Static Field
        private static int s_personalID = 3000;

        //Property
        public string PersonalID { get; } //Read only Property

        public string Name { get; set; }

        public string FatherName { get; set; }

        public Gender Gender { get; set; }

        public string MobileNumber { get; set; }

        public string MailID { get; set; }

        //Constutors
        public PersonalDetails(string name, string fatherName, Gender gender, string mobile, string mailID)
        {
            //auto Incrementaion
            s_personalID++;

            //assing values
            PersonalID = "PID" + s_personalID;
            Name = name;
            FatherName = fatherName;
            Gender = gender;
            MobileNumber = mobile;
            MailID = mailID;
        }

        
        // public PersonalDetails(string personalID, string name, string fatherName, Gender gender, string mobile, string mailID)
        // {

        //     //assing values
        //     PersonalID = personalID;
        //     Name = name;
        //     FatherName = fatherName;
        //     Gender = gender;
        //     MobileNumber = mobile;
        //     MailID = mailID;
        // }
    }
}