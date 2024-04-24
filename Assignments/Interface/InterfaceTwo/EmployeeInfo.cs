using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterfaceTwo
{
    public class EmployeeInfo : IDisplayInfo
    {
        /*
        EmployeeID, Name, FatherName
        */

        private static int s_employeeID = 200;

        //Property
        public string EmployeeID { get; }

        public string Name { get; set; }

        public string FatherName { get; set; }

        //Construtors
        public EmployeeInfo(string name, string fatherName)
        {
            s_employeeID++;
            EmployeeID = "EID" + s_employeeID;
            Name = name;
            FatherName = fatherName;
        }
        public void Display()
        {
            Console.WriteLine($"Employee ID: {EmployeeID}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Father Name: {FatherName}");
        }
    }
}