using System;
namespace OnlineMedicalStore;

class Program
{
    public static void Main(string[] args)
    {
        Operators.AddDefaultData();

        Operators.MainMenu();
    }
}