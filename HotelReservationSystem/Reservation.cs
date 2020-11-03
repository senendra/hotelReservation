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
        public void GetCheapestHotel()
        {
            int max = 0, min = 0;
            foreach (var item in dictionary)
            {
                if (max < item.Value.rates)
                {
                    max = item.Value.rates;
                }
            }
            foreach (var item in dictionary)
            {
                if (max > item.Value.rates)
                {
                    min = item.Value.rates;
                }
            }
            foreach (var item in dictionary)
            {
                if (min == item.Value.rates)
                {
                    double sum = min * GetDays();
                    Console.WriteLine("Hotel : " + item.Key + " Total rates: " + sum);
                }
            }
        }
        public double GetDays()
        {
            Console.WriteLine("Enter checkin date:");
            DateTime date1 = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter checkout date:");
            DateTime date2 = Convert.ToDateTime(Console.ReadLine());
            return 2;
        }
    }
}
