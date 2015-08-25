using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using IShow.ChooseDishes.Model.Booking;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Data;
using System.Windows;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.View.Home.Booking;


namespace IShow.ChooseDishes.ViewModel.Booking
{
    public class HomePageViewModel:ViewModelBase
    {
        /// <summary>
        /// 餐桌业务接口
        /// </summary>
        ITableStatusService _TableStatusService;    
        /// <summary>
        /// 餐桌状态业务接口
        /// </summary>
        ITableItemService _TableItemService;
        /// <summary>
        /// 参数设置业务接口
        /// </summary>
        IConfigurationService _ConfigurationService;
        /// <summary>
        /// 餐桌点餐业务接口
        /// </summary>
        IDeskDishesService _DeskDishesService;
        #region 餐桌类型

        BaseTableModel _TypeSelectedItem;
        public BaseTableModel TypeSelectedItem    //餐桌类型/区域的选中对象
        {
            get {
                return _TypeSelectedItem;
            }
            set {
                Set("TypeSelectedItem", ref _TypeSelectedItem, value);
            }
        }

        ObservableCollection<BaseTableModel> _TypeItems;
        public ObservableCollection<BaseTableModel> TypeItems   //所有餐桌类型/区域的集合
        {
            get {
                return _TypeItems ?? (_TypeItems = new ObservableCollection<BaseTableModel>());
            }
            set {
                Set("TypeItems", ref _TypeItems, value);
            }
        }
        #endregion

        #region 餐桌状态

        TableStatusModel _TableStatusSelectedItem;
        public TableStatusModel TableStatusSelectedItem     //餐桌状态的选中对象
        {
            get
            {
                return _TableStatusSelectedItem;
            }
            set
            {
                Set("TableStatusSelectedItem", ref _TableStatusSelectedItem, value);
            }
        }

        ObservableCollection<TableStatusModel> _TableStatusItems;
        public ObservableCollection<TableStatusModel> TableStatusItems  //所有餐桌状态的集合
        {
            get
            {
                return _TableStatusItems ?? (_TableStatusItems = new ObservableCollection<TableStatusModel>());
            }
            set
            {
                Set("TableStatusItems", ref _TableStatusItems, value);
            }
        }
        #endregion

        #region 餐台item
        private TableItemModel _TableSelectedItem;
        public TableItemModel TableSelectedItem    //餐桌的选中对象
        {
            get
            {
                return _TableSelectedItem;
            }
            set
            {
                Set("TableSelectedItem", ref _TableSelectedItem, value);
            }
        }
        private ObservableCollection<TableItemModel> _TableItems;
        public ObservableCollection<TableItemModel> TableItems    //所有餐桌的集合
        {
            get
            {
                return _TableItems ?? (_TableItems = new ObservableCollection<TableItemModel>());
            }
            set
            {
                Set("TableItems", ref _TableItems, value);
            }
        }
        
        #endregion 
        #region 餐台定位
        BaseTableModel _LocationSelectedItem;
        public BaseTableModel LocationSelectedItem
        {
            get
            {
                return _LocationSelectedItem;
            }
            set
            {
                Set("LocationSelectedItem", ref _LocationSelectedItem, value);
            }
        }
        ObservableCollection<BaseTableModel> _TableLocationItems;
        public ObservableCollection<BaseTableModel> TableLocationItems
        {
            get
            {
                return _TableLocationItems ?? (_TableLocationItems = new ObservableCollection<BaseTableModel>());
            }
            set
            {
                Set("TableLocationItems", ref _TableLocationItems, value);
            }
        }

