using System;
namespace HotelReservationSystem
{
    class HotelReservation
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hotel Reservation Program");
            Reservation reservation = new Reservation();
            Console.WriteLine("Enter customer type (REGULAR/REWARDED) :");
            string customerType = Console.ReadLine();
            customerType = customerType.ToUpper();
            if (customerType.Equals("REGULAR"))
            {
                reservation.AddDetailsRegular();
                reservation.GetCheapestBestRatedHotel();
                reservation.GetBestRatedHotel();
            }
            else if (customerType.Equals("REWARDED"))
            {
                reservation.AddDetailsRewarded();
                reservation.GetCheapestBestRatedHotel();
                reservation.GetBestRatedHotel();
            }
            else
            {
                Console.WriteLine("Your entered invalid customer type. Try Again!!");
            }
        }
    }
}
