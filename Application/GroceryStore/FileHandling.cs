using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore
{
    public class FileHandling
    {
        //Create folder
        public static void Create()
        {
            if (!Directory.Exists("GroceryStore"))
            {
                Console.WriteLine("Creating Folder ....");
                Directory.CreateDirectory("GroceryStore");
            }
            //File Create
            if (!File.Exists("GroceryStore/CutomerDetails.csv"))
            {
                File.Create("GroceryStore/CutomerDetails.csv").Close();
            }
            //Order Details
            if (!File.Exists("GroceryStore/OrderDetails.csv"))
            {
                File.Create("GroceryStore/OrderDetails.csv").Close();
            }
            //product Details
            if (!File.Exists("GroceryStore/ProductDetails.csv"))
            {
                File.Create("GroceryStore/ProductDetails.csv").Close();
            }
            //booking details

            if (!File.Exists("GroceryStore/BokkingDetails.csv"))
            {
                File.Create("GroceryStore/BokkingDetails.csv").Close();
            }
        }

        public static void WriteToCSV()
        {
            string[] customers = new string[Operators.customerList.Count];
            for (int i = 0; i < Operators.customerList.Count; i++)
            {
                // string name, string fatherName, Gender gender, string mobileNumber, DateTime dob, string mailID, int balance
                customers[i] = Operators.customerList[i].CustomerID + "," + Operators.customerList[i].Name + "," + Operators.customerList[i].FatherName + "," + Operators.customerList[i].Gender + "," + Operators.customerList[i].MobileNumber + "," + Operators.customerList[i].DOB.ToString("dd/MM/yyyy") + "," + Operators.customerList[i].MailID + "," + Operators.customerList[i].WalletBalance;
            }
            File.WriteAllLines("GroceryStore/CutomerDetails.csv", customers);


            //Order Details
            string[] orders = new string[Operators.orderList.Count];
            for (int i = 0; i < Operators.orderList.Count; i++)
            {
                // string bookingID, string productID, int purchaseCount, int priceOfOrder
                orders[i] = Operators.orderList[i].BookingID + "," + Operators.orderList[i].ProductID + "," + Operators.orderList[i].PurchaseCount + "," + Operators.orderList[i].PriceOfOrder;
            }
            File.WriteAllLines("GroceryStore/OrderDetails.csv", orders);

            //Product Details
            string[] products = new string[Operators.productList.Count];
            for (int i = 0; i < Operators.productList.Count; i++)
            {
                //  string productName, int quantityAvailable, int pricePerQuantity  

                products[i] = Operators.productList[i].ProductID + "," + Operators.productList[i].ProductName + "," + Operators.productList[i].QuantityAvailable + "," + Operators.productList[i].PricePerQuantity;
            }
            File.WriteAllLines("GroceryStore/ProductDetails.csv", products);

            //Booking details
            string[] bookings = new string[Operators.bookingList.Count];
            for (int i = 0; i < Operators.bookingList.Count; i++)
            {
                // string customerID, int totalPrice, DateTime dateOfBooking, BookingStatus bookingStatus
                bookings[i] = Operators.bookingList[i].BookingID + "," + Operators.bookingList[i].TotalPrice + "," + Operators.bookingList[i].DateofBooking + "," + Operators.bookingList[i].BookingStatus;
            }
            File.WriteAllLines("GroceryStore/BokkingDetails.csv", bookings);

        }

        public static void ReadFromCSV()
        {
            string[] students = File.ReadAllLines("GroceryStore/CutomerDetails.csv");
            foreach (string student in students)
            {
                CustomerDetails readCus = new CustomerDetails(student);
                Operators.customerList.Add(readCus);
            }

            //Order Details
            string[] orders = File.ReadAllLines("GroceryStore/OrderDetails.csv");
            foreach (string order in orders)
            {
                OrderDetails readOrder = new OrderDetails(order);
                Operators.orderList.Add(readOrder);
            }

            //Product Details
            string[] products = File.ReadAllLines("GroceryStore/ProductDetails.csv");
            foreach (string product in products)
            {
                ProductDetails readProduct = new ProductDetails(product);
                Operators.productList.Add(readProduct);
            }

            //Booking details
            string[] bookings = File.ReadAllLines("GroceryStore/BokkingDetails.csv");
            foreach (string booking in bookings)
            {
                BookingDetails readBooking = new BookingDetails(booking);
                Operators.bookingList.Add(readBooking);
            }
        }
    }
}