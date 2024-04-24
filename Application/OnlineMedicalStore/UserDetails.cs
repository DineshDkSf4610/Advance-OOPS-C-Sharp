using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class UserDetails : PersonalDetails, Interface
    {
        /*
            1.	UserID (Auto Increment – UID1001)
            2.	WalletBalance
        */

        private static int s_userID = 1000;

        public string UserID { get; }

        private int _balance;
        public int WalletBalance { get { return _balance; } }


        //Constructor
        public UserDetails(string name, int age, string city, string mobileNumber, int balance) : base(name, age, city, mobileNumber)
        {
            s_userID++;
            //Assiging values
            UserID = "UID" + s_userID;
            _balance = balance;
        }


        //Method

        public void WallerRecharge(int amount)
        {
            _balance += amount;
        }

        public void DeductBalance(int amount)
        {
            _balance -= amount;
        }

    }
}