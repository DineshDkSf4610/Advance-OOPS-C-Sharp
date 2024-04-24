using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class TicketFair
    {
        /*
            •	TicketID (Auto Generated – MR3001)
            •	FromLocation
            •	ToLocation
            •	TicketPrice
        */

        //Field
        //Static Field
        private static int s_ticketID = 3000;

        //Property
        public string TicketID { get; } //Read Only Property

        public string FromLocation { get; set; }

        public string ToLocation { get; set; }

        public int TicketPrice { get; set; }


        //Contructors
        public TicketFair(string fromLocation, string toLocation, int ticketPrice)
        {
            //Auto Incrementation
            s_ticketID++;
            //Assiging values
            TicketID = "MR" + s_ticketID;
            FromLocation = fromLocation;
            ToLocation = toLocation;
            TicketPrice = ticketPrice;
        }

        public TicketFair(string ticketFair)
        {
            string[] temp = ticketFair.Split(',');
            s_ticketID = int.Parse(temp[0].Remove(0,2));
            TicketID = temp[0];
            FromLocation = temp[1];
            ToLocation = temp[2];
            TicketPrice = int.Parse(temp[3]);
        }


    }
}