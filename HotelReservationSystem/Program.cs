using System;
namespace HotelReservationSystem
{
    class HotelReservation
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hotel Reservation Program");
            Reservation reservation = new Reservation();
            string temp = "1";
            while (temp != "0")
            {
                Console.WriteLine("\nEnter \n1. Add Hotel \n0. Exist");
                temp = Console.ReadLine();
                if (temp == "1")
                {
                    reservation.AddDetails();
                }
                else if (temp == "0")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("You have entered invalid entry. Please enter 1-0");
                }
            }
        }
    }
}
