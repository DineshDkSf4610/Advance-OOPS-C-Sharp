using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class Operations
    {
        //List Declaration
        // public static List<UserDetails> userList = new List<UserDetails>();

        // public static List<TravelDetails> travelHistoryList = new List<TravelDetails>();

        // public static List<TicketFair> ticketFairList = new List<TicketFair>();

        public static CustomList<UserDetails> userList = new CustomList<UserDetails>();

        public static CustomList<TravelDetails> travelHistoryList = new CustomList<TravelDetails>();

        public static CustomList<TicketFair> ticketFairList = new CustomList<TicketFair>();

        //current login user

        static UserDetails currentLoggedIn;

        //Main Menu 
        public static void MainMenu()
        {
            Console.WriteLine("Metro Card Management");
            Console.WriteLine("*********************\n");

            string mainMenuOption = "yes";

            do
            {
                Console.WriteLine("Select an Option : \n");
                Console.WriteLine("\t1.New User Registration");
                Console.WriteLine("\t2.User Login");
                Console.Write("\t3.Exit\n\n");
                Console.Write("Enter an Option: ");
                int mainMenuChoise = int.Parse(Console.ReadLine());

                switch (mainMenuChoise)
                {
                    case 1:
                        {
                            Console.WriteLine("\nUser Registration");
                            Console.WriteLine("*****************\n");
                            UserRegistaion();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("\nUser Login");
                            Console.WriteLine("**********\n");
                            UserLogin();
                            break;
                        }
                    case 3:
                        {
                            mainMenuOption = "no";
                            Console.WriteLine("\nExits");
                            break;
                        }
                }

            } while (mainMenuOption == "yes");
        }

        //user Registration
        public static void UserRegistaion()
        {
            Console.Write("Enter User Name: ");
            string userName = Console.ReadLine();
            Console.Write("Enter Mobile Number: ");
            string mobileNumber = Console.ReadLine();
            Console.Write("Enter Balance: ");
            int balance = int.Parse(Console.ReadLine());

            //Create a object
            UserDetails user = new UserDetails(userName, mobileNumber, balance);
            //Add List
            userList.Add(user);
            //display message
            Console.WriteLine("\n***************************************************************");
            Console.WriteLine($"Registration Successfully.Your card Number is {user.CardNumber}");
            Console.WriteLine("****************************************************************\n");
        }

        //User Login
        public static void UserLogin()
        {
            Console.Write("Enter Card Number: ");
            string cardNumber = Console.ReadLine().ToUpper();
            bool flag = true;
            //Check card number
            foreach (UserDetails user in userList)
            {
                if (cardNumber.Equals(user.CardNumber))
                {
                    flag = false;
                    //Assiging current login user onj
                    currentLoggedIn = user;
                    SubMenu();
                    break;
                }
            }

            if (flag)
            {
                Console.WriteLine("\n******************************************");
                Console.WriteLine("Invalid card Number or not present in list");
                Console.WriteLine("******************************************\n");
            }
        }

        //Sub Menu
        public static void SubMenu()
        {
            string subMenuOption = "yes";

            do
            {
                Console.WriteLine("\nSub Menu");
                Console.WriteLine("*********\n");
                Console.WriteLine("Select an Option: \n");
                Console.WriteLine("\t1.Balance Check\n\t2.Recharge\n\t3.View Travel History\n\t4.Travel\n\t5.Exit\n");
                Console.Write("Enter an Option: ");
                int subMenuChoise = int.Parse(Console.ReadLine());
                switch (subMenuChoise)
                {
                    case 1:
                        {
                            Console.WriteLine("\nBalance Check");
                            Console.WriteLine("________________");
                            BalanceCheck();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("\nRecharge");
                            Console.WriteLine("________________");
                            Recharge();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("\nView Travel History");
                            Console.WriteLine("_____________________");
                            viewTravelHistory();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("\nTravel");
                            Console.WriteLine("_______");
                            Travel();
                            break;
                        }
                    case 5:
                        {
                            subMenuOption = "no";
                            Console.WriteLine("\nExit");
                            Console.WriteLine("_____");
                            break;
                        }
                }

            } while (subMenuOption == "yes");

        }

        //Balance Check
        public static void BalanceCheck()
        {
            Console.WriteLine("\n*************************");
            Console.WriteLine($"Balance Amount : {currentLoggedIn.Balance}");
            Console.WriteLine("*************************");
        }

        //Recharge
        public static void Recharge()
        {
            Console.Write("Enter a Amount: ");
            int amount = int.Parse(Console.ReadLine());
            currentLoggedIn.WalletRecharge(amount);
            Console.WriteLine("\n*************************");
            Console.WriteLine("Recharge Successfully...!");
            Console.WriteLine($"Total Balance : {currentLoggedIn.Balance}");
            Console.WriteLine("*************************\n");
        }

        //View Travel History
        public static void viewTravelHistory()
        {
            Console.WriteLine($"{"TravelID",-10}{"CardNumber",-12}{"FromLocation",-15}{"ToLocation",-15}{"Date",-15}{"TravelCost",-10}");
            Console.WriteLine("_____________________________________________________________________________");
            bool flag = true;
            foreach (TravelDetails travel in travelHistoryList)
            {
                if (currentLoggedIn.CardNumber.Equals(travel.CardNumber))
                {
                    flag = false;
                    Console.WriteLine($"{travel.TravelId,-10}{travel.CardNumber,-12}{travel.FromLocation,-15}{travel.ToLocation,-15}{travel.Date.ToString("dd/MM/yyyy"),-15}{travel.TravelCost,-10}");
                }
            }
            Console.WriteLine("_____________________________________________________________________________");
            if (flag)
            {
                Console.WriteLine("\n**************");
                Console.WriteLine("Data Not Found");
                Console.WriteLine("**************\n");
            }
        }

        //Travel
        public static void Travel()
        {
            Console.WriteLine($"{"TicketID",-10}{"FromLocation",-15}{"ToLocation",-15}{"Fair",-5}");
            Console.WriteLine("___________________________________________");
            foreach (TicketFair ticket in ticketFairList)
            {
                Console.WriteLine($"{ticket.TicketID,-10}{ticket.FromLocation,-15}{ticket.ToLocation,-15}{ticket.TicketPrice,-5}");
            }

            Console.WriteLine("___________________________________________");

            Console.Write("Enter TicketID : ");
            string ticketlId = Console.ReadLine().ToUpper();
            bool flag = true;
            //check ticketID
            foreach (TicketFair ticket1 in ticketFairList)
            {
                if (ticketlId.Equals(ticket1.TicketID))
                {
                    flag = false;
                    //balnce check
                    if (ticket1.TicketPrice <= currentLoggedIn.Balance)
                    {
                        TravelDetails travel = new TravelDetails(currentLoggedIn.CardNumber, ticket1.FromLocation, ticket1.ToLocation, DateTime.Now, ticket1.TicketPrice);
                        travelHistoryList.Add(travel);
                        currentLoggedIn.DeductBalance(ticket1.TicketPrice);
                        Console.WriteLine("\n******************************");
                        Console.WriteLine($"Travel ID : {travel.TravelId}");
                        Console.WriteLine("Successfully ...!");
                        Console.WriteLine("******************************\n");

                    }
                    else
                    {
                        Console.WriteLine("\n******************************");
                        Console.WriteLine("Insufficient balance. Please Recharge");
                        Console.WriteLine("******************************\n");
                    }
                    break;
                }
            }

            if (flag)
            {
                Console.WriteLine("Invalid Ticket ID.");
            }

        }

        //Add Default Data
        public static void AddDefaultData()
        {
            //User Details
            UserDetails user = new UserDetails("Ravi", "9848812345", 1000);
            UserDetails user1 = new UserDetails("Baskaran", "9948854321", 1000);
            //add user list
            userList.Add(user);
            userList.Add(user1);


            //Travel History
            TravelDetails travelHistory1 = new TravelDetails("CMRL1001", "Airport", "Egmore", new DateTime(2023, 10, 10), 55);
            TravelDetails travelHistory2 = new TravelDetails("CMRL1001", "Egmore", "Koyambedu", new DateTime(2023, 10, 10), 32);
            TravelDetails travelHistory3 = new TravelDetails("CMRL1002", "Alandur", "Koyambedu", new DateTime(2023, 11, 10), 25);
            TravelDetails travelHistory4 = new TravelDetails("CMRL1002", "Egmore", "Thirumangalam", new DateTime(2023, 11, 10), 25);

            travelHistoryList.Add(travelHistory1);
            travelHistoryList.Add(travelHistory2);
            travelHistoryList.Add(travelHistory3);
            travelHistoryList.Add(travelHistory4);

            //Ticket Fair

            TicketFair ticketfair1 = new TicketFair("Airport", "Egmore", 55);
            TicketFair ticketfair2 = new TicketFair("Airport", "Koyambedu", 25);
            TicketFair ticketfair3 = new TicketFair("Alandur", "Koyambedu", 25);
            TicketFair ticketfair4 = new TicketFair("Koyambedu", "Egmore", 32);
            TicketFair ticketfair5 = new TicketFair("Vadapalani", "Egmore", 45);
            TicketFair ticketfair6 = new TicketFair("Arumbakkam", "Egmore", 25);
            TicketFair ticketfair7 = new TicketFair("Vadapalani", "Koyambedu", 25);
            TicketFair ticketfair8 = new TicketFair("Arumbakkam", "Koyambedu", 16);

            ticketFairList.Add(ticketfair1);
            ticketFairList.Add(ticketfair2);
            ticketFairList.Add(ticketfair3);
            ticketFairList.Add(ticketfair4);
            ticketFairList.Add(ticketfair5);
            ticketFairList.Add(ticketfair6);
            ticketFairList.Add(ticketfair7);
            ticketFairList.Add(ticketfair8);


            //Disply all values

            //user Details
            // Console.WriteLine("CardNumber	UserName	Phone	Balance");
            // Console.WriteLine("________________________________________");
            // foreach (UserDetails userValue in userList)
            // {
            //     Console.WriteLine($"{userValue.CardNumber}\t{userValue.UserName}\t{userValue.MobileNumber}\t{userValue.Balance}");
            // }

            //Travel History
            // Console.WriteLine("TravelID	CardNumber	FromLocation	ToLocation	Date	TravelCost");
            // Console.WriteLine("___________________________________________________________________");
            // foreach (TravelDetails travel in travelHistoryList)
            // {
            //     Console.WriteLine($"{travel.TravelId}\t{travel.CardNumber}\t{travel.FromLocation}\t{travel.ToLocation}\t{travel.Date.ToString("dd/MM/yyyy")}\t{travel.TravelCost}");
            // }

            //Ticket Fair
            // Console.WriteLine("TicketID	FromLocation	ToLocation	Fair");
            // Console.WriteLine("________________________________________");
            // foreach (TicketFair ticket in ticketFairList)
            // {
            //     Console.WriteLine($"{ticket.TicketID}\t{ticket.FromLocation}\t{ticket.ToLocation}\t{ticket.TicketPrice}");
            // }

            // Console.WriteLine($"{"TicketID",-10}{"FromLocation",-15}{"ToLocation",-15}{"Fair",-5}");
            // Console.WriteLine("___________________________________________");
            // foreach (TicketFair ticket in ticketFairList)
            // {
            //     Console.WriteLine($"{ticket.TicketID,-10}{ticket.FromLocation,-15}{ticket.ToLocation,-15}{ticket.TicketPrice,-5}");
            // }

            //  Console.WriteLine("___________________________________________");



        }
    }
}