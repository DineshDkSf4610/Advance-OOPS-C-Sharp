using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HierarchicalInheritanceOne
{
    public class Teacher : PersonalInfo
    {
        // TeacherID, Department, Subject teaching, Qualification, YearOfExperience, DateOfJoining

        private static int s_teacherID = 5000;

        public string TeacherID { get; set; }

        public string Department { get; set; }

        public string SubjectTeaching { get; set; }

        public string Qualification { get; set; }


        public string YearOfExperience { get; set; }

        public DateTime DateOfJoining { get; set; }

        //Constructors

        public Teacher(string name, string fatherName, string phone, string mailID, DateTime dob, Gender gender,string department, string subjectTeching, string qualification, string yearofExperience, DateTime dateOfJoining) : base(name,fatherName,phone,mailID,dob,gender)
        {
            s_teacherID++;

            TeacherID = "TID" + s_teacherID;
            Department = department;
            SubjectTeaching = subjectTeching;
            Qualification = qualification;
            YearOfExperience = yearofExperience;
            DateOfJoining = dateOfJoining;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Father: {FatherName}");
            Console.WriteLine($"Phone Number: {Phone}");
            Console.WriteLine($"Mail ID: {MailID}");
            Console.WriteLine($"Gender: {Gender}");
            Console.WriteLine($"Department: {Department}");
            Console.WriteLine($"Subject Teaching: {SubjectTeaching}");
            Console.WriteLine($"Qualificatin: {Qualification}");
            Console.WriteLine($"Year of Experience: {YearOfExperience}");
            Console.WriteLine($"Date Of Joining: {DateOfJoining}");
        }

    }
}