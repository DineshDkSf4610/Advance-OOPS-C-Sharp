using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterfaceTwo
{
    public class StudentInfo : IDisplayInfo
    {

        /*
        StudentID, Name, FatherName, Mobile
        */

        private static int s_studentID = 100;

        public string StudentID { get; }

        public string Name { get; set; }

        public string FatherName { get; set; }

        public string Mobile { get; set; }

        //Construtors

        public StudentInfo(string name, string fatherName, string mobile)
        {
            s_studentID++;
            StudentID = "SID" + s_studentID;
            Name = name;
            FatherName = fatherName;
            Mobile = mobile;
        }
        public void Display()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Father Name: {FatherName}");
            Console.WriteLine($"Mobile: {Mobile}");
        }

    }
}