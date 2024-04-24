using System;
namespace PartialClassOne;

class Program 
{
    public static void Main(string[] args)
    {
        EmployeeInfo employee = new EmployeeInfo();
        employee.Update();
        employee.Display();
    }
}