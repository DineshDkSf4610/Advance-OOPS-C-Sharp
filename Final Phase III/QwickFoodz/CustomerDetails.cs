using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public class CustomerDetails : PersonalDetails, IBalance
    {
        /*
            Field: _balance
            Properties: CustomerID, WalletBalance
            Methods: WalletRecharge, DeductBalance
        */

        //Field

        /// <summary>
        /// This is Private _balance Field. It is maintain to balance value
        /// </summary>
        private int _balance = 0;
        //Static Filed

        /// <summary>
        /// this is a static s_customerID field. uniq field
        /// </summary>
        private static int s_customerID = 1000;


        //Property

        /// <summary>
        /// This is CustomerID Read only Property. it is store to customer ID.
        /// </summary>
        /// <value></value>
        public string CustomerID { get; } //Read only property

        /// <summary>
        /// this is WalletBalance Property. Its store to user wallet balance. Read only Property
        /// </summary>
        /// <value></value>
        public int WalletBalance { get { return _balance; } }



        //Constructors
        public CustomerDetails(string name, string fatherName, Gender gender, string mobile, DateTime dob, string mailID, string location, int balance) : base(name, fatherName, gender, mobile, dob, mailID, location)
        {

            //Auto Incrementation
            s_customerID++;
            //Assiging value
            CustomerID = "CID" + s_customerID;
            _balance = balance;

        }
        public CustomerDetails(string student) : base(student)
        {
            string[] temp = student.Split(',');
            s_customerID = int.Parse(temp[0].Remove(0, 3));
            CustomerID = temp[0];
            _balance = int.Parse(temp[8]);

        }
        //Methods

        public void WalletRecharge(int amount)
        {
            _balance += amount;
        }

        public void DeductBalance(int amount)
        {
            _balance -= amount;
        }



    }
}