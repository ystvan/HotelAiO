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

        private HotelCatalogSingleton()
        {
            Hotels = new ObservableCollection<Hotel>();

            Hotels = new ObservableCollection<Hotel>(new PersistenceFacade().GetHotels());
        }

        public void Add(int Hotel_No, string Name, string Address)
        {
            Hotels.Add(new Hotel(Hotel_No, Name, Address));
            
        }

        public void Remove(Hotel thisHotel)
        {
            Hotels.Remove(thisHotel);

        }
    }
}
