using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface
{
    public interface ICalculate
    {
        //No fields and cosntructor
        //Property

        int Number{get;set;} //declaration only

        int Calculate(); //Method - declaration

        //Fully abtration - no definition
        
    }
}