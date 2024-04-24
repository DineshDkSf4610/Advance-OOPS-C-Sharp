using System;
using Operator_Overloading;
namespace OperatorOverloading;

class Program {
    public static void Main(string[] args)
    {
        Box box1 = new Box(1.2,3.2,4.2);
        Box box2 = new Box(10.1,11.1,12.20);

        Console.WriteLine(box1.CalculateVolume());
        Console.WriteLine(box2.CalculateVolume());


        Box box3 = Box.Add(box1, box2);

        Box box4 = box1 + box2;

        int c = 1+2;
        
    }
}