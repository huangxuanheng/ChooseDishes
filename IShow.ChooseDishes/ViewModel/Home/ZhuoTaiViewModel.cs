using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Model;
using IShow.ChooseDishes.ViewModel.Booking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace IShow.ChooseDishes.ViewModel.Home
{
    public class ZhuoTaiViewModel : ViewModelBase
    {
        public CollectionViewSource RecordsViewSource
        {
            get;
            set;
        }

        public ZhuoTaiViewModel(IMessenger messenger)
            : base(messenger)
        {
        }
    }
}
