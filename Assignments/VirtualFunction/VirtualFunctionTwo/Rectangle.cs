using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualFunctionTwo
{
    public class Rectangle : Dimention
    {

        public double Length { get {return Value1;} set{Value1 = value;} }

        public double Height { get {return Value2;} set{Value2 = value;} }

        public override void Calculate()
        {
            base.Calculate();
        }

        public Rectangle(double length, double height)
        {
            Length = length;
            Height = height;
        }

    }
}