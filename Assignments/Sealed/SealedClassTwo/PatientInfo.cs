using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SealedClassTwo
{
    public sealed class PatientInfo
    {
        //  PatientID, Name, FatherName, BedNo, NativePlace, AdmittedFor

        private static int s_patientID = 100;

        public string PatientID { get; } //Read Only Property

        public string Name { get; set; }

        public string FatherName { get; set; }

        public int BedNo { get; set; }

        public string NativePlace { get; set; }

        public string AdmittedFor { get; set; }


        public PatientInfo(string name, string fatherName, int bedNo, string nativePlace, string admittedFor)
        {
            s_patientID++;

            PatientID = "PID" + s_patientID;
            Name = name;
            FatherName = fatherName;
            BedNo = bedNo;
            NativePlace = nativePlace;
            AdmittedFor = admittedFor;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Father Name: {FatherName}");
            Console.WriteLine($"Bed No: {BedNo}");
            Console.WriteLine($"Native Place: {NativePlace}");
            Console.WriteLine($"Admitted for: {AdmittedFor}");
        }


    }
}