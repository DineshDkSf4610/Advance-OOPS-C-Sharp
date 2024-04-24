using System;
using System.Collections.Generic;
using Dependency_Injection;
namespace DependencyInjection;

class Program {
    public static void Main(string[] args)
    {
        CCAccount ccAccount = new CCAccount();
        ccAccount.AccountNumber = 123;
        ccAccount.Name = "dinesh";
        ccAccount.Balance = 101101010101;


        SBAccount sbAccount = new SBAccount();
        sbAccount.AccountNumber = 123;
        sbAccount.Name = "kumar";
        sbAccount.Balance = 101164345010101;

        List<CCAccount> ccList = new List<CCAccount>();
        ccList.Add(ccAccount);

        List<SBAccount> sbList = new List<SBAccount>();
        sbList.Add(sbAccount);

        List<IAccount> accountList = new List<IAccount>();
        accountList.Add(ccAccount);
        accountList.Add(sbAccount);

    }
}