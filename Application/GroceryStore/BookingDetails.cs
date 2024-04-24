using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore
{
    //Enum Declaration
    public enum BookingStatus { Default, Initiated, Booked, Cancelled }
    public class BookingDetails
    {
        /*
            BookingID {Auto Increment – BID3000}, CustomerID, 
            TotalPrice, DateOfBooking, 
            Booking Status – Default, Initiated, Booked, Cancelled.
        */

        //Field
        //Static Field
        private static int s_bookingID = 3000;

        //Property
        public string BookingID { get; } //Read Only Property

        public string CustomerID { get; set; }

        public int TotalPrice { get; set; }

        public DateTime DateofBooking { get; set; }

        public BookingStatus BookingStatus { get; set; }

        //Constructors

        public BookingDetails(string customerID, int totalPrice, DateTime dateOfBooking, BookingStatus bookingStatus)
        {
            //Auto Incrementation
            s_bookingID++;
            //Assigning values
            BookingID = "BID" + s_bookingID;
            CustomerID = customerID;
            TotalPrice = totalPrice;
            DateofBooking = dateOfBooking;
            BookingStatus = bookingStatus;
        }

        public BookingDetails(string bookingID, string customerID, int totalPrice, DateTime dateOfBooking, BookingStatus bookingStatus)
        {

            //Assigning values
            BookingID = bookingID;
            CustomerID = customerID;
            TotalPrice = totalPrice;
            DateofBooking = dateOfBooking;
            BookingStatus = bookingStatus;
        }

        public BookingDetails(string bookings)
        {
            string[] temp = bookings.Split(',');
            s_bookingID = int.Parse(temp[0].Remove(0, 3));
            BookingID = temp[0];
            CustomerID = temp[1];
            TotalPrice = int.Parse(temp[2]);
            DateofBooking = DateTime.ParseExact(temp[3], "dd/MM/yyyy", null);
            BookingStatus = Enum.Parse<BookingStatus>(temp[4], true);
        }

        //method
        public void ShowBookingDetails()
        {
            Console.WriteLine("BookingID	CustomerID	TotalPrice	DateOfBooking	BookingStatus");
            Console.WriteLine("_______________________________________________________________________");
            Console.WriteLine($"BookingID : {BookingID}\tCustomerID: {CustomerID}\tTotalPrice : {TotalPrice}\tDateOfBooking : {DateofBooking.ToString("dd/MM/yyyy")}\tBookingStatus : {BookingStatus}");
        }
    }
}