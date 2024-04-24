using System;
namespace VirtualFunctionTwo;

class Program
{
    public static void Main(string[] args)
    {
        Rectangle rect = new Rectangle(10,20);
        rect.Calculate();
        rect.DisplayArea();

        Sphere sphere = new Sphere(5);
        sphere.Calculate();
        sphere.DisplayArea();
    }
}