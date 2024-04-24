using System;
using InterfaceTwo;
namespace InterFaceTwo;

class Program {
    public static void Main(string[] args)
    {
     //Creat Object
     StudentInfo student = new StudentInfo("dinesh","kumar","9858757585885");
     student.Display();

     //Employee object
     EmployeeInfo employee = new EmployeeInfo("dinesh","kumar");
     employee.Display();   
    }
}