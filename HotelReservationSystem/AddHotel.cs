using System;
using System.Collections.Generic;
using System.Text;
namespace HotelReservationSystem
{
    class AddHotel
    {
        public string hotelName;
        public int rates;
        public AddHotel(string name, int rates)
        {
            hotelName = name;
            this.rates = rates;
        }
    }
}
