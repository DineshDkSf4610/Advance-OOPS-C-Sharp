using System;
namespace SealedClassTwo;

class Program
{
    public static void Main(string[] args)
    {
        PatientInfo newPatient = new PatientInfo("dinesh","kumar",88,"salem","heart");
        newPatient.DisplayInfo();

        DoctorInfo newDoctor = new DoctorInfo("dddd","kkkk");
        newDoctor.DisplayInfo();
    }
}