using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class TravelDetails
    {
        /*
            a.	TravelId (Auto Generated -TID2001)
            b.	Card Number
            c.	FromLocation
            d.	ToLocation
            e.	Date
            f.	Travel Cost
        */

        //Field
        //static Field
        private static int s_travelId = 2000;

        //Property
        public string TravelId { get; } //Read Only Property

        public string CardNumber { get; set; }

        public string FromLocation { get; set; }

        public string ToLocation { get; set; }

        public DateTime Date { get; set; }

        public int TravelCost { get; set; }

        //Constructors
        public TravelDetails(string cardNumber, string fromLocation, string toLocation, DateTime date, int travelCost)
        {
            //Auto Incrementaion
            s_travelId++;
            //Assigning values
            TravelId = "TID" + s_travelId;
            CardNumber = cardNumber;
            FromLocation = fromLocation;
            ToLocation = toLocation;
            Date = date;
            TravelCost = travelCost;
        }

        public TravelDetails(string travel)
        {
            string[] temp = travel.Split(',');
            s_travelId = int.Parse(temp[0].Remove(0, 3));
            TravelId = temp[0];
            CardNumber = temp[1];
            FromLocation = temp[2];
            ToLocation = temp[3];
            Date = DateTime.ParseExact(temp[4], "dd/MM/yyyy", null);
            TravelCost = int.Parse(temp[5]);
        }


    }
}