using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SingleInheritanceTwo;

namespace SingleinheritanceTwo
{
    public class AccountInfo : PersonalInfo  // Inherite PersonalInfo Class
    {

        /*
        AccountNumber, BranchName, IFSCCode, Balance

        */

        //Field
        //Static Field
        private static int s_accountNumber = 2000;

        //Property
        public string AccountNumber { get; } //Read only Propery

        public string BranchName { get; set; }

        public string IFSCCode { get; set; }

        public int Balance { get; set; }

        //Constractors

        public AccountInfo(string personalID, string name, string fatherName, string phone, string mailID, DateTime dob, Gender gender, string branchName, string ifscCode, int balance) : base(personalID, name, fatherName, phone, mailID, dob, gender)
        {
            //Auto Incrematation

            s_accountNumber++;

            //Assiging Values

            AccountNumber = "AID" + s_accountNumber;
            IFSCCode = ifscCode;
            Balance = balance;

        }

        //Methods

        public void ShowAccountInfo()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("******Account Details ************");
            Console.WriteLine($"Name: {Name}\nFather Name: {FatherName}\nPhone Number: {Phone}\nMail ID: {MailID}\nDOB: {DOB}\nGender: {Gender}\nBranch : {BranchName}\nIFSCCode: {IFSCCode}\nBalance: {Balance}");
        }

        //Deposit 

        public void Deposit(int amount)
        {
            Balance += amount;
        }

        //Withdraw
        public void Withdraw(int amount)
        {
            Balance -= amount;
        }

        // ShowBalance
        public int ShowBalance()
        {
            return Balance;
        }
    }
}