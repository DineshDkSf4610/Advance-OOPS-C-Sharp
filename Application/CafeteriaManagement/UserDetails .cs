using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaManagement
{
    public class UserDetails : PersonalDetails, IBalance
    {
        /*
        •	UserID (Auto – SF1001)
        •	WorkStationNumber
        •	Field: _balance
        •	Read only property: WalletBalance.
        */

        //Field
        //Static Field
        private static int s_userID = 1000;

        private int _balance;

        public string UserID { get; } //Read only property

        public string WorkStationNumber { get; set; }

        public int WalletBalance { get { return _balance; } } //Read only property

        //Construtors
        public UserDetails(string name, string fatherName, Gender gender, string mobile, string mailID, string workStationNumber, int walletBalance) : base(name, fatherName, gender, mobile, mailID)
        {
            //Auto Incrementation
            s_userID++;

            //Assiging values
            UserID = "SF" + s_userID;
            WorkStationNumber = workStationNumber;
            _balance = walletBalance;

        }


        //Methods
        public void WalletRecharge(int amount)
        {
            _balance += amount;
        }

        public void DeductAmount(int amount)
        {
            _balance -= amount;
        }
    }
}