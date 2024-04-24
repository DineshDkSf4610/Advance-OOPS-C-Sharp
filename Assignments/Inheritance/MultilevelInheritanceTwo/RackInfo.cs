using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultilevelInheritanceTwo
{
    public class RackInfo : DepartmentDetails
    {
        /*

         RackNumber, ColumnNumber

        */

        //Field
        //Static Field

        private static int s_rackNumber = 200;

        //Property
        public string RackNumberID { get; } //Read Only Property

        public int RackNumber { get; set; }

        public int ColumnNumber { get; set; }

        //Construtors

        public RackInfo(string departmentID, string departmentName, string degree, int rackNumber, int columnNumber) : base(departmentID, departmentName, degree)
        {
            //Auto Incrementaion
            s_rackNumber++;

            //Assiging Values
            RackNumberID = "RID" + s_rackNumber;
            RackNumber = rackNumber;
            ColumnNumber = columnNumber;
        }

        public RackInfo(string rackID, string departmentID, string departmentName, string degree, int rackNumber, int columnNumber) : base(departmentID, departmentName, degree)
        {

            //Assiging Values
            RackNumberID = rackID;
            RackNumber = rackNumber;
            ColumnNumber = columnNumber;
        }
    }
}