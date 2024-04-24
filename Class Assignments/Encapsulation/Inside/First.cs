using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inside
{
    public class First
    {
        private int _privateNumber = 10;

        public int PrivateOut { get {return _privateNumber;} }

        public int PublicNumber =  10;

        protected int ProtectedNumber = 30; //
    }
}