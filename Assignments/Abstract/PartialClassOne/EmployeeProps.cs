using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialClassOne
{
    //Enum Declaration
    public enum Gender {Select, Male, Female, Transgender}
    public partial class EmployeeInfo 
    {
        /*
        EmployeeID,Name,Gender,DOB, Mobile

        */

        //Field
        //static Field
        private static int s_employeeID = 1000;

        //Property

        public string EmployeeID { get;} //Read Only Property

        public string Name { get; set; }

        public Gender Gender { get; set; }

        public DateTime DOB { get; set; }

        public string Mobile { get; set; }

        
    }
}