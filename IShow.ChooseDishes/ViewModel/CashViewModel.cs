using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Model;
using IShow.ChooseDishes.Model.Util;
using IShow.ChooseDishes.View.CashWindow;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;

namespace IShow.ChooseDishes.ViewModel
{
    public class CashViewModel : ViewModelBase
    {
        IChooseDishesDataService _DataService;

        #region 

        CashTypeBean _CashTypeBean;
        public CashTypeBean CashTypeBean
        {
            get
            {
                return _CashTypeBean;
            }
            set
            {
                Set("CashTypeBean", ref _CashTypeBean, value);
            }
        }

        RelayCommand _AddCash;
        public RelayCommand AddCash
        {
            get
            {
                return _AddCash ?? (_AddCash = new RelayCommand(() =>
                {
                   _CashTypeBean.CreateDatetime = DateTime.Now;
                   CashType ct = SaveCashType();
                   if (ct != null)
                   {
                       LoadCashTypeBase(_CashBaseTypeIdLast);
                       _CashTypeBean = new CashTypeBean();
                       act.Close();
                   }
                  
                }));
            }
        }
        //保存数据,并继续新增
        RelayCommand _JiXuFun;
        public RelayCommand JiXuFun
        {
            get
            {
                return _JiXuFun ?? (_JiXuFun = new RelayCommand(() =>
                {
                    _CashTypeBean.CreateDatetime = DateTime.Now;
                    CashType ct = SaveCashType();
                    if (ct != null)
                    {
                        LoadCashTypeBase(_CashBaseTypeIdLast);
                        _CashTypeBean = new CashTypeBean();
                        CashTypeBean.CashBaseTypeId = _CashBaseTypeIdLast;
                    }
                    
                }));
            }
        }
        RelayCommand _UpdateCash;
        UpdateCashType uct { get; set; }
        public RelayCommand UpdateCash
        {
            get
            {
                return _UpdateCash ?? (_UpdateCash = new RelayCommand(() =>
                {
                    if (_SelectedCashBase != null)
                    {
                        uct = new UpdateCashType();
                        if (_CashBaseTypeIdLast == 4)//代金券
                        {
                            uct.RateViewValue.Visibility = System.Windows.Visibility.Hidden;
                            uct.RateView.Visibility = System.Windows.Visibility.Hidden;
                            uct.KeepRechargeViewValue.Visibility = System.Windows.Visibility.Hidden;
                            uct.KeepRechargeView.Visibility = System.Windows.Visibility.Hidden;
                        }
                        else if (_CashBaseTypeIdLast == 5)//折让
                        {
                            uct.IsPrivilegeView.Visibility = System.Windows.Visibility.Visible;
                            uct.AllDiscountView.Visibility = System.Windows.Visibility.Visible;
                        }
                        uct.Show();
                    }
                    else 
                    {
                        MessageBox.Show("请在右边列表中选择付款方式类型!");
                    }
                }));
            }
        }
        RelayCommand _UpdateCashValue;
        public RelayCommand UpdateCashValue
        {
            get 
            {
                return _UpdateCashValue ?? (_UpdateCashValue = new RelayCommand(() => {
                    //组合键方式
                    if (!CommonUtil.RegexpNumber(_SelectedCashBase.Keys))
                    {
                        MessageBox.Show("快捷键格式为 A  或者 A-Z ");
                        return;
                    }
                    var newCashType = _DataService.updateCashType(_SelectedCashBase.CreateCashType(_SelectedCashBase));
                    if (newCashType != null)
                    {
                        LoadCashTypeBase(_CashBaseTypeIdLast);
                        uct.Close();
                    }
                    else
                    {
                        MessageBox.Show("修改操作失败! 有可能 快捷键有重复 ! 请检查!");
                    }
                }));
            }
        }

        RelayCommand _DeleteCash;
        public RelayCommand DeleteCash
        {
            get
            {
                return _DeleteCash ?? (_DeleteCash = new RelayCommand(() =>
                {
                    if (_SelectedCashBase!=null)
                    {
                        bool flag = _DataService.deleteCashType(_SelectedCashBase.Id);
                        if (flag)
                        {
                            LoadCashTypeBase(_CashBaseTypeIdLast);
                        }
                        else
                        {
                            MessageBox.Show("删除操作失败!");
                        }
                    }
                }));
            }
        }

