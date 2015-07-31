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
    public class TakeoutOrderViewModel : ViewModelBase
    {
        #region Observable
        string _OrderPeople;   //订餐人姓名
        public string OrderPeople
        {
            get
            {
                return _OrderPeople;
            }
            set
            {
                Set("OrderPeople", ref _OrderPeople, value);
            }
        }

        string _Telephone;  //订餐人电话
        public string Telephone
        {
            get
            {
                return _Telephone;
            }
            set
            {
                Set("Telephone", ref _Telephone, value);
            }
        }
        string _Address;   //订餐人地址
        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                Set("Address", ref _Address, value);
            }
        }
        string _OrderId;   //订单号
        public string OrderId
        {
            get
            {
                return _OrderId;
            }
            set
            {
                Set("OrderId", ref _OrderId, value);
            }
        }
        string _Consume;   //消费金额
        public string Consume
        {
            get
            {
                return _Consume;
            }
            set
            {
                Set("Consume", ref _Consume, value);
            }
        }
        string _AdvanceAmout;   //预支金额
        public string AdvanceAmout
        {
            get
            {
                return _AdvanceAmout;
            }
            set
            {
                Set("AdvanceAmout", ref _AdvanceAmout, value);
            }
        }

        string _DeliveryManNum;   //送餐人
        public string DeliveryManNum
        {
            get
            {
                return _DeliveryManNum;
            }
            set
            {
                Set("DeliveryManNum", ref _DeliveryManNum, value);
            }
        }
        #endregion Observable

        #region Command
        RelayCommand _Commit;
        public RelayCommand Commit
        {
            get
            {
                return _Commit ?? (_Commit = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();

                    MessageBox.Show("确定外卖落单");
                    //1.将订餐人信息插入到外卖客户信息表中
                    //2.将订单信息插入到订单表中
                    //3.在厨房打印出厨打单
                    Logger.Log("确定外卖落单", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }
        RelayCommand _DeliveryMan;
        public RelayCommand DeliveryMan
        {
            get
            {
                return _DeliveryMan ?? (_DeliveryMan = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    //指定送餐人
                    MessageBox.Show("指定送餐人");
                    //1.保存数据到界面
                    
                    Logger.Log("指定送餐人", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }
        RelayCommand _NewCustomern;
        public RelayCommand NewCustomer
        {
            get
            {
                return _NewCustomern ?? (_NewCustomern = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    //新顾客，重置界面
                    MessageBox.Show("新顾客，重置界面");
                    
                    Logger.Log("新顾客，重置界面", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }
        #endregion Command
    }
}
