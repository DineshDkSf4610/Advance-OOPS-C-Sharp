using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore
{
    public class OrderDetails
    {
        /*
        OrderID {Auto Increment – OID4000}, BookingID, ProductID, PurchaseCount, PriceOfOrder
        */

        //Filed
        //Static Field
        private static int s_orderID = 4000;


        //Property
        public string OrderID { get; } //Read Only Property

        public string BookingID { get; set; }

        public string ProductID { get; set; }

        public int PurchaseCount { get; set; }

        public int PriceOfOrder { get; set; }

        //Constructors

        public OrderDetails(string bookingID, string productID, int purchaseCount, int priceOfOrder)
        {
            //Auto Incrementation
            s_orderID++;
            //assiging values
            OrderID = "OID" + s_orderID;
            BookingID = bookingID;
            ProductID = productID;
            PurchaseCount = purchaseCount;
            PriceOfOrder = priceOfOrder;
        }

        public OrderDetails(string orders)
        {
            string[] temp = orders.Split(',');
            s_orderID = int.Parse(temp[0].Remove(0, 3));
            OrderID = temp[0];
            BookingID = temp[1];
            ProductID = temp[2];
            PurchaseCount = int.Parse(temp[3]);
            PriceOfOrder = int.Parse(temp[4]);
        }
    }
}