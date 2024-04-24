using System;


namespace CafeteriaManagement
{
    public class Operations
    {
        //static list
        static CustomList<UserDetails> userList = new CustomList<UserDetails>();

        static CustomList<FoodDetails> foodList = new CustomList<FoodDetails>();

        static CustomList<OrderDetails> orderList = new CustomList<OrderDetails>();

        static CustomList<CartItem> cartList = new CustomList<CartItem>();
        static CustomList<CartItem> tempCartList = new CustomList<CartItem>();

        static UserDetails currentLoggedIn;

        //Main Menu
        public static void MainMenu()
        {
            Console.WriteLine("Cafeteria management.");
            string mainMenuOption = "yes";
            do
            {
                Console.WriteLine("Select Option");
                Console.WriteLine("_____________\n");
                Console.WriteLine("1.User Registration\n2.User Login\n3.Exit");
                int mainMenuChoise = int.Parse(Console.ReadLine());

                switch (mainMenuChoise)
                {
                    case 1:
                        {
                            Console.WriteLine("User Registration");
                            Console.WriteLine("*****************");
                            UserRegistration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("User Login");
                            Console.WriteLine("**********");
                            UserLogin();
                            break;
                        }
                    case 3:
                        {
                            mainMenuOption = "no";
                            Console.WriteLine("Exit");
                            Console.WriteLine("****");
                            break;
                        }
                }

            } while (mainMenuOption == "yes");
        }


