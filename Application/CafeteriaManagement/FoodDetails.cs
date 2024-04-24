using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaManagement
{
    public class FoodDetails
    {
        /*
        •	FoodID (Auto - FID101)
        •	FoodName
        •	FoodPrice
        •	AvailableQuantity
        */

        private static int s_foodID = 100;

        //Property
        public string FoodID { get; } //Read Only property

        public string FoodName { get; set; }

        public int FoodPrice { get; set; }

        public int AvailableQuantity { get; set; }


        //Construtors

        public FoodDetails(string foodName, int foodPrice, int availableQuentity)
        {
            //Auto Incremenation
            s_foodID++;

            //Assigning values
            FoodID = "FID" + s_foodID;
            FoodPrice = foodPrice;
            AvailableQuantity = availableQuentity;
        }

    }
}