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
    public class ChooseDishesViewModel:ViewModelBase
    {

        ObservableCollection<string> _Categorys;

        ObservableCollection<DishModel> _Dishes;

        public ObservableCollection<string> Categorys
        {
            get {
                return _Categorys ?? (_Categorys = new ObservableCollection<string>());
            }
        }

        public ObservableCollection<DishModel> Dishes
        {
            get
            {
                return _Dishes ?? (_Dishes = new ObservableCollection<DishModel>());
            }
        }

        public ChooseDishesViewModel() {
            for (int i = 0; i < 12; i++) {
                Categorys.Add("红烧" + i);
            }

            for (int i = 0; i < 10; i++) {
                Dishes.Add(new DishModel("S00" + i, "菜品" + i, 10.09));
            }
        }
    }
}
