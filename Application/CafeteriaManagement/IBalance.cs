using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaManagement
{
    public interface IBalance
    {
        int WalletBalance { get;}

        void WalletRecharge(int amount);

        void DeductAmount(int amount);
    }
}