using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class Operators
    {
        //List Declaration
        static List<UserDetails> userList = new List<UserDetails>();

        static List<MedicineDetails> medicineList = new List<MedicineDetails>();

        static List<OrderDetails> orderList = new List<OrderDetails>();

        //
        static UserDetails currentLoggedIn;


        //Main Menu
        public static void MainMenu()
        {
            Console.WriteLine("Onlice Medical Store");
            string mainMenuOption = "yes";

            do
            {
                Console.WriteLine("Select an Option : ");
                Console.WriteLine("\t1.User Registration\n\t2.User Login\n\t3.Exit\n");
                int mainMenuChoise = int.Parse(Console.ReadLine());

                switch (mainMenuChoise)
                {
                    case 1:
                        {
                            Console.WriteLine("User Registration");
                            UserRegistration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("User Login");
                            UserLogin();
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

        //User Registration
        public static void UserRegistration()
        {

        }

        //User Login
        public static void UserLogin()
        {
            Console.WriteLine("Enter a User ID : ");
            string userId = Console.ReadLine();
            bool flag = true;
            foreach (UserDetails user in userList)
            {
                if (userId.Equals(user.UserID))
                {
                    flag = false;
                    currentLoggedIn = user;
                    subMenu();
                    break;
                }
            }

            if (flag)
            {
                Console.WriteLine("Invalid User ID.");
            }
        }

        public static void subMenu()
        {
            string subMenuOption = "yes";
            do
            {
                Console.WriteLine("Select an Option : ");
                Console.WriteLine("\n1.Show Medicine List\n2.Purchase Medicine\n3.Modify purchse\n4.Cancel Purchase\n5.Show purchse history\n6.Recharge Wallet\n7.Show Wallet Balance\n8.Exit\n");
                int subMenuChoise = int.Parse(Console.ReadLine());

                switch (subMenuChoise)
                {
                    case 1:
                        {
                            Console.WriteLine("Show Medicine List");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Purchase Medicine");
                            PurchaseMedicine();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Modify Purchase");
                            ModifyMedicine();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Cancel Order");
                            CancelOrder();
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

        //Cancel Order
        public static void CancelOrder()
        {
            foreach (OrderDetails order in orderList)
            {
                if (currentLoggedIn.UserID.Equals(order.UserID) && order.OrderStatus == OrderStatus.Purchased)
                {
                    Console.WriteLine($"{order.OrderID}\t{order.MedicineID}\t{order.MedicineCount}\t{order.TotalPrice}");
                }

            }
            Console.WriteLine("Enter a Order ID: ");
            string orderID = Console.ReadLine();

            //Check orderr ID
            bool flag = true;
            foreach (OrderDetails order in orderList)
            {
                if (orderID.Equals(order.OrderID) && order.OrderStatus == OrderStatus.Purchased)
                {
                    flag = false;
                    foreach (MedicineDetails medicine in medicineList)
                    {
                        if (order.MedicineID.Equals(medicine.MedicineID))
                        {
                            order.OrderStatus = OrderStatus.Cancelled;
                            medicine.AvailableCount += order.MedicineCount;
                            currentLoggedIn.WallerRecharge(order.TotalPrice);
                            Console.WriteLine($"Order ID {order.OrderID} was cancelled successfully.");
                        }
                    }
                    break;
                }
            }

            if (flag)
            {
                Console.WriteLine("Invalid Order ID");
            }
        }
        public static void ModifyMedicine()
        {
            // string userID,string medicineID, int medicineCount, int totalPriced, DateTime orderDate, OrderStatus orderStatus
            foreach (OrderDetails order in orderList)
            {
                if (currentLoggedIn.UserID.Equals(order.UserID) && order.OrderStatus == OrderStatus.Purchased)
                {
                    Console.WriteLine($"{order.OrderID}\t{order.MedicineID}\t{order.MedicineCount}\t{order.TotalPrice}");
                }

            }
            Console.WriteLine("Enter a Order ID:");
            string orderID = Console.ReadLine();
            foreach (OrderDetails order in orderList)
            {
                if (currentLoggedIn.UserID.Equals(order.UserID) && order.OrderStatus == OrderStatus.Purchased)
                {
                    if (orderID.Equals(order.OrderID))
                    {
                        Console.WriteLine("Enter a New Qun: ");
                        int newQun = int.Parse(Console.ReadLine());

                        //check available qun
                        foreach (MedicineDetails medicine in medicineList)
                        {
                            if (order.MedicineID.Equals(medicine.MedicineID))
                            {
                                medicine.AvailableCount += order.MedicineCount; //Return add qun
                                if (medicine.AvailableCount >= newQun)
                                {
                                    currentLoggedIn.WallerRecharge(order.TotalPrice); //Return total amount
                                    order.TotalPrice = newQun * medicine.Price;
                                    order.MedicineCount = newQun; //Update qun
                                    medicine.AvailableCount -= newQun;
                                    currentLoggedIn.DeductBalance(newQun * medicine.Price);
                                    Console.WriteLine("Modify Successfully...!");

                                }
                                else
                                {
                                    Console.WriteLine("Quantity not available");
                                }
                            }
                        }


                    }
                }

            }

        }

        public static void PurchaseMedicine()
        {
            Console.WriteLine("Show Medicine List");
            // string medicineName, int availableCount, int price, DateTime dateOfExpiry
            foreach (MedicineDetails medicine in medicineList)
            {
                Console.WriteLine($"{medicine.MedicineID}\t{medicine.MedicineName}\t{medicine.AvailableCount}\t{medicine.Price}\t{medicine.DateOfExpiry}");
            }

            Console.WriteLine("Enter Medicine ID : ");
            string medicineID = Console.ReadLine();
            Console.WriteLine("Enter a Qun: ");
            int qun = int.Parse(Console.ReadLine());
            bool flag = true;
            foreach (MedicineDetails medicine in medicineList)
            {
                if (medicineID.Equals(medicine.MedicineID))
                {
                    flag = false;
                    if (qun <= medicine.AvailableCount)
                    {
                        if (medicine.DateOfExpiry > DateTime.Now)
                        {
                            if ((qun * medicine.Price) <= currentLoggedIn.WalletBalance)
                            {
                                medicine.AvailableCount -= qun;
                                // string userID,string medicineID, int medicineCount, int totalPriced, DateTime orderDate, OrderStatus orderStatus
                                OrderDetails order = new OrderDetails(currentLoggedIn.UserID, medicine.MedicineID, qun, qun * medicine.Price, DateTime.Now, OrderStatus.Purchased);
                                orderList.Add(order);
                                Console.WriteLine($"Order Successfully ...! OrderID : {order.OrderID}");
                            }
                            else
                            {
                                Console.WriteLine("Insufficient Balance");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Medicine not availble");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Qun Not available");
                    }
                    break;
                }
            }

            if (flag)
            {
                Console.WriteLine("Invalid Medicine ID");
            }
        }
        public static void AddDefaultData()
        {
            //User  Details
            // string name, int age, string city, string mobileNumber, int balance
            UserDetails user = new UserDetails("Ravi", 33, "Theni", "9877774440", 400);
            UserDetails user1 = new UserDetails("Baskaran", 33, "Chennai", "8847757470", 500);

            userList.Add(user);
            userList.Add(user1);

            //MedicineDetails 
            // string medicineName, int availableCount, int price, DateTime dateOfExpiry
            MedicineDetails medicine1 = new MedicineDetails("Paracitamol", 40, 5, new DateTime(2024, 06, 30));
            MedicineDetails medicine2 = new MedicineDetails("Calpol", 10, 5, new DateTime(2024, 05, 30));
            MedicineDetails medicine3 = new MedicineDetails("Gelucil", 3, 40, new DateTime(2023, 04, 30));
            MedicineDetails medicine4 = new MedicineDetails("Metrogel", 5, 50, new DateTime(2024, 12, 30));
            MedicineDetails medicine5 = new MedicineDetails("Povidin Iodin", 10, 50, new DateTime(2024, 10, 30));

            medicineList.Add(medicine1);
            medicineList.Add(medicine2);
            medicineList.Add(medicine3);
            medicineList.Add(medicine4);
            medicineList.Add(medicine5);

            //Order Details
            // string userID,string medicineID, int totalPriced, DateTime orderDate, OrderStatus orderStatus
            OrderDetails order1 = new OrderDetails("UID1001", "MD101", 3, 15, new DateTime(2022, 11, 13), OrderStatus.Purchased);
            OrderDetails order2 = new OrderDetails("UID1001", "MD102", 2, 10, new DateTime(2022, 11, 13), OrderStatus.Cancelled);
            OrderDetails order3 = new OrderDetails("UID1001", "MD103", 2, 100, new DateTime(2022, 11, 13), OrderStatus.Purchased);
            OrderDetails order4 = new OrderDetails("UID1002", "MD104", 3, 120, new DateTime(2022, 11, 15), OrderStatus.Cancelled);
            OrderDetails order5 = new OrderDetails("UID1002", "MD105", 5, 250, new DateTime(2022, 11, 15), OrderStatus.Purchased);
            OrderDetails order6 = new OrderDetails("UID1002", "MD106", 3, 15, new DateTime(2022, 11, 15), OrderStatus.Purchased);

            orderList.AddRange(new List<OrderDetails> { order1, order2, order3, order4, order5, order6 });

        }
    }
}