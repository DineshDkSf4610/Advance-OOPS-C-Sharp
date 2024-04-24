using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultilevelInheritanceTwo
{
    public class DepartmentDetails
    {
        /*

        DepartmentName, Degree

        */

        //Field 
        //Static Field
        private static int s_departmentID = 100;

        //Property

        public string DepartmentID { get; } //Read Only Propety

        public string DepartmentName { get; set; }

        public string Degree { get; set; }

        //Constructor

        public DepartmentDetails(string departmentName, string degree)
        {
            //Auto Incrementaion
            s_departmentID++;

            DepartmentID = "DID" + s_departmentID;
            DepartmentName = departmentName;
            Degree = degree;
        }

        public DepartmentDetails(string departmentID, string departmentName, string degree)
        {
            DepartmentID = departmentID;
            DepartmentName = departmentName;
            Degree = degree;
        }
    }
}