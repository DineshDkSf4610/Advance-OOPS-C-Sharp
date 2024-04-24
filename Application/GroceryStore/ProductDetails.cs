using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore
{
    public class ProductDetails
    {
        /*
        ProductID {Auto Increment – PID2000}, ProductName, QuantityAvailable, PricePerQuantity
        */

        //Field
        private static int s_productID = 2000;

        //Property
        public string ProductID { get; } //Read only property

        public string ProductName { get; set; }

        public int QuantityAvailable { get; set; }

        public int PricePerQuantity { get; set; }

        //Construtors
        public ProductDetails(string productName, int quantityAvailable, int pricePerQuantity)
        {
            //Auto Incrementaion
            s_productID++;
            //Assigning values
            ProductID = "PID" + s_productID;
            ProductName = productName;
            QuantityAvailable = quantityAvailable;
            PricePerQuantity = pricePerQuantity;
        }

        public ProductDetails(string products)
        {
            string[] temp = products.Split(',');
            s_productID = int.Parse(temp[0].Remove(0, 3));
            ProductID = temp[0];
            ProductName = temp[1];
            QuantityAvailable = int.Parse(temp[2]);
            PricePerQuantity = int.Parse(temp[3]);
        }

        //Methods
        public void ShowProductDetails()
        {

            Console.WriteLine($"Product ID: {ProductID}\tProduct Name: {ProductName}\tQuantityAvailable: {QuantityAvailable}\tPricePerQuantity : {PricePerQuantity}");
        }

    }
}