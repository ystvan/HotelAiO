using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelMVVM.Persistency;

namespace HotelMVVM.Model
{
    class RoomCatalogSingleton
    {
        private static RoomCatalogSingleton instance = new RoomCatalogSingleton();

        public static RoomCatalogSingleton Instance
        {
            get { return instance; }
        }

        public ObservableCollection<Room> Rooms { get; set; }

        private RoomCatalogSingleton()
        {
            Rooms = new ObservableCollection<Room>();

            Rooms = new ObservableCollection<Room>(new PersistenceFacade().GetRooms());
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
