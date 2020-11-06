using System;
namespace HotelReservationSystem
{
    class HotelReservation
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hotel Reservation Program");
            Reservation reservation = new Reservation();
            reservation.AddDetailsRegular();
            reservation.GetCheapestBestRatedHotel();
            reservation.GetBestRatedHotel();
            reservation.AddDetailsRewarded();
        }
    }
}
