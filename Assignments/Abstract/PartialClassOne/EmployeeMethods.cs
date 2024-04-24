using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialClassOne
{
    public partial class EmployeeInfo
    {
        //Methods
        public void Update()
        {
            Console.Write("Enter Your Name: ");
            Name = Console.ReadLine();
            Console.Write("Select an Option (Male/Female):");
            Gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            Console.Write("Enter a DOB (DD/MM/YYYY): ");
            DOB = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            Console.Write("Enter Your Mobile Number: ");
            Mobile = Console.ReadLine();

        }

        public void Display()
        {
            Console.WriteLine("******Display Details*********");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Gender : {Gender}");
            Console.WriteLine($"DOB : {DOB.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Mobile : {Mobile}");
        }
    }
}