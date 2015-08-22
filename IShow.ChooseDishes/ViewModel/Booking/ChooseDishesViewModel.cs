using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using IShow.ChooseDishes.Model.Booking;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.ViewModel.Common;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Model;
using GalaSoft.MvvmLight.Command;

namespace IShow.ChooseDishes.ViewModel.Booking
{
    public class ChooseDishesViewModel:ViewModelBase
    {
        IChooseDishesDataService _DataService;
        IDishService _DishService;
        //First
        //Second
        //大类
        ObservableCollection<DishType> _FirstCategorys;

        //小类
        ObservableCollection<DishType> _SecondCategorys;


        //菜品列表
        ObservableCollection<DishBeanUtil> _Dishes;
        /// <summary>
        /// 已选菜品
        /// </summary>
        ObservableCollection<DishBeanUtil> _OrderedDishes;



        public ObservableCollection<DishType> FirstCategorys
        {
            get {
                return _FirstCategorys ?? (_FirstCategorys = new ObservableCollection<DishType>());
            }
        }

        public ObservableCollection<DishType> SecondCategorys
        {
            get
            {
                return _SecondCategorys ?? (_SecondCategorys = new ObservableCollection<DishType>());
            }
        }

        public ObservableCollection<DishBeanUtil> Dishes
        {
            get
            {
                return _Dishes ?? (_Dishes = new ObservableCollection<DishBeanUtil>());
            }
        }

        public ObservableCollection<DishBeanUtil> OrderedDishes
        {
            get
            {
                return _OrderedDishes ?? (_OrderedDishes = new ObservableCollection<DishBeanUtil>());
            }
        }

        //选择大类显示对应小类
        public void SelectedItemFirstCategory(int dishTypeId)
        {
            List<DishType> listsmail = _DataService.FindDishTypeByType(dishTypeId);
            SecondCategorys.Clear();
            foreach (var element in listsmail)
            {
                SecondCategorys.Add(element);
            }
        }

        //选择小类显示菜品
        public void SelectedItemSecondCategory(int dishTypeId)
        {
            //更新菜品
            List<Dish> list = _DataService.FindDishs(dishTypeId);
            _Dishes.Clear();

            foreach (var element in list)
            {
                DishBean dishBean = new DishBean().CreateDishBean(element);
                //注入大类,小类
                ZhuRuDishTypeName(element, dishBean);
                CreateDishBeanUtil(dishBean);
            }
        }

        //落单操作
        public void SubmitOrders_Ation(List<DishBeanUtil> dishLish)
        {
            int i = dishLish.Count;
            OrderedDishes.Clear();
            foreach (DishBeanUtil d in dishLish)
            {
                OrderedDishes.Add(d);
            }
            Console.WriteLine(string.Format("dishList.Count : {0}", dishLish.Count));
        }

        //结账操作

        public ChooseDishesViewModel(IChooseDishesDataService dataService, IDishService dishService, IMessenger messenger)
            : base(messenger)
        {
            _DataService = dataService;
            _DishService = dishService;
            Init();
            //List<DishType> types = _DishService.LoadFatherType();    //大类
            //List<DishType> subs = _DishService.LoadSubTypeAndDishs();   //小类

            //for (int i = 0; i < 10; i++) {
            //    Dishes.Add(new DishModel("S00" + i, "菜品" + i, 10.09));
            //}
        }

        public void Init()
        {
            //加载菜品大类
            List<DishType> dishTypeBig = _DataService.FindDishTypeByType(0);
            foreach (var element in dishTypeBig)
            {
                FirstCategorys.Add(element);
            }
            //加载第一个菜品小类
            List<DishType> listsmail = _DataService.FindDishTypeByType(FirstCategorys[0].DishTypeId);
            SecondCategorys.Clear();
            foreach (var element in listsmail)
            {
                SecondCategorys.Add(element);
            }
            //加载所有菜品小类
            //List<DishType> dishTypeSmail = _DataService.FindDishTypeByType(-1);
        }

        // 装载 DishBeanUtil
        public void CreateDishBeanUtil(DishBean element)
        {
            if (element.DishPrice != null && element.DishPrice.Count > 0)
            {
                foreach (var elem in element.DishPrice)
                {
                    DishBeanUtil Dbu = new DishBeanUtil();
                    Dbu.CreateDishBeanUtilByDishBean(elem);
                    Dbu.DishName = element.DishName;
                    Dbu.Code = element.Code;
                    Dbu.DishUnitName = element.DishUnit.Name;
                    Dbu.PingYing = element.PingYing;
                    Dbu.AidNumber = element.PingYing;
                    Dbu.DishTypeBigName = element.DishTypeBigName;
                    Dbu.DishTypeName = element.DishTypeName;
                    Dishes.Add(Dbu);
                }
            }

        }

        public void CreateDishesMenusSelected(List<Dish> list)
        {
            _Dishes.Clear();

            foreach (var element in list)
            {
                DishBean dishBean = new DishBean().CreateDishBean(element);
                //注入小类
                if (element.DishType != null)
                {
                    dishBean.DishTypeName = element.DishType.Name;
                }
                //注入大类
                ZhuRuDishTypeName(element, dishBean);
                CreateDishBeanUtil(dishBean);
            }
        }
        public void ZhuRuDishTypeName(Dish element, DishBean dishBean)
        {
            if (element.DishType != null)
            {
                for (int j = 0; j < _FirstCategorys.Count; j++)
                {
                    if (element.DishType.ParentId == _FirstCategorys[j].DishTypeId)
                    {
                        dishBean.DishTypeBigName = _FirstCategorys[j].Name;
                        break;
                    }
                }

            }
        }
    }
}
