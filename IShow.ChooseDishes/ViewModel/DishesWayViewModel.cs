using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Model;
using IShow.ChooseDishes.Model.EnumSet;
using IShow.ChooseDishes.Security;
using IShow.ChooseDishes.View.Dishes;
using IShow.ChooseDishes.ViewModel.Common;
using IShow.Common.Log;
using IShow.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IShow.ChooseDishes.ViewModel
{
    public class DishesWayViewModel : ViewModelBase
    {
        IDishesWayDataService _DataService;
        
        #region Binding
        TreeNodeModel _RootTreeNode;
        public TreeNodeModel RootTreeNode   //the root tree
        {
            get
            {
                return _RootTreeNode;
            }
            set
            {
                Set("RootTreeNode", ref _RootTreeNode, value);
            }
        }
        TreeNodeModel _SelectedTreeNode;
        public TreeNodeModel SelectedTreeNode   //the root tree
        {
            get
            {
                return _SelectedTreeNode;
            }
            set
            {
                Set("SelectedTreeNode", ref _SelectedTreeNode, value);
            }
        }
        ObservableCollection<TreeNodeModel> _FirstGeneration;
        public ObservableCollection<TreeNodeModel> FirstGeneration   //目录树
        {
            get
            {
                return _FirstGeneration ?? (_FirstGeneration = new ObservableCollection<TreeNodeModel>());
            }
            set
            {
                this._FirstGeneration = value;
                Set("FirstGeneration", ref _FirstGeneration, value);
            }
        }

        DishesWayNameBean _DishesWayNameBean;

        public DishesWayNameBean DishesWayNameBean   //做法类型对象
        {
            get
            {
                return _DishesWayNameBean;
            }
            set
            {
                Set("DishesWayNameBean", ref _DishesWayNameBean, value);
            }
        }
        
        DishesWayBean _DishesWayBean;

        public DishesWayBean DishesWayBean   //做法列表对象
        {
            get
            {
                return _DishesWayBean;
            }
            set
            {
                Set("DishesWayBean", ref _DishesWayBean, value);
            }
        }

        DishesWayBean _DishesWaySelectedItem;
        public DishesWayBean DishesWaySelectedItem   //做法列表中被选中的行
        {
            get
            {
                return _DishesWaySelectedItem;
            }
            set
            {
                Set("DishesWaySelectedItem", ref _DishesWaySelectedItem, value);
            }
        }

        ObservableCollection<DishesWayBean> _DishesWayTableItems;
        public ObservableCollection<DishesWayBean> DishesWayTableItems    //做法表格集合
        {
            get
            {
                return _DishesWayTableItems ?? (_DishesWayTableItems = new ObservableCollection<DishesWayBean>());
            }
            private set { }
        }

        string _DischesWayCurrentItem;
        public string DischesWayCurrentItem     //修改做法显示的做法类型下的做法总数和当前做法
        {
            get
            {
                return _DischesWayCurrentItem;
            }
            set
            {
                Set("DischesWayCurrentItem", ref _DischesWayCurrentItem, value);
            }
        }


        DishesWayNameBean _DishesWayTypeSelectedItem;

        public DishesWayNameBean DishesWayTypeSelectedItem   //做法类型列表中被选中的行
        {
            get
            {
                return _DishesWayTypeSelectedItem;
            }
            set
            {
                Set("DishesWayTypeSelectedItem", ref _DishesWayTypeSelectedItem, value);
            }
        }
        ObservableCollection<DishesWayNameBean> _DishesWayTypeItems;
        public ObservableCollection<DishesWayNameBean> DishesWayTypeItems    //做法类型表格集合
        {
            get
            {
                return _DishesWayTypeItems ?? (_DishesWayTypeItems = new ObservableCollection<DishesWayNameBean>());
            }
            private set { }
        }
        #endregion



        #region Command
        RelayCommand _Add;
        public RelayCommand Add  //新增
        {
            get
            {
                return _Add ?? (_Add = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    if (typeXaml != null && typeXaml.IsActive)
                    {
                        DishesWayNameBean = new Model.DishesWayNameBean();
                        int count=DishesWayTypeItems.Count + 1;
                        DishesWayNameBean.LineNumber = count;
                        DishesWayNameBean.CreateBy = SubjectUtils.GetAuthenticationId();
                        DishesWayNameBean.CreateDatetime = DateTime.Now;
                        DishesWayTypeItems.Add(DishesWayNameBean);
                    }
                    else
                    {
                        //添加做法
                        OpenDishesWin(ButtonEventType.ADD);
                    }
                    
                    Logger.LogMethodExit();
                }));
            }
        }
        RelayCommand _UpdateDishesWayMenu;
        public RelayCommand UpdateDishesWayMenu   //修改做法
        {
            get
            {
                return _UpdateDishesWayMenu ?? (_UpdateDishesWayMenu = new RelayCommand(() =>
                {
                    //需传一个做法类型编码和做法编码进来
                    Logger.LogMethodEntry();
                    //修改做法
                    OpenDishesWin(ButtonEventType.UPDATE);
                    Logger.LogMethodExit();
                }));
            }
        }
        /// <summary>
        /// 0代表是新增做法类型 1表示修改做法类型
        /// </summary>
        /// <param name="type"></param>
        private void OpenDishesWin(ButtonEventType type)
        {
            DishesWaySettingXaml = new DishesWaySettingWindow();
            switch (type)
            {
                case ButtonEventType.ADD:
                    if (SelectedTreeNode == null)
                    {
                        MessageBox.Show("请选择做法类型!");
                        return;
                    }
                    InitAddData();

                    DishesWaySettingXaml.AddDescription.Visibility = Visibility.Visible;
                    DishesWaySettingXaml.Continue.Visibility = Visibility.Visible;
                    DishesWaySettingXaml.UpdateRecord.Visibility = Visibility.Hidden;
                    break;
                case ButtonEventType.UPDATE:
                    if (DishesWaySelectedItem == null)
                    {
                        MessageBox.Show("请选择要修改的做法!");
                        return;
                    }

                    DishesWayBean = new DishesWayBean();
                    DishesWayBean.IsReadOnlyCode = true;
                    DishesWaySelectedItem.UpdateBy = SubjectUtils.GetAuthenticationId();
                    DishesWaySelectedItem.UpdateDatetime = DateTime.Now;
                    DishesWayBean.CreateDishesWayBean(DishesWaySelectedItem);
                    DishesWayBean.CurrentScaleText = (DishesWayTableItems.IndexOf(DishesWaySelectedItem) + 1) + "/" + DishesWayTableItems.Count;
                    DishesWaySettingXaml.AddDescription.Visibility = Visibility.Hidden;
                    DishesWaySettingXaml.Continue.Visibility = Visibility.Hidden;
                    DishesWaySettingXaml.UpdateRecord.Visibility = Visibility.Visible;
                    break;
            }
            DishesWaySettingXaml.ShowDialog();
        }
        /// <summary>
        /// 初始化新增做法基本数据
        /// </summary>
        private void InitAddData()
        {
            DishesWayBean = new Model.DishesWayBean();
            DishesWayBean.IsReadOnlyCode = false;
            _DishesWayBean.DischesWayName = SelectedTreeNode.Text;
            _DishesWayBean.DischesWayNameId = int.Parse(SelectedTreeNode.Id);
        }
        
        RelayCommand _Deleted;
        public RelayCommand Deleted   //删除做法
        {
            get
            {
                return _Deleted ?? (_Deleted = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    if (typeXaml != null && typeXaml.IsActive)
                    {
                        //删除做法类型
                        if (DishesWayTypeSelectedItem == null)
                        {
                            MessageBox.Show("请选择要删除的做法类型!");
                            return;
                        }
                        if (DishesWayTypeSelectedItem.DischesWayNameId == 0)
                        {
                            DishesWayTypeItems.Remove(DishesWayTypeSelectedItem);
                        }
                        else
                        {
                            //_DataService.UpdateDishesWayNameDeletedTypeById();
                            //先查询该做法类型下是否存在有做法
                            List<DischesWay>dws=_DataService.FindAllDishesWayByTypeId(DishesWayTypeSelectedItem.DischesWayNameId);
                            if (dws != null&&dws.Count>0)
                            {
                                MessageBox.Show("对不起，该做法类型下存在有做法，不能删除!","提示",MessageBoxButton.OK,MessageBoxImage.Warning);
                                return;
                            }
                            bool IsUpdateSuccess=_DataService.UpdateDishesWayNameDeletedTypeById(DishesWayTypeSelectedItem.DischesWayNameId);
                            if (IsUpdateSuccess)
                            {
                                InitDishesWayTypeBaseData();
                                LoadTreeData(null);
                            }
                        }
                        
                    }
                    else
                    {
                        if (SelectedTreeNode == null)
                        {
                            MessageBox.Show("请选择做法类型!");
                            return;
                        }
                        //删除做法 
                        if (DishesWaySelectedItem == null)
                        {
                            MessageBox.Show("请选择要删除的做法!");
                            return;
                        }
                        MessageBoxResult result = MessageBox.Show("您确定要删除该做法吗？!", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            bool IsUpdateSuccess = _DataService.UpdateDeletedById(DishesWaySelectedItem.DischesWayId, 1);
                            if (IsUpdateSuccess)
                            {
                                LoadTreeData(SelectedTreeNode);
                            }
                        }
                    }
                    
                    Logger.Log("删除做法", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }

        RelayCommand _DishesWayTypeMenu;
        public RelayCommand DishesWayTypeMenu   //新增做法类型
        {
            get
            {
                return _DishesWayTypeMenu ?? (_DishesWayTypeMenu = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    InitDishesWayTypeBaseData();
                    //做法类型
                    typeXaml = new DishesWayTypeWindow();
                    typeXaml.ShowDialog();
                    Logger.Log("做法类型", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }
        /// <summary>
        /// 加载做法基本数据
        /// </summary>
        private void InitDishesWayTypeBaseData()
        {
            List<DischesWayName> dwns = _DataService.FindAllDishesWayName();
            DishesWayTypeItems.Clear();
            if (dwns != null)
            {
                foreach (var dwn in dwns)
                {
                    _DishesWayNameBean = new DishesWayNameBean();
                    _DishesWayNameBean.LineNumber = DishesWayTypeItems.Count + 1;
                    _DishesWayNameBean.CreateDishesWayNameBean(dwn);
                    _DishesWayNameBean.UpdateBy = SubjectUtils.GetAuthenticationId();
                    _DishesWayNameBean.UpdateDatetime = DateTime.Now;
                    DishesWayTypeItems.Add(DishesWayNameBean);
                }
            }
        }

        
        RelayCommand _PingYingMenu;
        public RelayCommand PingYingMenu   //生成拼音简码
        {
            get
            {
                return _PingYingMenu ?? (_PingYingMenu = new RelayCommand(() =>
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
        public RelayCommand Refresh   //刷新界面
        {
            get
            {
                return _Refresh ?? (_Refresh = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    //刷新做法页面
                   // MessageBox.Show("刷新做法页面");
                    if (typeXaml != null && typeXaml.IsActive)
                    {
                        InitDishesWayTypeBaseData();
                    }
                    else
                    {
                        LoadTreeData(null);
                    }
                    
                    Logger.Log("刷新做法页面", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }
        RelayCommand _PrintedMenu;
        public RelayCommand PrintedMenu   //打印做法
        {
            get
            {
                return _PrintedMenu ?? (_PrintedMenu = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    //打印
                    MessageBox.Show("打印");

                    Logger.Log("打印", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }
        private bool SelectedFlag = false;
        //树的选中事件
        RelayCommand<TreeNodeModel> _SelectedTree;
        public RelayCommand<TreeNodeModel> SelectedTree
        {
            get
            {
                return _SelectedTree ?? (_SelectedTree = new RelayCommand<TreeNodeModel>(node =>
                {
                    
                    Logger.LogMethodEntry();
                    node.Selected = true;
                    LoadTreeData(node);
                    Logger.Log("选中的树", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }
        /// <summary>
        /// 加载树的选择节点下的数据
        /// </summary>
        /// <param name="node"></param>
        private void LoadTreeData(TreeNodeModel node)
        {
            SelectedFlag = false;
            if (node!=null&&!RootTreeNode.Equals(node))
            {
                SelectedTreeNode = node;
                DischesWayName dwn = _DataService.FindDishesWayNameById(int.Parse(node.Id));
                LoadBaseData(dwn, 1);
            }
            else
            {
                //重新加载数据
                InitTreeByDishesWayData();
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
                    if (DishesWaySettingXaml != null && DishesWaySettingXaml.IsActive)
                    {
                        SaveData(SaveType.ITEM); //保存做法
                    }
                    else if (typeXaml != null && typeXaml.IsActive)
                    {
                        SaveData(SaveType.BIGTYPE);
                    }
                    Logger.Log("保存做法", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }
        //保存数据
        private void SaveData(SaveType index)
        {
            switch (index)
            {
                case SaveType.BIGTYPE:   //做法类型
                    List<DischesWayName>dwns=_DataService.FindAllDishesWayName();
                    foreach (var item in DishesWayTypeItems)
                    {
                        if (item.DischesWayNameId == 0 &&(string.IsNullOrEmpty(item.Name) || string.IsNullOrEmpty(item.Code)))   //空名
                        {
                            continue;
                        }
                        if (item.DischesWayNameId == 0 && string.IsNullOrEmpty(item.Name.Trim()) && string.IsNullOrEmpty(item.Code.Trim()))   //空名
                        {
                            continue;
                        }
                        DischesWayName dwn=item.CreateDishesWayName(item);
                        if (item.DischesWayNameId == 0)
                        {
                            //先根据编号查询数据库中是否已存在
                            DischesWayName dd=_DataService.FindDishesWayNameByCode(item.Code);
                            
                            if (dd != null)
                            {
                                //表示数据库中已然存在
                                MessageBox.Show("对不起，编码重复，不能保存","警告",MessageBoxButton.OK,MessageBoxImage.Warning);
                                return;
                            }
                            _DataService.AddDishesWayName(dwn);
                        }
                        if (dwns != null)
                        {
                            //数据库中如果已经存在的，并且名称是不相同的，则修改该条目，否则什么事也不做
                            foreach (var d in dwns)
                            {
                                if (item.DischesWayNameId == d.DischesWayNameId && !item.Name.Equals(d.Name))
                                {
                                    _DataService.UpdateDishesWayName(dwn);
                                }
                            }
                        }
                    }
                    typeXaml.Close();
                    InitDishesWayTypeBaseData();
                    LoadTreeData(null);
                    break;
                case SaveType.ITEM:    //做法
                    SaveDishesWay(0);
                    break;
                default:   //继续
                    SaveDishesWay(0);
                    InitAddData();
                    break;
            }
        }
        /// <summary>
        /// type=0表示正常保存新增或者修改，其他为上一条记录或者下一条记录保存
        /// </summary>
        /// <param name="type"></param>
        private void SaveDishesWay(int type)
        {
            if (string.IsNullOrEmpty(DishesWayBean.Code))
            {
                MessageBox.Show("请输入做法编码");
                return;
            }
            if (string.IsNullOrEmpty(DishesWayBean.Code.Trim()))
            {
                MessageBox.Show("做法编码不能是空字符!");
                return;
            }
            if (string.IsNullOrEmpty(DishesWayBean.Name))
            {
                MessageBox.Show("请输入做法名称");
                return;
            }
            if (string.IsNullOrEmpty(DishesWayBean.Name.Trim()))
            {
                MessageBox.Show("做法名称不能是空字符!");
                return;
            }
            bool hasSaveSuccess = false;
            //保存做法，调用数据持久层方法，将数据保存到数据库中
            DischesWay dw = DishesWayBean.CreateDishesWay(DishesWayBean);
            if (DishesWaySettingXaml.Continue.IsVisible)
            {
                //新增
                //hasSaveSuccess = _DataService.Add(dw);
                List<DischesWay> ddd=_DataService.FindDishesWayByCode(DishesWayBean.Code);
                if (ddd != null&&ddd.Count>1)
                {
                    //说明已经存在
                    MessageBox.Show("对不起，做法编码重复，不能保存!");
                    return;
                }
                hasSaveSuccess = _DataService.Add(DishesWayBean.Code, DishesWayBean.DischesWayNameId, DishesWayBean.Name, DishesWayBean.PingYing, DishesWayBean.AddPrice, DishesWayBean.AddPriceByNum);
            }
            else
            {
                //修改
                hasSaveSuccess = _DataService.Modify(dw);
            }
            if (hasSaveSuccess)
            {
                MessageBox.Show("保存成功");
                if (type == 0)
                {
                     DishesWaySettingXaml.Close();
                }
                DishesWaySettingXaml.IsTextBoxTextChanged = false;
                LoadTreeData(SelectedTreeNode);
            }
            else
            {
                MessageBox.Show("保存失败");
            }
            DishesWaySettingXaml.IsTextBoxTextChanged = false;
        }
        RelayCommand _Continue;
        public RelayCommand Continue    //继续编辑做法
        {
            get
            {
                return _Continue ?? (_Continue = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    //继续添加做法
                    //1.提示用户是否保存数据
                    SaveData(SaveType.LITTLETYPE);
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
                    Logger.LogMethodExit();
                }));
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
             switch (type)
             {
                 case 0:
                     currentItem = DishesWayTableItems.IndexOf(DishesWaySelectedItem) - 1;
                     break;
                 case 1:
                     currentItem = DishesWayTableItems.IndexOf(DishesWaySelectedItem) + 1;
                     break;
             }
             if (currentItem < 0)
             {
                 MessageBox.Show("已经是第一条记录了！");
                 currentItem = 0;
                 return;
             }
             if (currentItem > DishesWayTableItems.Count - 1)
             {
                 MessageBox.Show("已经是最后一条记录了！");
                 currentItem = DishesWayTableItems.Count - 1;
                 return;
             }
             DishesWaySelectedItem = DishesWayTableItems.ElementAt(currentItem);
             DishesWayBean = DishesWaySelectedItem;
             DishesWayBean.CurrentScaleText = (currentItem + 1) + "/" + DishesWayTableItems.Count;
         }

        #endregion Command

        DishesWaySettingWindow DishesWaySettingXaml { set; get; }   //做法页面
        DishesWayTypeWindow typeXaml { set; get; }    //做法类型页面


        public DishesWayViewModel(IDishesWayDataService dataService, IMessenger messenger)
            : base(messenger)
        {
            _DataService = dataService;
            //MessageBox.Show("在初始化做法");
            InitTreeByDishesWayData();
        }

        private void InitTreeByDishesWayData()
        {
            FirstGeneration.Clear();
            _RootTreeNode = new TreeNodeModel("全部类型");
            _RootTreeNode.Expanded = true;
            FirstGeneration.Add(RootTreeNode);
            new Task(() =>
            {
                List<DischesWayName> dwns = _DataService.FindAllDishesWayName();
                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    DishesWayTableItems.Clear();
                    if (dwns != null)
                    {
                        foreach (var dwn in dwns)
                        {
                            _RootTreeNode.createChild(dwn.DischesWayNameId.ToString(), dwn.Name);
                            LoadBaseData(dwn, 0);
                        }
                    }
                });
            }).Start();
            
           
        }
        /// <summary>
        /// 根据做法类型id查询和显示该做法类型下的所有做法
        /// </summary>
        /// <param name="wayTypeId">做法类型id</param>
        /// <param name="type">type=0表示全部加载数据，并显示到表格中，type！=0表示选中树节点时显示其对应的数据</param>
        private void LoadBaseData(DischesWayName dwn, int type)
        {
            if (dwn == null)
            {
                return;
            }
            int wayTypeId = dwn.DischesWayNameId;
            if (type != 0)
            {
                DishesWayTableItems.Clear();
            }
            
            //加载数据
            ICollection<DischesWay> dws = dwn.DischesWay;
            if (dws != null)
                foreach (var d in dws)
                {
                    if (d.Deleted == 1)
                        continue;
                    _DishesWayBean = new DishesWayBean();
                    _DishesWayBean.CreateDishesWayBean(d);
                    _DishesWayBean.DischesWayName = dwn.Name;
                    //设置显示行号和编码
                    _DishesWayBean.LineNumber = DishesWayTableItems.Count + 1;
                    _DishesWayBean.Code = d.Code;
                    if (!SelectedFlag)
                    {
                        DishesWaySelectedItem = DishesWayBean;
                        SelectedFlag = true;
                    }
                    DishesWayTableItems.Add(_DishesWayBean);
                }
        }
        /// <summary>
        /// 检查文本框文字是否发生改变，如果发生改变则提示
        /// </summary>
        public void CheckedTextChanged()
        {
            if (DishesWaySettingXaml.IsTextBoxTextChanged)
            {
                //文本框中有数据有变动，弹出提示
                MessageBoxResult result = MessageBox.Show("数据有变动，是否保存？", "提示", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    SaveDishesWay(0);
                }
            }
        }
    }
}
