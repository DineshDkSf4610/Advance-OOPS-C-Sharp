using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbstractOne
{
    public abstract class Shape
    {
        public abstract double Area { get; set;}

        public abstract double Volume { get; set;}

        public double Radius { get; set; }

        public double Height { get; set; }

        public double Width { get; set; }

        public double Page { get; set; }


        public abstract double CalculateArea();

        public abstract double CalculateVolume();

    }
}