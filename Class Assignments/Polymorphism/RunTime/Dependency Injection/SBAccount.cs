using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dependency_Injection
{
    public class SBAccount : IAccount
    {

        public int AccountNumber { get; set; }

        public string Name { get; set; }

        public double Balance { get; set; }        
    }
}