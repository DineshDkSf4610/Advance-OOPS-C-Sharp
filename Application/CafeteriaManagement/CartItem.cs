using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaManagement
{
    public class CartItem
    {
        /*
        •	ItemID (Auto - ITID101) 
        •	OrderID
        •	FoodID
        •	OrderPrice
        •	OrderQuantity

        */

        //field
        private static int s_itemId = 100;

        public string ItemID { get; } //Read only propety

        public string OrderID { get; set; }

        public string FoodID { get; set; }

        public int OrderPrice { get; set; }

        public int OrderQuantity { get; set; }

        //Contrutors

        public CartItem(string orderID, string foodID, int orderPrice, int orderQuantity)
        {
            //Auto Incrementaion
            s_itemId++;

            //assiging values
            ItemID = "ITID" + s_itemId;
            OrderID = orderID;
            FoodID = foodID;
            OrderPrice = orderPrice;
            OrderQuantity = orderQuantity;
        }

        

    }
}