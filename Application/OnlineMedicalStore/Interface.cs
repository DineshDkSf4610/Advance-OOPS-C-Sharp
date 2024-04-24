using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public interface Interface
    {
        int WalletBalance { get; }

        void WallerRecharge(int amount);

        void DeductBalance(int amount);
    }
}