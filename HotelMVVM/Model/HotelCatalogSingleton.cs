using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelMVVM.Persistency;

namespace HotelMVVM.Model
{
    class HotelCatalogSingleton
    {
        private static HotelCatalogSingleton instance = new HotelCatalogSingleton();

        public static HotelCatalogSingleton Instance
        {
            get { return instance; }
        }

        public ObservableCollection<Hotel> Hotels { get; set; }

        public ObservableCollection<Room> Rooms { get; set; }
        
        private HotelCatalogSingleton()
        {
            Hotels = new ObservableCollection<Hotel>();

            Hotels = new ObservableCollection<Hotel>(new PersistenceFacade().GetHotels());

            Rooms = new ObservableCollection<Room>();

            Rooms = new ObservableCollection<Room>(new PersistenceFacade().GetRooms());

        }

        public void Add(int Hotel_No, string Name, string Address)
        {
            Hotels.Add(new Hotel(Hotel_No, Name, Address));
            
        }

        public void Remove(Hotel thisHotel)
        {
            Hotels.Remove(thisHotel);

        }

        public void Add(int RooRoom_No, int Hotel_No, string Room_Type, string Room_Price)
        {
            Rooms.Add(new Room(Hotel_No, Hotel_No, Room_Type, Room_Price));

        }

        public void Remove(Room thisRoom)
        {
            Rooms.Remove(thisRoom);

        }
    }
}
