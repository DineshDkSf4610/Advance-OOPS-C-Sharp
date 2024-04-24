using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualFunctionTwo
{
    public class Dimention
    {
        public double Value1 { get; set; }

        public double Value2 { get; set; }

        public double Area { get; set; }

        public virtual void Calculate()
        {
            Area = Value1 * Value2;
        }

        public void DisplayArea()
        {
            Console.WriteLine($"Area: {Area}");
        }

        
    }
}