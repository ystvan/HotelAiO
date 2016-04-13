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
        public Handler.RoomHandler RoomHandler { get; set; }

        public ICommand CreateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public ICommand CreateRoomCommand { get; set; }
        public ICommand DeleteRoomCommand { get; set; }

        public Hotel NewHotel
        {
            get { return _newHotel; }
            set { _newHotel = value;
                    OnPropertyChanged(); }
        }

        public Room NewRoom
        {
            get { return _newRoom; }
            set { _newRoom = value;
                    OnPropertyChanged(); }
        }

        private Room _newRoom;

        private Hotel _newHotel;
        
        public HotelViewModel()
        {
            HotelCatalogSingleton = HotelCatalogSingleton.Instance;
            NewHotel = new Hotel();
            NewRoom = new Room();
            HotelHandler = new Handler.HotelHandler(this);
            RoomHandler = new Handler.RoomHandler(this);
            CreateCommand = new RelayCommand(HotelHandler.CreateHotel);
            DeleteCommand = new RelayCommand(HotelHandler.DeleteHotel);
            CreateRoomCommand = new RelayCommand(RoomHandler.CreateRoom);
            DeleteRoomCommand = new RelayCommand(RoomHandler.DeleteRoom);
        }

        public static Hotel SelectedHotel { get; set; }
        public static Room SelectedRoom { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        

    }
}
