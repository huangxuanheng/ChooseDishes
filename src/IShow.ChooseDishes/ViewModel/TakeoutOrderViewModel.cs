using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Security;
using IShow.ChooseDishes.View.TakeOut;
using IShow.Common.Log;
using IShow.Service.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace IShow.ChooseDishes.ViewModel
{
    public class TakeoutOrderViewModel : ViewModelBase
    {
        ITakeoutOrderDataService _DataService;
        public int InputParmeter = -1;
        #region Observable
        /**--------------------------外卖点餐页面相关属性定义----------------------------------*/
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

        string _ContactNumber;  //订餐人电话
        public string ContactNumber
        {
            get
            {
                return _ContactNumber;
            }
            set
            {
                Set("ContactNumber", ref _ContactNumber, value);
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
        string _AdvanceMoney;   //预支金额
        public string AdvanceMoney
        {
            get
            {
                return _AdvanceMoney;
            }
            set
            {
                Set("AdvanceMoney", ref _AdvanceMoney, value);
            }
        }

        string _DeliveryMan;   //送餐人
        public string DeliveryMan
        {
            get
            {
                return _DeliveryMan;
            }
            set
            {
                Set("DeliveryMan", ref _DeliveryMan, value);
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
        string _ConsumeMoney;   //消费金额
        public string ConsumeMoney
        {
            get
            {
                return _ConsumeMoney;
            }
            set
            {
                Set("ConsumeMoney", ref _ConsumeMoney, value);
            }
        }
        string _DiscountMoney;   //折扣金额
        public string DiscountMoney
        {
            get
            {
                return _DiscountMoney;
            }
            set
            {
                Set("DiscountMoney", ref _DiscountMoney, value);
            }
        }
        string _GiftMoney;   //赠送金额
        public string GiftMoney
        {
            get
            {
                return _GiftMoney;
            }
            set
            {
                Set("GiftMoney", ref _GiftMoney, value);
            }
        }
        string _WipeZeroMoney;   //抹零金额
        public string WipeZeroMoney
        {
            get
            {
                return _WipeZeroMoney;
            }
            set
            {
                Set("WipeZeroMoney", ref _WipeZeroMoney, value);
            }
        }
        string _AccountsMoney;   //应收金额
        public string AccountsMoney
        {
            get
            {
                return _AccountsMoney;
            }
            set
            {
                Set("AccountsMoney", ref _AccountsMoney, value);
            }
        }
        /**----------------------------------外卖点餐属性定义结束-------------------------------------------*/



        string _ClientNum;   //外卖客户编号
        public string ClientNum
        {
            get
            {


                return _ClientNum;
            }
            set
            {
                Set("ClientNum", ref _ClientNum, value);
            }
        }
        string _ClientName;   //外卖客户姓名
        public string ClientName
        {
            get
            {


                return _ClientName;
            }
            set
            {
                Set("ClientName", ref _ClientName, value);
            }
        }
        string _ClientContact;   //外卖客户联系电话
        public string ClientContact
        {
            get
            {


                return _ClientContact;
            }
            set
            {
                Set("ClientContact", ref _ClientContact, value);
            }
        }
        string _ClientPhone;   //外卖客户手机号码
        public string ClientPhone
        {
            get
            {


                return _ClientPhone;
            }
            set
            {
                Set("ClientPhone", ref _ClientPhone, value);
            }
        }
        string _ClientAddress;   //外卖客户地址
        public string ClientAddress
        {
            get
            {


                return _ClientAddress;
            }
            set
            {
                Set("ClientAddress", ref _ClientAddress, value);
            }
        }

        string _InputNumber;   //外卖客户地址
        public string InputNumber
        {
            get
            {


                return _InputNumber;
            }
            set
            {
                Set("InputNumber", ref _InputNumber, value);
            }
        }

        //TextBox _ContactNumberName;   //联系号码编辑控件
        //public TextBox ContactNumberName
        //{
        //    get
        //    {


        //        return _ContactNumberName;
        //    }
        //    set
        //    {

        //        Set("ContactNumberName", ref _ContactNumberName, value);
        //    }
        //}

        ObservableCollection<ClientInfoItem> _ClientInfoItems;
        public ObservableCollection<ClientInfoItem> ClientInfoItems   //外卖订餐人信息列表
        {
            get
            {
                return _ClientInfoItems ?? (_ClientInfoItems = new ObservableCollection<ClientInfoItem>());
            }
            set
            {
                this.ClientInfoItems = value;
                Set("ClientInfoItems", ref _ClientInfoItems, value);
            }
        }

        ClientInfoItem _ClientSelectedItem;
        public ClientInfoItem ClientSelectedItem   //外卖订餐人信息列表被选择的对象
        {
            get
            {
                return _ClientSelectedItem;
            }
            set
            {
                Set("ClientSelectedItem", ref _ClientSelectedItem, value);
            }
        }
        #endregion Observable



        #region Command
        /**------------------------外卖点餐相关事件绑定定义-----------------------------*/
        RelayCommand<string> _Input;
        public RelayCommand<string> Input   //接收键盘录入的信息
        {
            get
            {
                return _Input ?? (_Input = new RelayCommand<string>(num =>
                {
                    //if (ContactNumberName.Focus())
                    //{
                    //    MessageBox.Show("输入电话号码了");
                    //}
                    //Password += num.ToString();
                    TakeoutOrderWindow t=TakeoutOrderWindow.getInstance();
                    MessageBox.Show("电话号码"+t.Phone.IsTabStop+"="+t.OrderName.IsTabStop);
                    if (t.Phone.IsTabStop)
                    {
                        MessageBox.Show("输入电话号码");
                    }
                    else if (t.OrderName.IsFocused)
                    {
                        MessageBox.Show("输入订餐人姓名");
                    }
                    else if (t.Address.IsFocused)
                    {
                        MessageBox.Show("输入地址");
                    }
                }));
            }
        }
        RelayCommand _Deleted;
        public RelayCommand Deleted   //删除控件中的数据
        {
            get
            {
                return _Deleted ?? (_Deleted = new RelayCommand(() =>
                {
                    //Password = Password.Substring(0, Password.Length - 1);
                },
                    () =>
                    {
                        return !string.IsNullOrEmpty(null);
                    }));
            }
        }

        RelayCommand _SelectedOrderPeople;
        public RelayCommand SelectedOrderPeople    //选择联系人
        {
            get
            {
                return _SelectedOrderPeople ?? (_SelectedOrderPeople = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();

                    //MessageBox.Show("选择联系人");
                    //弹出外卖人记录查询页面
                    TakeOutClientInfoWindow toc = new TakeOutClientInfoWindow();
                    toc.ShowDialog();
                    Logger.Log("选择联系人", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }

        RelayCommand _HandWrite;
        public RelayCommand HandWrite    //手写输入页面
        {
            get
            {
                return _HandWrite ?? (_HandWrite = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();

                    MessageBox.Show("手写输入页面");

                    Logger.Log("手写输入页面", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }


        RelayCommand _Commit;
        public RelayCommand Commit    //确定落单提交
        {
            get
            {
                return _Commit ?? (_Commit = new RelayCommand(() =>
                {
                    // MessageBox.Show(ContactNumber + "=" + OrderPeople + "==" + Address);
                    Logger.LogMethodEntry();
                    new Task(
                        () =>
                        {
                            //提交订单
                            CommitOrder();
                        }
                        ).Start();
                    Logger.Log("确定外卖落单", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }
        
        RelayCommand _DeliveryManButton;
        public RelayCommand DeliveryManButton    //选择送餐人按钮
        {
            get
            {
                return _DeliveryManButton ?? (_DeliveryManButton = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    //指定送餐人
                   // MessageBox.Show("指定送餐人");
                    //1.保存数据到界面
                    TakeoutSelectDeliverman ts = new TakeoutSelectDeliverman();
                    ts.ShowDialog();
                    Logger.Log("指定送餐人", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }
        RelayCommand _NewCustomer;
        public RelayCommand NewCustomer   //新顾客
        {
            get
            {
                return _NewCustomer ?? (_NewCustomer = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    //新顾客，重置界面
                    //MessageBox.Show("新顾客，重置界面");
                    ResetOrderPeopleInfo();
                    Logger.Log("新顾客，重置界面", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }

        /**-------------------------------外卖点餐相关事件绑定定义结束-----------------------------------------------*/



        /**-----------------------------------选择外卖人信息相关事件绑定定义-------------------------------*/
        RelayCommand _FindNumber;
        public RelayCommand FindNumber   //根据已经存有的外卖人信息查找外卖客户
        {
            get
            {
                return _FindNumber ?? (_FindNumber = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    //输入号码后，根据号码进行模糊查找客户信息
                    //MessageBox.Show("选择订餐人");
                   LoaderTakeoutClientInfoListByInputNumber();
                    
                    Logger.Log("根据号码查找客户信息", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }
        

        RelayCommand _ClientInfoCommit;
        public RelayCommand ClientInfoCommit   //选择好客户后，确定选择客户到外卖点餐页面中
        {
            get
            {
                return _ClientInfoCommit ?? (_ClientInfoCommit = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    //选择客户，把客户带给外卖点餐页面的对应客户信息
                   // MessageBox.Show("把客户带给外卖点餐页面的对应客户信息");
                    if (ClientSelectedItem != null)
                    {
                        //表示已经选择好了订餐人,将订餐人信息赋值给上一级页面对应的属性，关闭当前页面
                        ContactNumber = ClientSelectedItem.ClientContact;
                        OrderPeople = ClientSelectedItem.ClientName;
                        Address = ClientSelectedItem.ClientAddress;
                        //关闭当前页面
                        TakeOutClientInfoWindow.CloseWindow();
                    }
                    else
                    {
                        MessageBox.Show("请选择订餐人！");
                    }
                    Logger.Log("把客户带给外卖点餐页面的对应客户信息", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }
        /**-----------------------------------选择外卖人信息相关事件绑定定义结束-------------------------------*/
        #endregion Command
        /**根据输入的员工编号查找员工*/
        public void LoaderPersonnelByInputNumber()
        {
            //读取数据库员工信息表，列出员工
            MessageBox.Show("根据编码过滤员工");
        }
        /**列出所有员工*/
        public void loaderAllPersonnel()
        {
            //查询员工数据库
            TakeoutSelectDeliverman.getInstance().initGrid(); 
        }
       
        //确定落单
        private void CommitOrder()
        {
            if (string.IsNullOrEmpty(ContactNumber))
            {
                MessageBox.Show("请填写联系电话");
                return;
            }
            if (string.IsNullOrEmpty(OrderPeople))
            {
                MessageBox.Show("请填写或者选择订餐人");
                return;
            }
            if (string.IsNullOrEmpty(Address))
            {
                MessageBox.Show("请填写订餐人地址");
                return;
            }
            bool flag = false;
            //1.将订餐人信息插入到外卖客户信息表中
            TakeoutClientInfo info = _DataService.FindTakeoutClientByTelephone(ContactNumber);
            if (info == null)
            {
                info = new TakeoutClientInfo()
                {
                    OrderPeopleId = new Random().Next(1000) + 1,
                    Order_people = OrderPeople,
                    Telephone = ContactNumber,
                    Address = Address,
                    Create_by = SubjectUtils.GetAuthenticationId(),     //操作人id
                    Create_datetime = DateTime.Now,
                    Status = 0,
                    Deleted = 0
                };

                flag = _DataService.AddTakeoutClientInfo(info);
            }
            else
            {
                info.Order_people = OrderPeople;
                info.Telephone = ContactNumber;
                info.Address = Address;
                info.Status = 0;
                info.Deleted = 0;
                info.Update_by = 0;    //操作人id
                info.Update_datetime = DateTime.Now;
                flag = _DataService.UpdateTakeoutClientInfo(info);
            }
            if (flag)
            {
                TakeoutOrder to = new TakeoutOrder();
                to.OrderPeopleId = info.OrderPeopleId;
                to.OrderId = 1222;   //订单号，去订单中查询获取
                to.DeliveryManNum = DeliveryMan;    //需要去员工数据库查找确定
                to.Num = "Q000";
                to.AdvanceAmount = 0;
                to.DeliverTime = DateTime.Now;    //送出时指定
                to.SendTime = DateTime.Now;
                to.Status = 0;     //0表示未送出状态，1表示在送出状态，2表示送达未签收状态，3.送达已签收状态
                to.Deleted = 0;
                to.CreateBy = SubjectUtils.GetAuthenticationId();     //操作人id
                to.CreateDatetime = DateTime.Now;
                //2.将订单信息插入到订单表中
                flag = _DataService.AddTakeoutOrder(to);
                if (flag)
                {
                    //关闭所有页面
                    //通知主线程执行关闭操作
                    DispatcherHelper.CheckBeginInvokeOnUI(()=>TakeoutOrderWindow.getInstance().Close());
                    //3.在厨房打印出厨打单
                    return;
                }
            }
            DispatcherHelper.CheckBeginInvokeOnUI(() => MessageBox.Show("外卖单录入失败"));
        }
        //根据输入的电话号码列出所有外卖人的信息
        private void LoaderTakeoutClientInfoListByInputNumber()
        {
            new Task(() =>
            {
                List<TakeoutClientInfo> clientInfos = _DataService.FindTakeoutClientListByTelephone(InputNumber);
                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    if (clientInfos != null)
                    {
                        ClientInfoItems.Clear();
                        for (int x = 0; x < clientInfos.Count; x++)
                        {
                            var info = clientInfos.ElementAt(x);
                            ClientInfoItem item = new ClientInfoItem()
                            {
                                IsMember = false,
                                ClientNum = info.OrderPeopleId.ToString(),
                                ClientAddress = info.Address,
                                ClientName = info.Order_people,
                                ClientContact = info.Telephone,
                                ClientPhone = info.Mobile
                            };
                            ClientInfoItems.Add(item);
                        }
                    }
                    else
                    {
                        MessageBox.Show("没有找到订餐人信息");
                    }
                    InputNumber = null;
                });  
            }).Start();
           
        }
        //重置订餐人信息
        private void ResetOrderPeopleInfo()
        {
            OrderPeople = null;
            ContactNumber = null;
            Address = null;
        }
        public TakeoutOrderViewModel(ITakeoutOrderDataService dataService, IMessenger messenger)
            : base(messenger)
        {
            _DataService = dataService;
        }
    }
    public class ClientInfoItem
    {
        public bool IsMember
        {
            set;
            get;
        }
        public string ClientNum
        {
            set;
            get;
        }
        public string ClientName
        {
            set;
            get;
        }
        public string ClientContact
        {
            set;
            get;
        }
        public string ClientPhone
        {
            set;
            get;
        }
        public string ClientAddress
        {
            set;
            get;
        }
    }
}
