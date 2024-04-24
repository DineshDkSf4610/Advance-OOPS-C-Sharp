using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SealedClassTwo
{
    public class DoctorInfo : PatientInfo // PatientInfo is sealed class file, so not accees class file
    {
        // DoctorID, Name, FatherName

        private static int s_doctorID = 5000;

        public string DoctorID { get; set; }

        public string Name { get; set; }

        public string FatherName { get; set; }

        public DoctorInfo(string name, string fatherName)
        {
            s_doctorID++;
            DoctorID = "DID" + s_doctorID;
            Name = name;
            FatherName = fatherName;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Doctor ID: {DoctorID}");
            Console.WriteLine($"Doctor Name: {Name}");
        }

    }
}