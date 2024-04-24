using System;
namespace AbstractClassessAndMethods;

class Program
{
    public static void Main(string[] args)
    {
        Syncfusion job1 = new Syncfusion();
        job1.Name = "Dinesh";
        Console.WriteLine(job1.Display());
        Console.WriteLine(job1.Salary(30));
    }

}