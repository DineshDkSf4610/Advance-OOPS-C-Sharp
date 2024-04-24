using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleInheritanceOne
{
    public class StudentInfo : PersonalInfo
    {

        /*
        RegisterNumber, Standard, Branch, AcadamicYear
        */


        //Field
        //Static Field

        private static int s_registrationNumber = 2000;

        //Property
        public string RegistrationID { get; } // Read Only Property

        public int Standard { get; set; }

        public string Branch { get; set; }

        public int AcadamicYear { get; set; }

        //Constractors

        public StudentInfo(string registarionID, string name, string fatherName, string phone, string mailID, DateTime dob, Gender gender, int standard, string branch, int acadamicYear) : base(registarionID, name, fatherName, phone, mailID, dob, gender)
        {
            //Auto Incrementation
            s_registrationNumber++;

            RegistrationID = "RID" + s_registrationNumber;
            Standard = standard;
            Branch = branch;
            AcadamicYear = acadamicYear;
        }

    }
}