using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbstractOne
{
    public class Cylinders : Shape
    {

        public override double Area { get; set; }

        public override double Volume { get; set; }

        public Cylinders(double radius, double height)
        {
            Radius = radius;
            Height = height;
        }

        public override double CalculateArea()
        {
            double tempArea = Radius + Height;
            Area = tempArea * (2 * Math.PI * Radius);
            Area = Math.Round(Area, 3);
            return Area;
        }

        public override double CalculateVolume()
        {
            Volume = Math.Round(Math.PI * Radius * Height, 3);
            return Volume;
        }


    }
}