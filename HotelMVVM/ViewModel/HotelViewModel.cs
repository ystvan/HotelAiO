using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HotelMVVM.Common;
using HotelMVVM.Handler;
using HotelMVVM.Model;

namespace HotelMVVM.ViewModel
{
    class HotelViewModel : INotifyPropertyChanged
    {
        public HotelCatalogSingleton HotelCatalogSingleton { get; set; }
        public Handler.HotelHandler HotelHandler { get; set; }
        public ICommand CreateCommand { get; set; }
        public Hotel NewHotel
        {
            get { return _newHotel; }
            set { _newHotel = value; OnPropertyChanged(); }
        }
        private Hotel _newHotel;
        
        public HotelViewModel()
        {
            HotelCatalogSingleton = HotelCatalogSingleton.Instance;
            NewHotel = new Hotel();
            HotelHandler = new Handler.HotelHandler(this);
            CreateCommand = new RelayCommand(HotelHandler.CreateHotel);
            //_deleteHotelCommand = new RelayCommand(HotelHandler.Delete);

        }

        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        

    }
}
