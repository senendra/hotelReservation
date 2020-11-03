using System;
using System.Collections.Generic;
using System.Text;
namespace HotelReservationSystem
{
    class AddHotel
    {
        public string hotelName;
        public int weekdaysRates;
        public int weekendsRates;
        public int rating;
        public AddHotel(string name, int weekdaysRates, int weekendsRates, int rating)
        {
            hotelName = name;
            this.weekdaysRates = weekdaysRates;
            this.weekendsRates = weekendsRates;
            this.rating = rating;
        }
    }
}
