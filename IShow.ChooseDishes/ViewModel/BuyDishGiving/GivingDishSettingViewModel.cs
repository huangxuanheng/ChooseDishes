using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.ViewModel.BuyDishGiving
{
    //菜品买赠设置
    public class GivingDishSettingViewModel : ViewModelBase
    {
        DishGivingModel _DishGivingModel;
        public DishGivingModel DishGivingModel
        {
            get { return _DishGivingModel; }
            set { Set("DishGivingModel", ref _DishGivingModel, value); }
        }
        public GivingDishSettingViewModel(IMessenger messenger)
            : base(messenger)
        {
            DishGivingModel dishGivingModel = new DishGivingModel();
            _DishGivingModel = new DishGivingModel();
            dishGivingModel = (DishGivingModel)ViewModelDeliver.Get();
            _DishGivingModel = dishGivingModel;

        }
    }
}
