using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialClassOne
{
    public partial class EmployeeInfo
    {

        // Constructors

        public EmployeeInfo(string name, Gender gender, DateTime dob, string mobile)
        {
            //Auto Incrementaiton
            s_employeeID++;
            //Assigning values
            EmployeeID = "EID" + s_employeeID;
            Name = name;
            Gender = gender;
            DOB = dob;
            Mobile = mobile;
        }

        public EmployeeInfo()
        {
            s_employeeID++;
            //Assigning values
            EmployeeID = "EID" + s_employeeID;
        }
    }
}