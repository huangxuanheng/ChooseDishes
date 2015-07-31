using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Data;
using IShow.Common.Log;
using IShow.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace IShow.ChooseDishes.ViewModel
{
    public class DishesWaySettingModel : ViewModelBase
    {
        IDishesWayDataService _DataService;
        #region Observable
        string _Code;
        public string Code
        {
            get
            {
                return _Code;
            }
            set
            {
                Set("Code", ref _Code, value);
            }
        }

        string _DischesWayType;
        public string DischesWayType
        {
            get
            {
                return _DischesWayType;
            }
            set
            {
                Set("DischesWayType", ref _DischesWayType, value);
            }
        }
        string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                Set("Name", ref _Name, value);
            }
        }
        string _PingYing;
        public string PingYing
        {
            get
            {
                return _PingYing;
            }
            set
            {
                Set("PingYing", ref _PingYing, value);
            }
        }
        string _AddPrice;
        public string AddPrice
        {
            get
            {
                return _AddPrice;
            }
            set
            {
                Set("AddPrice", ref _AddPrice, value);
            }
        }
        string _AddPriceByNum;
        public string AddPriceByNum
        {
            get
            {
                return _AddPriceByNum;
            }
            set
            {
                Set("AddPriceByNum", ref _AddPriceByNum, value);
            }
        }
        #endregion Observable

        #region Command
        RelayCommand _Save;
        public RelayCommand Save
        {
            get
            {
                return _Save ?? (_Save = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    if (string.IsNullOrEmpty(Code))
                    {
                        MessageBox.Show("编码不能为空");
                        return;
                    }
                    if (string.IsNullOrEmpty(Name))
                    {
                        MessageBox.Show("做法说明不能为空");
                        return;
                    }

                    //保存做法，调用数据持久层方法，将数据保存到数据库中
                    SaveDishesWay();
                    Logger.Log("保存做法", LOGSEVERITY.Debug);
                    MessageBox.Show("保存成功");
                    Logger.LogMethodExit();
                }));
            }
        }
        RelayCommand _Continue;
        public RelayCommand Continue
        {
            get
            {
                return _Continue ?? (_Continue = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    //继续添加做法
                    MessageBox.Show("数据有改动，是否保存数据？","惠员管理系统",MessageBoxButton.YesNoCancel,MessageBoxImage.Question);
                    //1.提示用户是否保存数据
                    // *是：先查询数据库中是否有条记录，如果有，则弹出对话框提示，否则保存数据
                    // *否：重新刷新界面，把原有的数据清除，只留下做法类型
                    Logger.Log("继续添加做法", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }
        
        #endregion Command
        private void SaveDishesWay()
        {
            DischesWay dw = new DischesWay();
            try
            {
                dw.AddPrice = Double.Parse(AddPrice);
            }
            catch (Exception)
            {
                MessageBox.Show("加价只能输入数字!!!");
                return;
            }
            if (AddPriceByNum.Equals("False"))
            {
                MessageBox.Show("按数量加价" + AddPriceByNum);
                dw.AddPriceByNum = 0;
            }
            else
            {
                MessageBox.Show("按数量加价" + AddPriceByNum);
                dw.AddPriceByNum = 1;
            }

            dw.Code = Int32.Parse(Code);
            dw.CreateBy = 1;
            dw.CreateDatetime = DateTime.Now;
            dw.Deleted = 0;
            //dw.DischesWayId      //自增长
            dw.DischesWayNameId = 2;
            dw.Name = Name;
            dw.PingYing = PingYing;
            dw.Status = 0;
            _DataService.AddDishesWay(dw);
        }
        public DischesWayName DishesWayName
        {
            set;
            get;
        }
        public DishesWaySettingModel(IDishesWayDataService dataService, IMessenger messenger)
            : base(messenger)
        {
            _DataService = dataService;
            //MessageBox.Show("在初始化厨打做法设置");
        }
    }

   
}
