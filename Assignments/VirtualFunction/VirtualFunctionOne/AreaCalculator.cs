using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualFunctionOne
{
    public class AreaCalculator
    {


        public double Radius { get; set; }

        public AreaCalculator(double radius)
        {
            Radius = radius;
        }

        public virtual double Calculate()
        {
            return 3.14 * Radius * Radius;
        }

        public virtual void DisPlay()
        {
            Console.WriteLine($"Area: {Calculate()}");
        }

    }
}