using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Model;
using IShow.ChooseDishes.View.BuyDishGiving;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.ViewModel.BuyDishGiving
{
    //菜品买赠 窗口
    public class BuyDishGivingViewModel : ViewModelBase
    {
        IChooseDishesDataService _DataService;
        IDishService _IDishService;

        public BuyDishGivingViewModel(IChooseDishesDataService dataService, IDishService DishService, IMessenger messenger)
            : base(messenger)
        {
            _DataService = dataService;
            _IDishService = DishService;
            //Init();
            
        }
        
        public void Init()
        {
            //List<DishGivingModel> list = _DataService.findBargainDishAll();
            //DishesGivingList.Clear();
            //foreach(var element in list){
            //    DishesGivingList.Add((new BargainDishBean()).CreateBargainDishBean(element));
            //}
        }
        private ObservableCollection<DishGivingModel> _DishesGivingList = new ObservableCollection<DishGivingModel>();
        public ObservableCollection<DishGivingModel> DishesGivingList
        {
            get {
                return _DishesGivingList;
            }
            set
            {
                Set("DishesGivingList", ref _DishesGivingList, value);
            }
        } 
        //新增买赠菜品选择窗口
        AddBuyGivingDishes _AddBuyGivingDishesWin;
        RelayCommand _AddBuyGivingDishes;
        public RelayCommand AddBuyGivingDishes
        {
            get
            {
                return _AddBuyGivingDishes ?? (_AddBuyGivingDishes = new RelayCommand(() =>
                {
                    _AddBuyGivingDishesWin = new AddBuyGivingDishes();
                    _AddBuyGivingDishesWin.ShowDialog();
                }));
            }
        }
        //修改菜品买赠设置
        BuyGivingSetting _BuyGivingSettingWin;
        RelayCommand _UpdataBuyGivingDishes;
        public RelayCommand UpdataBuyGivingDishes
        {
            get
            {
                return _UpdataBuyGivingDishes ?? (_UpdataBuyGivingDishes = new RelayCommand(() =>
                {
                    _BuyGivingSettingWin = new BuyGivingSetting();
                    _BuyGivingSettingWin.ShowDifferentStyleWin(1);//修改操作，显示上下记录按钮
                    _BuyGivingSettingWin.ShowDialog();
                }));
            }
        }
    }
}
