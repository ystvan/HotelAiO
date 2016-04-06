using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HotelMVVM.Model;

namespace HotelMVVM.ViewModel
{
    class RoomViewModel : INotifyPropertyChanged
    {

        public RoomCatalogSingleton RoomCatalogSingleton { get; set; }

        public Handler.RoomHandler RoomHandler { get; set; }

        public ICommand CreateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public Room NewRoom
        {
            get { return _newRoom; }
            set { _newRoom = value; OnPropertyChanged(); }
        }

        private Room _newRoom;

        public RoomViewModel()
        {
            RoomCatalogSingleton = RoomCatalogSingleton.Instance;

        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
