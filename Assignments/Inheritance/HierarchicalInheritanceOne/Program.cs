using System;
namespace HierarchicalInheritanceOne;

class Program
{
    public static void Main(string[] args)
    {
        Teacher teacher = new Teacher("dinesh","kumar","99595959595","dinesh@gmail.com", new DateTime(2001,11,11),Gender.Male,"Computer","SQL","MCA","4",new DateTime(2020,11,11));
        teacher.ShowDetails();
        Console.WriteLine("\n************************\n");

        StudentInfo student = new StudentInfo("dinesh","kumar","99595959595","dinesh@gmail.com", new DateTime(2001,11,11),Gender.Male,"BCA","Computer",4);
        student.ShowDetails();
         Console.WriteLine("\n************************\n");

         PrincipalInfo principal = new PrincipalInfo("dinesh","kumar","99595959595","dinesh@gmail.com", new DateTime(2001,11,11),Gender.Male,"M.Phile",5,new DateTime(2020,11,11));
         principal.ShowDetails();
    }
}