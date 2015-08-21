using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using IShow.Common.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace IShow.ChooseDishes.ViewModel
{
    public class DishesWayFromModel : ViewModelBase
    {

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

        string _DischesWayName;
        public string DischesWayName
        {
            get
            {
                return _DischesWayName;
            }
            set
            {
                Set("DischesWayName", ref _DischesWayName, value);
            }
        }
        string _WayDetail;
        public string WayDetail
        {
            get
            {
                return _WayDetail;
            }
            set
            {
                Set("WayDetail", ref _WayDetail, value);
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
                    if (string.IsNullOrEmpty(WayDetail))
                    {
                        MessageBox.Show("做法说明不能为空");
                        return;
                    }

                    //保存做法，调用数据持久层方法，将数据保存到数据库中
                    if (!string.IsNullOrEmpty(AddPrice))
                    {
                        char[] chs=AddPrice.ToArray();
                        foreach(char i in chs){
                            if (i < 0 || i > 9)
                            {
                                MessageBox.Show("价格不能为字母");
                                return;
                            }
                        }
                    }
                    Logger.Log("保存做法", LOGSEVERITY.Debug);

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
                    MessageBox.Show("继续添加做法");
                    //1.保存数据到数据库
                    //2.重新刷新界面，把原有的数据清除，只留下做法类型
                    Logger.Log("继续添加做法", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }
        
        #endregion Command
    }
}
