using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Model;
using IShow.ChooseDishes.Model.EnumSet;
using IShow.ChooseDishes.Model.Util;
using IShow.ChooseDishes.View.Dishes;
using IShow.Common.Log;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IShow.ChooseDishes.ViewModel
{
    public class MarketTypeViewModel: ViewModelBase
    {
        IMarketTypeDataService _DataService;

        #region Observable
        MarketTypeBean _SelectedItem;
        public MarketTypeBean SelectedItem     //被选中的行
        {
            get
            {
                return _SelectedItem;
            }
            set
            {
                Set("SelectedItem", ref _SelectedItem, value);
            }
        }

        ObservableCollection<MarketTypeBean> _MarketTypeItems;
        public ObservableCollection<MarketTypeBean> MarketTypeItems   //所有的列表集合
        {
            get
            {
                return _MarketTypeItems ?? (_MarketTypeItems = new ObservableCollection<MarketTypeBean>());
            }
            private set { }
        }

        MarketTypeBean _MarketTypeBean;
        public MarketTypeBean MarketTypeBean
        {
            get
            {
                return _MarketTypeBean;
            }
            set
            {
                Set("MarketTypeBean", ref _MarketTypeBean, value);
            }
        }
        #endregion Observable

        #region Command

        RelayCommand _Add;
        public RelayCommand Add
        {
            get
            {
                return _Add ?? (_Add = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();


                    LoaderAddBaseData();
                   
                    MarketTypeSetView = new View.Dishes.MarketTypeSetView();
                    //加载基本数据
                    
                    //隐藏上一条下一条等的控件
                    MarketTypeSetView.GridRecord.Visibility = Visibility.Hidden;
                    MarketTypeSetView.Continue.Visibility = Visibility.Visible;
                    MarketTypeSetView.ShowDialog();
                   
                    Logger.Log("新增市别", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }

        private void LoaderAddBaseData()
        {
            new Task(() =>
            {
                List<MarketType> mts = _DataService.FindAllMarketType();
                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    MarketTypeBean = new Model.MarketTypeBean();
                    if (mts != null)
                    {
                        MarketType mt = mts.ElementAt(mts.Count - 1);
                        if (mt.Id + 1 < 10)
                        {
                            _MarketTypeBean.Code = "0" + (mt.Id + 1);
                        }
                        else if (mt.Id + 1 < 100)
                        {
                            _MarketTypeBean.Code = "" + (mt.Id + 1);
                        }
                    }
                    else
                    {
                        _MarketTypeBean.Code = "01";
                    }
                    MarketTypeBean.StartTime = DateTime.Now;
                    MarketTypeSetView.IsTextBoxTextChanged = false;
                });
               
            }).Start();
           
        }
        RelayCommand _Update;
        public RelayCommand Update
        {
            get
            {
                return _Update ?? (_Update = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    ShowUpdateDetail();
                    Logger.Log("修改市别", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                    return;
                }));
            }
        }
        /// <summary>
        /// 显示修改详细页面
        /// </summary>
        public void ShowUpdateDetail()
        {
            if (SelectedItem == null)
            {
                MessageBox.Show("请选择要修改的市别！");
                return;
            }
            //MessageBox.Show("时间"+DateTime.Now.ToLongTimeString());
            MarketTypeBean =MarketTypeBean.CreateMarketTypeBean(SelectedItem);

            MarketTypeSetView = new View.Dishes.MarketTypeSetView();
            //隐藏上一条下一条等的控件
            MarketTypeSetView.GridRecord.Visibility = Visibility.Visible;
            MarketTypeSetView.Continue.Visibility = Visibility.Hidden;
            MarketTypeSetView.ShowDialog();
        }
        RelayCommand _Deleted;
        public RelayCommand Deleted
        {
            get
            {
                return _Deleted ?? (_Deleted = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    if (SelectedItem == null)
                    {
                        MessageBox.Show("请选择要删除的市别！");
                        return;
                    }
                    MarketType mt = MarketTypeBean.CreateMarketType(SelectedItem);
                    mt.Deleted = 1;
                    new Task(() =>
                    {
                        MarketType m = _DataService.UpdateMarketType(mt);
                        DispatcherHelper.CheckBeginInvokeOnUI(() =>
                        {
                            if (m != null)
                            {
                                //修改状态成功
                                InitMarketTypeData();
                            }
                            else
                            {
                                MessageBox.Show("删除失败！");
                            }
                        });
                       
                    }).Start();
                   
                    Logger.Log("删除市别", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }
        RelayCommand _Save;
        public RelayCommand Save   //保存
        {
            get
            {
                return _Save ?? (_Save = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    if (MarketTypeSetView.Continue.IsVisible)
                    {
                        //新增
                        SaveMarketType(ButtonEventType.ADD);
                    }
                    else
                    {
                        //修改
                        SaveMarketType(ButtonEventType.UPDATE);
                    }
                    
                    Logger.Log("保存市别", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }

        RelayCommand _Continue;
        public RelayCommand Continue    //继续编辑
        {
            get
            {
                return _Continue ?? (_Continue = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    Logger.Log("继续编辑市别", LOGSEVERITY.Debug);
                    SaveMarketType(ButtonEventType.DEFAULT);
                    Logger.LogMethodExit();
                }));
            }
        }

        RelayCommand _PreviousRecord;
        public RelayCommand PreviousRecord    //上一条记录
        {
            get
            {
                return _PreviousRecord ?? (_PreviousRecord = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    SwitchSelectedItem(0);
                    Logger.Log("查看上一条市别记录", LOGSEVERITY.Debug);
                    Logger.LogMethodExit();
                }));
            }
        }
        RelayCommand _NextRecord;
        public RelayCommand NextRecord    //下一条记录
        {
            get
            {
                return _NextRecord ?? (_NextRecord = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    SwitchSelectedItem(1);
                    Logger.Log("查看下一条市别记录", LOGSEVERITY.Debug);
                    Logger.LogMethodExit();
                }));
            }
        }
        #endregion Command

        public void CheckedTextChanged()
        {
            if (MarketTypeSetView.IsTextBoxTextChanged)
            {
                //文本框中有数据有变动，弹出提示
                MessageBoxResult result = MessageBox.Show("数据有变动，是否保存？", "提示", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                   
                    if (MarketTypeSetView.Continue.IsVisible)
                    {   
                        SaveMarketType(ButtonEventType.ADD);
                        LoaderAddBaseData();
                    }
                    else
                    {
                        SaveMarketType(ButtonEventType.UPDATE);
                    }  
                }
                else if (result == MessageBoxResult.No)
                {
                    LoaderAddBaseData();
                    return;
                }
            }
            else
            {
                if (MarketTypeSetView.Continue.IsVisible)
                {
                    LoaderAddBaseData();
                }
                
            }
        }
        /// <summary>
        /// 保存市别
        /// <para>默认表示保存新增，1表示保存修改，3表示点击继续按钮</para>
        /// </summary>
        /// <param name="type"></param>
        private void SaveMarketType(ButtonEventType type)
        {
            if (type.Equals(ButtonEventType.DEFAULT))  //3
            {
                if (CommonUtil.IsNullOrEmpty(MarketTypeBean.Name))
                {
                    LoaderAddBaseData();
                    return;
                }
                
            }
            if (CommonUtil.IsNullOrEmpty(MarketTypeBean.Name))
            {
                MessageBox.Show("市别名称不能为空字符!");
                return;
            }
            if (CommonUtil.IsNullOrEmpty(MarketTypeBean.ShowStartTime))
            {
                MessageBox.Show("开始时间不能为空字符!");
                return;
            }
            if (!CommonUtil.IsCorrectFormatTime(MarketTypeBean.ShowStartTime))
            {
                MessageBox.Show("开始时间格式不正确,请核实!");
                return;
            }
            if (type.Equals(ButtonEventType.DEFAULT))  //3
            {
                CheckedTextChanged();  //数据有变动
                return;
            }
            
            MarketType temp=null;
            MarketType mt=MarketTypeBean.CreateMarketType(MarketTypeBean);
            
            switch (type)
            {
                default:
                    //新增
                    if (type.Equals( ButtonEventType.DEFAULT))
                    {
                        if (string.IsNullOrEmpty(mt.Name))
                        {
                            return;
                        }
                    }
                    MarketTypeBean.StartTime = DateTime.Today;
                    temp=_DataService.AddMarketType(mt);
                    break;
                case ButtonEventType.UPDATE:
                    //修改
                    mt.UpdateDatetime = DateTime.Now;
                    temp = _DataService.UpdateMarketType(mt);
                    break;
            }
            if (temp != null)
            {
                MarketTypeSetView.IsTextBoxTextChanged = false;
                MessageBox.Show("保存成功");
                InitMarketTypeData();
            }
            else
            {
                MessageBox.Show("由于系统原因保存失败");
            }
        }
        private int currentItem;
        /// <summary>
        /// 切换选择的条目，主要用于查看上一条和下一条记录
        /// 0是上一条记录，1是下一条记录
        /// </summary>
        /// <param name="type"></param>
        private void SwitchSelectedItem(int type)
        {
            CheckedTextChanged();
            switch (type)
            {
                case 0:
                    currentItem=MarketTypeItems.IndexOf(SelectedItem)-1;
                    break;
                case 1:
                    currentItem = MarketTypeItems.IndexOf(SelectedItem) + 1;
                    break;
            }
            if (currentItem < 0)
            {
                MessageBox.Show("已经是第一条记录了！");
                currentItem = 0;
                return;
            }
            if (currentItem > MarketTypeItems.Count - 1)
            {
                MessageBox.Show("已经是最后一条记录了！");
                currentItem = MarketTypeItems.Count - 1;
                return;
            }
            SelectedItem = MarketTypeItems.ElementAt(currentItem);
            MarketTypeBean =MarketTypeBean.CreateMarketTypeBean( SelectedItem);
            MarketTypeSetView.IsTextBoxTextChanged = false;
        }


        public MarketTypeSetView MarketTypeSetView { set; get; }

        public MarketTypeViewModel(IMarketTypeDataService dataService, IMessenger messenger)
            : base(messenger)
        {
            _DataService = dataService;
            InitMarketTypeData();
        }
        private bool Selected = false;
       
        private void InitMarketTypeData()
        {

            new Task(() =>
            {
                List<MarketType> mts = _DataService.FindAllMarketTypeByDeletedStatus();
                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    MarketTypeItems.Clear();
                    if (mts != null)
                    {
                        for (int x = 0; x < mts.Count; x++)
                        {
                            var mt = mts.ElementAt(x);
                            _MarketTypeBean = new Model.MarketTypeBean();
                            _MarketTypeBean.LineNumber = MarketTypeItems.Count + 1;
                            if (mt.Id < 10)
                            {
                                _MarketTypeBean.Code = "0"+mt.Id;
                            }
                            else if (mt.Id < 100)
                            {
                                _MarketTypeBean.Code = "" + mt.Id;
                            }
                            _MarketTypeBean.CreateMarketTypeBean(mt);
                            if (!Selected)
                            {
                                _SelectedItem = _MarketTypeBean;
                                Selected = true;
                            }
                            else if (_SelectedItem != null && _SelectedItem.Id == _MarketTypeBean.Id)
                            {
                                _SelectedItem = _MarketTypeBean;
                            }
                            MarketTypeItems.Add(_MarketTypeBean);
                        }
                    }
                });
                
            }).Start();
           
        }
    }
}