        //User Registration
        public static void UserRegistration()
        {
            Console.Write("User Name: ");
            string userName = Console.ReadLine();
            Console.Write("Father Name: ");
            string fatherName = Console.ReadLine();
            Console.Write("Mobile Number: ");
            string mobileNumber = Console.ReadLine();
            Console.Write("Mail ID: ");
            string mailID = Console.ReadLine();
            Console.Write("Select an Gender (Male/Female/Transgender) : ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            Console.Write("Enter a  Work Station Number : ");
            string workStationNumber = Console.ReadLine();
            Console.Write("Balance : ");
            int balance = int.Parse(Console.ReadLine());

            UserDetails user = new UserDetails(userName, fatherName, gender, mobileNumber, mailID, workStationNumber, balance);
            userList.Add(user);
            Console.WriteLine("*************************");
            Console.WriteLine($"User ID : {user.UserID}");
            Console.WriteLine("Registration Successfully");
            Console.WriteLine("*************************");
        }

        //User Login
        public static void UserLogin()
        {
            Console.Write("Enter User ID: ");
            string userID = Console.ReadLine();

            bool flag = true;
            foreach (UserDetails user in userList)
            {
                if (userID.Equals(user.UserID))
                {
                    flag = false;
                    currentLoggedIn = user;
                    Console.WriteLine("Logged Successfullty");
                    SubMenu();
                    break;

                }
            }

            if (flag)
            {
                Console.WriteLine("User ID is Invalid or not present");
            }


        }
        //SubMenu
        public static void SubMenu()
        {
            string subMenuChoise = "yes";
            Console.WriteLine("*******Sub Menu*********");
            do
            {
                Console.WriteLine("Select an Option: \n");
                Console.WriteLine("1.Show My Profile\n2.Food Order\n3.Modify Order\n4.Cancel Order\n5.Order History\n6.Wallet Recharge\n7.Show WalletBalance\n8.Exit\n");
                int subMenuOption = int.Parse(Console.ReadLine());

                switch (subMenuOption)
                {
                    case 1:
                        {
                            Console.WriteLine("Show My Profile");
                            Console.WriteLine("***************");
                            ShowMyProfile();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Food Order");
                            Console.WriteLine("**********");
                            FoodOrder();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Modify Order");
                            Console.WriteLine("************");
                            ModifyOrder();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Cancel Order");
                            Console.WriteLine("************");
                            CancelOrder();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Order History");
                            Console.WriteLine("*************");
                            OrderHistory();
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Wallet Recharge");
                            Console.WriteLine("***************");
                            WalletRecharge();
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Show Wallet Balance");
                            Console.WriteLine("*******************");
                            ShowWalletBalance();
                            break;
                        }
                    case 8:
                        {
                            subMenuChoise = "no";
                            Console.WriteLine("Exit");
                            Console.WriteLine("****");
                            break;
                        }
                }

            } while (subMenuChoise == "yes");
        }
        //show My Profile
        public static void ShowMyProfile()
        {
            Console.WriteLine("Personal Details");
            Console.WriteLine("***************");

            Console.WriteLine($"Name : {currentLoggedIn.Name}\nFather Name: {currentLoggedIn.FatherName}\nGender : {currentLoggedIn.Gender}\nMobile Number: {currentLoggedIn.MobileNumber}\nMail ID: {currentLoggedIn.MailID}\nWalletBalance : {currentLoggedIn.WalletBalance}");

             Console.WriteLine("\n***************\n");
        }

        //Food Order
        public static void FoodOrder()
        {
            //available Product List
            Console.WriteLine("FoodID	FoodName	Price	AvailableQuantity");
            foreach(FoodDetails food in foodList)
            {
             Console.WriteLine($"{food.FoodID}\t{food.FoodName}\t{food.FoodPrice}\t{food.AvailableQuantity}");
            }

            OrderDetails order = new OrderDetails(currentLoggedIn.UserID,DateTime.Now,0,OrderStatus.Initiated);
            
            //Display product list
            //create temp cart item list
            //create object status initiated, current date time , total price 0
            // get input product id and qut
            Console.Write("Enter a Food ID: ");
            string foodID = Console.ReadLine();
            Console.Write("Enter a Quantity : ");
            int qun = int.Parse(Console.ReadLine());

            //check food id and available quantity
            string picFood = "yes";
            do
            {
                bool flag = true;
                foreach (FoodDetails food in foodList)
                {
                    if (foodID.Equals(food.FoodID) && qun <= food.AvailableQuantity)
                    {
                        flag = false;
                        CartItem item = new CartItem(order.OrderID, food.FoodID, food.FoodPrice, qun);
                        tempCartList.Add(item);
                        food.AvailableQuantity -= qun;
                        Console.WriteLine("Itam Added Successfully");
                        Console.WriteLine("***********************");
                        Console.Write("Do you want to pick another food (yes/no) :");
                        picFood = Console.ReadLine();

                    }
                }

                if (flag)
                {
                    Console.WriteLine("Invalid input or not available quantity");
                }
            } while (picFood == "yes");
            Console.Write("Order Confirmed ? - yes/no :");
            string confirm = Console.ReadLine();

            if(confirm == "yes")
            {
                Console.WriteLine("Order List");
                Console.WriteLine("**********");
                Console.WriteLine("ItemID	OrderID	FoodID	OrderPrice	OrderQuantity");
                int totalAmount = 0;
                foreach(CartItem item in tempCartList)
                {
                    Console.WriteLine($"{item.ItemID}\t{item.OrderID}\t{item.OrderPrice}\t{item.OrderQuantity}");
                    totalAmount += item.OrderPrice;
                }
                Console.WriteLine("Total Price : " + totalAmount);

                //check available balance
                if(totalAmount <= currentLoggedIn.WalletBalance)
                {
                    //dedute baklce
                    currentLoggedIn.DeductAmount(totalAmount);
                    cartList.AddRange(tempCartList);
                    OrderDetails modifyOrder = new OrderDetails(order.OrderID, currentLoggedIn.UserID, DateTime.Now, totalAmount, OrderStatus.Ordered);
                    orderList.Add(modifyOrder);
                    Console.WriteLine($"Order placed successfully, and OrderID is {modifyOrder.OrderID}");
                }
                else
                {
                    Console.WriteLine("Insufficient balance to  purchase. Please Recharge");
                }



            }else{
                //Reduce the count
                foreach(CartItem item in tempCartList)
                {
                    foreach(FoodDetails food in foodList)
                    {
                        if(item.FoodID.Equals(food.FoodID)){
                            food.AvailableQuantity += item.OrderQuantity;
                        }
                    }
                }
            }


        }

        //Modify Order

        public static void ModifyOrder()
        {

        }

        //Cancel Order
        public static void CancelOrder()
        {

        }

        //Order History
        public static void OrderHistory()
        {

        }

        //Wallet Recharge
        public static void WalletRecharge()
        {

        }

        //Show WalletBalance
        public static void ShowWalletBalance()
        {

        }

        public static void AddDefaultData()
        {
            //User list
            UserDetails user1 = new UserDetails("Ravichandran", "Ettapparajan", Gender.Male, "8857777575", "ravi@gmail.com", "WS101", 400);
            UserDetails user2 = new UserDetails("Baskaran", "Baskaran", Gender.Male, "9577747744", "baskaran@gmail.com", "WS105", 500);

            userList.Add(user1);
            userList.Add(user2);

            //Order Details

            OrderDetails order1 = new OrderDetails("OID1001", "SF1001", new DateTime(2022, 06, 15), 70, OrderStatus.Ordered);
            OrderDetails order2 = new OrderDetails("OID1002", "SF1002", new DateTime(2022, 06, 15), 100, OrderStatus.Ordered);

            orderList.Add(order1);
            orderList.Add(order2);

            //Cart Items
            CartItem cart1 = new CartItem("OID1001", "FID101", 20, 1);
            CartItem cart2 = new CartItem("OID1001", "FID103", 10, 1);
            CartItem cart3 = new CartItem("OID1001", "FID105", 40, 1);
            CartItem cart4 = new CartItem("OID1001", "FID103", 10, 1);
            CartItem cart5 = new CartItem("OID1001", "FID104", 50, 1);
            CartItem cart6 = new CartItem("OID1001", "FID105", 40, 1);

            cartList.Add(cart1);
            cartList.Add(cart2);
            cartList.Add(cart3);
            cartList.Add(cart4);
            cartList.Add(cart5);
            cartList.Add(cart6);

            //Food list

            FoodDetails food1 = new FoodDetails("Coffee", 20, 100);
            FoodDetails food2 = new FoodDetails("Tea", 15, 100);
            FoodDetails food3 = new FoodDetails("Biscuit", 10, 100);
            FoodDetails food4 = new FoodDetails("Juice", 50, 100);
            FoodDetails food5 = new FoodDetails("Puff", 40, 100);
            FoodDetails food6 = new FoodDetails("Milk", 10, 100);
            FoodDetails food7 = new FoodDetails("Popcorn", 20, 20);

            foodList.Add(food1);
            foodList.Add(food2);
            foodList.Add(food3);
            foodList.Add(food4);
            foodList.Add(food5);
            foodList.Add(food6);
            foodList.Add(food7);

        }
    }
}