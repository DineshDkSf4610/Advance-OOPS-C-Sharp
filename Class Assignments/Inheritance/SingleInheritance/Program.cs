using System;
using System.Collections.Generic;
namespace SingleInheritance;

class Program
{
    public static void Main(string[] args)
    {
        //List Declaration

        List<PersonalDetails> personalList = new List<PersonalDetails>();
        //Personal Details obj
        PersonalDetails personal = new PersonalDetails("dinesh", "kumar", Gender.Male, "9988776655");
        Console.WriteLine($"Peronal ID : {personal.UserID}\nName: {personal.Name}\nGender : {personal.Gender}\nPhone Number : {personal.PhoneNumber}");

        //Student Details

        StudentDetails student = new StudentDetails(personal.UserID, personal.Name, personal.FatherName, personal.Gender, personal.PhoneNumber, 1, "2022");


    }
}
