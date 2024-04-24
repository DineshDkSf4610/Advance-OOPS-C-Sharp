using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore
{
    public class Operators
    {

        //list declaration
        static CustomerDetails currentLoggedIn;
        public static List<CustomerDetails> customerList = new List<CustomerDetails>();
        public static List<ProductDetails> productList = new List<ProductDetails>();

        public static List<BookingDetails> bookingList = new List<BookingDetails>();

        public static List<OrderDetails> orderList = new List<OrderDetails>();

        public static List<OrderDetails> tempOrderList = new List<OrderDetails>();

        //MainMenu
        public static void MainMenu()
        {
            Console.WriteLine("Online Grocery Store Application");
            string maniMenuOption = "yes";

            do
            {
                Console.WriteLine("Selete an Option :");
                Console.WriteLine("1.Customer Registration\n2.Customer Login\n3.Exit\n");
                int mainMenuChoise = int.Parse(Console.ReadLine());

                switch (mainMenuChoise)
                {
                    case 1:
                        {
                            Console.WriteLine("Customer Registration");
                            CustomerRegistration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Customer Login");
                            CustomerLogin();
                            break;
                        }
                    case 3:
                        {
                            maniMenuOption = "no";
                            Console.WriteLine("Exit");
                            break;
                        }
                }

            } while (maniMenuOption == "yes");
        }
        //Customer Registration
        public static void CustomerRegistration()
        {
            // string name, string fatherName, Gender gender, string mobileNumber, DateTime dob, string mailID, int balance) 

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Father Name: ");
            string fatherName = Console.ReadLine();
            Console.Write("Select Gender (Male/Female/Transgender) : ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            Console.Write("Enter Mobile Number : ");
            string mobileNumber = Console.ReadLine();
            Console.Write("Enter a DOB (dd/MM/yyyy) : ");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.WriteLine("Enter a Mail ID : ");
            string mailID = Console.ReadLine();
            Console.Write("Balance : ");
            int balance = int.Parse(Console.ReadLine());

            CustomerDetails cus = new CustomerDetails(name, fatherName, gender, mobileNumber, dob, mailID, balance);
            customerList.Add(cus);
            Console.WriteLine($"Registration Successfully. Customer ID : {cus.CustomerID}");
        }

        //Customer Login

        public static void CustomerLogin()
        {
            Console.Write("Enter User ID : ");
            string userID = Console.ReadLine();

            bool flag = true;
            foreach (CustomerDetails cus in customerList)
            {
                if (userID.Equals(cus.CustomerID))
                {
                    flag = false;
                    currentLoggedIn = cus;
                    SubMeu();
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("Invalid User ID.");
            }
        }

        public static void SubMeu()
        {
            string subMenuOption = "yes";
            do
            {
                Console.WriteLine("Select an Option :");
                Console.WriteLine("\t1.Show Customer Details\n\t2.Show Product Details\t\n3.Wallet Recharge\t\n4.Take Order\t\n5.Modify order Quantity\t\n6.Cancel Order\t\n7.Show Balance\t\n8.Exit\n");
                int subMenuChoise = int.Parse(Console.ReadLine());

                switch (subMenuChoise)
                {
                    case 1:
                        {
                            Console.WriteLine("Show Customer Details");
                            ShowCustomerDetails();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Show Product Details");
                            ShowProductDetails();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Wallet Recharge");
                            WalletRecharge();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Take Order");
                            TakeOrder();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Modity Order Quantity");
                            ModifyOrderQuantity();
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Cancel Order");
                            CancelOrder();
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Show Balance");
                            ShowBalance();
                            break;
                        }
                    case 8:
                        {
                            subMenuOption = "no";
                            Console.WriteLine("Exit");
                            break;
                        }
                }
            } while (subMenuOption == "yes");
        }

        //Show Customer Details
        public static void ShowCustomerDetails()
        {
            Console.WriteLine($"Name : {currentLoggedIn.Name}\nFather Name : {currentLoggedIn.FatherName}\nGender : {currentLoggedIn.Gender}\nDOB : {currentLoggedIn.DOB.ToString("dd/MM/yyyy")}\nMail ID: {currentLoggedIn.MailID}\nMobile Number : {currentLoggedIn.MobileNumber}\nBalance : {currentLoggedIn.WalletBalance}\n\n");
        }
        //Show Product Details
        public static void ShowProductDetails()
        {
            Console.WriteLine("ProductID	ProductName	QuantityAvailable	PricePerQuantity");
            Console.WriteLine("____________________________________________________________");
            foreach (ProductDetails product in productList)
            {
                product.ShowProductDetails();
            }
        }
        //Wallet Reacharge
        public static void WalletRecharge()
        {
            Console.Write("Enter a Amount : ");
            int amount = int.Parse(Console.ReadLine());

            currentLoggedIn.WalletRecharge(amount);
            Console.WriteLine($"Balance : {currentLoggedIn.WalletBalance}");
            Console.WriteLine("Recharge Successfully");
        }

        //Take Order
        public static void TakeOrder()
        {
            //Create booking onj
            BookingDetails booking = new BookingDetails(currentLoggedIn.CustomerID, 0, DateTime.Now, BookingStatus.Initiated);

            //show available product details
            foreach (ProductDetails product in productList)
            {
                product.ShowProductDetails();
            }
            string contine = "yes";
            do
            {
                //get product id 
                Console.Write("Enter a Product ID: ");
                string productID = Console.ReadLine();
                Console.Write("Enter a Quantity : ");
                int qun = int.Parse(Console.ReadLine());

                //check product id and qun
                bool flag = true;
                foreach (ProductDetails product1 in productList)
                {
                    if (productID.Equals(product1.ProductID) && product1.QuantityAvailable >= qun)
                    {
                        flag = false;
                        OrderDetails addProduct = new OrderDetails(booking.BookingID, product1.ProductID, qun, product1.PricePerQuantity * qun);
                        tempOrderList.Add(addProduct);
                        product1.QuantityAvailable -= qun;
                        Console.WriteLine("Product Added Succesfully");
                        break;
                    }
                }
                if (flag)
                {
                    Console.WriteLine("Invalid Product ID or Not avaialble quantity");
                }
                Console.Write("Do you want to another Product ID ? yes/no");
                contine = Console.ReadLine();
            } while (contine == "yes");

            // show total and confim
            // int totalAmount = 0;
            // foreach(OrderDetails order in tempOrderList)
            // {
            //     totalAmount += order.PriceOfOrder;
            // }
            Console.WriteLine("Total Amount : " + totalPurchaseAmount());
            Console.Write("Order Confirmed ? - yes/no");
            string confim = Console.ReadLine();
            if (confim == "yes")
            {
                if (currentLoggedIn.WalletBalance >= totalPurchaseAmount())
                {
                    //Update
                    BookingDetails booking1 = new BookingDetails(booking.BookingID, currentLoggedIn.CustomerID, 0, DateTime.Now, BookingStatus.Booked);
                    bookingList.Add(booking1);
                    orderList.AddRange(tempOrderList);
                    tempOrderList.Clear();
                    currentLoggedIn.DeduceAmount(totalPurchaseAmount());
                    Console.WriteLine("Order Successfully. Order ID : " + booking1.BookingID);
                }
                else
                {
                    Console.WriteLine("Insufficient account balance recharge with " + totalPurchaseAmount());
                }
            }
            else
            {
                foreach (OrderDetails order in tempOrderList)
                {
                    foreach (ProductDetails product in productList)
                    {
                        if (order.ProductID.Equals(product.ProductID))
                        {
                            product.QuantityAvailable += order.PurchaseCount;
                        }
                    }
                }
            }
        }

        public static int totalPurchaseAmount()
        {
            int totalAmount = 0;
            foreach (OrderDetails order in tempOrderList)
            {
                totalAmount += order.PriceOfOrder;
            }

            return totalAmount;
        }
        //Modify Order Quantity
        public static void ModifyOrderQuantity()
        {
            bool flag = true;
            //Show Booking details
            Console.WriteLine($"{"BookingID",-13}{"CustomerID",-13}{"TotalPrice",-13}{"DateOfBooking",-15}{"BookingStatus",-15}");
            foreach (BookingDetails booking in bookingList)
            {
                if (currentLoggedIn.CustomerID.Equals(booking.CustomerID) && booking.BookingStatus == BookingStatus.Booked)
                {
                    flag = false;
                    Console.WriteLine($"{booking.BookingID,-13}{booking.CustomerID,-13}{booking.TotalPrice,-13}{booking.DateofBooking.ToString("dd/MM/yyyy"),-15}{booking.BookingStatus,-15}");
                }
            }

            if (flag)
            {
                Console.WriteLine("Data Not Found.");
            }

            if (!flag)
            {
                Console.WriteLine("Enter Booking ID: ");
                string bookingID = Console.ReadLine();

                //Show Order list
                foreach(OrderDetails order in orderList)
                {
                    
                }
            }


        }

        //cancel Order
        public static void CancelOrder()
        {
            //Show Booking Details
            foreach (BookingDetails booking in bookingList)
            {
                if (currentLoggedIn.CustomerID.Equals(booking.CustomerID) && booking.BookingStatus == BookingStatus.Booked)
                {
                    //    string bookingID ,string customerID, int totalPrice, DateTime dateOfBooking, BookingStatus bookingStatus) 
                    Console.WriteLine($"{booking.BookingID}\t{booking.TotalPrice}\t{booking.DateofBooking}\t{booking.BookingStatus}");
                }
            }
            Console.Write("Enter a Booking ID : ");
            string bookingID = Console.ReadLine();
            bool flag = true;
            foreach (BookingDetails booking in bookingList)
            {
                if (bookingID.Equals(booking.BookingID))
                {
                    flag = false;
                    booking.BookingStatus = BookingStatus.Cancelled;
                    currentLoggedIn.WalletRecharge(booking.TotalPrice);
                    foreach (OrderDetails order in orderList)
                    {
                        if (booking.BookingID.Equals(order.BookingID))
                        {
                            foreach (ProductDetails product in productList)
                            {
                                if (order.ProductID.Equals(product.ProductID))
                                {
                                    product.QuantityAvailable += order.PurchaseCount;
                                }
                            }
                        }
                    }
                    Console.WriteLine("Order Cancel Successufully");
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("Invalid Booking ID");
            }
        }
        //Show Balance
        public static void ShowBalance()
        {
            Console.WriteLine("Balance : " + currentLoggedIn.WalletBalance);
        }
        //
        //Add Default data
        public static void AddDefaultData()
        {
            //Customer Details
            // CustomerID	WalletBalance	Name	FatherName	Gender	Mobile	DOB	MailID
            CustomerDetails customer1 = new CustomerDetails("Ravi", "Ettapparajan", Gender.Male, "974774646", new DateTime(1999, 11, 11), "ravi@gmail.com", 10000);
            CustomerDetails customer2 = new CustomerDetails("Baskaran", "Sethurajan", Gender.Male, "847575775", new DateTime(1999, 11, 11), "baskaran@gmail.com", 15000);
            customerList.Add(customer1);
            customerList.Add(customer2);


            //ProductDetails 

            ProductDetails product1 = new ProductDetails("Sugar", 20, 40);
            ProductDetails product2 = new ProductDetails("Rice", 100, 50);
            ProductDetails product3 = new ProductDetails("Milk", 10, 40);
            ProductDetails product4 = new ProductDetails("Coffee", 10, 10);
            ProductDetails product5 = new ProductDetails("Tea", 10, 10);
            ProductDetails product6 = new ProductDetails("Masala Powder", 10, 20);
            ProductDetails product7 = new ProductDetails("Salt", 10, 10);
            ProductDetails product8 = new ProductDetails("Turmeric Powder", 10, 25);
            ProductDetails product9 = new ProductDetails("Chilli Powder", 10, 20);
            ProductDetails product10 = new ProductDetails("Groundnut Oil", 10, 140);

            productList.AddRange(new List<ProductDetails> { product1, product2, product3, product4, product5, product6, product7, product8, product9, product10 });

            //BookingDetails 
            // string customerID, int totalPrice, DateTime dateOfBooking, BookingStatus bookingStatus

            BookingDetails booking1 = new BookingDetails("CID1001", 220, new DateTime(2022, 07, 26), BookingStatus.Booked);
            BookingDetails booking2 = new BookingDetails("CID1002", 400, new DateTime(2022, 07, 26), BookingStatus.Booked);
            BookingDetails booking3 = new BookingDetails("CID1001", 280, new DateTime(2022, 07, 26), BookingStatus.Cancelled);
            BookingDetails booking4 = new BookingDetails("CID1002", 0, new DateTime(2022, 07, 26), BookingStatus.Initiated);

            bookingList.AddRange(new List<BookingDetails> { booking1, booking2, booking3, booking4 });

            //OrderDetails
            // string bookingID, string productID, int purchaseCount, int priceOfOrde
            OrderDetails order1 = new OrderDetails("BID3001", "PID2001", 2, 80);
            OrderDetails order2 = new OrderDetails("BID3001", "PID2002", 2, 100);
            OrderDetails order3 = new OrderDetails("BID3001", "PID2003", 1, 40);
            OrderDetails order4 = new OrderDetails("BID3002", "PID2001", 1, 40);
            OrderDetails order5 = new OrderDetails("BID3002", "PID2002", 4, 200);
            OrderDetails order6 = new OrderDetails("BID3002", "PID2010", 1, 140);
            OrderDetails order7 = new OrderDetails("BID3002", "PID2009", 1, 20);
            OrderDetails order8 = new OrderDetails("BID3003", "PID2002", 2, 100);
            OrderDetails order9 = new OrderDetails("BID3003", "PID2008", 4, 100);
            OrderDetails order10 = new OrderDetails("BID3003", "PID2001", 2, 80);

            orderList.AddRange(new List<OrderDetails> { order1, order2, order3, order4, order5, order6, order7, order8, order9, order10 });
        }
    }
}