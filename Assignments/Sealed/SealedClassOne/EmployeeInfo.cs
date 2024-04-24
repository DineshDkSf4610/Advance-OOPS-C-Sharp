using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SealedClassOne
{
    public sealed class EmployeeInfo
    {
        private static int s_userID = 2000;

        public string UserID { get; } //Read only property

        public string Password { get; set; }

        public int KeyInfo = 100;


        public EmployeeInfo(string password)
        {
            s_userID++;
            UserID = "UID" + s_userID;
            Password = password;

        }

        public void UpdateInfo(string password)
        {
            Password = password;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"UserID: {UserID}");
            Console.WriteLine($"Password: {Password}");
        }

    }
}