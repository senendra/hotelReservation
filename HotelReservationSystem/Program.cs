using System;
namespace HotelReservationSystem
{
    class HotelReservation
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hotel Reservation Program");
            Reservation reservation = new Reservation();
            reservation.AddDetails();
            reservation.GetCheapestBestRatedHotel();
            reservation.GetBestRatedHotel();
        }
    }
}
