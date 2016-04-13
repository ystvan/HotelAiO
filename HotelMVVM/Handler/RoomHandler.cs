using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelMVVM.Model;
using HotelMVVM.Persistency;
using HotelMVVM.ViewModel;

namespace HotelMVVM.Handler
{
    class RoomHandler
    {
        public HotelViewModel HotelViewModel { get; set; }

        public RoomHandler(HotelViewModel hotelViewModel)
        {
            HotelViewModel = hotelViewModel;
        }

        public void CreateRoom()
        {
            Room room = new Room(HotelViewModel.NewRoom.Room_No, HotelViewModel.NewRoom.Hotel_No, 
                                    HotelViewModel.NewRoom.Room_Type, HotelViewModel.NewRoom.Room_Price);

            new PersistenceFacade().SaveRoom(room);

            var rooms = new PersistenceFacade().GetRooms();

            HotelViewModel.HotelCatalogSingleton.Rooms.Clear();
            foreach (var r in rooms)
            {
                HotelViewModel.HotelCatalogSingleton.Rooms.Add(r);
            }

            HotelViewModel.NewRoom.Room_No = 0;
            HotelViewModel.NewRoom.Hotel_No = 0;
            HotelViewModel.NewRoom.Room_Type = "";
            HotelViewModel.NewRoom.Room_Price = "";
        }

        public void DeleteRoom()
        {
            new PersistenceFacade().DeleteRoom(HotelViewModel.SelectedRoom);
            var rooms = new PersistenceFacade().GetRooms();

            HotelViewModel.HotelCatalogSingleton.Rooms.Clear();
            foreach (var r in rooms)
            {
                HotelViewModel.HotelCatalogSingleton.Rooms.Add(r);
            }
        }
    }
}
