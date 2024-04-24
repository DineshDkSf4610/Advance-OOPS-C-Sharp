using System;
namespace SingleInheritanceOne;

class Program
{
    public static void Main(string[] args)
    {

        PersonalInfo personal = new PersonalInfo("Dinesh", "kumar", "6384225424", "dinesh@gmail.com", new DateTime(2001, 04, 11), Gender.Male);

        StudentInfo student = new StudentInfo(personal.PersonalInfoID, personal.Name, personal.FatherName, personal.Phone, personal.MailID, personal.DOB, personal.Gender, 10, "new", 2022);

        Console.WriteLine("**************************");
        Console.WriteLine("****Student Details ******");
        Console.WriteLine($"Name: {student.Name}\nFather Name: {student.FatherName}\nPhone: {student.Phone}\nMail ID: {student.MailID}\nDOB: {student.DOB}\nStandard: {student.Standard}\nBranch: {student.Branch}\nAcadamic Year: {student.AcadamicYear}");

    }
}