        TableWindow TableXaml { set; get; }
        #endregion
        #region 餐台加台、并台、拆台、搭台
        BaseTableModel _BaseTableSelectedItem;
        public BaseTableModel BaseTableSelectedItem
        {
            get
            {
                return _BaseTableSelectedItem;
            }
            set
            {
                Set("BaseTableSelectedItem", ref _BaseTableSelectedItem, value);
            }
        }
        ObservableCollection<BaseTableModel> _BaseTableItems;
        public ObservableCollection<BaseTableModel> BaseTableItems
        {
            get
            {
                return _BaseTableItems ?? (_BaseTableItems = new ObservableCollection<BaseTableModel>());
            }
            set
            {
                Set("BaseTableItems", ref _BaseTableItems, value);
            }
        }
        /// <summary>
        /// 加台页面
        /// </summary>
        BaseTableWindow AddTableXaml { set; get; }
        #endregion
        public HomePageViewModel(ITableStatusService _Service, ITableItemService _TableItemService, IConfigurationService _ConfigurationService, IDeskDishesService _DeskDishesService, IMessenger messenger)
        {
            this._TableStatusService = _Service;
            this._TableItemService = _TableItemService;
            this._ConfigurationService = _ConfigurationService;
            this._DeskDishesService = _DeskDishesService;
            InitTableStatusNum();
            InitTableData();
        }

        /// <summary>
        /// 初始化餐桌定位页面
        /// </summary>
        public void InitTableLocation(){
            TableXaml = new TableWindow();
            Config config = _ConfigurationService.Find(TableLocationMapping.TableLocationName[TableLocation.NAME]);
            if (config != null)
            {

                string[] value=config.Value.Split(new char[]{'_'});
                //餐桌定位的拼接类型是编码或者id直接使用下划线分割"_"
                if (config.Disabled == 1)   //餐桌类型
                {
                    TableXaml.TableType.IsChecked = true;
                    LoaderTableTypeLocation(value);
                }
                else if (config.Disabled == 2)   //区域
                {
                    TableXaml.Location.IsChecked = true;
                    LoaderTableLocation(value);
                }
            }
            TableXaml.ShowDialog();
        }
        /// <summary>
        /// 标识默认选中的餐桌定位
        /// </summary>
        bool flag = false;
        /// <summary>
        /// 加载餐桌定位区域定位
        /// </summary>
        private void LoaderTableLocation(string[]values)
        {
            flag = false;
            List<Location> tts = _TableStatusService.GetAllLocation();
            TableLocationItems.Clear();
            if (tts != null)
            {
                foreach (var tt in tts)
                {
                    BaseTableModel ttm=new BaseTableModel(tt.LocationId, tt.Name);
                    if (!flag)
                    {
                        LocationSelectedItem = ttm;
                        flag = true;
                    }
                    if (values != null)
                        foreach (var value in values)
                        {
                            if (string.IsNullOrEmpty(value))
                                continue;
                            if (tt.LocationId == int.Parse(value))
                            {
                                ttm.Checked = true;
                            }
                        }
                
                    TableLocationItems.Add(ttm);
                }
            }
        }
        /// <summary>
        /// 加载餐桌定位---餐桌类型定位
        /// </summary>
        private void LoaderTableTypeLocation(string[]values)
        {
            flag = false;
            List<TableType> types = _TableStatusService.GetAllTypes();
            TableLocationItems.Clear();
            if (types != null)
            {
                foreach (var tt in types)
                {
                    
                    BaseTableModel ttm=new BaseTableModel(tt.TableTypeId, tt.Name);
                    if (!flag)
                    {
                        LocationSelectedItem = ttm;
                        flag = true;
                    }
                    if(values!=null)
                    foreach (var value in values)
                    {
                        if (string.IsNullOrEmpty(value))
                            continue;
                        if (tt.TableTypeId == int.Parse(value))
                        {
                            ttm.Checked = true;
                        }
                    }
                    TableLocationItems.Add(ttm);
                }
            }
        }

