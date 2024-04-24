using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultilevelInheritanceTwo
{
    public class BookInfo : RackInfo
    {
        /*

        BookID, BookName, AuthorName, Price

        */

        //Field
        //Static Field

        private static int s_bookID = 3000;

        //Property
        public string BookID { get; } //Read Only Property

        public string BookName { get; set; }

        public string AuthorName { get; set; }

        public int Price { get; set; }

        //Constructors

        public BookInfo(string rackID, string departmentID, string departmentName, string degree, int rackNumber, int columnNumber, string bookName, string authorName, int price) : base(rackID, departmentName, degree, rackNumber, columnNumber)
        {
            //Auto Incrementation
            s_bookID++;
            //Assigning values
            BookID = "BID" + s_bookID;
            BookName = bookName;
            AuthorName = authorName;
            Price = price;
        }

        //Methods

        public void DisplayInfo()
        {
            Console.WriteLine("Online Library");
            Console.WriteLine("**************");
            Console.WriteLine($"Author Name: {AuthorName}");
            Console.WriteLine($"Book Name: {BookName}");
            Console.WriteLine($"Department Name: {DepartmentName}");
            Console.WriteLine($"Degree: {Degree}");
            Console.WriteLine($"Rack Number: {RackNumber}");
            Console.WriteLine($"Column  Number: {ColumnNumber}");
            Console.WriteLine($"Price: {Price}");

        }
    }
}