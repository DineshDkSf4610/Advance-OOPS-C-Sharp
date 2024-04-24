using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HierarchicalInheritance
{
    public class StudentDetails : PersonalDetails
    {
        //Field 
        //Static Field
        private static int s_studentID = 2000;

        //Property

        public string  StudentID { get; } //Read only property

        public int Standard { get; set; }

        public string YearOfJoining { get; set; }


        //construtors

        public StudentDetails(string userID, string name, string fatherName, Gender gender, string phoneNumber, int standard, string yearOfJoining) : base(userID, name, fatherName, gender, phoneNumber)
        {
            //Auto Incrementation
            s_studentID++;

            //Asssiging value
            StudentID = "SID" + s_studentID;
            Standard = standard;
            YearOfJoining = yearOfJoining;
        }

        
    }
}