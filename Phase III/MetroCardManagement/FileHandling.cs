using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class FileHandling
    {
        //Create Folder
        public static void Create()
        {
            if (!Directory.Exists("MetroCard"))
            {
                //Crea Folder
                Console.WriteLine("Creating Folder ....");
                Directory.CreateDirectory("MetroCard");
            }

            //File Create
            //user Details Files csv
            if (!File.Exists("MetroCard/UserDetails.csv"))
            {
                Console.WriteLine("Creating File ... !");
                File.Create("MetroCard/UserDetails.csv").Close();
            }

            //create Travel Details csv file

            if (!File.Exists("MetroCard/TravelDetails.csv"))
            {
                Console.WriteLine("Creating File ... !");
                File.Create("MetroCard/TravelDetails.csv").Close();
            }

            //create TicketFair details csv file

            if (!File.Exists("MetroCard/TicketFair.csv"))
            {
                Console.WriteLine("Creating File ... !");
                File.Create("MetroCard/TicketFair.csv").Close();
            }
        }

        //WriteToSCV

        public static void WriteToCSV()
        {
            //User Details file
            string[] users = new string[Operations.userList.Count];
            // string userName, string mobileNumber, int balance
            for (int i = 0; i < Operations.userList.Count; i++)
            {
                users[i] = Operations.userList[i].CardNumber + "," + Operations.userList[i].UserName + "," + Operations.userList[i].MobileNumber + "," + Operations.userList[i].Balance;
            }
            //
            File.WriteAllLines("MetroCard/UserDetails.csv", users);


            //TravelDetails file

            string[] travels = new string[Operations.travelHistoryList.Count];
            // string cardNumber,string fromLocation, string toLocation, DateTime date, int travelCost
            for (int i = 0; i < Operations.travelHistoryList.Count; i++)
            {
                travels[i] = Operations.travelHistoryList[i].TravelId + "," + Operations.travelHistoryList[i].CardNumber + "," + Operations.travelHistoryList[i].FromLocation + "," + Operations.travelHistoryList[i].ToLocation + "," + Operations.travelHistoryList[i].Date.ToString("dd/MM/yyyy") + "," + Operations.travelHistoryList[i].TravelCost;
            }

            File.WriteAllLines("MetroCard/TravelDetails.csv", travels);

            //Travel Fair Details

            string[] travelFair = new string[Operations.ticketFairList.Count];
            // string fromLocation, string toLocation, int ticketPrice
            for (int i = 0; i < Operations.ticketFairList.Count; i++)
            {
                travelFair[i] = Operations.ticketFairList[i].TicketID + "," + Operations.ticketFairList[i].FromLocation + "," + Operations.ticketFairList[i].ToLocation + "," + Operations.ticketFairList[i].TicketPrice;
            }
            File.WriteAllLines("MetroCard/TicketFair.csv", travelFair);


        }

        //ReadFromCSV

        public static void ReadFromCSV()
        {
            //userDetails
            string[] users = File.ReadAllLines("MetroCard/UserDetails.csv");
            foreach (string user in users)
            {
                UserDetails adduser = new UserDetails(user);
                Operations.userList.Add(adduser);
            }

            //TravelDetails

            string[] travels = File.ReadAllLines("MetroCard/TravelDetails.csv");
            foreach (string travel in travels)
            {
                TravelDetails addTravel = new TravelDetails(travel);
                Operations.travelHistoryList.Add(addTravel);
            }

            //Ticket Fair
            string[] tickets = File.ReadAllLines("MetroCard/TicketFair.csv");
            foreach (string ticket in tickets)
            {
                TicketFair addTicket = new TicketFair(ticket);
                Operations.ticketFairList.Add(addTicket);
            }
        }
    }
}