﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
namespace HotelReservationSystem
{
    class Reservation
    {
        private int check;
        Dictionary<string, AddHotel> dictionary = new Dictionary<string, AddHotel>();
        public void AddDetailsRegular()
        {
            AddHotel addLakewood = new AddHotel("Lakewood",110 , 90, 3);
            dictionary.Add("RegularLakewood", addLakewood);
            AddHotel addBridgewood = new AddHotel("Bridgewood", 150, 50, 4);
            dictionary.Add("RegularBridgewood", addBridgewood);
            AddHotel addRidgewood = new AddHotel("Ridgewood", 220, 150, 5);
            dictionary.Add("RegularRidgewood", addRidgewood);
        }
        public void AddDetailsRewarded()
        {
            AddHotel addLakewood = new AddHotel("Lakewood", 80, 80, 3);
            dictionary.Add("RewardedLakewood", addLakewood);
            AddHotel addBridgewood = new AddHotel("Bridgewood", 110, 50, 4);
            dictionary.Add("RewardedBridgewood", addBridgewood);
            AddHotel addRidgewood = new AddHotel("Ridgewood", 100, 40, 5);
            dictionary.Add("RewardedRidgewood", addRidgewood);
        }

        public void GetCheapestBestRatedHotel()
        {
            int max = 0, minWeekDay = 0 , minWeekend = 0, totalRate;
            Console.WriteLine("\n  Cheapest Best rated hotel");
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
            switch (check)
            {
                case 1:
                    totalRate = minWeekend * 2;
                    foreach (var item in dictionary)
                    {
                        if (minWeekend == item.Value.weekendsRates)
                        {
                            Console.WriteLine(" Hotel : " + item.Value.hotelName + "\n Rating : " + item.Value.rating + "\n Total rates: " + totalRate);
                        }
                    }
                    break;
                case 3:
                    totalRate = minWeekDay * 2;
                    foreach (var item in dictionary)
                    {
                        if (minWeekDay == item.Value.weekdaysRates)
                        {
                            Console.WriteLine(" Hotel : " + item.Value.hotelName + "\n Rating " + item.Value.rating + "\n Total rates: " + totalRate);
                        }
                    }
                    break;
                case 2:
                    int sum1 = 0, sum2 = 0, ratingHotel1 = 0, ratingHotel2 = 0;
                    string hotel1 = null, hotel2 = null;
                    foreach (var item in dictionary)
                    {
                        if (minWeekDay == item.Value.weekdaysRates)
                        {
                            sum1 = minWeekDay + item.Value.weekendsRates;
                            ratingHotel1 = item.Value.rating;
                            hotel1 = item.Value.hotelName;
                        }
                        if (minWeekend == item.Value.weekendsRates)
                        {
                            sum2 = minWeekend + item.Value.weekdaysRates;
                            ratingHotel2 = item.Value.rating;
                            hotel2 = item.Value.hotelName;
                        }
                    }
                    if (sum1 == sum2)
                    {
                        if(ratingHotel1 > ratingHotel2)
                            Console.WriteLine(" Hotel : " + hotel1 + "\n Rating : "+ ratingHotel1 + "\n Total rates : " + sum1);
                        else if(ratingHotel1 < ratingHotel2)
                            Console.WriteLine(" Hotel : " + hotel2 + "\n Rating : " + ratingHotel2 + "\n Total rates : " + sum1);
                        else
                            Console.WriteLine(" Hotel : " +hotel2  + "\n Rating : " + ratingHotel2 + "\n Total rates : " + sum1);

                    }
                    else if (sum1 > sum2)
                    {
                        Console.WriteLine(" Hotel : " + hotel2 + "\n Rating : " + ratingHotel2 + "\n Total rates : " + sum2);
                    }
                    else
                    {
                        Console.WriteLine(" Hotel : " + hotel1 + "\n Rating : " + ratingHotel1 + "\n Total rates : " + sum1);
                    }
                    break;
            }
        }
        public void GetDays()
        {
            try
            {
                Console.WriteLine("Enter checkin date(dd/mm/yyyy):");
                DateTime date1 = Convert.ToDateTime(Console.ReadLine());
                string day1 = date1.DayOfWeek.ToString(); ;
                Console.WriteLine("Enter checkout date(dd/mm/yyyy):");
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
            catch
            {
                Console.WriteLine("Entered date in incorrect formate(dd/mm/yyyy). Try Again!!");
            }
        }
        public void GetBestRatedHotel()
        {
            Console.WriteLine("\n  Best Hotel");
            GetDays();
            int totalRate , maxRating = 0, maxWeekDay = 0, maxWeekend = 0;
            foreach (var item in dictionary)
            {
                if (maxWeekDay < item.Value.weekdaysRates)
                {
                    maxWeekDay = item.Value.weekdaysRates;
                }
            }
            foreach (var item in dictionary)
            {
                if (maxWeekend < item.Value.weekendsRates)
                {
                    maxWeekend = item.Value.weekendsRates;
                }
            }
            foreach (var item in dictionary)
            {
                if (maxRating < item.Value.rating)
                {
                    maxRating = item.Value.rating;
                }
            }
            switch (check)
            {
                case 1:
                    totalRate = maxWeekend * 2;
                    foreach (var item in dictionary)
                    {
                        if (maxWeekend == item.Value.weekendsRates)
                        {
                            Console.WriteLine(" Hotel : " + item.Value.hotelName + "\n Rating " + item.Value.rating + "\n Total rates: " + totalRate);
                        }
                    }
                    break;
                case 3:
                    totalRate = maxWeekDay * 2;
                    foreach (var item in dictionary)
                    {
                        if (maxWeekDay == item.Value.weekdaysRates)
                        {
                            Console.WriteLine(" Hotel : " + item.Value.hotelName + "\n Rating " + item.Value.rating + "\n Total rates: " + totalRate);
                        }
                    }
                    break;
                case 2:
                    int sum1 = 0, sum2 = 0, ratingHotel1 = 0, ratingHotel2 = 0;
                    string hotel1 = null, hotel2 = null;
                    foreach (var item in dictionary)
                    {
                        if (maxWeekDay == item.Value.weekdaysRates)
                        {
                            sum1 = maxWeekDay + item.Value.weekendsRates;
                            ratingHotel1 = item.Value.rating;
                            hotel1 = item.Value.hotelName;
                        }
                        if (maxWeekend == item.Value.weekendsRates)
                        {
                            sum2 = maxWeekend + item.Value.weekdaysRates;
                            ratingHotel2 = item.Value.rating;
                            hotel2 = item.Value.hotelName;
                        }
                    }
                    if (sum1 == sum2)
                    {
                        if (ratingHotel1 > ratingHotel2)
                            Console.WriteLine(" Hotel : " + hotel1 + "\n Rating : " + ratingHotel1 + "\n Total rates : " + sum1);
                        else if (ratingHotel1 < ratingHotel2)
                            Console.WriteLine(" Hotel : " + hotel2 + "\n Rating : " + ratingHotel2 + "\n Total rates : " + sum1);
                        else
                            Console.WriteLine(" Hotel : " + hotel2 + "\n Rating : " + ratingHotel2 + "\n Total rates : " + sum1);

                    }
                    else if (sum1 > sum2)
                    {
                        Console.WriteLine(" Hotel : " + hotel2 + "\n Rating : " + ratingHotel2 + "\n Total rates : " + sum2);
                    }
                    else
                    {
                        Console.WriteLine(" Hotel : " + hotel1 + "\n Rating : " + ratingHotel1 + "\n Total rates : " + sum1);
                    }
                    break;

            }
        }
    }
}
