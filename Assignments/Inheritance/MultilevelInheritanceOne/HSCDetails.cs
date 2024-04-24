using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MultilvelInheritanceOne;

namespace MultilevelInheritanceOne
{
    public class HSCDetails : StudentInfo //inherite StudentInfor class
    {
        /*
        HSCMarksheetNumber, Physics, Chemistry, Maths, Total, Percentage marks
        */

        //Field
        //Static Field

        private static int s_HSCMarksheetNumber = 12000;

        //Property

        public string HSCMarksheetNumber { get; } //Read Only Property

        public int Physics { get; set; }

        public int Chemistry { get; set; }

        public int Maths { get; set; }

        public int Total { get; set; }

        public double PercentageMarks { get; set; }

        //Constractors

        public HSCDetails(string registarionID, string personalID, string name, string fatherName, string phone, string mailID, DateTime dob, Gender gender, int standard, string branch, int acadamicYear, int physics, int chemistry, int maths) : base(registarionID, personalID, name, fatherName, phone, mailID, dob, gender, standard, branch, acadamicYear)
        {
            //Auto Incrementation
            s_HSCMarksheetNumber++;
            //Assigning values
            HSCMarksheetNumber = "HSCID" + s_HSCMarksheetNumber;
            Physics = physics;
            Chemistry = chemistry;
            Maths = maths;
            Total = TotalMarks();
            PercentageMarks = Percentage();
        }

        //Methods
        public void GetMarks()
        {
            Console.WriteLine($"Physics: {Physics}");
            Console.WriteLine($"Chemistry: {Chemistry}");
            Console.WriteLine($"Maths: {Maths}");
        }

        //Total
        public int TotalMarks()
        {
            Total = Physics + Chemistry + Maths;
            return Total;
        }

        //percentage
        public double Percentage()
        {
            PercentageMarks = (double)TotalMarks() / 3;

            return PercentageMarks;
        }

        //Show Marksheet

        public void ShowMarksheet()
        {
            Console.WriteLine("*********************************");
            Console.WriteLine("********** Mark Sheets **********");
            Console.WriteLine("*********************************");

            GetMarks();
            Console.WriteLine($"Total: {Total}");
            Console.WriteLine($"Percentage: {PercentageMarks}");
        }
    }
}