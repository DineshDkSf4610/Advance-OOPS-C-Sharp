using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbstractClassessAndMethods
{
    public abstract class Employee //abstract class
    {
        //Abstract class - partial abstration.
        //It has fields, property, method, constructors, destrutors, indexers, eventss.
        //can have both abstract declaration and normal definitions
        //can only used with an inherited class
        //Not support multiple inheritance
        //it cannot be static class
        protected string _name; //Normal Field

        public abstract string Name { get; set; } //Abstract Property

        public double Amount { get; set; } //Normal Property

        public string Display() //Normal Method
        {
            return _name;
        }

        public abstract double Salary(int dates); //Abstract Method - Only Declaration
    }
}