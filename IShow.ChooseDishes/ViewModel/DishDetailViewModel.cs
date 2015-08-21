using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Model;
using IShow.ChooseDishes.View;
using IShow.ChooseDishes.ViewModel.Common;
using IShow.ChooseDishes.Data;
using System.Diagnostics;
using IShow.ChooseDishes.View.Dishes;

namespace IShow.ChooseDishes.ViewModel
{
     
    /// <summary>
    /// 道菜明细
    /// </summary>
    public class DishDetailViewModel : ViewModelBase
    {
        IChooseDishesDataService _IChooseDishesDataService;

        //选择道菜明细页面
        DishDetailView dw { get; set; }

        //模糊搜索
        string _MoFuSouSuo;
        public string MoFuSouSuo
        {

            get
            {
                return _MoFuSouSuo;
            }
            set
            {
                Set("MoFuSouSuo", ref _MoFuSouSuo, value);
            }
        }

        //条件重置  ResetSelectValue
        RelayCommand _ResetSelectValue;
        public RelayCommand ResetSelectValue
        {
            get
            {
                return _ResetSelectValue ?? (_ResetSelectValue = new RelayCommand(() =>
                {
                     MoFuSouSuo = null;
                     dw.DishTypeBigComBoBox.SelectedItem = null;
                     dw.DishTypeSmailComBoBox.SelectedItem = null;

                }));

            }
        }

        //运用  进行模糊搜索  YunYongSelectValue
        RelayCommand _YunYongSelectValue;
        public RelayCommand YunYongSelectValue
        {
            get
            {
                return _YunYongSelectValue ?? (_YunYongSelectValue = new RelayCommand(() =>
                {
                    //搜索更新菜品
                    List<Dish> list = _IChooseDishesDataService.FindDishsByDishName(_MoFuSouSuo);
                    _DishesMenusSelected.Clear();

                    foreach (var element in list)
                    {
                        DishesMenusSelected.Add(new DishBean().CreateDishBean(element));
                    }

                }));

            }
        }

        //保存
        RelayCommand _OkSelect;
        public RelayCommand OkSelect
        {
            get
            {
                return _OkSelect ?? (_OkSelect = new RelayCommand(() =>
                {












                }));

            }
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

                List<DishType> listsmail = _IChooseDishesDataService.FindDishTypeByType(value.DishTypeId);
                DishTypeSmail.Clear();
                foreach (var element in listsmail)
                {
                    DishTypeSmail.Add(element);
                }
                //更新菜品
                List<Dish> list = _IChooseDishesDataService.FindDishPackages(value.DishTypeId);
                _DishesMenusSelected.Clear();

                foreach (var element in list)
                {
                    DishesMenusSelected.Add(new DishBean().CreateDishBean(element));
                }

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
                List<Dish> list = _IChooseDishesDataService.FindDishPackages(value.DishTypeId);
                _DishesMenusSelected.Clear();

                foreach (var element in list)
                {
                    DishesMenusSelected.Add(new DishBean().CreateDishBean(element));
                }

                Set("SelectedItemSmail", ref _SelectedItemSmail, value);
            }
        }

        //加载所有的 菜品 大类 小类 
        public void LoadDishObject()
        {
            //加载所有小类
            _DishTypeSmail = new ObservableCollection<DishType>();
            List<DishType> listsmail = _IChooseDishesDataService.FindDishTypeByType(-1);
            _DishTypeSmail.Clear();
            foreach (var element in listsmail)
            {
                _DishTypeSmail.Add(element);
            }

            //加载所有的菜品
            List<Dish> list = _IChooseDishesDataService.FindDishPackages(0);
            _DishesMenusSelected.Clear();

            foreach (var element in list)
            {
                DishBean dishBean = new DishBean().CreateDishBean(element);
                //注入大类,小类
                for (int i = 0; i < _DishTypeSmail.Count; i++)
                {
                    if (element.DishTypeId == _DishTypeSmail[i].DishTypeId)
                    {
                        dishBean.DishTypeName = _DishTypeSmail[i].Name;
                        bool flag = false;
                        for (int j = 0; j < _DishTypeBig.Count; j++)
                        {
                            if (_DishTypeSmail[i].ParentId == _DishTypeBig[j].DishTypeId)
                            {
                                dishBean.DishTypeBigName = _DishTypeBig[j].Name;
                                flag = true;
                                break;
                            }
                        }
                        if (flag) break;
                    }
                }
                DishesMenusSelected.Add(dishBean);
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
        ObservableCollection<DishBean> _DishesMenusSelected = new ObservableCollection<DishBean>();
        public ObservableCollection<DishBean> DishesMenusSelected
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

        public DishDetailViewModel(IChooseDishesDataService dataService, IMessenger messenger)
            : base(messenger)
        {
            _IChooseDishesDataService = dataService;
            //加载菜品大类
            _DishTypeBig = _IChooseDishesDataService.FindDishTypeByType(0);
            //加载菜品小类
            _DishTypeSmail = new ObservableCollection<DishType>();
            List<DishType> listsmail = _IChooseDishesDataService.FindDishTypeByType(-1);
            _DishTypeSmail.Clear();
            foreach (var element in listsmail)
            {
                _DishTypeSmail.Add(element);
            }
            //加载菜品
             List<Dish> list = _IChooseDishesDataService.FindDishPackages(0);
            _DishesMenusSelected.Clear();

            foreach (var element in list)
            {
                DishBean dishBean = new DishBean().CreateDishBean(element);
                //注入大类,小类
                for (int i = 0; i < _DishTypeSmail.Count; i++)
                {
                    if (element.DishTypeId == _DishTypeSmail[i].DishTypeId)
                    {
                        dishBean.DishTypeName = _DishTypeSmail[i].Name;
                        bool flag = false;
                        for (int j = 0; j < _DishTypeBig.Count; j++)
                        {
                            if (_DishTypeSmail[i].ParentId == _DishTypeBig[j].DishTypeId)
                            {
                                dishBean.DishTypeBigName = _DishTypeBig[j].Name;
                                flag = true;
                                break;
                            }
                        }
                        if (flag) break;
                    }
                }
                DishesMenusSelected.Add(dishBean);
            }

        }


    }

}
   
