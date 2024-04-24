using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inside
{
    public class Second : First
    {
        protected int ProtectedNumberOut {get{return ProtectedNumber;}}
    }
}