using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMVVM.Model
{
    class Hotel
    {
        public int Hotel_No { get; set; }
        public string Hotel_Name { get; set; }
        public string Hotel_Address { get; set; }

        public Hotel(int hotelNo, string name, string address)
        {
            Hotel_No = hotelNo;
            Hotel_Name = name;
            Hotel_Address = address;
        }

        public Hotel()
        {
            
        }
        public override string ToString()
        {
            return string.Format("Hotelno: {0}, \nName: {1},\nAddress: {2}\n\n", Hotel_No, Hotel_Name, Hotel_Address);
        }

    }
}
