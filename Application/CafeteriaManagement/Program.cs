using System;
namespace CafeteriaManagement;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Cafeteria Management");
        //Add Default Data
        Operations.AddDefaultData();

        //Main Menu
        Operations.MainMenu();

    }
}