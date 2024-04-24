using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore
{
    public class CustomerDetails : PersonalDetails, IBalance
    {
        /*
        CustomerID {Auto Increment – CID1000}, WalletBalance
        */

        //Field
        private static int s_customerID = 1000;

        //Property
        public string CustomerID { get; } //Read only property

  


        //Construtors
        public CustomerDetails(string name, string fatherName, Gender gender, string mobileNumber, DateTime dob, string mailID, int balance) : base(name, fatherName, gender, mobileNumber, dob, mailID, balance)
        {
            //Auto Incrementation
            s_customerID++;

            CustomerID = "CID" + s_customerID;
        }

         public CustomerDetails(string customerID, string name, string fatherName, Gender gender, string mobileNumber, DateTime dob, string mailID, int balance) : base(name, fatherName, gender, mobileNumber, dob, mailID, balance)
        {
            CustomerID = customerID;
        }
         public CustomerDetails(string customers) : base(customers)
        {
            string[] temp = customers.Split(',');
            s_customerID = int.Parse(temp[0].Remove(0,3));
            CustomerID = temp[0];
        }


        //Method
        // public void WalletRecharge(int amount)
        // {
        //     _balance += amount;
        // }


    }
}