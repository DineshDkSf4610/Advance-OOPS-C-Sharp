using System;
namespace Interface;

class Program {
    public static void Main(string[] args)
    {
        Square number = new Square(); //class variable as object

        number.Number = 20;
        Console.WriteLine(number.Calculate());

        Circle circle = new Circle();
        circle.Number = 20;
        Console.WriteLine(circle.Calculate());
    }
}