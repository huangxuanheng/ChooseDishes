using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.View.Dishes;
using IShow.ChooseDishes.View.BargainDish;
using IShow.ChooseDishes.View.CashWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IShow.ChooseDishes.View.PromotionsDish;
using IShow.ChooseDishes.View.Table;

namespace IShow.ChooseDishes.ViewModel.Home
{
    public class BaseContentViewModel : ViewModelBase
    {

        #region Command
        RelayCommand _CaiPinZiLiao;    //菜品资料
        public RelayCommand CaiPinZiLiao
        {
            get
            {
                return _CaiPinZiLiao ?? (_CaiPinZiLiao = new RelayCommand(() =>
                {
                    DishesWin dishesWin = new DishesWin();
                    dishesWin.ShowDialog();
                }));
            }
        }
        RelayCommand _DishesWay;    //菜品做法
        public RelayCommand DishesWay
        {
            get
            {
                return _DishesWay ?? (_DishesWay = new RelayCommand(() =>
                {
                    //MessageBox.Show("菜品做法");
                    DishesWayWindow dw = new DishesWayWindow();
                    dw.ShowDialog();
                }));
            }
        }
        RelayCommand _MarketTypeSetting;    //市别设置
        public RelayCommand MarketTypeSetting
        {
            get
            {
                return _MarketTypeSetting ?? (_MarketTypeSetting = new RelayCommand(() =>
                {
                    //MessageBox.Show("市别设置");
                    MarketTypeView mtv = new MarketTypeView();
                    mtv.ShowDialog();
                }));
            }
        }
        RelayCommand _RawMaterial;    //菜品原料
        public RelayCommand RawMaterial
        {
            get
            {
                return _RawMaterial ?? (_RawMaterial = new RelayCommand(() =>
                {
                    // MessageBox.Show("菜品原料");
                    MaterialView mv = new MaterialView();
                    mv.ShowDialog();
                }));
            }
        }
        RelayCommand _DishesWayRef;    //做法关联
        public RelayCommand DishesWayRef
        {
            get
            {
                return _DishesWayRef ?? (_DishesWayRef = new RelayCommand(() =>
                {
                    DischesWayRefView mv = new DischesWayRefView();
                    mv.ShowDialog();
                }));
            }
        }
        
        #endregion
        //OpenCashWin
        #region Command
        RelayCommand _OpenCashWin;    //收银方式
        public RelayCommand OpenCashWin
        {
            get
            {
                return _OpenCashWin ?? (_OpenCashWin = new RelayCommand(() =>
                {
                    CashWin _CashWin = new CashWin();
                    _CashWin.ShowDialog();
                }));
            }
        }
        #endregion
        //OpenBargainDishWin
        #region Command
        RelayCommand _OpenBargainDishWin;    //菜品 特价
        public RelayCommand OpenBargainDishWin
        {
            get
            {
                return _OpenBargainDishWin ?? (_OpenBargainDishWin = new RelayCommand(() =>
                {
                    BargainDishWin _BargainDishWin = new BargainDishWin();
                    _BargainDishWin.ShowDialog();
                }));
            }
        }
        #endregion
        //PromotionsDishWin
        #region Command
        RelayCommand _OpenPromotionsDishWin;    //菜品 买赠
        public RelayCommand OpenPromotionsDishWin
        {
            get
            {
                return _OpenPromotionsDishWin ?? (_OpenPromotionsDishWin = new RelayCommand(() =>
                {
                    PromotionsDishWin _PromotionsDishWin = new PromotionsDishWin();
                    _PromotionsDishWin.ShowDialog();
                }));
            }
        }
        #endregion

        RelayCommand _TableInfo;    //餐桌资料
        public RelayCommand TableInfo
        {
            get
            {
                return _TableInfo ?? (_TableInfo = new RelayCommand(() =>
                {
                    // MessageBox.Show("菜品原料");
                    TableMainWindow mv = new TableMainWindow();
                    mv.ShowDialog();
                }));
            }
        }

        #region private
        private void _Initialize()
        {
            try
            {




            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        public BaseContentViewModel(IMessenger messenger)
            : base(messenger)
        {
            _Initialize();
        }
    }
}
