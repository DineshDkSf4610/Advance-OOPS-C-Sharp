using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SealedClassOne
{
    public class Hack : EmployeeInfo
    {
        // EmployeeInfo class is sealed class, so not assess the class file and properties
        private static int s_storeUserID = 100;

        public string StoreUserID { get;} //Read Only Property

        public string StorePassword { get; set; }
        

        public Hack(string storePassword)
        {
            s_storeUserID++;
            StoreUserID = "SID" + s_storeUserID;
            StorePassword = storePassword;
        }
        
        public void ShowKeyInfo()
        {
            // Console.WriteLine(KeyInfo);
            //EmployeeInfo class is sealed type, so not access Keyinfo Property
            
        }

        public void GetUserInfo(){

        }

        public void ShowUserInfo()
        {

        }
        
    }
}