        /// <summary>
        /// 初始化餐桌状态数量
        /// </summary>
        private void InitTableStatusNum()
        {
            TableStatusItems.Clear();
            TableStatusItems.Add(new TableStatusModel(TableStatus.Idle, "空闲(" + _TableItemService.GetNumByStatus(0) + ")"));
            TableStatusItems.Add(new TableStatusModel(TableStatus.Using, "使用(" + _TableItemService.GetNumByStatus(1) + ")"));
            TableStatusItems.Add(new TableStatusModel(TableStatus.Waiting, "待清(" + _TableItemService.GetNumByStatus(2) + ")"));
            TableStatusItems.Add(new TableStatusModel(TableStatus.Scheduled, "预定(" + _TableItemService.GetNumByStatus(3) + ")"));
            TableStatusItems.Add(new TableStatusModel(TableStatus.Excess, "超额(" + _TableItemService.GetNumByStatus(4) + ")"));
        }
        /// <summary>
        /// 初始化餐桌数据
        /// </summary>
        private void InitTableData()
        {
            TypeItems.Clear();

            InitTableLocationItemData(0);
            //List<TableType> types = _TableService.GetAllTypes();
            //List<Location> locations = _TableService.GetAllLocation();
            
        }
        /// <summary>
        /// 初始化餐桌定位数据，主要在主页面显示
        /// status=0表示添加空闲的桌台，status=1表示添加正在使用的桌台，status=2添加待清的桌台
        /// </summary>
        ///  <param name="status">status=0表示初始化加载餐桌定位及桌台数据，status=1表示点击类型加载对应桌台数据</param>
        private void InitTableLocationItemData(int status)
        {
            Config config = _ConfigurationService.Find(TableLocationMapping.TableLocationName[TableLocation.NAME]);
            if (config != null)
            {
                //餐桌定位的拼接类型是编码或者id直接使用下划线分割"_"
                if (config.Disabled == 1)   //餐桌类型
                {
                    if (status==0)
                        TypeItems.Add(new BaseTableModel("所有餐桌"));
                    //
                    string[] values = config.Value.Split(new char[] { '_' });
                    List<TableType> types = _TableStatusService.GetTypesByIds(values);
                    LoaderTableType(types, status);
                }
                else if (config.Disabled == 2)   //区域
                {
                    if (status == 0)
                    TypeItems.Add(new BaseTableModel("所有区域"));
                    string[] values = config.Value.Split(new char[] { '_' });
                    List<Location> locations = _TableStatusService.GetLocationByAllId(values);
                    LoaderLocation(locations, status);
                }
            }
        }
        /// <summary>
        /// 加载餐桌类型
        /// </summary>
        /// <param name="types"></param>
        /// /// <param name="status">status=0表示初始化加载，status=1表示点击类型加载对应桌台</param>
        private void LoaderTableType(List<TableType> types,int status)
        {
            TableItems.Clear();
            if (types != null && types.Count > 0)
                foreach (var type in types)
                {
                    if (status == 0)
                    {
                        BaseTableModel ttms = new BaseTableModel(type.TableTypeId, type.Code, type.Name);
                        TypeItems.Add(ttms);
                    }
                    ICollection<Table> tables = type.Table;
                    LoaderTableItem(tables);
                }
        }
        /// <summary>
        /// 加载区域
        /// </summary>
        /// <param name="locations"></param>
        private void LoaderLocation(List<Location> locations, int status)
        {
            TableItems.Clear();
            if (locations != null && locations.Count > 0)
                foreach (var location in locations)
                {
                    if (status == 0)
                    {
                        BaseTableModel ttms = new BaseTableModel(location.LocationId, location.Code, location.Name);
                        TypeItems.Add(ttms);
                    }
                    ICollection<Table> tables = location.Table;
                    LoaderTableItem(tables);
                }
        }
        /// <summary>
        /// 加载桌台状态
        /// </summary>
        /// <param name="type"></param>
        private void LoaderTableItem(ICollection<Table> tables)
        {
            if (tables != null && tables.Count > 0)
            {
                foreach (var table in tables)
                {
                    ICollection<TableItem> items = table.TableItem;
                    if (items != null && items.Count > 0)
                    {
                        foreach (var item in items)
                        {
                            DeskDishes dd=_DeskDishesService.GetDeskDischesByTableId(item.Id);
                            if (item.Status == 0)
                            {
                                TableItems.Add(new TableItemModel(item.Id + "", table.Name, (double)item.Money, TableStatus.Idle,6 , (int)item.SeatedNum, false));
                            }
                            if (item.Status == 1)
                            {
                                TableItems.Add(new TableItemModel(item.Id + "", table.Name, (double)item.Money, TableStatus.Using, 8, (int)item.SeatedNum, true));
                            }
                            if (item.Status == 2)
                            {
                                TableItems.Add(new TableItemModel(item.Id + "", table.Name, TableStatus.Waiting));
                            }
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 选择餐桌状态时调用
        /// </summary>
        public  void TableSelectionChanged()
        {
            ///TODO 开台或者点菜
            MessageBox.Show("确定要对" + TableSelectedItem.Name+"进行开台吗？","提示",MessageBoxButton.YesNo);
        }
        /// <summary>
        /// 选择餐桌类型或者区域时调用
        /// </summary>
        public void TypeItemSelectionChanged()
        {
            //MessageBox.Show("确定要对进行开台吗？" + TypeSelectedItem.Name + TypeSelectedItem.Id, "提示", MessageBoxButton.YesNo);
            if (TypeSelectedItem.Id == -1)
            {
                InitTableLocationItemData(1);
            }
            else
            {
                List<Table> tables = _TableStatusService.GetTableAndRefByTypeId(TypeSelectedItem.Id);
                TableItems.Clear();
                LoaderTableItem(tables);
            }
            
        }
        /// <summary>
        /// 状态选择时过滤对应的桌台
        /// </summary>
        internal void TableStatusSelectionChanged()
        {
            List<TableItem> items = null;
            switch (TableStatusSelectedItem.Color)
            {
                case TableStatus.Idle:
                   items = _TableItemService.GetDetailByStatus(0);
                    break;
                case TableStatus.Using:
                    items = _TableItemService.GetDetailByStatus(1);
                    break;
                case TableStatus.Waiting:
                    items = _TableItemService.GetDetailByStatus(2);
                    break;
                case TableStatus.Scheduled:
                    items = _TableItemService.GetDetailByStatus(3);
                    break;
                case TableStatus.Excess:
                    items = _TableItemService.GetDetailByStatus(4);
                    break;
            }
            TableItems.Clear();
            if (items != null && items.Count > 0)
            {
                foreach (var item in items)
                {
                    if (item.Status == 0)
                    {
                        TableItems.Add(new TableItemModel(item.Id + "", item.Table.Name, (double)item.Money, TableStatus.Idle, 6, (int)item.SeatedNum, false));
                    }
                    if (item.Status == 1)
                    {
                        TableItems.Add(new TableItemModel(item.Id + "", item.Table.Name, (double)item.Money, TableStatus.Using, 8, (int)item.SeatedNum, true));
                    }
                    if (item.Status == 2)
                    {
                        TableItems.Add(new TableItemModel(item.Id + "", item.Table.Name, TableStatus.Waiting));
                    }
                }
            }
        }
        /// <summary>
        /// 餐桌类型或者区域的选中事件回调
        /// </summary>
        internal void ChectedTableLocation()
        {
            //if (LocationSelectedItem!=null)
            //    LocationSelectedItem.Checked = !LocationSelectedItem.Checked;
            foreach (var type in TableLocationItems)
            {
                if (type.Equals(LocationSelectedItem))
                {
                    type.Checked = !type.Checked;
                }
            }
        }
        /// <summary>
        /// 确定选中的餐桌类型或者区域，记录到数据库中
        /// </summary>
        internal void RecordData()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var type in TableLocationItems)
            {
                if (type.Checked)
                {
                    sb.Append(type.Id).Append("_");
                }
            }
            if(sb.Length>1)
                sb.Remove(sb.Length-1,1);
            _ConfigurationService.Update(TableLocationMapping.TableLocationName[TableLocation.NAME],sb.ToString(),TableXaml.TableType.IsChecked==true?1:2);
            TableXaml.Close();
            TableXaml = null;
            InitTableData();
        }
        /// <summary>
        /// 餐桌定位中选择了桌类定位，显示所有桌类
        /// </summary>
        internal void CheckedTableType()
        {
            LoaderTableTypeLocation(null);
        }
        /// <summary>
        /// 餐桌定位页面中选择区域，显示所有区域
        /// </summary>
        internal void CheckedLocation()
        {
            LoaderTableLocation(null);
        }
        /// <summary>
        /// 跳出加台页面
        /// </summary>
        public void InitAddTable()
        {
            InitBaseTableItemData(1);

            AddTableXaml = new BaseTableWindow();
            AddTableXaml.SelectedBtns.Visibility = Visibility.Collapsed;
            AddTableXaml.Title = "加台(请选择需要加入的桌台!)";
            AddTableXaml.ShowDialog();
        }
        /// <summary>
        /// 根据餐桌状态初始化基餐桌数据
        /// status=0表示添加空闲的桌台，status=1表示添加正在使用的桌台，status=2添加待清的桌台
        /// </summary>
        /// <param name="status">status=0表示添加空闲的桌台，status=1表示添加正在使用的桌台，status=2添加待清的桌台</param>
        private void InitBaseTableItemData(int status)
        {
            BaseTableItems = new ObservableCollection<BaseTableModel>();
            //查数据库
            Config config = _ConfigurationService.Find(TableLocationMapping.TableLocationName[TableLocation.NAME]);
            if (config != null)
            {
                //餐桌定位的拼接类型是编码或者id直接使用下划线分割"_"
                if (config.Disabled == 1)   //餐桌类型
                {
                    string[] values = config.Value.Split(new char[] { '_' });
                    List<TableType> types = _TableStatusService.GetTypesByIds(values);
                    if (types != null && types.Count > 0)
                    {
                        foreach (var type in types)
                        {
                            ICollection<Table> tables = type.Table;
                            InitAddTableData(tables, status);
                        }
                    }
                }
                else if (config.Disabled == 2)   //区域
                {
                    string[] values = config.Value.Split(new char[] { '_' });
                    List<Location> locations = _TableStatusService.GetLocationByAllId(values);
                    if (locations != null && locations.Count > 0)
                    {
                        foreach (var type in locations)
                        {
                            ICollection<Table> tables = type.Table;
                            InitAddTableData(tables, status);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 初始化加台(加席)数据
        /// </summary>
        /// <param name="tables"></param>
        /// <param name="tables">status=0表示添加空闲的桌台，status=1表示添加正在使用的桌台，status=2添加待清的桌台</param>
        private void InitAddTableData(ICollection<Table> tables,int status)
        {
            if (tables != null && tables.Count > 0)
                foreach (var table in tables)
                {
                    ICollection<TableItem> tbItems = table.TableItem;
                    if (tbItems != null && tbItems.Count > 0)
                    {
                        foreach (var item in tbItems)
                        {
                            if (item.Status == status)
                            {
                                BaseTableItems.Add(new BaseTableModel(table.TableId, table.Name));
                            }
                        }
                    }
                }
        }
        /// <summary>
        /// 加台页面选择的桌台
        /// </summary>
        internal void AddTableSelected()
        {
            //foreach (var item in BaseTableItems)
            //{
            //    item.Checked = false;
            //}

            if (BaseTableSelectedItem != null)
            {
                BaseTableSelectedItem.Checked = !BaseTableSelectedItem.Checked;
                if (AddTableXaml.Title.Contains("搭台"))
                {
                    //检查是否有过并台现象，如果有，弹出对话框提示是否要拆台，拆台后关闭页面
                    
                }
            }
        }
        private ObservableCollection<BaseTableModel> _AddTableTemps;
        /// <summary>
        /// 选择新的桌台
        /// </summary>
        internal void SelectedNewTable()
        {
            
            if (!AddTableXaml.Title.Contains("被加入"))    
            {
                if (BaseTableSelectedItem == null || !BaseTableSelectedItem.Checked)
                {
                    MessageBox.Show("请选择需要加席的餐桌!");
                    return;
                }
                _AddTableTemps = new ObservableCollection<BaseTableModel>();
                _AddTableTemps.Add(BaseTableSelectedItem);
                AddTableXaml.Title = "加台(请选择需要被加入的餐台)";
                InitBaseTableItemData(0);
            }
            else
            {
                if (BaseTableSelectedItem == null || !BaseTableSelectedItem.Checked)
                {
                    MessageBox.Show("请选择需要被加入的餐台!");
                    return;
                }
                if (_AddTableTemps!=null)
                    _AddTableTemps.Add(BaseTableSelectedItem);
                ///TODO 打开开台页面
                MessageBox.Show("跳出加台页面");
            }
            
        }
        /// <summary>
        /// 临时集合，用来记录已存在的餐桌
        /// </summary>
        ObservableCollection<BaseTableModel> obs;
        /// <summary>
        /// 根据输入的餐桌编号查找餐桌
        /// </summary>
        internal void QueryNum(string InputNum)
        {
            if (string.IsNullOrEmpty(InputNum) && AddTableXaml.Title.Contains("请选择需要加入的桌台"))
            {
                InitBaseTableItemData(1);
                return;
            }
            else if (string.IsNullOrEmpty(InputNum) && AddTableXaml.Title.Contains("被加入"))
            {
                InitBaseTableItemData(0);
                return;
            }
            if (obs == null)
            {
                obs = new ObservableCollection<BaseTableModel>();
            }
            obs.Clear();
            foreach (var item in BaseTableItems)
            {
                if (item.Name.Contains(InputNum)|| item.Id.ToString() .Contains(InputNum))
                {
                    obs.Add(item);
                }
            }
            BaseTableItems.Clear();
            
            foreach (var ob in obs)
            {
                BaseTableItems.Add(ob);
            }
        }

        /// <summary>
        /// 并台
        /// </summary>
        internal void MergeTable()
        {
            InitBaseTableItemData(1);

            AddTableXaml = new BaseTableWindow();
            AddTableXaml.Title = "餐桌并桌";
            AddTableXaml.NotSelected.Visibility = Visibility.Collapsed;
            AddTableXaml.Commit.Content = "并台";
            AddTableXaml.ShowDialog();
        }

        /// <summary>
        /// 确认合并所选餐桌
        /// </summary>
        internal void SelectedMergeTable()
        {
            _AddTableTemps = new ObservableCollection<BaseTableModel>();
            foreach (var item in BaseTableItems)
            {
                if (item.Checked)
                {
                    _AddTableTemps.Add(item);
                }
            }
            if (_AddTableTemps.Count < 2)
            {
                MessageBox.Show("至少选择两个或者以上的桌台否则不能并台!");
                return;
            }
            
        }
        /// <summary>
        /// 选择所有的桌台
        /// </summary>
        internal void SelectedAllTable()
        {
            foreach (var item in BaseTableItems)
            {
                item.Checked = true;
            }
        }
        /// <summary>
        /// 打开搭台/拆台页面
        /// </summary>
        internal void OpenJoinOrTear()
        {
            InitBaseTableItemData(1);

            AddTableXaml = new BaseTableWindow();
            AddTableXaml.SelectedBtns.Visibility = Visibility.Collapsed;
            AddTableXaml.Title = "搭台(选择需要搭的餐台)";
            AddTableXaml.ShowDialog();
        }
        /// <summary>
        /// 打开开台页面
        /// </summary>
        internal void OpenCreateTable()
        {
            //记录已经选择的桌台
        }
    }
}
