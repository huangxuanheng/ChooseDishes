using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Model;
using IShow.ChooseDishes.View.Dishes;
using IShow.ChooseDishes.ViewModel.Common;
using IShow.Common.Log;
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
    public class DishesWayRefViewModel : ViewModelBase
    {
        IDischesWayRefService _DataService;
        IDishesWayDataService _DishesWaySercice;
        IChooseDishesDataService _ChooseDishesService;
        IDishService _DishService;
        ObservableCollection<DishBean> _DishesList;
        public ObservableCollection<DishBean> DishesList  //不是套菜的菜品集合
        {
            get
            {
                return _DishesList ?? (_DishesList = new ObservableCollection<DishBean>());
            }
            set
            {
                this._DishesList = value;
                Set("DishesList", ref _DishesList, value);
            }
        }
        DishBean _SelectedDishItem;
        public DishBean SelectedDishItem    // 菜品
        {
            set
            {
                Set("SelectedDishItem", ref _SelectedDishItem, value);
            }
            get
            {
                return _SelectedDishItem;
            }
        }
        ObservableCollection<DischesWayRefModel> _DishesWayRefTableItems;
        public ObservableCollection<DischesWayRefModel> DishesWayRefTableItems  //做法关联集合
        {
            get
            {
                return _DishesWayRefTableItems ?? (_DishesWayRefTableItems = new ObservableCollection<DischesWayRefModel>());
            }
            set
            {
                this._DishesWayRefTableItems = value;
                Set("DishesWayRefTableItems", ref _DishesWayRefTableItems, value);
            }
        }
        DischesWayRefModel _DishesWayRefSelectedItem;
        public DischesWayRefModel DishesWayRefSelectedItem
        {
            set
            {
                Set("DishesWayRefSelectedItem", ref _DishesWayRefSelectedItem, value);
            }
            get
            {
                return _DishesWayRefSelectedItem;
            }
        }
        DischesWayRefModel _DischesWayRefModel;
        public DischesWayRefModel DischesWayRefModel
        {
            set
            {
                Set("DischesWayRefModel", ref _DischesWayRefModel, value);
            }
            get
            {
                return _DischesWayRefModel;
            }
        }
        
        ObservableCollection<DishesWayBean> _DishesWayTableItems;
        public ObservableCollection<DishesWayBean> DishesWayTableItems  //做法集合
        {
            get
            {
                return _DishesWayTableItems ?? (_DishesWayTableItems = new ObservableCollection<DishesWayBean>());
            }
            set
            {
                this._DishesWayTableItems = value;
                Set("DishesWayTableItems", ref _DishesWayTableItems, value);
            }
        }
        DishesWayBean _DishesWaySelectedItem;
        public DishesWayBean DishesWaySelectedItem    //选择的做法
        {
            set
            {
                Set("DishesWaySelectedItem", ref _DishesWaySelectedItem, value);
            }
            get
            {
                return _DishesWaySelectedItem;
            }
        }

        ObservableCollection<DishesWayBean> _DishesWaySelectedItems;
        public ObservableCollection<DishesWayBean> DishesWaySelectedItems  //批处理做法选中集合
        {
            get
            {
                return _DishesWaySelectedItems ?? (_DishesWaySelectedItems = new ObservableCollection<DishesWayBean>());
            }
            set
            {
                this._DishesWaySelectedItems = value;
                Set("DishesWaySelectedItems", ref _DishesWaySelectedItems, value);
            }
        }
        DishesWayBean _DishesWayTempSelectedItem;
        public DishesWayBean DishesWayTempSelectedItem    //选择的做法
        {
            set
            {
                Set("DishesWayTempSelectedItem", ref _DishesWayTempSelectedItem, value);
            }
            get
            {
                return _DishesWayTempSelectedItem;
            }
        }
        
        ObservableCollection<TreeNodeModel> _DishWayTrees;
        public ObservableCollection<TreeNodeModel> DishWayTrees  //做法目录树
        {
            get
            {
                return _DishWayTrees ?? (_DishWayTrees = new ObservableCollection<TreeNodeModel>());
            }
            set
            {
                this._DishWayTrees = value;
                Set("DishWayTrees", ref _DishWayTrees, value);
            }
        }
        TreeNodeModel _DishWayRootTreeNode;
        public TreeNodeModel DishWayRootTreeNode   //根树
        {
            get
            {
                return _DishWayRootTreeNode;
            }
            set
            {
                Set("DishWayRootTreeNode", ref  _DishWayRootTreeNode, value);
            }
        }

        ObservableCollection<TreeNodeModel> _FirstGeneration;
        public ObservableCollection<TreeNodeModel> FirstGeneration  //目录树
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
        TreeNodeModel _RootTreeNode;
        public TreeNodeModel RootTreeNode   //根树
        {
            get
            {
                return _RootTreeNode;
            }
            set
            {
                Set("RootTreeNode",ref  _RootTreeNode, value);
            }
        }
        
        string _InputQuery;
        public string InputQuery    // 输入查询的参数：菜品名称、菜品编码、拼音编码
        {
            set
            {
                Set("InputQuery", ref _InputQuery, value);
            }
            get
            {
                return _InputQuery;
            }
        }
        DishBean _DishBean;
        public DishBean DishBean    // 菜品
        {
            set
            {
                Set("DishBean", ref _DishBean, value);
            }
            get
            {
                return _DishBean;
            }
        }
        DishesWayBean _DishesWayBean;
        public DishesWayBean DishesWayBean    //菜品做法
        {
            set
            {
                Set("DishesWayBean", ref _DishesWayBean, value);
            }
            get
            {
                return _DishesWayBean;
            }
        }
        TreeNodeModel _SelectedTreeItem;
        public TreeNodeModel SelectedTreeItem
        {
            set
            {
                Set("SelectedTreeItem", ref _SelectedTreeItem, value);
            }
            get
            {
                return _SelectedTreeItem;
            }
        }
        //菜品树的选中事件
        RelayCommand<TreeNodeModel> _SelectedTree;
        public RelayCommand<TreeNodeModel> SelectedTree
        {
            get
            {
                return _SelectedTree ?? (_SelectedTree = new RelayCommand<TreeNodeModel>(node =>
                {
                    
                    Logger.LogMethodEntry();
                    node.Selected = true;
                    SelectedTreeItem = node;
                    IsSelectedDishItem = false;
                    DishesWayRefTableItems.Clear();
                    DishesList.Clear();
                    if (!node.Text.Equals("全部类型"))
                    {
                        if (RootTreeNode.Equals(node.Parent))
                        {

                            //点击的是大类，显示该大类下所有的小类及小类下的所有菜品
                            List<DishType> subs = _DishService.LoadSubTypeByFatherId(int.Parse(node.Id));
                            List<DishUnit> dus = _DishService.QueryAllDishesUnits();
                            if (subs != null && subs.Count > 0)
                                foreach (var sub in subs)
                                {
                                    LoadDishBaseData(dus, sub);
                                }
                        }
                        else
                        {
                            //小类
                            DishType sub = _DishService.LoadSubTypeBySubId(int.Parse(node.Id));
                            List<DishUnit> dus = _DishService.QueryAllDishesUnits();
                            DishesList.Clear();
                            LoadDishBaseData(dus, sub);
                        }
                    }
                    
                    else
                    {
                        LoadTreeData();
                    }
                    Logger.Log("选中的树", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }


        //做法树的选中事件
        RelayCommand<TreeNodeModel> _SelectedWayTree;
        public RelayCommand<TreeNodeModel> SelectedWayTree
        {
            get
            {
                return _SelectedWayTree ?? (_SelectedWayTree = new RelayCommand<TreeNodeModel>(node =>
                {
                    
                    Logger.LogMethodEntry();
                    node.Selected = true;
                    if (node != null && DishWayRootTreeNode.Equals(node.Parent))
                    {
                        List<DischesWayName> dwns = _DishesWaySercice.FindAllDishesWayName();
                        foreach (var dwn in dwns)
                        {
                            if (node.Id.Equals(dwn.DischesWayNameId.ToString()))
                            {
                                DishesWayTableItems.Clear();
                                LoadDishesWayData(dwn, node);
                            }
                        }
                    }
                    else
                    {
                        InitDishesWayTreeData();
                    }
                    Logger.Log("选中的树", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }
        
        RelayCommand _Add;
        public RelayCommand Add  //新增
        {
            get
            {
                return _Add ?? (_Add = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    InitDishWayRootTree();
                    
                    DishesWayRefSelXaml = new DishesWayRefSelView();
                    DishesWayRefSelXaml.ShowDialog();
                    Logger.LogMethodExit();
                }));
            }
        }
        /// <summary>
        /// 加载做法树
        /// </summary>
        private void InitDishWayRootTree()
        {
            DishWayTrees.Clear();
            _DishWayRootTreeNode = new TreeNodeModel("全部做法");
            DishWayTrees.Add(DishWayRootTreeNode);
            InitDishesWayTreeData();
        }
        /// <summary>
        /// 加载做法的树
        /// </summary>
        private void InitDishesWayTreeData()
        {
            List<DischesWayName> dwns = _DishesWaySercice.FindAllDishesWayName();
            DishesWayTableItems.Clear();
            if (dwns != null)
            {
                foreach (var dwn in dwns)
                {
                    TreeNodeModel node = DishWayRootTreeNode.createChild(dwn.DischesWayNameId.ToString(), dwn.Name);
                    node.Expanded = true;
                    LoadDishesWayData(dwn, node);
                }
            }
        }

        private void LoadDishesWayData(DischesWayName dwn, TreeNodeModel node)
        {
                ICollection<DischesWay> dws = dwn.DischesWay;
                if (dws != null)
                {
                    foreach (var d in dws)
                    {
                        if (d.Deleted == 0)
                        {
                            _DishesWayBean = new DishesWayBean();
                            _DishesWayBean.CreateDishesWayBean(d);
                            _DishesWayBean.LineNumber = DishesWayTableItems.Count + 1;
                            DishesWayTableItems.Add(DishesWayBean);
                        }
                    }
                }
        }
        RelayCommand _Deleted;
        public RelayCommand Deleted   //删除
        {
            get
            {
                return _Deleted ?? (_Deleted = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    
                    if (DishesWayRefSelectedItem == null)
                    {
                        MessageBox.Show("请选择需要删除的做法关联");
                        return;
                    }
                    bool flag=_DataService.ModifyDeleted(DishesWayRefSelectedItem.DishId, DishesWayRefSelectedItem.DischesWayId);
                    if (flag)
                    {
                        LoadWayRefData();
                    }
                    Logger.LogMethodExit();
                }));
            }
        }
        RelayCommand _Batch;
        public RelayCommand Batch   //批量
        {
            get
            {
                return _Batch ?? (_Batch = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    if (SelectedTreeItem == null)
                    {
                        MessageBox.Show("请选择菜品类别!");
                        return;
                    }
                    DishesWaySelectedItems.Clear();
                    InitDishWayRootTree();

                    DischesWayRefBatchXaml = new DischesWayRefBatchView();
                    DischesWayRefBatchXaml.ShowDialog();
                    Logger.LogMethodExit();
                }));
            }
        }
        RelayCommand _SelectedAll;
        public RelayCommand SelectedAll   //全选
        {
            get
            {
                return _SelectedAll ?? (_SelectedAll = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    if (DishesWayRefSelXaml != null && DishesWayRefSelXaml.IsActive)
                    {
                        foreach (var select in DishesWayTableItems)
                        {
                            DishesWayRefSelXaml.DishesWay.SelectedItems.Add(select);
                        }
                    }
                    else
                    {
                        
                        DishesWaySelectedItems.Clear();
                        foreach (var select in DishesWayTableItems)
                        {
                            DishesWaySelectedItems.Add(select);
                        }
                    }
                    
                    Logger.LogMethodExit();
                }));
            }
        }
        RelayCommand _SelectedNot;
        public RelayCommand SelectedNot   //全不选
        {
            get
            {
                return _SelectedNot ?? (_SelectedNot = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    if (DishesWayRefSelXaml != null && DishesWayRefSelXaml.IsActive)
                    {
                        DishesWayRefSelXaml.DishesWay.SelectedItems.Clear();
                    }
                    else
                    {
                        DishesWaySelectedItems.Clear();
                    }
                    
                    Logger.LogMethodExit();
                }));
            }
        }
        RelayCommand _Application;
        public RelayCommand Application   //应用
        {
            get
            {
                return _Application ?? (_Application = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    //DishType type = _DishService.LoadSubTypeBySubId(SelectedDishItem.DishId);
                    //type.
                    SaveWayRef();
                    Logger.LogMethodExit();
                }));
            }
        }
        /// <summary>
        /// 保存做法关联
        /// </summary>
        private void SaveWayRef()
        {
            List<DischesWayRef> dwrs = _DataService.QueryAllByDishesId(SelectedDishItem.DishId);

            foreach (var selectedItem in DishesWayRefSelXaml.DishesWay.SelectedItems)
            {
                var item = selectedItem as DishesWayBean;
                if (item != null)
                {
                    bool flag = true;
                    foreach (var dwr in dwrs)
                    {
                        //判断是否已然存在
                        if (item.DischesWayId == dwr.DischesWayId)
                        {
                            flag = false;
                            break;
                        }
                    }
                    //插入到做法关联表中
                    if (flag)   //如果不存在，则添加
                        _DataService.Add(SelectedDishItem.DishId, item.DischesWayId);
                }
            }
            LoadWayRefData();
        }
        RelayCommand _MoveToDown;
        public RelayCommand MoveToDown   //向下移
        {
            get
            {
                return _MoveToDown ?? (_MoveToDown = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    if (DishesWaySelectedItem == null)
                    {
                        return;
                    }
                    if (DischesWayRefBatchXaml.DishesWay.SelectedItems.Count >0)
                    {
                        foreach (var selected in DischesWayRefBatchXaml.DishesWay.SelectedItems)
                        {
                            var select = selected as DishesWayBean;
                            if(select!=null)
                                DishesWaySelectedItems.Add(select);
                        }  
                    }
                    Logger.LogMethodExit();
                }));
            }
        }
        RelayCommand _MoveToUp;
        public RelayCommand MoveToUp   //向上移
        {
            get
            {
                return _MoveToUp ?? (_MoveToUp = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    if(DishesWayTempSelectedItem==null){
                        return;
                    }
                    int count = DishesWaySelectedItems.Count;
                    
                    for (int x = count-1; x >=0; x--)
                    {

                        var selected = DishesWaySelectedItems.ElementAt(x);
                        if (DischesWayRefBatchXaml.DishesWayRef.SelectedItems.Contains(selected))
                            DishesWaySelectedItems.Remove(selected);
                    }
                    Logger.LogMethodExit();
                }));
            }
        }

        RelayCommand _Commit;
        public RelayCommand Commit   //确定
        {
            get
            {
                return _Commit ?? (_Commit = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    if (DishesWayRefSelXaml != null && DishesWayRefSelXaml.IsActive)
                    {
                        //保存
                        SaveWayRef();
                        //关闭
                        DishesWayRefSelXaml.Close();
                    }
                    else
                    {
                        if (RootTreeNode.Equals(SelectedTreeItem.Parent))   //大类
                        {
                            List<DishType>childrens=_DishService.LoadSubTypeByFatherId(int.Parse(SelectedTreeItem.Id));
                            if (childrens != null && childrens.Count > 0)
                            {
                                foreach (var child in childrens)
                                {
                                    SaveBatch(child);
                                }
                            }
                        }
                        else
                        {
                            //小类
                            DishType type=_DishService.LoadSubTypeBySubId(int.Parse(SelectedTreeItem.Id));
                            SaveBatch(type);
                        }
                        LoadWayRefData();
                        DischesWayRefBatchXaml.Close();
                    }
                    
                    Logger.LogMethodExit();
                }));
            }
        }
        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="child"></param>
        private void SaveBatch(DishType child)
        {
            ICollection<Dish> dishes = child.Dish;
            if (dishes != null && dishes.Count > 0)
            {
                foreach (var dish in dishes)
                {
                    //获取菜品下说有的做法
                    List<DischesWayRef> dwrs = _DataService.QueryAllByDishesId(dish.DishId);
                    foreach (var selectedItem in DishesWaySelectedItems)
                    {
                        //根据小类id查找所有的菜品
                        //插入到做法关联表中
                        bool flag = true;
                        foreach (var dwr in dwrs)
                        {
                            //判断是否已然存在
                            if (selectedItem.DischesWayId == dwr.DischesWayId)
                            {
                                flag = false;
                                break;
                            }
                        }
                        if(flag)
                        _DataService.Add(dish.DishId, selectedItem.DischesWayId);
                    }
                }
            }
        }
        RelayCommand _Query;
        public RelayCommand Query   //查询
        {
            get
            {
                return _Query ?? (_Query = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    if (string.IsNullOrEmpty(InputQuery))
                    {
                        LoadTreeData();
                        return;
                    }
                    List<Dish>dishes=_ChooseDishesService.FindDishNotTaoCanList(InputQuery);
                    DishesList.Clear();
                    if (dishes == null || dishes.Count == 0)
                    {
                        return;
                    }
                    List<DishUnit> dus = _DishService.QueryAllDishesUnits();
                    LoadDishData(dus, dishes);
                    Logger.LogMethodExit();
                }));
            }
        }
        
        DishesWayRefSelView DishesWayRefSelXaml { set; get; }
        DischesWayRefBatchView DischesWayRefBatchXaml { set; get; }

        public DishesWayRefViewModel(IDischesWayRefService dataService,IDishesWayDataService dishesWaySercice,IChooseDishesDataService chooseDishesService,IDishService dishService, IMessenger messenger)
            : base(messenger)
        {
            _DataService = dataService;
            _DishesWaySercice = dishesWaySercice;
            _ChooseDishesService=chooseDishesService;
            _DishService = dishService;
            //MessageBox.Show("在初始化做法");
            InitTreeByDishData();
        }
        /// <summary>
        /// 加载根树 _DishBean
        /// </summary>
        private void InitTreeByDishData()
        {
            _RootTreeNode = new TreeNodeModel("全部类型");
            _RootTreeNode.Expanded = true;
            FirstGeneration.Add(_RootTreeNode);
            
            //List<DischesWayRef>dwrs= _DataService.QueryAll();
            LoadTreeData();
        }
        /// <summary>
        /// 加载树及其数据
        /// </summary>
        private void LoadTreeData()
        {
            List<DishType> types = _DishService.LoadFatherType();    //大类
            List<DishType> subs = _DishService.LoadSubTypeAndDishs();   //小类
            List<DishUnit> dus = _DishService.QueryAllDishesUnits();
            DishesList.Clear();
            RootTreeNode.Children.Clear();
            if (types != null)
            {
                foreach (var type in types)
                {
                    TreeNodeModel node = _RootTreeNode.createChild(type.DishTypeId.ToString(), type.Name);
                    if (subs != null && subs.Count > 0)
                    {
                        foreach (var sub in subs)
                        {
                            if (sub.ParentId == int.Parse(node.Id))
                            {
                                TreeNodeModel subNode = node.createChild(sub.DishTypeId.ToString(), sub.Name);
                                LoadDishBaseData(dus, sub);
                            }
                        }
                    }

                }
            }
        }
        /// <summary>
        /// 根据菜品单位和菜品类别对象加载菜品基本数据
        /// </summary>
        /// <param name="dus"></param>
        /// <param name="sub"></param>
        private void LoadDishBaseData(List<DishUnit> dus, DishType sub)
        {
            if (dus == null||sub==null)
            {
                return;
            }
            ICollection<Dish> dishes = sub.Dish;
            LoadDishData(dus, dishes);
        }
        private bool IsSelectedDishItem=false;
        /// <summary>
        /// 根据菜品单位、菜品集合相关数据，显示到界面上
        /// </summary>
        /// <param name="dus"></param>
        /// <param name="dishes"></param>
        private void LoadDishData(List<DishUnit> dus, ICollection<Dish> dishes)
        {
            if (dishes != null && dishes.Count > 0)
            {
                foreach (var dish in dishes)
                {
                    if (dish.Deleted == 1)
                    {
                        continue;
                    }

                    _DishBean = new DishBean();
                    _DishBean.LineNumber1 = DishesList.Count + 1;
                    foreach (var d in dus)
                    {
                        if (d.Deleted == 1)
                        {
                            continue;
                        }
                        if (dish.DishUnitId == d.DishUnitId)
                        {
                            _DishBean.CreateDishBean2DishWay(dish, d);
                        }
                    }
                    if (!IsSelectedDishItem)
                    {
                        SelectedDishItem = DishBean;
                        IsSelectedDishItem=true;
                        LoadRefData(dish);
                    }
                    DishesList.Add(DishBean);
                }
            }
            else if (dishes != null && dishes.Count == 0)
            {
                LoadWayRefData();
            }
        }
        /// <summary>
        /// 加载做法关联的基本数据
        /// </summary>
        /// <param name="dish"></param>
        private void LoadRefData(Dish dish)
        {
            DishesWayRefTableItems.Clear();
            if (dish == null)
            {
                return;
            }
            List<DischesWayRef> dwrs = _DataService.QueryAllByDishesId(dish.DishId);
            if (dwrs != null && dwrs.Count > 0)
                foreach (var dwr in dwrs)
                {
                    _DischesWayRefModel = new DischesWayRefModel();
                    _DischesWayRefModel.LineNumber = DishesWayRefTableItems.Count + 1;
                    _DischesWayRefModel.CreateDischesWayRefModel(dwr);
                    DishesWayRefTableItems.Add(DischesWayRefModel);
                }
        }
        /// <summary>
        /// 保存做法关联价格
        /// </summary>
        public void SavePrice2WayRef()
        {
            if (DishesWayRefSelectedItem == null)
            {
                return;
            }
            _DataService.ModifyByPrice(DishesWayRefSelectedItem.DishId, DishesWayRefSelectedItem.DischesWayId, DishesWayRefSelectedItem.Price);
        }

        public void LoadWayRefData()
        {
            if (SelectedDishItem == null)
            {
                return;
            }
            Dish dish = _ChooseDishesService.FindDishByDishId(SelectedDishItem.DishId);
            LoadRefData(dish);
        }
    }
}
