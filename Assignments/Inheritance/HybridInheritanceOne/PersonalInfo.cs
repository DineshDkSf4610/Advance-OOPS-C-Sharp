using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HybridInheritanceOne
{

    //Enum Declaration

    public enum Gender { Select, Male, Female }
    public class PersonalInfo
    {
        /*

        Name, FatherName, Phone ,Mail, DOB, Gender

        */


        //Field 
        //Static Field
        private static int s_personalID = 1000;


        //Property
        public string PersonalInfoID { get; } //Read only property
        public string Name { get; set; }

        public string FatherName { get; set; }

        public string Phone { get; set; }

        public string MailID { get; set; }

        public DateTime DOB { get; set; }

        public Gender Gender { get; set; }


        //Construtors

        public PersonalInfo(string name, string fatherName, string phone, string mailID, DateTime dob, Gender gender)
        {
            //Auto Incrementation
            s_personalID++;

            //Assiging values
            PersonalInfoID = "PID" + s_personalID;
            Name = name;
            FatherName = fatherName;
            Phone = phone;
            MailID = mailID;
            DOB = dob;
            Gender = gender;
        }

        public PersonalInfo(string registarionID, string name, string fatherName, string phone, string mailID, DateTime dob, Gender gender)
        {
            //Assiging values
            PersonalInfoID = registarionID;
            Name = name;
            FatherName = fatherName;
            Phone = phone;
            MailID = mailID;
            DOB = dob;
            Gender = gender;
        }

    }
}