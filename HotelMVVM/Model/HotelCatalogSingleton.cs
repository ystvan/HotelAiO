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

        
    }
}
