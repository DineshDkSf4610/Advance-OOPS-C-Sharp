using System;
namespace MetroCardManagement;

class Program
{
    public static void Main(string[] args)
    {

        //create folder
        FileHandling.Create();
        //Add Defult values
        // Operations.AddDefaultData();

        //ReadFile
        FileHandling.ReadFromCSV();

        //MainMenu
        Operations.MainMenu();

        //Write to csv
        FileHandling.WriteToCSV();
    }
}