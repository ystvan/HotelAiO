using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelMVVM.Model;
using HotelMVVM.ViewModel;

namespace HotelMVVM.Handler
{
    class RoomHandler
    {
        public RoomViewModel RoomViewModel { get; set; }

        public RoomHandler(RoomViewModel roomViewModel)
        {
            RoomViewModel = roomViewModel;
        }

        public void CreateRoom()
        {
            Room room = new Room(RoomViewModel.NewRoom.Room_No, RoomViewModel.NewRoom.Hotel_No, 
                                    RoomViewModel.NewRoom.Room_Type, RoomViewModel.NewRoom.Room_Price);


        }

        public void DeleteRoom()
        {
            
        }
    }
}
