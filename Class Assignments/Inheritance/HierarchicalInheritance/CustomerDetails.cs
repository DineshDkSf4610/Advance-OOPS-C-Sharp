using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HierarchicalInheritance
{
    public class CustomerDetails : PersonalDetails
    {
        //Field
        //Static Field
        private static int s_customerID = 2000;


        //Properties
        public string CustomerID { get; } // Read Only Property
        public int Balance { get; set; }

        //Construtors
        public CustomerDetails(string userID, string name, string fatherName, Gender gender, string phoneNumber, int balance) : base(userID, name, fatherName, gender, phoneNumber)
        {
            // Auto Incrementation
            s_customerID++;
            //Assiging value
            CustomerID = "CID" + s_customerID;
            Balance = balance;
        }
    }
}