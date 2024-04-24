using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public class FoodDetails
    {
        /*
        FoodID, FoodName, PricePerQuantity, QuantityAvailable
        */

        //static field
        private static int s_foodID = 2000;

        //property
        public string FoodID { get; } //Read Only Property

        public string FoodName { get; set; }

        public int PricePerQuantity { get; set; }

        public int QuantityAvailable { get; set; }


        //Constructors

        public FoodDetails(string foodName, int pricePerQuantity, int quantityAvailable)
        {
            //Auto Incrementaion
            s_foodID++;

            //Assiging value
            FoodID = "FID" + s_foodID;
            FoodName = foodName;
            PricePerQuantity = pricePerQuantity;
            QuantityAvailable = quantityAvailable;
        }
        public FoodDetails(string foods)
        {

            string[] temp = foods.Split(',');
            s_foodID = int.Parse(temp[0].Remove(0, 3));
            FoodID = temp[0];
            FoodName = temp[1];
            PricePerQuantity = int.Parse(temp[2]);
            QuantityAvailable = int.Parse(temp[3]);
        }


    }
}