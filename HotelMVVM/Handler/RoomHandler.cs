using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
