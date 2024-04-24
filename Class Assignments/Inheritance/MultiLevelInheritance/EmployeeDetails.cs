using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiLevelInheritance
{
    public class EmployeeDetails : StudentDetails
    {
        //Field
        //Static Field
        private static int s_employeeID = 1000;

        //Property

        public string EmployeeID { get; } //Read Only Property

        public string Designation { get; set; }

        //Constutors
        public EmployeeDetails(string studentID, string userID, string name, string fatherName, Gender gender, string phoneNumber, int standard, string yearOfJoining, string designation) : base(studentID, name, fatherName, gender, phoneNumber, standard, yearOfJoining)
        {
            s_employeeID++;

            EmployeeID = "EID" + s_employeeID;
            Designation = designation;
        }

    }
}