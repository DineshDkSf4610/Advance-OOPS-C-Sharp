using System;
namespace PartialClassesAndMethods;

class Program
{
    public static void Main(string[] args)
    {
        PersonalDetails personal = new PersonalDetails();
        personal.DOB = new DateTime(1999, 10, 01);
    }
}