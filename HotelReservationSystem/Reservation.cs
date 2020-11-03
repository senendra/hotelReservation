using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    class Reservation
    {
        private string hotelName;
        private int rates;
        Dictionary<string, AddHotel> dictionary = new Dictionary<string, AddHotel>();
        public void AddDetails()
        {
            Console.Write("Enter Hotel name: ");
            hotelName = Console.ReadLine();
            Console.Write("Enter Rates : ");
            rates = Convert.ToInt32(Console.ReadLine());
            AddHotel add = new AddHotel(hotelName, rates);
            dictionary.Add(hotelName, add);
        }
    }
}
