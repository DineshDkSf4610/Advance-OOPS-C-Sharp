using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualFunctionTwo
{
    public class Sphere : Dimention
    {
        public double Radius { get { return Value1; } set { Value1 = value; } }

        public override void Calculate()
        {
            Area = 4 * 3.14 * Radius * Radius;
        }

        public Sphere(double radius)
        {
            Radius = radius;
        }


    }
}