using System;
namespace QwickFoodz;

class Program
{
    public static void Main(string[] args)
    {
        //Create files and folder
        FileHandling.create();
        //Adding default data
        // Operations.AddDefaultData();

        //Read Files
        FileHandling.ReadFromCSV();


        //Mainu menu call
        Operations.MainMenu();

        //wrirte data
        FileHandling.WriteToCSV();
    }
}