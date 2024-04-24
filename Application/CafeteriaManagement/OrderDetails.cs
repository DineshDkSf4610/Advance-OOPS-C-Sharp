using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaManagement
{
    //enum Declaration

    public enum OrderStatus { Default, Initiated, Ordered, Cancelled }
    public class OrderDetails
    {
        /*

            •	OrderID (Auto – OID1001)
            •	UserID
            •	OrderDate
            •	TotalPrice
            •	OrderStatus – (Default, Initiated, Ordered, Cancelled)
        */

        private static int s_orderID = 1000;

        //Property
        public string OrderID { get; } //Read only property

        public string UserID { get; set; }

        public DateTime OrderDate { get; set; }

        public int TotalPrice { get; set; }


        public OrderStatus OrderStatus { get; set; }

        //Constructors
        public OrderDetails(string userID, DateTime orderDate, int totalPrice, OrderStatus orderStaus)
        {
            //Auto incrementation
            s_orderID++;

            //assiging values
            OrderID = "OID" + s_orderID;
            UserID = userID;
            OrderDate = orderDate;
            TotalPrice = totalPrice;
            OrderStatus = orderStaus;
        }

        public OrderDetails(string orderID, string userID, DateTime orderDate, int totalPrice, OrderStatus orderStaus)
        {
            //assiging values
            OrderID = orderID;
            UserID = userID;
            OrderDate = orderDate;
            TotalPrice = totalPrice;
            OrderStatus = orderStaus;
        }
    }
}