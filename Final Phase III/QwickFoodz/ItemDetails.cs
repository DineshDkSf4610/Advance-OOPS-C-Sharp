using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public class ItemDetails
    {
        /*
        ItemID – (ITID100), OrderID, FoodID, PurchaseCount, PriceOfOrder
        */

        //static Field
        private static int s_itemID = 4000; // ITID100

        public string ItemID { get; } //Read Only Property

        public string OrderID { get; set; }

        public string FoodID { get; set; }

        public int PurchaseCount { get; set; }

        public int PriceOfOrder { get; set; }

        //Constructors

        public ItemDetails(string orderID, string foodID, int purchaseCOunt, int priceOfOrder)
        {
            //auto incrementation
            s_itemID++;
            //assigin value
            ItemID = "ITID" + s_itemID;
            OrderID = orderID;
            FoodID = foodID;
            PurchaseCount = purchaseCOunt;
            PriceOfOrder = priceOfOrder;
        }
        public ItemDetails(string itemsList)
        {
            string[] temp = itemsList.Split(',');
            s_itemID = int.Parse(temp[0].Remove(0, 4));
            ItemID = temp[0];
            OrderID = temp[1];
            FoodID = temp[2];
            PurchaseCount = int.Parse(temp[3]);
            PriceOfOrder = int.Parse(temp[4]);
        }

    }
}