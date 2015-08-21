using GalaSoft.MvvmLight;
using IShow.ChooseDishes.Model.Booking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.ViewModel.TakeOut
{
    public class TakeawayDeliveryViewModel : ViewModelBase
    {
        public ObservableCollection<TableItemModel> _Items;
        public ObservableCollection<TableItemModel> Items
        {
            get
            {
                return _Items ?? (_Items = new ObservableCollection<TableItemModel>());
            }
            set
            {
                Set("Items", ref _Items, value);
            }
        }
        public TakeawayDeliveryViewModel()
        {
            for (int x = 0; x < 20; x++)
            {
                //Items.Add(new TableItemModel(11,1111,"11" + x, "aa" + x, 10003, TableStatus.Locked));
            }
        }
    }
}
