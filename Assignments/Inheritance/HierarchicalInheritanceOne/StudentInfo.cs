using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HierarchicalInheritanceOne
{
    public class StudentInfo : PersonalInfo
    {

        /*
         StudentID, Degree, Department, semester
        */


        //Field
        //Static Field

        private static int s_studentID = 2000;

        //Property
        public string StudentID { get; } // Read Only Property

        public string Degree { get; set; }

        public string Department { get; set; }

        public int Semester { get; set; }

        //Constractors

        public StudentInfo( string name, string fatherName, string phone, string mailID, DateTime dob, Gender gender, string degree, string department, int semester) : base( name, fatherName, phone, mailID, dob, gender)
        {
            //Auto Incrementation
            s_studentID++;

            StudentID = "RID" + s_studentID;
            Degree = degree;
            Department = department;
            Semester = semester;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Father: {FatherName}");
            Console.WriteLine($"Phone Number: {Phone}");
            Console.WriteLine($"Mail ID: {MailID}");
            Console.WriteLine($"Gender: {Gender}");
            Console.WriteLine($"Degree: {Degree}");
            Console.WriteLine($"Department: {Department}");
            Console.WriteLine($"Semester: {Semester}");
        }

    }
}