using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    class Reservation
    {
        private string hotelName;
        private int weekdaysRates;
        private int weekendsRates;
        private int noOfWeekdays = 0;
        private int noOfWeekends = 0;
        Dictionary<string, AddHotel> dictionary = new Dictionary<string, AddHotel>();
        public void AddDetails()
        {
            Console.Write("Enter Hotel name: ");
            hotelName = Console.ReadLine();
            Console.Write("Enter Weekday Rates per day : ");
            weekdaysRates = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Weekend Rates per day : ");
            weekendsRates = Convert.ToInt32(Console.ReadLine());
            AddHotel add = new AddHotel(hotelName, weekdaysRates, weekendsRates);
            dictionary.Add(hotelName, add);
        }
        public void GetCheapestHotel()
        {
            int max = 0, minWeekDay = 0 , minWeekend = 0;
            GetDays();
            //To get minimum rate on weekdays
            foreach (var item in dictionary)
            {
                if (max < item.Value.weekdaysRates)
                {
                    max = item.Value.weekdaysRates;
                }
            }
            foreach (var item in dictionary)
            {
                if (max > item.Value.weekdaysRates)
                {
                    minWeekDay = item.Value.weekdaysRates;
                }
            }
            //To get minimum rate on weekends
            max = 0;
            foreach (var item in dictionary)
            {
                if (max < item.Value.weekdaysRates)
                {
                    max = item.Value.weekdaysRates;
                }
            }
            foreach (var item in dictionary)
            {
                if (max > item.Value.weekendsRates)
                {
                    minWeekend = item.Value.weekendsRates;
                }
            }
            foreach (var item in dictionary)
            {
                if (minWeekDay == item.Value.weekdaysRates || minWeekend == item.Value.weekendsRates)
                {
                    double sum = minWeekDay * noOfWeekdays + minWeekend * noOfWeekends;
                    Console.WriteLine("Hotel : " + item.Key + " Total rates: " + sum);
                }
            }
        }
        public void GetDays()
        {
            Console.WriteLine("Enter checkin date:");
            DateTime date1 = Convert.ToDateTime(Console.ReadLine());
            string day1 = date1.DayOfWeek.ToString(); ;
            Console.WriteLine("Enter checkout date:");
            DateTime date2 = Convert.ToDateTime(Console.ReadLine());
            if(day1 == "Saturday" || day1 == "Sunday")
            {
                noOfWeekdays = 1;
                noOfWeekends = 1;
            }
            else
            {
                noOfWeekdays = 2;
                noOfWeekends = 0;
            }
        }
    }
}
