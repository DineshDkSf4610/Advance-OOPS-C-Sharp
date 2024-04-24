using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    //enum Declatatin
    public enum OrderStatus { Default, Initiated, Ordered, Cancelled }
    public class OrderDetails
    {
        /*
        OrderID, CustomerID, TotalPrice, DateOfOrder, OrderStatus – {Default, Initiated, Ordered, Cancelled}.
        */

        //static Field
        private static int s_orderID = 3000;

        //Property
        public string OrderID { get; } //Read Only Property

        public string CustomerID { get; set; }

        public int TotalPrice { get; set; }

        public DateTime DateOfOrder { get; set; }

        public OrderStatus OrderStatus { get; set; }

        //Constructors

        public OrderDetails(string customerID, int totalPrice, DateTime dateOfOrder, OrderStatus orderstatus)
        {
            //Auto incrementation
            s_orderID++;
            //Assiging value
            OrderID = "OID" + s_orderID;
            CustomerID = customerID;
            TotalPrice = totalPrice;
            DateOfOrder = dateOfOrder;
            OrderStatus = orderstatus;
        }

        public OrderDetails(string orders)
        {
            string[] temp = orders.Split(',');
            s_orderID = int.Parse(temp[0].Remove(0, 3));
            OrderID = temp[0];
            CustomerID = temp[1];
            TotalPrice = int.Parse(temp[2]);
            DateOfOrder = DateTime.ParseExact(temp[3], "dd/MM/yyyy", null);
            OrderStatus = Enum.Parse<OrderStatus>(temp[4], true);
        }


        public OrderDetails(string orderID,string customerID, int totalPrice, DateTime dateOfOrder, OrderStatus orderstatus)
        {
            OrderID = orderID;
            CustomerID = customerID;
            TotalPrice = totalPrice;
            DateOfOrder = dateOfOrder;
            OrderStatus = orderstatus;
        }

    }
}