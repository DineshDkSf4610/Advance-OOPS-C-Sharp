using System;
using AbstarctOne;
namespace AbstractOne;

class Program
{
    public static void Main(string[] args)
    {
        Cylinders cylinder = new Cylinders(3,5);
        Cubes cube = new Cubes(4);

        Console.WriteLine("Cylinder:");
        Console.WriteLine($"Area: {cylinder.CalculateArea()}");
        Console.WriteLine($"Volume: {cylinder.CalculateVolume()}");

        Console.WriteLine("Cube:");
        Console.WriteLine($"Area: {cube.CalculateArea()}");
        Console.WriteLine($"Volume: {cube.CalculateVolume()}");


    }
}