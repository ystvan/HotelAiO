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
    class HotelHandler
    {
        public HotelViewModel HotelViewModel { get; set; }

        public HotelHandler(HotelViewModel hotelViewModel)
        {
            HotelViewModel = hotelViewModel;
        }

        public void CreateHotel()
        {
            Hotel hotel = new Hotel(HotelViewModel.NewHotel.Hotel_No,
                                            HotelViewModel.NewHotel.Hotel_Name,
                                            HotelViewModel.NewHotel.Hotel_Address);

            new PersistenceFacade().SaveHotel(hotel);

            //HotelViewModel.Hotels.Hotels.Add(hotel);
            var hotels = new PersistenceFacade().GetHotels();

            HotelViewModel.HotelCatalogSingleton.Hotels.Clear();
            foreach (var h in hotels)
            {
                HotelViewModel.HotelCatalogSingleton.Hotels.Add(h);
            }

            HotelViewModel.NewHotel.Hotel_No = 0;
            HotelViewModel.NewHotel.Hotel_Name = "";
            HotelViewModel.NewHotel.Hotel_Address = "";

        }

        public void DeleteHotel()
        {
            //HotelViewModel.HotelCatalogSingleton.Remove(HotelViewModel.SelectedHotel);

            new PersistenceFacade().DeleteHotel(HotelViewModel.SelectedHotel);
            var hotels = new PersistenceFacade().GetHotels();

            HotelViewModel.HotelCatalogSingleton.Hotels.Clear();
            foreach (var h in hotels)
            {
                HotelViewModel.HotelCatalogSingleton.Hotels.Add(h);
            }
        }



    }
}