        bool selectCBT = false;
        RelayCommand<int> _CashBaseTypeId;
        public RelayCommand<int> CashBaseTypeId
        {
            get
            {
                return _CashBaseTypeId ?? (_CashBaseTypeId = new RelayCommand<int>(num =>
                {
                    selectCBT = true;
                    _CashBaseTypeIdLast = num;
                    LoadCashTypeBase(_CashBaseTypeIdLast);
        
                }));
            }
        }
        int _CashBaseTypeIdLast;
        public int CashBaseTypeIdLast
        {
            get
            {
                return _CashBaseTypeIdLast;
            }
            set
            {
                Set("CashBaseTypeIdLast", ref _CashBaseTypeIdLast, value);
            }
        }
        AddCashType act {get;set;}

        RelayCommand _OpenSaveWin;
        public RelayCommand OpenSaveWin
        { 
            get
            {
                return _OpenSaveWin ?? (_OpenSaveWin=new RelayCommand(()=>{
                    if (selectCBT)
                    {
                        _CashTypeBean = new CashTypeBean();
                        _CashTypeBean.CashBaseTypeId = CashBaseTypeIdLast;
                        act = new AddCashType();
                        _CashTypeBean.CashBaseTypeName = _CashTypeBean.TiQuName(CashBaseTypeIdLast);
                        if (_CashBaseTypeIdLast==2)//会员卡
                        {
                            MessageBox.Show("会员卡类型的付款方式不能自定义操作类型!");
                            return;
                        }
                        else if (_CashBaseTypeIdLast == 4)//代金券
                        {
                            act.ReceptionUseingView.IsChecked = true;
                            act.RateViewValue.Visibility = System.Windows.Visibility.Hidden;
                            act.RateView.Visibility = System.Windows.Visibility.Hidden;
                            act.KeepRechargeViewValue.Visibility = System.Windows.Visibility.Hidden;
                            act.KeepRechargeView.Visibility = System.Windows.Visibility.Hidden;
                        }
                        else if (_CashBaseTypeIdLast == 5)//折让
                        {
                            act.ReceptionUseingView.IsChecked = true;
                            act.IsPrivilegeView.Visibility = System.Windows.Visibility.Visible;
                            act.AllDiscountView.Visibility = System.Windows.Visibility.Visible;
                        }
                        else 
                        {
                            act.IsPaidView.IsChecked = true;
                            act.ReceptionUseingView.IsChecked = true;
                        }
                        act.Show();
                    }
                    else {
                        MessageBox.Show("请在左边列表中选择付款方式类型!");
                    }
            
                }));
            }

        }

        bool _IsNotEdit;
        public bool IsNotEdit
        {
            get
            {
                return _IsNotEdit;
            }
            set
            {
                Set("IsNotEdit", ref _IsNotEdit, value);
            }
        }
        

        //选择一行
        CashTypeBean _SelectedCashBase;
        public CashTypeBean SelectedCashBase
        {
            get
            {
                return _SelectedCashBase;
            }
            set
            {
                Set("SelectedCashBase", ref _SelectedCashBase, value);
            }
        }
        ObservableCollection<CashTypeBean> _CashTypes = new ObservableCollection<CashTypeBean>();
        public ObservableCollection<CashTypeBean> CashTypes
        {
            get
            {
                return _CashTypes;
            }
            set
            {
                Set("CashTypes", ref _CashTypes, value);
            }
        }

        public CashType SaveCashType()
        {
            //数据验证
            if (_CashTypeBean.Code==null||_CashTypeBean.Code.Length > 10 || _CashTypeBean.Code.Length < 1) 
            {
                MessageBox.Show("编号长度必须在1到10位之间!");
                return null;
            }
            //收银方式
            if (_CashTypeBean.Name == null || _CashTypeBean.Name.Length > 12 || _CashTypeBean.Name.Length < 2)
            {
                MessageBox.Show("编号长度必须在1到20位之间!");
                return null;
            }
            //组合键方式
            if (!CommonUtil.RegexpNumber(_CashTypeBean.Keys))
            {
                MessageBox.Show("快捷键格式为 A  或者 A-Z ");
                return null;
            }
            CashType cashType  =  _DataService.addCashType(_CashTypeBean.CreateCashType(_CashTypeBean));
            if (cashType == null) {
                MessageBox.Show(" 新增失败 , 可能 快捷键有冲突 !");
            }
            return cashType;
        }
        public void LoadCashTypeBase(int CashBaseTypeId)
        {
            List<CashType> array = _DataService.findCashType(CashBaseTypeId);
            
            CashTypes.Clear();
            for (int i = 0; i < array.Count; i++)
            {
                CashTypes.Add((new CashTypeBean()).CreateCashTypeBean(array[i]));
            }
        }


        #endregion 

        public CashViewModel(IChooseDishesDataService dataService, IMessenger messenger)
            : base(messenger)
        {
            _DataService = dataService;
            IsNotEdit = true;
            //LoadCashTypeBase(0);
            
        }
    }
}
