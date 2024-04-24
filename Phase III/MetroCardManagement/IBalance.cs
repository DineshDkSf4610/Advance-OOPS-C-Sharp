using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public interface IBalance
    {

        //propery
        int Balance { get; set; }


        //Method
        void WalletRecharge(int amount);

        void DeductBalance(int amount);
    }
}