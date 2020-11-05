﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    class Reservation
    {
        private string hotelName;
        private int weekdaysRates;
        private int weekendsRates;
        private int check;
        private int rating;
        Dictionary<string, AddHotel> dictionary = new Dictionary<string, AddHotel>();
        public void AddDetails()
        {
            Console.Write("Enter Hotel name: ");
            hotelName = Console.ReadLine();
            Console.Write("Enter Weekday Rates per day : ");
            weekdaysRates = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Weekend Rates per day : ");
            weekendsRates = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Rating : ");
            rating = Convert.ToInt32(Console.ReadLine());
            AddHotel add = new AddHotel(hotelName, weekdaysRates, weekendsRates, rating);
            dictionary.Add(hotelName, add);
        }
        public void GetCheapestHotel()
        {
            int max = 0, minWeekDay = 0 , minWeekend = 0, maxRating =0, totalRate;
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
                if (max < item.Value.weekendsRates)
                {
                    max = item.Value.weekendsRates;
                }
            }
            foreach (var item in dictionary)
            {
                if (max > item.Value.weekendsRates)
                {
                    minWeekend = item.Value.weekendsRates;
                }
            }
            ////To get best rated hotel
            //foreach (var item in dictionary)
            //{
            //    if (minWeekDay == item.Value.weekdaysRates || minWeekend == item.Value.weekendsRates)
            //    {
            //        if(rating < item.Value.rating)
            //        {
            //            rating = item.Value.rating;
            //        }
            //    }
            //}
            switch (check)
            {
                case 1:
                    totalRate = minWeekend * 2;
                    foreach (var item in dictionary)
                    {
                        if (minWeekend == item.Value.weekendsRates)
                        {
                            Console.WriteLine("Hotel : " + item.Key + " Total rates: " + totalRate);
                        }
                    }
                    break;
                case 3:
                    totalRate = minWeekDay * 2;
                    foreach (var item in dictionary)
                    {
                        if (minWeekDay == item.Value.weekdaysRates)
                        {
                            Console.WriteLine("Hotel : " + item.Key + " Total rates: " + totalRate);
                        }
                    }
                    break;
                case 2:
                    int sum1 = 0, sum2 = 0;
                    string hotel1 = null, hotel2 = null;
                    foreach (var item in dictionary)
                    {
                        if (minWeekDay == item.Value.weekdaysRates)
                        {
                            sum1 = minWeekDay + item.Value.weekendsRates;
                            hotel1 = item.Key;
                        }
                        if (minWeekend == item.Value.weekendsRates)
                        {
                            sum2 = minWeekend + item.Value.weekdaysRates;
                            hotel2 = item.Key;
                        }
                    }
                    if (sum1 == sum2)
                    {
                        Console.WriteLine("Hotel : " + hotel1 +" and "+ hotel2 + " Total rates: " + sum1);
                    }
                    else if (sum1 > sum2)
                    {
                        Console.WriteLine("Hotel : " + hotel2 + " Total rates: " + sum2);
                    }
                    else
                    {
                        Console.WriteLine("Hotel : " + hotel1 + " Total rates: " + sum1);
                    }
                    break;
            }
        }
        public void GetDays()
        {
            Console.WriteLine("Enter checkin date:");
            DateTime date1 = Convert.ToDateTime(Console.ReadLine());
            string day1 = date1.DayOfWeek.ToString(); ;
            Console.WriteLine("Enter checkout date:");
            DateTime date2 = Convert.ToDateTime(Console.ReadLine());
            string day2 = date2.DayOfWeek.ToString();
            if (day1 == "Saturday" && day2 == "Sunday")
            {
                check = 1;
            }
            else if ((day1 == "Friday" && day2 == "Saturday") || (day1 == "Sunday" && day2 == "Monday"))
            {
                check = 2;
            }
            else
            {
                check = 3;
            }
        }
    }
}
