using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.View.DischesWayView;
using IShow.Common.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace IShow.ChooseDishes.ViewModel
{
    public class DishesWayModel : ViewModelBase
    {
        //实例化对象时就给IDischesWayModel对象赋值，方便调用数据持久层操作数据库

        //1.页面传入数据新增时，调用数据持久层的添加方法将做法添加到数据库

        //2.页面操作修改做法时，调用数据持久层的修改方法将做法进行修改

        //3.页面操作删除做法时，调用数据持久层删除对应做法

        //4.提供一个查询做法的功能，根据传入的做法类型id，获取所有的做法


        #region Command
        RelayCommand _DishesWayName;
        public RelayCommand DishesWayName
        {
            get
            {
                return _DishesWayName ?? (_DishesWayName = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    //做法类型
                    MessageBox.Show("做法类型");
                    Logger.Log("做法类型", LOGSEVERITY.Debug);
                    
                    Logger.LogMethodExit();
                }));
            }
        }
        RelayCommand _AddDishesWay;
        public RelayCommand AddDishesWay
        {
            get
            {
                return _AddDishesWay ?? (_AddDishesWay = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    //添加做法
                   // MessageBox.Show("添加做法");

                    Logger.Log("添加做法", LOGSEVERITY.Debug);
                    new DishesWayFrom().ShowDialog();
                    Logger.LogMethodExit();
                }));
            }
        }
        RelayCommand _UpdateDishesWay;
        public RelayCommand UpdateDishesWay
        {
            get
            {
                return _UpdateDishesWay ?? (_UpdateDishesWay = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    //修改做法
                    MessageBox.Show("修改做法");
                    //弹出修改做法界面，从数据库中读取做法表的信息，设置到界面上
                    Logger.Log("修改做法", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }
        
        RelayCommand _DeleteDishesWay;
        public RelayCommand DeleteDishesWay
        {
            get
            {
                return _DeleteDishesWay ?? (_DeleteDishesWay = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    //删除做法
                    MessageBox.Show("删除做法");

                    Logger.Log("删除做法", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }
        
        RelayCommand _PingYing;
        public RelayCommand PingYing
        {
            get
            {
                return _PingYing ?? (_PingYing = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    //做法拼音简码生成
                    MessageBox.Show("做法拼音简码生成");

                    Logger.Log("做法拼音简码生成", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }
        RelayCommand _Refresh;
        public RelayCommand Refresh
        {
            get
            {
                return _Refresh ?? (_Refresh = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    //刷新做法页面
                    MessageBox.Show("刷新做法页面");

                    Logger.Log("刷新做法页面", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }
        RelayCommand _Printed;
        public RelayCommand Printed
        {
            get
            {
                return _Printed ?? (_Printed = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    //打印
                    MessageBox.Show("打印");

                    Logger.Log("打印", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }
        RelayCommand _Exited;
        public RelayCommand Exited
        {
            get
            {
                return _Exited ?? (_Exited = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    //退出做法页面
                    MessageBox.Show("退出做法页面");

                    Logger.Log("退出做法页面", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }
        
        
        #endregion Command

        //public LoginViewModel(IDischesWayNameDataService dataService, IMessenger messenger)
        //    : base(messenger)
        //{
        //    _DataService = dataService;
        //}
    }
}
