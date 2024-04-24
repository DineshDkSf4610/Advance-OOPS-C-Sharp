using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbstractOne;

namespace AbstarctOne
{
    public class Cubes : Shape
    {
        public override double Area { get; set; }

        public override double Volume { get; set; }


        public Cubes(double area)
        {
            Area = area;
        }

        public override double CalculateArea()
        {
            return 6 * (Area * Area);
        }

        public override double CalculateVolume()
        {
            return Math.Pow(Area, 3);
        }
    }


}