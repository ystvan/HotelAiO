using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMVVM.Model
{
    class Room
    {
        public int Room_No { get; set; }
        public int Hotel_No { get; set; }
        public string Room_Type { get; set; }
        public string Room_Price { get; set; }

        public Room(int roomNo, int hotelNo, string roomType, string roomPrice)
        {
            Room_No = roomNo;
            Hotel_No = hotelNo;
            Room_Type = roomType;
            Room_Price = roomPrice;
        }

        public Room()
        {

        }
        public override string ToString()
        {
            return string.Format("RoomNo: {0}, In which hotel: {1}, Type: {2} Price per night:", Room_No, Hotel_No, Room_Type, Room_Price);
        }
    }
}
