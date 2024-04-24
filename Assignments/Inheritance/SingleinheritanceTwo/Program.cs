using System;
using SingleinheritanceTwo;
namespace SingleInheritanceTwo;

class Program
{
    public static void Main(string[] args)
    {
        //Create Personal Info
        PersonalInfo personal = new PersonalInfo("dinehs", "kumar", "6646464646", "dinesh@gmail.come", new DateTime(2001, 04, 11), Gender.Male);

        //Account Info
        AccountInfo account = new AccountInfo(personal.PersonalInfoID, personal.Name, personal.FatherName, personal.Phone, personal.MailID, personal.DOB, personal.Gender, "Chennai", "IFSC1001", 100);

        //Display Details
        account.ShowAccountInfo();

        //Deposit Amount
        account.Deposit(200);
        Console.WriteLine($"Total Balance: {account.Balance}");

        //Withdraw
        account.Withdraw(100);
        Console.WriteLine($"Balance: {account.Balance}");

        //show Balance
        Console.WriteLine($"Balance: {account.ShowBalance().ToString()}");
    }
}