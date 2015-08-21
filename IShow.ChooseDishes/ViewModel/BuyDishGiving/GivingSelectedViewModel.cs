using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.ViewModel.BuyDishGiving
{
    //赠品选择
    public class GivingSelectedViewModel : ViewModelBase
    {
        IChooseDishesDataService _DataService;

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
                    DishesMenusSelected.Add(Dbu);
                }
            }

        }
        public void OkSelect_Dish(DishBeanUtil dish) { 
            //保存需要添加的菜品
            //DishGivingModel dishGiving = new DishGivingModel();
            DishGivingModel dishGiving = (DishGivingModel)ViewModelDeliver.Get();
            dishGiving.SaveGivingDishDetail(dish);
            //ViewModelDeliver.Set(dishGiving);
        }

        //点击菜品大类 SelectedItemBig
        DishType _SelectedItemBig;
        public DishType SelectedItemBig
        {
            get
            {
                return _SelectedItemBig;
            }
            set
            {
                if (value == null)
                {
                    LoadDishObject();
                    return;
                }

                List<DishType> listsmail = _DataService.FindDishTypeByType(value.DishTypeId);
                DishTypeSmail.Clear();
                foreach (var element in listsmail)
                {
                    DishTypeSmail.Add(element);
                }
                //更新菜品
                List<Dish> list = _DataService.FindDishs(value.DishTypeId);
                CreateDishesMenusSelected(list);

                Set("SelectedItemBig", ref _SelectedItemBig, value);
            }
        }
        //点击菜品小类 SelectedItemSmail
        DishType _SelectedItemSmail;
        public DishType SelectedItemSmail
        {
            get
            {
                return _SelectedItemSmail;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                //更新菜品
                List<Dish> list = _DataService.FindDishs(value.DishTypeId);
                _DishesMenusSelected.Clear();

                foreach (var element in list)
                {
                    DishBean dishBean = new DishBean().CreateDishBean(element);
                    //注入大类,小类
                    ZhuRuDishTypeName(element, dishBean);
                    CreateDishBeanUtil(dishBean);
                }

                Set("SelectedItemSmail", ref _SelectedItemSmail, value);
            }
        }

        //加载所有的 菜品 大类 小类 
        public void LoadDishObject()
        {
            //加载所有小类
            DishTypeSmail = new ObservableCollection<DishType>();
            List<DishType> listsmail = _DataService.FindDishTypeByType(-1);
            DishTypeSmail.Clear();
            foreach (var element in listsmail)
            {
                DishTypeSmail.Add(element);
            }

            //加载所有的菜品
            List<Dish> list = _DataService.FindDishs(0);
            CreateDishesMenusSelected(list);


        }

        //选择的菜品 SelectedItemDish
        DishBeanUtil _SelectedItemDish;
        public DishBeanUtil SelectedItemDish
        {
            get
            {
                return _SelectedItemDish;
            }
            set
            {
                Set("SelectedItemDish", ref _SelectedItemDish, value);
            }
        }
        //菜品大类
        List<DishType> _DishTypeBig;
        public List<DishType> DishTypeBig
        {
            get
            {
                return _DishTypeBig;
            }
            set
            {
                Set("DishTypeBig", ref _DishTypeBig, value);
            }
        }
        //菜品小类
        ObservableCollection<DishType> _DishTypeSmail;
        public ObservableCollection<DishType> DishTypeSmail
        {
            get
            {
                return _DishTypeSmail;
            }
            set
            {
                Set("DishTypeSmail", ref _DishTypeSmail, value);
            }
        }

        //选择菜品
        ObservableCollection<DishBeanUtil> _DishesMenusSelected = new ObservableCollection<DishBeanUtil>();
        public ObservableCollection<DishBeanUtil> DishesMenusSelected
        {
            get
            {
                return _DishesMenusSelected;
            }
            set
            {
                Set("DishesMenusSelected", ref _DishesMenusSelected, value);
            }
        }

        public GivingSelectedViewModel(IChooseDishesDataService dataService, IMessenger messenger)
            : base(messenger)
        {
            _DataService = dataService;
            Init();
        }
        public void Init() {
            //加载菜品大类
            _DishTypeBig = _DataService.FindDishTypeByType(0);
            //加载菜品小类
            DishTypeSmail = new ObservableCollection<DishType>();
            List<DishType> listsmail = _DataService.FindDishTypeByType(-1);
            DishTypeSmail.Clear();
            foreach (var element in listsmail)
            {
                DishTypeSmail.Add(element);
            }
            //加载菜品
            List<Dish> list = _DataService.FindDishs(0);
            CreateDishesMenusSelected(list);
        }


        public void CreateDishesMenusSelected(List<Dish> list) {
            _DishesMenusSelected.Clear();

            foreach (var element in list)
            {
                DishBean dishBean = new DishBean().CreateDishBean(element);
                //注入小类
                if(element.DishType!=null){
                    dishBean.DishTypeName = element.DishType.Name;
                }
                //注入大类
                ZhuRuDishTypeName(element, dishBean);
                CreateDishBeanUtil(dishBean);
            }
        }
        public void ZhuRuDishTypeName(Dish element, DishBean dishBean)
        {
            if(element.DishType!=null){
                for (int j = 0; j < _DishTypeBig.Count; j++)
                {
                    if (element.DishType.ParentId == _DishTypeBig[j].DishTypeId)
                    {
                        dishBean.DishTypeBigName = _DishTypeBig[j].Name;
                        break;
                    }
                }
                    
            }        
        }
    }
}
