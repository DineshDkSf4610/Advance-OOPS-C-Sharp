using System;
using MultilevelInheritanceOne;
namespace MultilvelInheritanceOne;

class Program
{
    public static void Main(string[] args)
    {
        PersonalInfo person = new PersonalInfo("dinesh", "kumar", "9494949494", "dinesh@gmail.come", new DateTime(2001, 04, 11), Gender.Male);

        StudentInfo student = new StudentInfo(person.PersonalInfoID, person.Name, person.FatherName, person.Phone, person.MailID, person.DOB, person.Gender, 12, "State Board", 2023);

        HSCDetails hssc = new HSCDetails(student.RegistrationID, student.PersonalInfoID, student.Name, student.FatherName, student.Phone, student.MailID, student.DOB, student.Gender, student.Standard, student.Branch, student.AcadamicYear, 98, 88, 99);


        //Show MarkSheet

        hssc.ShowMarksheet();
     

    }
}