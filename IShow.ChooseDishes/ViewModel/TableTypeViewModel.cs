
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Model.EnumSet;
using IShow.ChooseDishes.Security;
using IShow.ChooseDishes.View.Table;
using IShow.Service;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IShow.ChooseDishes.ViewModel
{
    public class TableTypeViewModel : ViewModelBase
    {
        ITableService TableService;

        TableViewModel tableViewModel = ServiceLocator.Current.GetInstance<TableViewModel>();
        public TableTypeViewModel(ITableService tableService, IMessenger messenger)
            : base(messenger)
        {
            this.TableService = tableService;


        }

        #region Observable

        ObservableCollection<TableTypeTreeNode> _TableTypeTree;

        public ObservableCollection<TableTypeTreeNode> TableTypeTree
        {
            get
            {
                return _TableTypeTree;
            }
            set
            {
                Set("TableTypeTree", ref _TableTypeTree, value);
            }
        }

        int _TableTypeId;
        public int TableTypeId
        {

            get
            {
                return _TableTypeId;
            }
            set
            {
                Set("TableTypeId", ref _TableTypeId, value);
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

        int _Status;
        public int Status
        {

            get
            {
                return _Status;
            }
            set
            {
                Set("Status", ref _Status, value);
            }
        }

        string _PeopleMin;
        public string PeopleMin
        {

            get
            {
                return _PeopleMin;
            }
            set
            {
                Set("PeopleMin", ref _PeopleMin, value);
            }
        }

        string _PeopleMax;
        public string PeopleMax
        {
            get
            {
                return _PeopleMax;
            }
            set
            {
                Set("PeopleMax", ref _PeopleMax, value);
            }
        }

        string _Prefix;
        public string Prefix
        {
            get
            {
                return _Prefix;
            }
            set
            {
                Set("Prefix", ref _Prefix, value);
            }
        }

        PriceType _PriceType;
        public PriceType PriceType
        {

            get
            {
                return _PriceType;
            }
            set
            {
                Set("PriceType", ref _PriceType, value);
            }
        }

        string _ServerfreeNax;
        public string ServerfreeNax
        {

            get
            {
                return _ServerfreeNax;
            }
            set
            {
                Set("ServerfreeNax", ref _ServerfreeNax, value);
            }
        }


        ServerfreeMode _ServerfreeModel;
        public ServerfreeMode ServerfreeModel
        {

            get
            {
                return _ServerfreeModel;
            }
            set
            {
                Set("ServerfreeModel", ref _ServerfreeModel, value);
            }
        }


        ConsumerMode _ConsumerMode;
        public ConsumerMode ConsumerMode
        {

            get
            {
                return _ConsumerMode;
            }
            set
            {
                Set("ConsumerMode", ref _ConsumerMode, value);
            }
        }

        /// <summary>
        /// 低消特殊时段低消方式
        /// </summary>
        ConsumerMode _SpecialConsumerMode;
        public ConsumerMode SpecialConsumerMode
        {

            get
            {
                return _SpecialConsumerMode;
            }
            set
            {
                Set("SpecialConsumerMode", ref _SpecialConsumerMode, value);
            }
        }

        /// <summary>
        /// 服务费特殊时段中服务费计算式
        /// </summary>
        ServerfreeAccountType _SpecailServerfreeAccountType;
        public ServerfreeAccountType SpecailServerfreeAccountType
        {
            get
            {
                return _SpecailServerfreeAccountType;
            }
            set
            {
                Set("SpecailServerfreeAccountType", ref _SpecailServerfreeAccountType, value);
            }
        }


        string _ColorType;
        public string ColorType
        {
            get
            {
                return _ColorType;
            }
            set
            {
                Set("ColorType;", ref _ColorType, value);
            }
        }

        string _Rate;
        public string Rate
        {
            get
            {
                return _Rate;
            }
            set
            {
                Set("Rate", ref _Rate, value);
            }
        }

        string _ServerfreeNum;
        public string ServerfreeNum
        {
            get
            {
                return _ServerfreeNum;
            }
            set
            {
                Set("ServerfreeNum", ref _ServerfreeNum, value);
            }
        }

        ServerfreeAccountType _ServerfreeAccountType;
        public ServerfreeAccountType ServerfreeAccountType
        {
            get
            {
                return _ServerfreeAccountType;
            }
            set
            {
                Set("ServerfreeAccountType", ref _ServerfreeAccountType, value);
            }
        }

        string _CreateBy;
        public string CreateBy
        {

            get
            {
                return _CreateBy;
            }
            set
            {
                Set("CreateBy", ref _CreateBy, value);
            }
        }

        System.DateTime _CreateDatetime;
        public System.DateTime CreateDatetime
        {

            get
            {
                return _CreateDatetime;
            }
            set
            {
                Set("CreateDatetime", ref _CreateDatetime, value);
            }
        }

        string _UpdateBy;
        public string UpdateBy
        {

            get
            {
                return _UpdateBy;
            }
            set
            {
                Set("UpdateBy", ref _UpdateBy, value);
            }
        }

        System.DateTime _UpdateTime;
        public System.DateTime UpdateTime
        {

            get
            {
                return _UpdateTime;
            }
            set
            {
                Set("UpdateTime", ref _UpdateTime, value);
            }
        }

        int _Deleted;
        public int Deleted
        {

            get
            {
                return _Deleted;
            }
            set
            {
                Set("Deleted", ref _Deleted, value);
            }
        }

        AccountType _LowConsCalcType;
        public AccountType LowConsCalcType
        {
            get
            {
                return _LowConsCalcType;
            }
            set
            {
                Set("LowConsCalcType", ref _LowConsCalcType, value);
            }
        }

        AccountType _ServerFeeCalcType;
        public AccountType ServerFeeCalcType
        {
            get
            {
                return _ServerFeeCalcType;
            }
            set
            {
                Set("ServerFeeCalcType", ref _ServerFeeCalcType, value);
            }
        }

        int _ConsumerMoney;
        public int ConsumerMoney
        {
            get
            {
                return _ConsumerMoney;
            }
            set
            {
                Set("ConsumerMoney", ref _ConsumerMoney, value);
            }
        }

        int _CanDiscount;
        public int CanDiscount
        {
            get
            {
                return _CanDiscount;
            }
            set
            {
                Set("CanDiscount", ref _CanDiscount, value);
            }
        }

        int _InLowConsume;
        public int InLowConsume
        {
            get
            {
                return _InLowConsume;
            }
            set
            {
                Set("InLowConsume", ref _InLowConsume, value);
            }
        }

        int _StartUnit;
        public int StartUnit
        {
            get
            {
                return _StartUnit;
            }
            set
            {
                Set("StartUnit", ref _StartUnit, value);
            }
        }

        int _StartMoney;
        public int StartMoney
        {
            get
            {
                return _StartMoney;
            }
            set
            {
                Set("StartMoney", ref _StartMoney, value);
            }
        }

        int _StartGetMoneyTime;
        public int StartGetMoneyTime
        {
            get
            {
                return _StartGetMoneyTime;
            }
            set
            {
                Set("StartGetMoneyTime", ref _StartGetMoneyTime, value);
            }
        }

        int _OutTime;
        public int OutTime
        {
            get
            {
                return _OutTime;
            }
            set
            {
                Set("OutTime", ref _OutTime, value);
            }
        }

        int _OutMoney;
        public int OutMoney
        {
            get
            {
                return _OutMoney;
            }
            set
            {
                Set("OutMoney", ref _OutMoney, value);
            }
        }

        int _OutTimeFree;
        public int OutTimeFree
        {
            get
            {
                return _OutTimeFree;
            }
            set
            {
                Set("OutTimeFree", ref _OutTimeFree, value);
            }
        }

        /// <summary>
        /// 服务费特殊时段列表数据
        /// </summary>
        ObservableCollection<TableTypeDetail> _ServerFeeSpecailPeriods;
        public ObservableCollection<TableTypeDetail> ServerFeeSpecailPeriods
        {
            get
            {
                return _ServerFeeSpecailPeriods;
            }
            set
            {
                Set("ServerFeeSpecailPeriods", ref _ServerFeeSpecailPeriods, value);
            }
        }

        /// <summary>
        /// 服务费特殊时段列表当前选中行
        /// </summary>
        TableTypeDetail _SelectedServerFeePeriod;
        public TableTypeDetail SelectedServerFeePeriod
        {
            get
            {
                return _SelectedServerFeePeriod;
            }
            set
            {
                Set("SelectedServerFeePeriod", ref _SelectedServerFeePeriod, value);
            }
        }

        /// <summary>
        /// 低消特殊时段列表数据
        /// </summary>
        ObservableCollection<TableTypeDetail> _LowConsSpecailPeriods;
        public ObservableCollection<TableTypeDetail> LowConsSpecailPeriods
        {
            get
            {
                return _LowConsSpecailPeriods;
            }
            set
            {
                Set("LowConsSpecailPeriods", ref _LowConsSpecailPeriods, value);
            }
        }

        /// <summary>
        /// 低消特殊时段列表当前选中行
        /// </summary>
        TableTypeDetail _SelectedLowConsPeriod;
        public TableTypeDetail SelectedLowConsPeriod
        {
            get
            {
                return _SelectedLowConsPeriod;
            }
            set
            {
                Set("SelectedLowConsPeriod", ref _SelectedLowConsPeriod, value);
            }
        }

        /// <summary>
        /// 餐桌类型服务费设置
        /// </summary>
        TableTypeDetail _ServerFeeDetail;
        public TableTypeDetail ServerFeeDetail
        {
            get
            {
                return _ServerFeeDetail;
            }
            set
            {
                Set("ServerFeeDetail", ref _ServerFeeDetail, value);
            }
        }

        /// <summary>
        /// 餐桌类型低消设置
        /// </summary>
        TableTypeDetail _LowConsumerDetail;
        public TableTypeDetail LowConsumerDetail
        {
            get
            {
                return _LowConsumerDetail;
            }
            set
            {
                Set("LowConsumerDetail", ref _LowConsumerDetail, value);
            }
        }

        /// <summary>
        /// 低消特殊时段，对应新增特殊时段界面
        /// </summary>
        TableTypeDetail _LowConsSpecialPeriod;
        public TableTypeDetail LowConsSpecialPeriod
        {
            get
            {
                return _LowConsSpecialPeriod;
            }
            set
            {
                Set("LowConsSpecialPeriod", ref _LowConsSpecialPeriod, value);
            }
        }

        /// <summary>
        /// 服务费特殊时段，对应新增特殊时段界面
        /// </summary>
        TableTypeDetail _ServerFeeSpecialPeriod;
        public TableTypeDetail ServerFeeSpecialPeriod
        {
            get
            {
                return _ServerFeeSpecialPeriod;
            }
            set
            {
                Set("ServerFeeSpecialPeriod", ref _ServerFeeSpecialPeriod, value);
            }
        }


        #endregion Observable


        #region 变量

        public Nullable<int> currentTableTypeId;//用于新增特殊时段时记录当前餐桌类型ID

        /// <summary>
        /// 数据类型为低消特殊时段
        /// </summary>
        int DATATYPE_LC = 4;

        /// <summary>
        /// 数据类型为服务费特殊时段
        /// </summary>
        int DATATYPE_SF = 3;

        #endregion

        #region Command
        RelayCommand _SaveType;
        public RelayCommand SaveType
        {
            get
            {
                return _SaveType ?? (_SaveType = new RelayCommand(() =>
                {
                    try
                    {
                        if (currentTableTypeId == null)
                        {
                            currentTableTypeId = SaveTypeMethod();

                            //清空窗口数据
                            ClearWin();
                        }
                        else
                        {
                            UpdateTypeMethod();
                            MessageBox.Show("新增成功！");
                            ClearWin();
                        }

                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("新增失败！");
                    }
                }));
            }
        }

        public int SaveTypeMethod()
        {
            try
            {
                TableType type = new TableType();
                type.Code = Code;
                type.Name = Name;
                type.PeopleMax = Convert.ToInt32(PeopleMax);
                type.PeopleMin = Convert.ToInt32(PeopleMin);
                //type.Prefix = Prefix;
                type.PriceType = (int)PriceType;
                type.ServerfreeModel = (int)ServerfreeModel;
                type.LowConsCalcType = (int)LowConsCalcType;
                type.ServerFeeCalcType = (int)ServerFeeCalcType;
                type.Status = 0;
                type.Deleted = 0;
                type.ColorType = ColorType;
                type.CreateDatetime = DateTime.Now;
                type.CreateBy = SubjectUtils.GetAuthenticationId();
                type.UpdateBy = SubjectUtils.GetAuthenticationId();
                type.UpdateDatetime = DateTime.Now;

                ServerFeeDetail.CreateBy = SubjectUtils.GetAuthenticationId();
                ServerFeeDetail.DataType = 1;
                ServerFeeDetail.ServerfreeAccountType = (int)ServerfreeAccountType;

                LowConsumerDetail.CreateBy = SubjectUtils.GetAuthenticationId();
                LowConsumerDetail.DataType = 2;
                LowConsumerDetail.ConsumerMode = (int)ConsumerMode;

                int tableTypeId = TableService.SaveTableTypeAll(type, ServerFeeDetail, LowConsumerDetail);

                MessageBox.Show("新增成功！");


                //刷新界面上的目录树
                TableViewModel tableModel = ServiceLocator.Current.GetInstance<TableViewModel>();
                _TableTypeTree = tableModel.TableTypeTree;
                TableTypeTreeNode tableTypeTreeNode = new TableTypeTreeNode(type.TableTypeId.ToString(), type.Name, tableModel.TableTypeTree[0], false, null);
                tableTypeTreeNode.Action = tableModel.LoadTableTypeAction;
                tableModel.TableTypeTree[0].Children.Add(tableTypeTreeNode);
                return tableTypeId;
            }
            catch (Exception e)
            {
                throw new ServiceException(e.Message);
            }

        }

        /// <summary>
        /// 清除新增餐桌类型界面信息
        /// </summary>
        public void ClearWin()
        {
            Code = "";
            Name = "";
            PeopleMax = "";
            PeopleMin = "";
            Rate = "";
            Prefix = "";
            ColorType = "";
            ServerfreeNax = "";
            ServerfreeNum = "";
            PriceType = 0;
            ServerfreeAccountType = 0;
            ServerfreeModel = 0;
            ServerFeeCalcType = 0;
            LowConsCalcType = 0;
            ServerFeeDetail = null;
            LowConsumerDetail = null;
            LowConsSpecialPeriod = null;
            ServerFeeSpecialPeriod = null;
            LowConsSpecailPeriods = null;
            ServerFeeSpecailPeriods = null;
            SelectedLowConsPeriod = null;
            SelectedServerFeePeriod = null;
            //currentTableTypeId = null;
        }

        RelayCommand _UpdateType;
        public RelayCommand UpdateType
        {
            get
            {
                return _UpdateType ?? (_UpdateType = new RelayCommand(() =>
                {
                    try
                    {

                        UpdateTypeMethod();
                        MessageBox.Show("修改成功！");
                        ClearWin();
                        TableViewModel tableModel = ServiceLocator.Current.GetInstance<TableViewModel>();
                        tableModel.updateTableType.Close();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("修改失败！");
                        throw e;
                    }

                }));
            }
        }

        public void UpdateTypeMethod()
        {
            try
            {
                TableType type = new TableType();
                type.Code = Code;
                type.Name = Name;
                type.PeopleMax = Convert.ToInt32(PeopleMax);
                type.PeopleMin = Convert.ToInt32(PeopleMin);
                //type.Prefix = Prefix;
                type.PriceType = (int)PriceType;
                type.ServerfreeModel = (int)ServerfreeModel;
                type.LowConsCalcType = (int)LowConsCalcType;
                type.ServerFeeCalcType = (int)ServerFeeCalcType;
                type.Status = 0;
                type.Deleted = 0;
                type.ColorType = ColorType;
                type.CreateDatetime = DateTime.Now;
                type.CreateBy = SubjectUtils.GetAuthenticationId();
                type.UpdateBy = SubjectUtils.GetAuthenticationId();
                type.UpdateDatetime = DateTime.Now;
                type.CanDiscount = CanDiscount;
                type.InLowConsume = InLowConsume;

                TableViewModel tableViewModel = ServiceLocator.Current.GetInstance<TableViewModel>();
                if (currentTableTypeId == null)
                {//修改窗口修改餐桌类型 
                    type.TableTypeId = tableViewModel.SelectedType.TableTypeId;
                }
                else//新增窗口修改餐桌类型
                {
                    type.TableTypeId = (int)currentTableTypeId;
                }

                ServerFeeDetail.UpdateBy = SubjectUtils.GetAuthenticationId();
                ServerFeeDetail.ServerfreeAccountType = (int)ServerfreeAccountType;

                LowConsumerDetail.ConsumerMode = (int)ConsumerMode;
                LowConsumerDetail.UpdateBy = SubjectUtils.GetAuthenticationId();

                TableService.UpdateTableTypeAll(type, ServerFeeDetail, LowConsumerDetail);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        RelayCommand _DeleteType;
        public RelayCommand DeleteType
        {
            get
            {
                return _DeleteType ?? (_DeleteType = new RelayCommand(() =>
                {
                    try
                    {
                        TableService.DeleteTableType(1);
                        MessageBox.Show("新增成功！");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("修改失败！");
                    }
                }));
            }
        }
        #endregion

        #region 低消特殊时段
        AddLowConsumerSpecialPeriod addLowConsumerSpecialPeriod;

        RelayCommand _AddLowConsumePeriod;
        public RelayCommand AddLowConsumePeriod
        {
            get
            {
                return _AddLowConsumePeriod ?? (_AddLowConsumePeriod = new RelayCommand(() =>
                {
                    if (currentTableTypeId == null)
                    {
                        currentTableTypeId = SaveTypeMethod();
                    }
                    LowConsSpecialPeriod = new TableTypeDetail();
                    addLowConsumerSpecialPeriod = new AddLowConsumerSpecialPeriod();
                    addLowConsumerSpecialPeriod.Show();
                }));
            }
        }

        RelayCommand _SaveLowConsSpecialPeriod;
        public RelayCommand SaveLowConsSpecialPeriod
        {
            get
            {
                return _SaveLowConsSpecialPeriod ?? (_SaveLowConsSpecialPeriod = new RelayCommand(() =>
                {
                    try
                    {
                        LowConsSpecialPeriod.DataType = DATATYPE_LC;
                        LowConsSpecialPeriod.ConsumerMode = (int)SpecialConsumerMode;
                        LowConsSpecialPeriod.TableTypeId = (int)currentTableTypeId;
                        TableService.SaveTableTypeDetail(LowConsSpecialPeriod);
                        MessageBox.Show("新增成功！");
                        //清空窗口数据
                        LowConsSpecialPeriod = null;
                        LowConsSpecialPeriod = new TableTypeDetail();

                        //刷新低消列表
                        List<TableTypeDetail> detailList = TableService.LoadTableTypeDetails((int)currentTableTypeId, 4);
                        if (LowConsSpecailPeriods == null)
                        {
                            LowConsSpecailPeriods = new ObservableCollection<TableTypeDetail>();
                        }
                        else
                        {
                            LowConsSpecailPeriods.Clear();
                        }
                        foreach (TableTypeDetail detail in detailList)
                        {
                            LowConsSpecailPeriods.Add(detail);
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                        ///TODO
                    }
                }));
            }
        }

        UpdateLowConsumerSpecialPeriod updateLowConsumerSpecialPeriod;

        RelayCommand _ModifyLowConsumePeriod;
        public RelayCommand ModifyLowConsumePeriod
        {
            get
            {
                return _ModifyLowConsumePeriod ?? (_ModifyLowConsumePeriod = new RelayCommand(() =>
                {
                    try
                    {
                        if (SelectedLowConsPeriod == null)
                        {
                            MessageBox.Show("请在列表中选择要修改的数据！");
                            return;
                        }
                        LowConsSpecialPeriod = null;
                        LowConsSpecialPeriod = new TableTypeDetail();
                        LowConsSpecialPeriod = SelectedLowConsPeriod;

                        SpecialConsumerMode = (ConsumerMode)SelectedLowConsPeriod.ConsumerMode;
                        updateLowConsumerSpecialPeriod = new UpdateLowConsumerSpecialPeriod();
                        updateLowConsumerSpecialPeriod.Show();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }));
            }
        }

        RelayCommand _UpdateLowConsSpecialPeriod;
        public RelayCommand UpdateLowConsSpecialPeriod
        {
            get
            {
                return _UpdateLowConsSpecialPeriod ?? (_UpdateLowConsSpecialPeriod = new RelayCommand(() =>
                {
                    try
                    {
                        LowConsSpecialPeriod.ConsumerMode = (int)SpecialConsumerMode;

                        TableService.UpdateTableTypeDetail(LowConsSpecialPeriod);
                        MessageBox.Show("修改成功！");
                        //清空窗口数据
                        LowConsSpecialPeriod = null;
                        LowConsSpecialPeriod = new TableTypeDetail();
                        updateLowConsumerSpecialPeriod.Close();
                        //刷新低消列表
                        List<TableTypeDetail> detailList = TableService.LoadTableTypeDetails((int)currentTableTypeId, 4);
                        if (LowConsSpecailPeriods == null)
                        {
                            LowConsSpecailPeriods = new ObservableCollection<TableTypeDetail>();
                        }
                        else
                        {
                            LowConsSpecailPeriods.Clear();
                        }
                        foreach (TableTypeDetail detail in detailList)
                        {
                            LowConsSpecailPeriods.Add(detail);
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                        ///TODO
                    }
                }));
            }
        }

        RelayCommand _DeleteLowConsumePeriod;
        public RelayCommand DeleteLowConsumePeriod
        {
            get
            {
                return _DeleteLowConsumePeriod ?? (_DeleteLowConsumePeriod = new RelayCommand(() =>
                {
                    try
                    {
                        if (SelectedLowConsPeriod == null)
                        {
                            MessageBox.Show("请在列表中选择要修改的数据！");
                            return;
                        }

                        TableService.DeleteTableTypeDetail(SelectedLowConsPeriod.TableTypeDetailId);
                        MessageBox.Show("删除成功！");

                        //刷新低消列表
                        List<TableTypeDetail> detailList = TableService.LoadTableTypeDetails((int)currentTableTypeId, 4);
                        if (LowConsSpecailPeriods == null)
                        {
                            LowConsSpecailPeriods = new ObservableCollection<TableTypeDetail>();
                        }
                        else
                        {
                            LowConsSpecailPeriods.Clear();
                        }
                        foreach (TableTypeDetail detail in detailList)
                        {
                            LowConsSpecailPeriods.Add(detail);
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                        ///TODO
                    }
                }));
            }
        }
        #endregion

        #region 服务费特殊时段
        AddServerFeeSpecialPeriod addServerFeeSpecialPeriod;

        RelayCommand _AddServerFeePeriod;
        public RelayCommand AddServerFeePeriod
        {
            get
            {
                return _AddServerFeePeriod ?? (_AddServerFeePeriod = new RelayCommand(() =>
                {
                    if (currentTableTypeId == null)
                    {
                        currentTableTypeId = SaveTypeMethod();
                    }
                    ServerFeeSpecialPeriod = new TableTypeDetail();
                    addServerFeeSpecialPeriod = new AddServerFeeSpecialPeriod();

                    InitAddServerFeePeriodWin();
                    addServerFeeSpecialPeriod.Show();
                }));
            }
        }

        RelayCommand _SaveServerFeeSpecialPeriod;
        public RelayCommand SaveServerFeeSpecialPeriod
        {
            get
            {
                return _SaveServerFeeSpecialPeriod ?? (_SaveServerFeeSpecialPeriod = new RelayCommand(() =>
                {
                    try
                    {
                        ServerFeeSpecialPeriod.DataType = DATATYPE_SF;
                        ServerFeeSpecialPeriod.ServerfreeAccountType = (int)SpecailServerfreeAccountType;
                        ServerFeeSpecialPeriod.TableTypeId = (int)currentTableTypeId;
                        TableService.SaveTableTypeDetail(ServerFeeSpecialPeriod);
                        MessageBox.Show("新增成功！");
                        //清空窗口数据
                        ServerFeeSpecialPeriod = null;
                        ServerFeeSpecialPeriod = new TableTypeDetail();

                        //刷新低消列表
                        List<TableTypeDetail> detailList = TableService.LoadTableTypeDetails((int)currentTableTypeId, 3);
                        if (LowConsSpecailPeriods == null)
                        {
                            ServerFeeSpecailPeriods = new ObservableCollection<TableTypeDetail>();
                        }
                        else
                        {
                            ServerFeeSpecailPeriods.Clear();
                        }
                        foreach (TableTypeDetail detail in detailList)
                        {
                            ServerFeeSpecailPeriods.Add(detail);
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                        ///TODO
                    }
                }));
            }
        }

        UpdateServerFeeSpecialPeriod updateServerFeeSpecialPeriod;

        RelayCommand _ModifyServerFeePeriod;
        public RelayCommand ModifyServerFeePeriod
        {
            get
            {
                return _ModifyServerFeePeriod ?? (_ModifyServerFeePeriod = new RelayCommand(() =>
                {
                    try
                    {
                        if (SelectedServerFeePeriod == null)
                        {
                            MessageBox.Show("请在列表中选择要修改的数据！");
                            return;
                        }
                        ServerFeeSpecialPeriod = null;
                        ServerFeeSpecialPeriod = new TableTypeDetail();
                        ServerFeeSpecialPeriod = SelectedServerFeePeriod;

                        SpecailServerfreeAccountType = (ServerfreeAccountType)SelectedServerFeePeriod.ServerfreeAccountType;
                        updateServerFeeSpecialPeriod = new UpdateServerFeeSpecialPeriod();

                        InitUpdateServerFeePeriodWin();
                        updateServerFeeSpecialPeriod.Show();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }));
            }
        }

        RelayCommand _UpdateServerFeeSpecialPeriod;
        public RelayCommand UpdateServerFeeSpecialPeriod
        {
            get
            {
                return _UpdateServerFeeSpecialPeriod ?? (_UpdateServerFeeSpecialPeriod = new RelayCommand(() =>
                {
                    try
                    {
                        ServerFeeSpecialPeriod.ServerfreeAccountType = (int)SpecailServerfreeAccountType;

                        TableService.UpdateTableTypeDetail(ServerFeeSpecialPeriod);
                        MessageBox.Show("修改成功！");
                        //清空窗口数据
                        ServerFeeSpecialPeriod = null;
                        ServerFeeSpecialPeriod = new TableTypeDetail();
                        updateServerFeeSpecialPeriod.Close();
                        //刷新低消列表
                        List<TableTypeDetail> detailList = TableService.LoadTableTypeDetails((int)currentTableTypeId, 3);
                        if (LowConsSpecailPeriods == null)
                        {
                            ServerFeeSpecailPeriods = new ObservableCollection<TableTypeDetail>();
                        }
                        else
                        {
                            ServerFeeSpecailPeriods.Clear();
                        }
                        foreach (TableTypeDetail detail in detailList)
                        {
                            ServerFeeSpecailPeriods.Add(detail);
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                        ///TODO
                    }
                }));
            }
        }

        RelayCommand _DeleteServerFeePeriod;
        public RelayCommand DeleteServerFeePeriod
        {
            get
            {
                return _DeleteServerFeePeriod ?? (_DeleteServerFeePeriod = new RelayCommand(() =>
                {
                    try
                    {
                        if (SelectedServerFeePeriod == null)
                        {
                            MessageBox.Show("请在列表中选择要修改的数据！");
                            return;
                        }

                        TableService.DeleteTableTypeDetail(SelectedServerFeePeriod.TableTypeDetailId);
                        MessageBox.Show("删除成功！");

                        //刷新低消列表
                        List<TableTypeDetail> detailList = TableService.LoadTableTypeDetails((int)currentTableTypeId, 3);
                        if (ServerFeeSpecailPeriods == null)
                        {
                            ServerFeeSpecailPeriods = new ObservableCollection<TableTypeDetail>();
                        }
                        else
                        {
                            ServerFeeSpecailPeriods.Clear();
                        }
                        foreach (TableTypeDetail detail in detailList)
                        {
                            ServerFeeSpecailPeriods.Add(detail);
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                        ///TODO
                    }
                }));
            }
        }
        #endregion

        #region 辅助方法
        public void InitAddServerFeePeriodWin(){
            if(ServerfreeModel==ServerfreeMode.NOTHANDLE){

                addServerFeeSpecialPeriod.StartUnit.IsEnabled = false;
                addServerFeeSpecialPeriod.StartMoney.IsEnabled = false;
                addServerFeeSpecialPeriod.StartGetMoneyTime.IsEnabled = false;
                addServerFeeSpecialPeriod.OutTime.IsEnabled = false;
                addServerFeeSpecialPeriod.OutMoney.IsEnabled = false;
                addServerFeeSpecialPeriod.OutTimeFree.IsEnabled = false;

                addServerFeeSpecialPeriod.ServerfreeNum.IsEnabled = false;
                addServerFeeSpecialPeriod.Rate.IsEnabled = false;
            }
            else if (ServerfreeModel == ServerfreeMode.TIMEUNIT) //时间单位
            {
                addServerFeeSpecialPeriod.StartUnit.IsEnabled = true;
                addServerFeeSpecialPeriod.StartMoney.IsEnabled = true;
                addServerFeeSpecialPeriod.StartGetMoneyTime.IsEnabled = true;
                addServerFeeSpecialPeriod.OutTime.IsEnabled = true;
                addServerFeeSpecialPeriod.OutMoney.IsEnabled = true;
                addServerFeeSpecialPeriod.OutTimeFree.IsEnabled = true;

                addServerFeeSpecialPeriod.ServerfreeNum.IsEnabled = false;
                addServerFeeSpecialPeriod.Rate.IsEnabled = false;
            }
            else if (ServerfreeModel == ServerfreeMode.CONSSERVERFEERATE)//消费额服务费率
            {
                addServerFeeSpecialPeriod.StartUnit.IsEnabled = false;
                addServerFeeSpecialPeriod.StartMoney.IsEnabled = false;
                addServerFeeSpecialPeriod.StartGetMoneyTime.IsEnabled = false;
                addServerFeeSpecialPeriod.OutTime.IsEnabled = false;
                addServerFeeSpecialPeriod.OutMoney.IsEnabled = false;
                addServerFeeSpecialPeriod.OutTimeFree.IsEnabled = false;

                addServerFeeSpecialPeriod.ServerfreeNum.IsEnabled = false;
                addServerFeeSpecialPeriod.Rate.IsEnabled = true;
            }
            else if (ServerfreeModel == ServerfreeMode.TABLEFEE)//餐桌定额
            {
                addServerFeeSpecialPeriod.StartUnit.IsEnabled = false;
                addServerFeeSpecialPeriod.StartMoney.IsEnabled = false;
                addServerFeeSpecialPeriod.StartGetMoneyTime.IsEnabled = false;
                addServerFeeSpecialPeriod.OutTime.IsEnabled = false;
                addServerFeeSpecialPeriod.OutMoney.IsEnabled = false;
                addServerFeeSpecialPeriod.OutTimeFree.IsEnabled = false;

                addServerFeeSpecialPeriod.ServerfreeNum.IsEnabled = true;
                addServerFeeSpecialPeriod.Rate.IsEnabled = false;
            }
            else if (ServerfreeModel == ServerfreeMode.DISHSERVERFEERATE)//菜品消费服务费率
            {
                addServerFeeSpecialPeriod.StartUnit.IsEnabled = false;
                addServerFeeSpecialPeriod.StartMoney.IsEnabled = false;
                addServerFeeSpecialPeriod.StartGetMoneyTime.IsEnabled = false;
                addServerFeeSpecialPeriod.OutTime.IsEnabled = false;
                addServerFeeSpecialPeriod.OutMoney.IsEnabled = false;
                addServerFeeSpecialPeriod.OutTimeFree.IsEnabled = false;

                addServerFeeSpecialPeriod.ServerfreeNum.IsEnabled = false;
                addServerFeeSpecialPeriod.Rate.IsEnabled = true;
            }
        }

        public void InitUpdateServerFeePeriodWin()
        {
            UpdateServerFeeSpecialPeriod addServerFeeSpecialPeriod = updateServerFeeSpecialPeriod;

            if (ServerfreeModel == ServerfreeMode.NOTHANDLE)
            {
                
                addServerFeeSpecialPeriod.StartUnit.IsEnabled = false;
                addServerFeeSpecialPeriod.StartMoney.IsEnabled = false;
                addServerFeeSpecialPeriod.StartGetMoneyTime.IsEnabled = false;
                addServerFeeSpecialPeriod.OutTime.IsEnabled = false;
                addServerFeeSpecialPeriod.OutMoney.IsEnabled = false;
                addServerFeeSpecialPeriod.OutTimeFree.IsEnabled = false;

                addServerFeeSpecialPeriod.ServerfreeNum.IsEnabled = false;
                addServerFeeSpecialPeriod.Rate.IsEnabled = false;
            }
            else if (ServerfreeModel == ServerfreeMode.TIMEUNIT) //时间单位
            {
                addServerFeeSpecialPeriod.StartUnit.IsEnabled = true;
                addServerFeeSpecialPeriod.StartMoney.IsEnabled = true;
                addServerFeeSpecialPeriod.StartGetMoneyTime.IsEnabled = true;
                addServerFeeSpecialPeriod.OutTime.IsEnabled = true;
                addServerFeeSpecialPeriod.OutMoney.IsEnabled = true;
                addServerFeeSpecialPeriod.OutTimeFree.IsEnabled = true;

                addServerFeeSpecialPeriod.ServerfreeNum.IsEnabled = false;
                addServerFeeSpecialPeriod.Rate.IsEnabled = false;
            }
            else if (ServerfreeModel == ServerfreeMode.CONSSERVERFEERATE)//消费额服务费率
            {
                addServerFeeSpecialPeriod.StartUnit.IsEnabled = false;
                addServerFeeSpecialPeriod.StartMoney.IsEnabled = false;
                addServerFeeSpecialPeriod.StartGetMoneyTime.IsEnabled = false;
                addServerFeeSpecialPeriod.OutTime.IsEnabled = false;
                addServerFeeSpecialPeriod.OutMoney.IsEnabled = false;
                addServerFeeSpecialPeriod.OutTimeFree.IsEnabled = false;

                addServerFeeSpecialPeriod.ServerfreeNum.IsEnabled = false;
                addServerFeeSpecialPeriod.Rate.IsEnabled = true;
            }
            else if (ServerfreeModel == ServerfreeMode.TABLEFEE)//餐桌定额
            {
                addServerFeeSpecialPeriod.StartUnit.IsEnabled = false;
                addServerFeeSpecialPeriod.StartMoney.IsEnabled = false;
                addServerFeeSpecialPeriod.StartGetMoneyTime.IsEnabled = false;
                addServerFeeSpecialPeriod.OutTime.IsEnabled = false;
                addServerFeeSpecialPeriod.OutMoney.IsEnabled = false;
                addServerFeeSpecialPeriod.OutTimeFree.IsEnabled = false;

                addServerFeeSpecialPeriod.ServerfreeNum.IsEnabled = true;
                addServerFeeSpecialPeriod.Rate.IsEnabled = false;
            }
            else if (ServerfreeModel == ServerfreeMode.DISHSERVERFEERATE)//菜品消费服务费率
            {
                addServerFeeSpecialPeriod.StartUnit.IsEnabled = false;
                addServerFeeSpecialPeriod.StartMoney.IsEnabled = false;
                addServerFeeSpecialPeriod.StartGetMoneyTime.IsEnabled = false;
                addServerFeeSpecialPeriod.OutTime.IsEnabled = false;
                addServerFeeSpecialPeriod.OutMoney.IsEnabled = false;
                addServerFeeSpecialPeriod.OutTimeFree.IsEnabled = false;

                addServerFeeSpecialPeriod.ServerfreeNum.IsEnabled = false;
                addServerFeeSpecialPeriod.Rate.IsEnabled = true;
            }
        }
        #endregion
    }
}
