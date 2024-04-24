using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HierarchicalInheritanceOne
{
    public class PrincipalInfo : PersonalInfo
    {
        // Properties: PrincipalID, Qualification, YearOfExperience, DateOfJoining

        private static int s_pricipleID = 4000;

        public string PrincipalID { get; set; }

        public string Qualification { get; set; }

        public int YearOfExperience { get; set; }

        public DateTime DateOfJoining { get; set; }


        //Constructors

        public PrincipalInfo(string name, string fatherName, string phone, string mailID, DateTime dob, Gender gender, string qualification, int yearOfExperience, DateTime dateOfJoining) : base(name, fatherName, phone, mailID, dob, gender)
        {
            s_pricipleID++;

            PrincipalID = "PID" + s_pricipleID;
            Qualification = qualification;
            YearOfExperience = yearOfExperience;
            DateOfJoining = dateOfJoining;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Father: {FatherName}");
            Console.WriteLine($"Phone Number: {Phone}");
            Console.WriteLine($"Mail ID: {MailID}");
            Console.WriteLine($"Gender: {Gender}");
            Console.WriteLine($"Qualificatin: {Qualification}");
            Console.WriteLine($"Year of Experience: {YearOfExperience}");
            Console.WriteLine($"Date Of Joining: {DateOfJoining}");
        }

    }
}