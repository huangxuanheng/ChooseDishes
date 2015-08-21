using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using IShow.ChooseDishes.Model.Booking;

namespace IShow.ChooseDishes.ViewModel.Booking
{
   public class BookingPrePrintViewModel:ViewModelBase
    {
        ObservableCollection<DishModel> _Dishes;


        public ObservableCollection<DishModel> Dishes
        {
            get
            {
                return _Dishes ?? (_Dishes = new ObservableCollection<DishModel>());
            }
        }
        public BookingPrePrintViewModel()
        {
            
            for (int i = 0; i < 10; i++) {
                Dishes.Add(new DishModel("S00" + i, "菜品" + i, 10.09));
            }
        }

    }
}
