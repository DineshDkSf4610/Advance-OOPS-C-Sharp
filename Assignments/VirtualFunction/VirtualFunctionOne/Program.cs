using System;
namespace VirtualFunctionOne;

class Program 
{
    public static void Main(string[] args)
    {
        VolumeCalculator volumCal = new VolumeCalculator(5,10);
        AreaCalculator areaCal = new AreaCalculator(5);

        //Display

        volumCal.DisPlay();
        areaCal.DisPlay();
    }
}