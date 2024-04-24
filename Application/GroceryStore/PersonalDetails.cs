using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore
{

    //Enum Declaration
    public enum Gender { Select, Male, Female, Transgender }
    public class PersonalDetails : IBalance
    {
        /*

        Name, FatherName, Gender, Mobile, DOB, MailID

        */

        //Filed

        private int _balance;

        //Propety

        public int WalletBalance { get { return _balance; } }
        public string Name { get; set; }

        public string FatherName { get; set; }

        public Gender Gender { get; set; }

        public string MobileNumber { get; set; }

        public DateTime DOB { get; set; }

        public string MailID { get; set; }


        //Construtors

        public PersonalDetails(string name, string fatherName, Gender gender, string mobileNumber, DateTime dob, string mailID, int balance)
        {
            Name = name;
            FatherName = fatherName;
            Gender = gender;
            MobileNumber = mobileNumber;
            DOB = dob;
            MailID = mailID;
            _balance = balance;
        }
        public PersonalDetails(string customers)
        {
            string[] temp = customers.Split(',');
            Name = temp[0];
            FatherName = temp[1];
            Gender = Enum.Parse<Gender>(temp[2], true);
            MobileNumber = temp[3];
            DOB = DateTime.ParseExact(temp[4], "dd/MM/yyyy", null);
            MailID = temp[5];
            _balance = int.Parse(temp[6]);
        }

        public void WalletRecharge(int amount)
        {
            _balance += amount;
        }

        public void DeduceAmount(int amount)
        {
            _balance -= amount;
        }
    }
}