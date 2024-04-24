using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class UserDetails : PersonalDetails, IBalance
    {
        /*
            •	CardNumber(Auto generation- CMRL1001)
            •	Balance
        */

        //Field
        //Static Field 

        /// <summary>
        /// This is a Static Pricate Field
        /// </summary>
        private static int s_cardNumber = 1000;

        //Property

        /// <summary>
        /// This is CardNumber Property. It is hold on user Card Number. and read only Property
        /// </summary>
        /// <value></value>
        public string CardNumber { get; } //Read Only Property

        /// <summary>
        /// This is Balance Property. It is store to user Balance data.
        /// </summary>
        /// <value></value>
        public int Balance { get; set; }

        //Constructors
        /// <summary>
        /// This is Paramerized Construtors
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="mobileNumber"></param>
        /// <param name="balance"> </param>
        /// <returns></returns>
        public UserDetails(string userName, string mobileNumber, int balance) : base(userName, mobileNumber)
        {
            //Auto Incrementation
            s_cardNumber++;
            //Assiging values
            CardNumber = "CMRL" + s_cardNumber;
            Balance = balance;
        }
        public UserDetails(string student) : base(student)
        {
            string[] temp = student.Split(',');
            s_cardNumber = int.Parse(temp[0].Remove(0, 4));
            CardNumber = temp[0];
            Balance = int.Parse(temp[3]);
        }
        //methods

        public void WalletRecharge(int amount)
        {
            Balance += amount;
        }


        //Methods

        public void DeductBalance(int amount)
        {
            Balance -= amount;
        }
    }
}