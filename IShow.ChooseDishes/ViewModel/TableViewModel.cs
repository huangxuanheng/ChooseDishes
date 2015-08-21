using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Model.EnumSet;
using IShow.ChooseDishes.Security;
using IShow.ChooseDishes.View.Table;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IShow.ChooseDishes.ViewModel
{
    public class TableViewModel : ViewModelBase
    {
        ITableService _TableService;

        IChooseDishesDataService _DataService;

        public TableViewModel(ITableService tableService, IChooseDishesDataService dataService, IMessenger messenger)
            : base(messenger)
        {
            _TableService = tableService;
            _DataService = dataService;
            this.Init();//构造目录树
            //初始化时查询所有餐桌
            this.TableGrid = new ObservableCollection<Table>(_TableService.LoadAllTable());

        }

        public void Init()
        {
            this.TableTypeTree = new ObservableCollection<TableTypeTreeNode>();
            TableTypeTreeNode root = TableTypeTreeNode.createRoot("0", "全部类型", false);
            root.Action = LoadTableTypeAction;
            this.TableTypeTree.Add(root);
            //加载桌类
            var tableTypes = _TableService.LoadAllTableType();
            //MessageBox.Show("disheTypes===" + disheTypes.Count() + disheTypes[0].Name);
            foreach (var tableType in tableTypes)
            {
                var child = root.createChild(tableType.TableTypeId.ToString(), tableType.Name, false);
                child.Action = LoadTableTypeAction;
                root.Children.Add(child);
            }
        }

        public void LoadTableTypeAction(object parameter)
        {
            TableTypeTreeNode node = (TableTypeTreeNode)parameter;
            //MessageBox.Show("start");
            this.TableGrid.Clear();
            List<Table> tableList;
            if (node.Id.Equals("0"))//根结点
            {
                tableList = _TableService.LoadAllTable();//查询所有餐桌
            }
            else//非根结点
            {
                tableList = _TableService.LoadTableByTypeId(Convert.ToInt32(node.Id));//根据餐桌类型查询餐桌
            }
            foreach (Table table in tableList)
            {
                this.TableGrid.Add(table);
            }
        }



        #region 页面数据
        int _TableId;
        public int TableId
        {

            get
            {
                return _TableId;
            }
            set
            {
                Set("TableId", ref _TableId, value);
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

        string _Seat;
        public string Seat
        {

            get
            {
                return _Seat;
            }
            set
            {
                Set("Seat", ref _Seat, value);
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

        int _LocationId;
        public int LocationId
        {

            get
            {
                return _LocationId;
            }
            set
            {
                Set("LocationId", ref _LocationId, value);
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

        string _CodePrefix;
        public string CodePrefix
        {
            get
            {
                return _CodePrefix;
            }
            set
            {
                Set("CodePrefix", ref _CodePrefix, value);
            }
        }

        string _CodeLength;
        public string CodeLength
        {
            get
            {
                return _CodeLength;
            }
            set
            {
                Set("CodeLength", ref _CodeLength, value);
            }
        }

        string _CodeStart;
        public string CodeStart
        {
            get
            {
                return _CodeStart;
            }
            set
            {
                Set("CodeStart", ref _CodeStart, value);
            }
        }

        string _CodeEnd;
        public string CodeEnd
        {
            get
            {
                return _CodeEnd;
            }
            set
            {
                Set("CodeEnd", ref _CodeEnd, value);
            }
        }

        string _FilterCode;
        public string FilterCode
        {
            get
            {
                return _FilterCode;
            }
            set
            {
                Set("FilterCode", ref _FilterCode, value);
            }
        }

        ObservableCollection<TableTypeTreeNode> _TableTypeTree;
        public ObservableCollection<TableTypeTreeNode> TableTypeTree
        {
            get
            {
                return _TableTypeTree ?? (_TableTypeTree = new ObservableCollection<TableTypeTreeNode>());
            }
            set
            {
                this._TableTypeTree = value;
                Set("TableTypeTree", ref _TableTypeTree, value);
            }
        }

        ObservableCollection<Table> _TableGrid;
        public ObservableCollection<Table> TableGrid
        {
            get
            {
                return _TableGrid ?? (_TableGrid = new ObservableCollection<Table>());
            }
            set
            {
                this._TableGrid = value;
                Set("TableGrid", ref _TableGrid, value);
            }
        }

        Table _SelectedTable;
        public Table SelectedTable
        {
            get
            {
                return _SelectedTable;
            }
            set
            {
                this._SelectedTable = value;
                Set("SelectedTable", ref _SelectedTable, value);
            }
        }

        TableType _SelectedType;
        public TableType SelectedType
        {
            get
            {
                return _SelectedType;
            }
            set
            {
                this._SelectedType = value;
                Set("SelectedType", ref _SelectedType, value);
            }
        }

        Dictionary<int, string> _TableTypeItems;
        public Dictionary<int, string> TableTypeItems
        {
            get
            {
                return _TableTypeItems ?? (_TableTypeItems = new Dictionary<int, string>());
            }
            set
            {
                Set("TableTypeItems", ref _TableTypeItems, value);
            }
        }

        Dictionary<int, string> _LocationItems;
        public Dictionary<int, string> LocationItems
        {
            get
            {
                return _LocationItems ?? (LocationItems = new Dictionary<int, string>());
            }
            set
            {
                Set("LocationItems", ref _LocationItems, value);
            }
        }
        #endregion

        #region Command
        RelayCommand _AddTable;
        public RelayCommand AddTable
        {
            get
            {
                return _AddTable ?? (_AddTable = new RelayCommand(() =>
                {
                    ClearWinData();
                    if (this.TableTypeItems.Count == 0)
                    {

                        //初始化餐桌类型
                        List<TableType> typeList = _TableService.LoadAllTableType();
                        foreach (TableType type in typeList)
                        {
                            this.TableTypeItems.Add(type.TableTypeId, type.Name);
                        }
                        //初始化区域
                        List<Location> locationList = _DataService.queryByLocation();
                        foreach (Location type in locationList)
                        {
                            LocationItems.Add(type.LocationId, type.Name);
                        }
                    }

                    //打开新增窗口                    
                    AddTableWindow addTableWin = new AddTableWindow();
                    addTableWin.ShowDialog();
                }));
            }
        }

        UpdateTableWindow updateTableWin;

        RelayCommand _ModifyTable;
        public RelayCommand ModifyTable
        {
            get
            {
                return _ModifyTable ?? (_ModifyTable = new RelayCommand(() =>
                {
                    if (SelectedTable == null)
                    {
                        MessageBox.Show("请选择要修改的餐桌！");
                        return;
                    }
                    //初始化餐桌类型
                    if (this.TableTypeItems.Count == 0)
                    {
                        List<TableType> typeList = _TableService.LoadAllTableType();
                        foreach (TableType type in typeList)
                        {
                            this.TableTypeItems.Add(type.TableTypeId, type.Name);
                        }
                        //初始化区域
                        List<Location> locationList = _DataService.queryByLocation();
                        foreach (Location type in locationList)
                        {
                            LocationItems.Add(type.LocationId, type.Name);
                        }
                    }
                    Code = SelectedTable.Code;
                    Name = SelectedTable.Name;
                    Seat = SelectedTable.Seat.ToString();
                    TableTypeId = SelectedTable.TableTypeId;
                    LocationId = SelectedTable.LocationId;
                    Status = SelectedTable.Status;
                    //CreateBy = SelectedTable.CreateBy;
                    //CreateDatetime = SelectedTable.CreateDatetime;
                    //UpdateBy = SelectedTable.UpdateBy;
                    //UpdateTime=SelectedTable.UpdateDatetime

                    updateTableWin = new UpdateTableWindow();
                    updateTableWin.ShowDialog();
                }));
            }
        }

        public AddTableType typeWin;

        RelayCommand _OpenTableTypeWin;
        public RelayCommand OpenTableTypeWin
        {
            get
            {
                return _OpenTableTypeWin ?? (_OpenTableTypeWin = new RelayCommand(() =>
                {
                    TableTypeViewModel tableTypeModel = ServiceLocator.Current.GetInstance<TableTypeViewModel>();
                    tableTypeModel.ClearWin();
                    tableTypeModel.currentTableTypeId = null;
                    typeWin = null;
                    typeWin = new AddTableType();

                    ServiceLocator.Current.GetInstance<TableTypeViewModel>().ServerFeeDetail = new TableTypeDetail();
                    ServiceLocator.Current.GetInstance<TableTypeViewModel>().LowConsumerDetail = new TableTypeDetail();
                    InitWinComponent(typeWin);
                    typeWin.ShowDialog();
                }));
            }
        }

        RelayCommand _SaveTable;
        public RelayCommand SaveTable
        {
            get
            {
                return _SaveTable ?? (_SaveTable = new RelayCommand(() =>
                {
                    if (Code == null || Code.Equals(""))
                    {
                        MessageBox.Show("编号不能为空");
                    }
                    if (Name == null || Name.Equals(""))
                    {
                        MessageBox.Show("名称不能为空");
                    }
                    if (Seat == null || Seat.Equals(""))
                    {
                        MessageBox.Show("人数不能为空");
                    }
                    Table table = new Table();
                    table.Code = Code;
                    table.Name = Name;
                    table.Seat = Convert.ToInt32(Seat);
                    table.TableTypeId = TableTypeId;
                    table.LocationId = LocationId;
                    table.Status = Status;
                    table.Deleted = 0;
                    table.CreateDatetime = DateTime.Now;
                    table.CreateBy = SubjectUtils.GetAuthenticationId();
                    table.UpdateBy = SubjectUtils.GetAuthenticationId();
                    table.UpdateDatetime = DateTime.Now;

                    Hashtable hash = _TableService.SaveTable(table);
                    if (hash["code"].ToString().Equals("0"))//新增成功
                    {
                        //刷新主窗口餐桌列表数据
                        TableGrid.Add(table);
                        //清空窗口数据
                        ClearWin();
                    }
                    MessageBox.Show(hash["message"].ToString());
                }));
            }
        }

        //清空新增餐桌窗口数据
        public void ClearWin()
        {
            this.Code = "";
            this.Name = "";
            this.Seat = "";
        }

        RelayCommand _UpdateTable;
        public RelayCommand UpdateTable
        {
            get
            {
                return _UpdateTable ?? (_UpdateTable = new RelayCommand(() =>
                {
                    if (Name == null || Name.Equals(""))
                    {
                        MessageBox.Show("名称不能为空");
                    }
                    if (Seat == null || Seat.Equals(""))
                    {
                        MessageBox.Show("人数不能为空");
                    }
                    Table table = new Table();
                    table.Code = Code;
                    table.Name = Name;
                    table.Seat = Convert.ToInt32(Seat);
                    table.TableTypeId = TableTypeId;
                    table.LocationId = LocationId;
                    table.Status = Status;
                    table.Deleted = 0;
                    table.CreateDatetime = DateTime.Now;
                    table.CreateBy = SubjectUtils.GetAuthenticationId();
                    table.UpdateBy = SubjectUtils.GetAuthenticationId();
                    table.UpdateDatetime = DateTime.Now;
                    table.TableId = SelectedTable.TableId;

                    bool flag = _TableService.UpdateTable(table);
                    if (flag)//修改成功
                    {
                        MessageBox.Show("修改成功！");
                        //刷新主窗口餐桌列表数据
                        //TableGrid.Clear();
                        //List<Table> tableList=_TableService.LoadAllTable();
                        //for (int loop = 0; loop < tableList.Count; loop++)
                        //{
                        //    TableGrid.Add(tableList[loop]);
                        //}
                        //清空窗口数据
                        ClearWin();
                        updateTableWin.Close();
                    }

                }));
            }
        }

        RelayCommand _DeleteTable;
        public RelayCommand DeleteTable
        {
            get
            {
                return _DeleteTable ?? (_DeleteTable = new RelayCommand(() =>
                {

                    if (SelectedTable == null)
                    {
                        System.Windows.MessageBox.Show("请在右边列表中选中要删除的餐桌！");
                        return;
                    }
                    DialogResult result = System.Windows.Forms.MessageBox.Show("删除后数据将不能恢复，确定删除吗？", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    { //删除操作
                        bool flag = _TableService.DeleteTable(SelectedTable.TableId);
                        if (flag)
                        {
                            System.Windows.MessageBox.Show("删除成功！");
                            //刷新列表数据
                            TableGrid.Remove(SelectedTable);
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("删除失败！");
                        }
                    }
                    else
                    {

                        return;
                    }

                }));
            }
        }

        RelayCommand _OpenLocationWin;
        public RelayCommand OpenLocationWin
        {
            get
            {
                return _OpenLocationWin ?? (_OpenLocationWin = new RelayCommand(() =>
               {
                   OrgLocation orgLocationWin = new OrgLocation();
                   orgLocationWin.ShowDialog();
               }));
            }
        }

        RelayCommand _OpenBearingWin;
        public RelayCommand OpenBearingWin
        {
            get
            {
                return _OpenBearingWin ?? (_OpenBearingWin = new RelayCommand(() =>
                {
                    OrgBearing orgBearingWin = new OrgBearing();
                    orgBearingWin.ShowDialog();
                }));
            }
        }

        public UpdateTableType updateTableType;

        RelayCommand _OpenUpdateTypeWin;
        public RelayCommand OpenUpdateTypeWin
        {
            get
            {
                return _OpenUpdateTypeWin ?? (_OpenUpdateTypeWin = new RelayCommand(() =>
                {
                    int currentTableTypeId = 0;
                    for (var index = 0; index < TableTypeTree[0].Children.Count; index++)
                    {
                        if (TableTypeTree[0].Children[index]._Selected == true)//是否选了餐桌类型
                        {
                            currentTableTypeId = Convert.ToInt32(TableTypeTree[0].Children[index].Id);
                            break;
                        }
                    }
                    if (currentTableTypeId != 0)
                    {
                        TableType currentType = _TableService.LoadTableTypeById(currentTableTypeId);

                        SelectedType = currentType;//记录当前选中的餐桌类型

                        TableTypeViewModel model = ServiceLocator.Current.GetInstance<TableTypeViewModel>();
                        model.currentTableTypeId = currentTableTypeId;

                        model.ClearWin();
                        updateTableType = null;
                        updateTableType = new UpdateTableType();

                        model.Name = currentType.Name;
                        model.Code = currentType.Code;
                        model.ColorType = currentType.ColorType;
                        model.PeopleMax = currentType.PeopleMax.ToString();
                        model.PeopleMin = currentType.PeopleMin.ToString();
                        //model.Prefix = currentType.Prefix;
                        model.PriceType = (PriceType)currentType.PriceType;
                        model.LowConsCalcType = (AccountType)currentType.LowConsCalcType;
                        model.ServerFeeCalcType = (AccountType)currentType.ServerFeeCalcType;
                        model.CanDiscount = currentType.CanDiscount;
                        model.InLowConsume = currentType.InLowConsume;
                        model.ServerfreeModel = (ServerfreeMode)currentType.ServerfreeModel;


                        ServiceLocator.Current.GetInstance<TableTypeViewModel>().ServerFeeDetail = new TableTypeDetail();
                        ServiceLocator.Current.GetInstance<TableTypeViewModel>().LowConsumerDetail = new TableTypeDetail();
                        ServiceLocator.Current.GetInstance<TableTypeViewModel>().LowConsSpecailPeriods = new ObservableCollection<TableTypeDetail>();
                        ServiceLocator.Current.GetInstance<TableTypeViewModel>().ServerFeeSpecailPeriods = new ObservableCollection<TableTypeDetail>();

                        //查询餐桌类型详细设置
                        List<TableTypeDetail> detailList = _TableService.LoadAllTableTypeDetails(currentType.TableTypeId);
                        foreach (TableTypeDetail detail in detailList)
                        {
                            if (detail.DataType == 1)
                            {
                                //服务费设置
                                model.ServerFeeDetail = null;
                                model.ServerFeeDetail = detail;
                                model.ServerfreeAccountType=(ServerfreeAccountType)detail.ServerfreeAccountType;
                            }
                            else if (detail.DataType == 2)
                            {
                                //低消设置
                                model.LowConsumerDetail = null;
                                model.LowConsumerDetail = detail;
                                //model.ConsumerMode = null;
                                model.ConsumerMode = (ConsumerMode)detail.ConsumerMode;
                            }
                            else if (detail.DataType ==3)
                            {
                                //查询服务费特殊时段
                                model.ServerFeeSpecailPeriods.Add(detail);
                            } if (detail.DataType == 4)
                            {
                                //查询低消特殊时段
                                model.LowConsSpecailPeriods.Add(detail);
                            }
                        }

                        //设置窗口控件的可编辑状态
                        InitWinComponent(updateTableType);
                        updateTableType.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("请选择要修改的餐桌类型！");
                        return;
                    }
                }));
            }
        }


        public void InitWinComponent(UpdateTableType typeWin)
        {
            if ((int)typeWin.ServerFeeMode.SelectedValue == (int)ServerfreeMode.NOTHANDLE)
            { //服务费模式，不处理

                typeWin.StartUnit.IsEnabled = false;
                typeWin.StartMoney.IsEnabled = false;
                typeWin.StartGetMoneyTime.IsEnabled = false;
                typeWin.OutTime.IsEnabled = false;
                typeWin.OutMoney.IsEnabled = false;
                typeWin.OutTimeFree.IsEnabled = false;

                typeWin.ServerfreeNum.IsEnabled = false;
            }
            else if ((int)typeWin.ServerFeeMode.SelectedValue == (int)ServerfreeMode.TIMEUNIT) //时间单位
            {
                typeWin.StartUnit.IsEnabled = true;
                typeWin.StartMoney.IsEnabled = true;
                typeWin.StartGetMoneyTime.IsEnabled = true;
                typeWin.OutTime.IsEnabled = true;
                typeWin.OutMoney.IsEnabled = true;
                typeWin.OutTimeFree.IsEnabled = true;

                typeWin.ServerfreeNum.IsEnabled = false;
                typeWin.Rate.IsEnabled = false;
            }
            else if ((int)typeWin.ServerFeeMode.SelectedValue == (int)ServerfreeMode.CONSSERVERFEERATE)//消费额服务费率
            {
                typeWin.StartUnit.IsEnabled = false;
                typeWin.StartMoney.IsEnabled = false;
                typeWin.StartGetMoneyTime.IsEnabled = false;
                typeWin.OutTime.IsEnabled = false;
                typeWin.OutMoney.IsEnabled = false;
                typeWin.OutTimeFree.IsEnabled = false;

                typeWin.ServerfreeNum.IsEnabled = false;
                typeWin.Rate.IsEnabled = true;
            }
            else if ((int)typeWin.ServerFeeMode.SelectedValue == (int)ServerfreeMode.TABLEFEE)//餐桌定额
            {
                typeWin.StartUnit.IsEnabled = false;
                typeWin.StartMoney.IsEnabled = false;
                typeWin.StartGetMoneyTime.IsEnabled = false;
                typeWin.OutTime.IsEnabled = false;
                typeWin.OutMoney.IsEnabled = false;
                typeWin.OutTimeFree.IsEnabled = false;

                typeWin.ServerfreeNum.IsEnabled = true;
                typeWin.Rate.IsEnabled = false;
            }
            else if ((int)typeWin.ServerFeeMode.SelectedValue == (int)ServerfreeMode.DISHSERVERFEERATE)//菜品消费服务费率
            {
                typeWin.StartUnit.IsEnabled = false;
                typeWin.StartMoney.IsEnabled = false;
                typeWin.StartGetMoneyTime.IsEnabled = false;
                typeWin.OutTime.IsEnabled = false;
                typeWin.OutMoney.IsEnabled = false;
                typeWin.OutTimeFree.IsEnabled = false;

                typeWin.ServerfreeNum.IsEnabled = false;
                typeWin.Rate.IsEnabled = true;
            }
        }


        

        RelayCommand _BatchAddTable;
        public RelayCommand BatchAddTable
        {
            get
            {
                return _BatchAddTable ?? (_BatchAddTable = new RelayCommand(() =>
                {
                    //初始化餐桌类型
                    if (this.TableTypeItems.Count == 0)
                    {
                        List<TableType> typeList = _TableService.LoadAllTableType();
                        foreach (TableType type in typeList)
                        {
                            this.TableTypeItems.Add(type.TableTypeId, type.Name);
                        }
                        //初始化区域
                        List<Location> locationList = _DataService.queryByLocation();
                        foreach (Location type in locationList)
                        {
                            LocationItems.Add(type.LocationId, type.Name);
                        }
                    }

                    AddTableBatchWindow batchWin = new AddTableBatchWindow();
                    batchWin.ShowDialog();
                }));
            }
        }

        RelayCommand _GenerateTable;
        public RelayCommand GenerateTable
        {
            get
            {
                return _GenerateTable ?? (_GenerateTable = new RelayCommand(() =>
                {
                    if (CodeLength == null || CodeLength.Trim().Equals(""))
                    {
                        MessageBox.Show("请输入“编号长度”！");
                        return;
                    }
                    if (CodeStart == null || CodeStart.Trim().Equals("") || CodeEnd == null || CodeEnd.Trim().Equals(""))
                    {
                        MessageBox.Show("起始编号和结束编号必需填写完整！");
                        return;
                    }
                    if (Seat == null || Seat.Trim().Equals(""))
                    {
                        MessageBox.Show("请输入“人数”！");
                        return;
                    }
                    if (TableTypeId == 0)
                    {
                        MessageBox.Show("请选择“所属类型”！");
                        return;
                    }
                    if (LocationId == 0)
                    {
                        MessageBox.Show("请选择“所属区域”！");
                        return;
                    }
                    for (int loop = Convert.ToInt32(CodeStart); loop <= Convert.ToInt32(CodeEnd); loop++)
                    {
                        if (FilterCode != null && !FilterCode.Trim().Equals(""))//是否有要过滤的编号，如果有则跳过
                        {
                            string[] filterCodeArray = FilterCode.Split(',');
                            bool flag = true;//标记是否包含要过滤的编号，有则改为false
                            for (int index = 0; index < filterCodeArray.Length; index++)
                            {
                                if (filterCodeArray[index].Equals(loop.ToString()))
                                {
                                    flag = false;
                                }
                            }
                            if (flag)
                            {
                                SaveTableInBatch(loop);
                            }
                        }
                        else
                        {
                            SaveTableInBatch(loop);
                        }

                    }
                    MessageBox.Show("批量生成完成！");
                    ClearBatchWinData();
                }));
            }
        }

        //
        public void SaveTableInBatch(int loop)
        {
            Table table = new Table();
            if (CodePrefix != null && !CodePrefix.Trim().Equals(""))
            {//编号有前缀
                int lengthDiff = Convert.ToInt32(CodeLength) - (CodePrefix.Length + loop.ToString().Length);
                if (lengthDiff <= 0)
                {//前缀加编号是否大于编号长度，如果小于则要补0
                    table.Code = CodePrefix + loop.ToString();
                }
                else
                {//长度不达标，中间补0
                    for (int Cursor = 1; Cursor <= lengthDiff; Cursor++)
                    {
                        table.Code = CodePrefix + "0";
                    }
                    table.Code = table.Code + loop.ToString();
                }
            }
            else
            {//编号没有前缀
                int lengthDiff = Convert.ToInt32(CodeLength) - loop.ToString().Length;
                if (lengthDiff <= 0)
                {//前缀加编号是否大于编号长度，如果小于则要补0
                    table.Code = loop.ToString();
                }
                else
                {//长度不达标，中间补0
                    for (int Cursor = 1; Cursor <= lengthDiff; Cursor++)
                    {
                        table.Code = "0";
                    }
                    table.Code = table.Code + loop.ToString();
                }
            }
            table.Name = "桌" + table.Code;
            table.LocationId = LocationId;
            table.TableTypeId = TableTypeId;
            table.Seat = Convert.ToInt32(Seat);
            table.Deleted = 0;
            table.Status = Status;
            table.CreateBy = SubjectUtils.GetAuthenticationId();
            table.CreateDatetime = DateTime.Now;
            table.UpdateBy = SubjectUtils.GetAuthenticationId();
            table.UpdateDatetime = DateTime.Now;
            _TableService.SaveTable(table);
            //刷新餐桌列表数据
            TableGrid.Add(table);
        }

        /// <summary>
        /// 清空新增、修改餐桌窗口数据
        /// </summary>
        public void ClearWinData()
        {
            this.Code = "";
            this.Name = "";
            this.Seat = "";
            this.TableTypeId = 0;
            this.LocationId = 0;
            this.Status = 0;
        }

        /// <summary>
        /// 清除批量新增餐桌窗口数据
        /// </summary>
        public void ClearBatchWinData()
        {
            this.CodePrefix = "";
            this.CodeLength = "";
            this.CodeStart = "";
            this._CodeEnd = "";
            this.Seat = "";
            this.TableTypeId = 0;
            this.LocationId = 0;
            this.FilterCode = "";
        }

        public void InitWinComponent(AddTableType typeWin)
        {
            if ((int)typeWin.ServerFeeMode.SelectedValue == (int)ServerfreeMode.NOTHANDLE)
            { //服务费模式，不处理

                typeWin.StartUnit.IsEnabled = false;
                typeWin.StartMoney.IsEnabled = false;
                typeWin.StartGetMoneyTime.IsEnabled = false;
                typeWin.OutTime.IsEnabled = false;
                typeWin.OutMoney.IsEnabled = false;
                typeWin.OutTimeFree.IsEnabled = false;

                typeWin.ServerfreeNum.IsEnabled = false;
                typeWin.Rate.IsEnabled = false;
            }
            else if ((int)typeWin.ServerFeeMode.SelectedValue == (int)ServerfreeMode.TIMEUNIT) //时间单位
            {
                typeWin.StartUnit.IsEnabled = true;
                typeWin.StartMoney.IsEnabled = true;
                typeWin.StartGetMoneyTime.IsEnabled = true;
                typeWin.OutTime.IsEnabled = true;
                typeWin.OutMoney.IsEnabled = true;
                typeWin.OutTimeFree.IsEnabled = true;

                typeWin.ServerfreeNum.IsEnabled = false;
                typeWin.Rate.IsEnabled = false;
            }
            else if ((int)typeWin.ServerFeeMode.SelectedValue == (int)ServerfreeMode.CONSSERVERFEERATE)//消费额服务费率
            {
                typeWin.StartUnit.IsEnabled = false;
                typeWin.StartMoney.IsEnabled = false;
                typeWin.StartGetMoneyTime.IsEnabled = false;
                typeWin.OutTime.IsEnabled = false;
                typeWin.OutMoney.IsEnabled = false;
                typeWin.OutTimeFree.IsEnabled = false;

                typeWin.ServerfreeNum.IsEnabled = false;
                typeWin.Rate.IsEnabled = true;
            }
            else if ((int)typeWin.ServerFeeMode.SelectedValue == (int)ServerfreeMode.TABLEFEE)//餐桌定额
            {
                typeWin.StartUnit.IsEnabled = false;
                typeWin.StartMoney.IsEnabled = false;
                typeWin.StartGetMoneyTime.IsEnabled = false;
                typeWin.OutTime.IsEnabled = false;
                typeWin.OutMoney.IsEnabled = false;
                typeWin.OutTimeFree.IsEnabled = false;

                typeWin.ServerfreeNum.IsEnabled = true;
                typeWin.Rate.IsEnabled = false;
            }
            else if ((int)typeWin.ServerFeeMode.SelectedValue == (int)ServerfreeMode.DISHSERVERFEERATE)//菜品消费服务费率
            {
                typeWin.StartUnit.IsEnabled = false;
                typeWin.StartMoney.IsEnabled = false;
                typeWin.StartGetMoneyTime.IsEnabled = false;
                typeWin.OutTime.IsEnabled = false;
                typeWin.OutMoney.IsEnabled = false;
                typeWin.OutTimeFree.IsEnabled = false;

                typeWin.ServerfreeNum.IsEnabled = false;
                typeWin.Rate.IsEnabled = true;
            }
        }


        #endregion
    }

    public class TableTypeTreeNode
    {
        /// <summary>
        /// 节点编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 节点名称
        /// </summary>
        public string Name { get; set; }

        public TableTypeTreeNode Parent { get; set; }

        //public bool isRoot()
        //{
        //    return this.Parent == null;
        //}


        public Action<object> Action
        {
            get;
            set;
        }

        public bool _Selected;

        public bool Selected
        {
            get
            {
                return _Selected;
            }
            set
            {
                this._Selected = value;
                //Action = LoadTableTypeAction;
                Action(this);
                if (this.Id.Equals("0"))
                {
                    Action(this);
                }
            }
        }

        /// <summary>
        /// 子节点
        /// </summary>
        public ObservableCollection<TableTypeTreeNode> Children { get; set; }

        /// <summary>
        /// 父节点

        public TableTypeTreeNode(string id, string name, TableTypeTreeNode parent, bool selected, ObservableCollection<TableTypeTreeNode> children)
        {
            this.Id = id;
            this.Name = name;
            this.Parent = parent;
            this._Selected = selected;
            this.Children = children ?? new ObservableCollection<TableTypeTreeNode>();
        }

        public static TableTypeTreeNode createRoot(string id, string name, bool selected)
        {
            return new TableTypeTreeNode(id, name, null, selected, null);
        }

        public TableTypeTreeNode createChild(string id, string name, bool selected)
        {
            return new TableTypeTreeNode(id, name, this, selected, null);
        }
    }
}
