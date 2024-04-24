using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbstractClassessAndMethods
{
    public class Zoho : Employee
    {
        //Abstract Property Definitions
        public override string Name { get { return _name; } set { _name = value; } }

        //Abstract Method Definition
        public override double Salary(int dates)
        {
            Amount = (double)dates * 1000;
            return Amount;
        }


    }
}