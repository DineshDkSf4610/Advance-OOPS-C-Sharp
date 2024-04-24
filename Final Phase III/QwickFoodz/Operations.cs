using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public class Operations
    {

        //List Declaration

        public static List<CustomerDetails> customerList = new List<CustomerDetails>();

        public static List<FoodDetails> foodList = new List<FoodDetails>();

        public static List<OrderDetails> orderList = new List<OrderDetails>();

        public static List<ItemDetails> itemList = new List<ItemDetails>();

        //temp order
        static List<ItemDetails> localTempList = new List<ItemDetails>();

        // static CustomList<CustomerDetails> customerList = new CustomList<CustomerDetails>();

        // static CustomList<FoodDetails> foodList = new CustomList<FoodDetails>();

        // static CustomList<OrderDetails> orderList = new CustomList<OrderDetails>();

        // static CustomList<ItemDetails> itemList = new CustomList<ItemDetails>();

        // //temp order
        // static List<ItemDetails> localTempList = new List<ItemDetails>();

        //current Login
        static CustomerDetails currentLoggedIn;

        //Main Menu 
        public static void MainMenu()
        {
            Console.WriteLine("Online Food Delivery Application (Qwick Foodz)");
            Console.WriteLine("**********************************************\n");
            string mainMenuOption = "yes";

            do
            {
                Console.WriteLine("Select an Option : ");
                Console.WriteLine("\n\t1.Customer Registration\n\t2.Customer Login\n\t3.Exit\n");
                Console.Write("Enter an Option: ");
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
                            mainMenuOption = "no";
                            Console.WriteLine("Exit");
                            break;
                        }
                }

            } while (mainMenuOption == "yes");
        }

        //Customer Registration
        public static void CustomerRegistration()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Father Name: ");
            string fatherName = Console.ReadLine();
            Console.Write("Enter Gender (Male/Female/Trangender) :");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            Console.Write("Enter Mobile Number: ");
            string mobileNumber = Console.ReadLine();
            Console.Write("Enter DOB (DD/MM/YYYY): ");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.Write("Enter Mail ID: ");
            string mailID = Console.ReadLine();
            Console.Write("Enter Location: ");
            string location = Console.ReadLine();
            Console.Write("Enter Balance: ");
            int balance = int.Parse(Console.ReadLine());

            //Create an object
            CustomerDetails neCustomer = new CustomerDetails(name, fatherName, gender, mobileNumber, dob, mailID, location, balance);
            customerList.Add(neCustomer);
            Console.WriteLine($"\n**************************************************************************");
            Console.WriteLine($"Customer registration successful Your Customer ID: {neCustomer.CustomerID}");
            Console.WriteLine($"**************************************************************************\n");
        }

        //Customer Login
        public static void CustomerLogin()
        {
            Console.Write("Enter CustomerID: ");
            string customerID = Console.ReadLine().ToUpper();
            //check customer id
            bool flag = true;
            foreach (CustomerDetails customer in customerList)
            {
                if (customerID.Equals(customer.CustomerID))
                {
                    flag = false;
                    currentLoggedIn = customer;
                    SubMenu();
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("Invalid user ID");
            }
        }

        public static void SubMenu()
        {
            Console.WriteLine("\nSub Menu");
            Console.WriteLine("********");

            string subMenuOption = "yes";

            do
            {
                Console.WriteLine("Select an Option: ");
                Console.WriteLine("\n\t1.Show Profile\n\t2.Order Food\n\t3.Cancel Order\n\t4.Modify Order\n\t5.Order History\n\t6.Recharge Wallet\n\t7.Show Wallet Balance\n\t8.Exit\n");
                Console.Write("Enter an Option: ");
                int subMenuChoise = int.Parse(Console.ReadLine());

                switch (subMenuChoise)
                {
                    case 1:
                        {
                            Console.WriteLine("\nshow Profile");
                            Console.WriteLine("*************");
                            ShowProfile();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("\nOrder Food");
                            Console.WriteLine("*************");
                            OrderFood();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("\nCancel Order");
                            Console.WriteLine("*************");
                            CancelOrder();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("\nModify Order");
                            Console.WriteLine("*************");
                            ModifyOrder();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("\nOrder History");
                            Console.WriteLine("*************");
                            OrderHistroy();
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("\nRecharge Wallet");
                            Console.WriteLine("*************");
                            RechargeWallet();
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("\nShow Wallet Balance");
                            Console.WriteLine("*************");
                            ShowWalletBalance();
                            break;
                        }
                    case 8:
                        {
                            subMenuOption = "no";
                            Console.WriteLine("\nExit");
                            Console.WriteLine("*************");
                            break;
                        }
                }

            } while (subMenuOption == "yes");
        }

        //show Profile
        public static void ShowProfile()
        {
            Console.WriteLine("");
            Console.WriteLine($"Name: {currentLoggedIn.Name}");
            Console.WriteLine($"Father Name: {currentLoggedIn.FatherName}");
            Console.WriteLine($"Gender: {currentLoggedIn.Gender}");
            Console.WriteLine($"Mobile Number: {currentLoggedIn.Mobile}");
            Console.WriteLine($"DOB: {currentLoggedIn.DOB.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Mail ID: {currentLoggedIn.MailID}");
            Console.WriteLine($"Location: {currentLoggedIn.Location}");
            Console.WriteLine($"Wallet Balance: {currentLoggedIn.WalletBalance}");
            Console.WriteLine("");
        }

        //Order Food
        public static void OrderFood()
        {
            //create object
            OrderDetails newOrder = new OrderDetails(currentLoggedIn.CustomerID, 0, DateTime.Now, OrderStatus.Initiated);
            //creat local temp
            //Add temp Lisr
            // tempList.Add(newOrder);

            //show all food items list
            Console.WriteLine($"{"FoodID",-10}{"FoodName",-22}{"PricePerQuantity",-22}{"QuantityAvailable",-24}");
            foreach (FoodDetails food in foodList)
            {
                Console.WriteLine($"{food.FoodID,-10}{food.FoodName,-22}{food.PricePerQuantity,-22}{food.QuantityAvailable,-24}");
            }
            Console.WriteLine("");
            //Repeat loop
            string contin = "yes";
            do
            {
                Console.WriteLine("");
                //ask input to Food id
                Console.Write("Enter Food ID: ");
                string foodID = Console.ReadLine().ToUpper();
                //get No of Qun
                Console.Write("Enter Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                //check food id and available qun
                bool flag = true;
                foreach (FoodDetails food1 in foodList)
                {
                    if (foodID.Equals(food1.FoodID) && quantity <= food1.QuantityAvailable)
                    {
                        flag = false;
                        // string orderID, string foodID, int purchaseCOunt, int priceOfOrder
                        ItemDetails newItem = new ItemDetails(newOrder.OrderID, food1.FoodID, quantity, quantity * food1.PricePerQuantity);
                        localTempList.Add(newItem);
                        //deduct available Qun
                        food1.QuantityAvailable -= quantity;
                        //more to order
                        Console.Write("\nDo you want to order more ? - yes/no: ");
                        contin = Console.ReadLine();
                        break;
                    }
                }
                if (flag)
                {
                    Console.WriteLine("FoodID Invalid or FoodQuantity unavailable.");
                }
            } while (contin == "yes");

            if (localTempList.Count > 0)
            {
                //confim order
                Console.Write("\nDo you want to confirm purchase ? - yes/no :");
                string confim = Console.ReadLine();

                if (confim == "yes")
                {

                    int totalAmount = 0;
                    //calculate total amount
                    foreach (ItemDetails local in localTempList)
                    {
                        totalAmount += local.PriceOfOrder;
                    }
                    //check sufficient balance
                    string balanceContinue = "yes";
                    do
                    {
                        if (currentLoggedIn.WalletBalance >= totalAmount)
                        {
                            balanceContinue = "no";
                            OrderDetails confirmOrder = new OrderDetails(newOrder.OrderID, currentLoggedIn.CustomerID, totalAmount, DateTime.Now, OrderStatus.Ordered);
                            orderList.Add(confirmOrder);
                            currentLoggedIn.DeductBalance(totalAmount);
                            itemList.AddRange(localTempList);
                            Console.WriteLine("\n*********************************");
                            Console.WriteLine("Order Successfully....!");
                            Console.WriteLine($"Order ID: {confirmOrder.OrderID}");
                            Console.WriteLine("*********************************\n");
                            localTempList.Clear();
                        }
                        else
                        {
                            Console.WriteLine("insufficient balance..!");
                            Console.Write("Continue to Recharge ? - yes/no :");
                            balanceContinue = Console.ReadLine();
                            if (balanceContinue == "yes")
                            {
                                Console.Write("Enter a Amount: ");
                                int amount = int.Parse(Console.ReadLine());
                                currentLoggedIn.WalletRecharge(amount);
                                Console.WriteLine("Recharge Successully ... !");
                                Console.WriteLine($"Total Balance : {currentLoggedIn.WalletBalance}");
                            }
                            else
                            {
                                //back to add food qun
                                foreach (ItemDetails local in localTempList)
                                {
                                    foreach (FoodDetails food in foodList)
                                    {
                                        if (local.FoodID.Equals(food.FoodID))
                                        {
                                            // add food qun
                                            food.QuantityAvailable += local.PurchaseCount;
                                        }
                                    }
                                }
                            }
                        }
                    } while (balanceContinue == "yes");


                }
                else
                {
                    //back to add food qun
                    foreach (ItemDetails local in localTempList)
                    {
                        foreach (FoodDetails food in foodList)
                        {
                            if (local.FoodID.Equals(food.FoodID))
                            {
                                // add food qun
                                food.QuantityAvailable += local.PurchaseCount;
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No Items List.");
            }


        }

        //cancel Order
        public static void CancelOrder()
        {
            bool flag = true;
            Console.WriteLine($"{"OrderID",-10}{"CustomerID",-12}{"TotalPrice",-13}{"DateOfOrder",-15}{"OrderStatus",-15}");
            foreach (OrderDetails order in orderList)
            {
                if (currentLoggedIn.CustomerID.Equals(order.CustomerID) && order.OrderStatus == OrderStatus.Ordered)
                {
                    flag = false;
                    Console.WriteLine($"{order.OrderID,-10}{order.CustomerID,-12}{order.TotalPrice,-13}{order.DateOfOrder.ToString("dd/MM/yyyy"),-15}{order.OrderStatus,-15}");
                }
            }

            if (!flag)
            {
                Console.Write("Enter OrderID: ");
                string orderID = Console.ReadLine().ToUpper();
                //check orderId
                bool orderFlag = true;
                foreach (OrderDetails order in orderList)
                {
                    if (orderID.Equals(order.OrderID))
                    {
                        orderFlag = false;
                        order.OrderStatus = OrderStatus.Cancelled;
                        currentLoggedIn.WalletRecharge(order.TotalPrice); //refund
                        Console.WriteLine("\n***********************");
                        Console.WriteLine("Order Cancel Succefully");
                        Console.WriteLine("***********************\n");
                    }
                }
                if (orderFlag)
                {
                    Console.WriteLine("\n***********************");
                    Console.WriteLine("Invalid Order ID.");
                    Console.WriteLine("***********************\n");
                }
            }
            else
            {
                Console.WriteLine("\n***********************");
                Console.WriteLine("Data Not Found.");
                Console.WriteLine("***********************\n");
            }
        }

        //Modity Order
        public static void ModifyOrder()
        {
            //Show Order list
            bool flag = true;
            Console.WriteLine($"{"OrderID",-12}{"CustomerID",-13}{"TotalPrice",-12}{"DateOfOrder",-15}{"OrderStatus",-15}");
            foreach (OrderDetails order in orderList)
            {
                if (currentLoggedIn.CustomerID.Equals(order.CustomerID) && order.OrderStatus == OrderStatus.Ordered)
                {
                    flag = false;
                    Console.WriteLine($"{order.OrderID,-12}{order.CustomerID,-13}{order.TotalPrice,-12}{order.DateOfOrder.ToString("dd/MM/yyyy"),-15}{order.OrderStatus,-15}");
                }
            }
            if (flag)
            {
                Console.WriteLine("Data Not Found.");
            }
            else
            {
                //ask order id
                Console.Write("Order ID: ");
                string orderID = Console.ReadLine().ToUpper();

                //check Order Id
                bool orderFlag = true;
                foreach (OrderDetails order in orderList)
                {
                    if (orderID.Equals(order.OrderID))
                    {
                        orderFlag = false;
                        Console.WriteLine("*****Items List********");
                        // ItemID	OrderID	FoodID	PurchaseCount	PriceOfOrder
                        Console.WriteLine($"{"ItemID",-12}{"OrderID",-12}{"FoodID",-12}{"PurchaseCount",-17}{"PriceOfOrder",-15}");
                        foreach (ItemDetails item in itemList)
                        {
                            if (order.OrderID.Equals(item.OrderID))
                            {
                                Console.WriteLine($"{item.ItemID,-12}{item.OrderID,-12}{item.FoodID,-12}{item.PurchaseCount,-17}{item.PriceOfOrder,-15}");

                            }
                        }
                        Console.Write("Enter Item ID: ");
                        string itemID = Console.ReadLine().ToUpper();
                        Console.Write("Enter New Quantity: ");
                        int newQun = int.Parse(Console.ReadLine());
                        bool itemIDFlag = true;
                        foreach (ItemDetails item in itemList)
                        {
                            //check item id
                            if (itemID.Equals(item.ItemID))
                            {
                                itemIDFlag = false;
                                //check Qun 
                                foreach (FoodDetails food in foodList)
                                {
                                    //get food
                                    if (item.FoodID.Equals(food.FoodID))
                                    {
                                        //Return food qun
                                        food.QuantityAvailable += item.PurchaseCount;
                                        currentLoggedIn.WalletRecharge(item.PriceOfOrder);
                                        if (food.QuantityAvailable >= newQun && currentLoggedIn.WalletBalance >= newQun * food.PricePerQuantity)
                                        {
                                            food.QuantityAvailable -= newQun;
                                            item.PriceOfOrder = newQun * food.PricePerQuantity;
                                            currentLoggedIn.DeductBalance(newQun * food.PricePerQuantity);


                                            int totalAmount = 0;
                                            foreach (ItemDetails item1 in itemList)
                                            {
                                                if (item.OrderID.Equals(item1.OrderID))
                                                {
                                                    totalAmount += item1.PriceOfOrder;
                                                }
                                            }
                                            // update total amount in order details
                                            order.TotalPrice = totalAmount;
                                            // foreach (OrderDetails order in orderList)
                                            // {
                                            //     if (item.OrderID.Equals(order.OrderID))
                                            //     {
                                            //         order.TotalPrice = totalAmount;
                                            //         break;
                                            //     }
                                            // }
                                            Console.WriteLine("\n************************************************");
                                            Console.WriteLine($"Order ID {item.OrderID} + modified successfully");
                                            Console.WriteLine("\n************************************************\n");

                                        }
                                        else
                                        {
                                            food.QuantityAvailable -= item.PurchaseCount;
                                            currentLoggedIn.DeductBalance(item.PriceOfOrder);
                                            Console.WriteLine("Quantity Not available.");
                                        }

                                    }
                                }
                            }
                        }

                        if (itemIDFlag)
                        {
                            Console.WriteLine("Invalid Item ID.");
                        }
                        break;
                    }
                }
                if (orderFlag)
                {
                    Console.WriteLine("Invalid Order ID.");
                }

            }
        }
        //order history
        public static void OrderHistroy()
        {
            Console.WriteLine($"{"OrderID",-10}{"CustomerID",-13}{"TotalPrice",-13}{"DateOfOrder",-15}{"OrderStatus",-15}");
            foreach (OrderDetails order in orderList)
            {
                if (currentLoggedIn.CustomerID.Equals(order.CustomerID))
                {
                    Console.WriteLine($"{order.OrderID,-10}{order.CustomerID,-13}{order.TotalPrice,-13}{order.DateOfOrder.ToString("dd/MM/yyyy"),-15}{order.OrderStatus,-15}");
                }
            }
        }

        //Recharge Wallet
        public static void RechargeWallet()
        {
            Console.Write("Enter a Amount: ");
            int amount = int.Parse(Console.ReadLine());
            currentLoggedIn.WalletRecharge(amount);
            Console.WriteLine("***********************************");
            Console.WriteLine($"Total Balance : {currentLoggedIn.WalletBalance}");
            Console.WriteLine($"Recharge Successfully ......!");
            Console.WriteLine("***********************************\n");
        }
        //ShowWalletBalance
        public static void ShowWalletBalance()
        {
            Console.WriteLine("***************************");
            Console.WriteLine($"Wallet Balance: {currentLoggedIn.WalletBalance}");
            Console.WriteLine("***************************");

        }
        public static void AddDefaultData()
        {
            //Customer Details
            CustomerDetails customer1 = new CustomerDetails("Ravi", "Ettapparajan", Gender.Male, "974774646", new DateTime(1999, 11, 11), "ravi@gmail.com", "Chennai", 10000);
            CustomerDetails customer2 = new CustomerDetails("Baskaran", "Sethurajan", Gender.Male, "847575775", new DateTime(1999, 11, 11), "baskaran@gmail.com", "Chennai", 15000);
            customerList.Add(customer1);
            customerList.Add(customer2);

            //Food Details
            // string foodName, int pricePerQuantity, int quantityAvailable
            FoodDetails food1 = new FoodDetails("Chicken Briyani 1Kg", 100, 12);
            FoodDetails food2 = new FoodDetails("Mutton Briyani 1Kg", 150, 10);
            FoodDetails food3 = new FoodDetails("Veg Full Meals", 80, 30);
            FoodDetails food4 = new FoodDetails("Noodles", 100, 40);
            FoodDetails food5 = new FoodDetails("Dosa", 40, 40);
            FoodDetails food6 = new FoodDetails("Idly (2 pieces)", 20, 50);
            FoodDetails food7 = new FoodDetails("Pongal", 40, 20);
            FoodDetails food8 = new FoodDetails("Vegetable Briyani", 80, 15);
            FoodDetails food9 = new FoodDetails("Lemon Rice", 50, 30);
            FoodDetails food10 = new FoodDetails("Veg Pulav", 120, 30);
            FoodDetails food11 = new FoodDetails("Chicken 65 (200 Grams)", 75, 30);

            foodList.Add(food1);
            foodList.Add(food2);
            foodList.Add(food3);
            foodList.Add(food4);
            foodList.Add(food5);
            foodList.Add(food6);
            foodList.Add(food7);
            foodList.Add(food8);
            foodList.Add(food9);
            foodList.Add(food10);
            foodList.Add(food11);

            //OrderDetails 
            // string customerID, int totalPrice, DateTime dateOfOrder, OrderStatus orderstatus
            OrderDetails order1 = new OrderDetails("CID1001", 580, new DateTime(2022, 11, 26), OrderStatus.Ordered);
            OrderDetails order2 = new OrderDetails("CID1002", 870, new DateTime(2022, 11, 26), OrderStatus.Ordered);
            OrderDetails order3 = new OrderDetails("CID1001", 820, new DateTime(2022, 11, 26), OrderStatus.Cancelled);

            orderList.Add(order1);
            orderList.Add(order2);
            orderList.Add(order3);

            //ItemDetails 
            // string orderID, string foodID, int purchaseCOunt, int priceOfOrder
            ItemDetails item1 = new ItemDetails("OID3001", "FID2001", 2, 200);
            ItemDetails item2 = new ItemDetails("OID3001", "FID2002", 2, 300);
            ItemDetails item3 = new ItemDetails("OID3001", "FID2003", 1, 80);
            ItemDetails item4 = new ItemDetails("OID3002", "FID2001", 1, 100);
            ItemDetails item5 = new ItemDetails("OID3002", "FID2002", 4, 600);
            ItemDetails item6 = new ItemDetails("OID3002", "FID2010", 1, 120);
            ItemDetails item7 = new ItemDetails("OID3002", "FID2009", 1, 50);
            ItemDetails item8 = new ItemDetails("OID3003", "FID2002", 2, 300);
            ItemDetails item9 = new ItemDetails("OID3003", "FID2008", 4, 320);
            ItemDetails item10 = new ItemDetails("OID3003", "FID2001", 2, 200);

            itemList.Add(item1);
            itemList.Add(item2);
            itemList.Add(item3);
            itemList.Add(item4);
            itemList.Add(item5);
            itemList.Add(item6);
            itemList.Add(item7);
            itemList.Add(item8);
            itemList.Add(item9);
            itemList.Add(item10);

        }
    }
}