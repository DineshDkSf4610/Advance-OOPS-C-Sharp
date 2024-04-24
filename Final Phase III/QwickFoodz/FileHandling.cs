using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public class FileHandling
    {
        //Create Folder
        public static void create()
        {
            if (!Directory.Exists("QwickFoodzData"))
            {
                Console.WriteLine("Creating Folder ....!");
                Directory.CreateDirectory("QwickFoodzData");
            }
            //file Creating
            //Customer Details
            if (!File.Exists("QwickFoodzData/CustomerDetails.csv"))
            {
                Console.WriteLine("Creating File ....!");
                File.Create("QwickFoodzData/CustomerDetails.csv").Close();
            }

            // FoodDetails

            if (!File.Exists("QwickFoodzData/FoodDetails.csv"))
            {
                Console.WriteLine("Creating File ....!");
                File.Create("QwickFoodzData/FoodDetails.csv").Close();
            }
            //Order Details

            if (!File.Exists("QwickFoodzData/OrderDetails.csv"))
            {
                Console.WriteLine("Creating File ....!");
                File.Create("QwickFoodzData/OrderDetails.csv").Close();
            }

            //item Details

            if (!File.Exists("QwickFoodzData/ItemDetails.csv"))
            {
                Console.WriteLine("Creating File ....!");
                File.Create("QwickFoodzData/ItemDetails.csv").Close();
            }

        }

        //write to csv

        public static void WriteToCSV()
        {
            //CustomerDetails
            string[] customers = new string[Operations.customerList.Count];
            // string name, string fatherName, Gender gender, string mobile, DateTime dob, string mailID, string location, int balance
            for (int i = 0; i < Operations.customerList.Count; i++)
            {
                customers[i] = Operations.customerList[i].CustomerID + "," + Operations.customerList[i].Name + "," + Operations.customerList[i].FatherName + "," + Operations.customerList[i].Gender + "," + Operations.customerList[i].Mobile + "," + Operations.customerList[i].DOB.ToString("dd/MM/yyyy") + "," + Operations.customerList[i].MailID + "," + Operations.customerList[i].Location + "," + Operations.customerList[i].WalletBalance;
            }

            File.WriteAllLines("QwickFoodzData/CustomerDetails.csv", customers);

            // FoodDetails
            string[] foods = new string[Operations.foodList.Count];
            // string foodName, int pricePerQuantity, int quantityAvailable
            for (int i = 0; i < Operations.foodList.Count; i++)
            {
                foods[i] = Operations.foodList[i].FoodID + "," + Operations.foodList[i].FoodName + "," + Operations.foodList[i].PricePerQuantity + "," + Operations.foodList[i].QuantityAvailable;
            }

            File.WriteAllLines("QwickFoodzData/FoodDetails.csv", foods);


            //OrderDetails
            string[] orders = new string[Operations.orderList.Count];
            // string customerID, int totalPrice, DateTime dateOfOrder, OrderStatus orderstatus
            for (int i = 0; i < Operations.orderList.Count; i++)
            {
                orders[i] = Operations.orderList[i].OrderID+","+Operations.orderList[i].CustomerID+","+Operations.orderList[i].TotalPrice+","+Operations.orderList[i].DateOfOrder.ToString("dd/MM/yyyy")+","+Operations.orderList[i].OrderStatus;
            }

            File.WriteAllLines("QwickFoodzData/OrderDetails.csv", orders);

            // ItemDetails

            string[] items = new string[Operations.itemList.Count];
            //  string orderID, string foodID, int purchaseCOunt, int priceOfOrder
            for (int i = 0; i < Operations.itemList.Count; i++)
            {
                items[i] = Operations.itemList[i].ItemID + "," + Operations.itemList[i].OrderID + "," + Operations.itemList[i].FoodID + "," + Operations.itemList[i].PurchaseCount + "," + Operations.itemList[i].PriceOfOrder;
            }

              File.WriteAllLines("QwickFoodzData/ItemDetails.csv", items);

        }
   
        public static void ReadFromCSV()
        {
            //CustomerDetails
           string[] customerlist =  File.ReadAllLines("QwickFoodzData/CustomerDetails.csv");

           foreach(string customer in customerlist)
           {
             CustomerDetails cus = new CustomerDetails(customer);
             Operations.customerList.Add(cus);
           }

            //    FoodDetails

            string[] foodlists = File.ReadAllLines("QwickFoodzData/FoodDetails.csv");

            foreach (string food in foodlists)
            {
                FoodDetails newfood = new FoodDetails(food);
                Operations.foodList.Add(newfood);
            }

            //OrderDetails

             string[] orderList = File.ReadAllLines("QwickFoodzData/OrderDetails.csv");

             foreach(string order in orderList)
             {
                OrderDetails readOrder = new OrderDetails(order);
                Operations.orderList.Add(readOrder);
             }

             //ItemDetails

             string[] itemLists = File.ReadAllLines("QwickFoodzData/ItemDetails.csv");

             foreach(string item in itemLists)
             {
                
             }

        }
    }
}