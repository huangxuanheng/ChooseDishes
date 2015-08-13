﻿using GalaSoft.MvvmLight;
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
                        List<DischesWayName>dwns=_DataService.FindAllDishesWayName();
                        DishesWayNameBean = new Model.DishesWayNameBean();
                        int count=DishesWayTypeItems.Count + 1;
                        if (count < 10)
                        {
                            DishesWayNameBean.Code = "0" + count;
                        }
                        else
                        {
                            DishesWayNameBean.Code = count.ToString();
                        } 

                        DishesWayNameBean.LineNumber = count;
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
                    DishesWayBean = DishesWaySelectedItem;
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
            _DishesWayBean.CreateBy = SubjectUtils.GetAuthenticationId();
            _DishesWayBean.CreateDatetime = DateTime.Now;
            _DishesWayBean.DischesWayName = SelectedTreeNode.Text;
            _DishesWayBean.DischesWayNameId = int.Parse(SelectedTreeNode.Id);
            List<DischesWay> dws = _DataService.FindAll();
            StringBuilder sb = new StringBuilder();
            if (DishesWayBean.DischesWayNameId < 10)
            {
                sb.Append("0").Append(DishesWayBean.DischesWayNameId);
            }
            else
            {
                sb.Append(DishesWayBean.DischesWayNameId);
            }
            _DishesWayBean.Code = sb.ToString() + (dws.Count + 1);
            
        }
        
        RelayCommand _DeleteDishesWayMenu;
        public RelayCommand DeleteDishesWayMenu   //删除做法
        {
            get
            {
                return _DeleteDishesWayMenu ?? (_DeleteDishesWayMenu = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
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
                   MessageBoxResult result= MessageBox.Show("您确定要删除该做法吗？!","提示",MessageBoxButton.YesNo,MessageBoxImage.Question);
                   if (result == MessageBoxResult.Yes)
                   {
                       bool IsUpdateSuccess=_DataService.UpdateDeletedById(DishesWaySelectedItem.DischesWayId,1);
                       if (IsUpdateSuccess)
                       {
                           LoadTreeData(SelectedTreeNode);
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
                    List<DischesWayName>dwns=_DataService.FindAllDishesWayName();
                    DishesWayTypeItems.Clear();
                    if (dwns != null)
                    {
                        foreach (var dwn in dwns)
                        {
                            _DishesWayNameBean = new DishesWayNameBean();
                            _DishesWayNameBean.CreateDishesWayNameBean(dwn);
                            DishesWayTypeItems.Add(DishesWayNameBean);
                        }
                    }
                    //做法类型
                    typeXaml = new DishesWayTypeWindow();
                    typeXaml.ShowDialog();
                    Logger.Log("做法类型", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
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
        RelayCommand _RefreshMenu;
        public RelayCommand RefreshMenu   //刷新界面
        {
            get
            {
                return _RefreshMenu ?? (_RefreshMenu = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    //刷新做法页面
                    MessageBox.Show("刷新做法页面");
                   
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
                    foreach (var item in DishesWayTypeItems)
                    {
                        if (item.DischesWayNameId == 0 && string.IsNullOrEmpty(item.Name))   //空名
                        {
                            continue;
                        }
                        DischesWayName dwn=item.CreateDishesWayName(item);
                        if (item.DischesWayNameId == 0)
                        {
                            _DataService.AddDishesWayName(dwn);
                        }

                    }
                    break;
                case SaveType.ITEM:    //做法
                    SaveDishesWay();
                    break;
                default:   //继续
                    SaveDishesWay();
                    InitAddData();
                    break;
            }
        }
        private void SaveDishesWay()
        {

            if (DishesWayBean.Name == null)
            {
                MessageBox.Show("请输入做法名称");
                return;
            }
            bool hasSaveSuccess = false;
            //保存做法，调用数据持久层方法，将数据保存到数据库中
            DischesWay dw = DishesWayBean.CreateDishesWay(DishesWayBean);
            if (DishesWaySettingXaml.Continue.IsVisible)
            {
                //新增
                hasSaveSuccess = _DataService.Add(dw);
                
            }
            else
            {
                //修改
                hasSaveSuccess = _DataService.Modify(dw);
            }
            if (hasSaveSuccess)
            {
                MessageBox.Show("保存成功");
                LoadTreeData(SelectedTreeNode);
            }
            else
            {
                MessageBox.Show("保存失败");
            }
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
            List<DischesWayName>dwns=_DataService.FindAllDishesWayName();
            DishesWayTableItems.Clear();
            if (dwns != null)
            {
                foreach (var dwn in dwns)
                {
                    _RootTreeNode.createChild(dwn.DischesWayNameId.ToString(), dwn.Name);
                    LoadBaseData(dwn, 0);
                }
            }
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
            List<DischesWay> dws = _DataService.FindAllDishesWayByTypeId(wayTypeId);
            if (dws != null)
                foreach (var d in dws)
                {
                    _DishesWayBean = new DishesWayBean();
                    _DishesWayBean.CreateDishesWayBean(d);
                    _DishesWayBean.DischesWayName = dwn.Name;
                    //设置显示行号和编码
                    _DishesWayBean.LineNumber = DishesWayTableItems.Count + 1;
                    StringBuilder sb = new StringBuilder();
                    if (wayTypeId< 10)
                    {
                        if (wayTypeId == 0)
                        {
                            sb.Append(wayTypeId);
                        }
                        else
                         sb.Append("0").Append(wayTypeId);
                    }
                    else
                    {
                        sb.Append(wayTypeId);
                    }
                    sb.Append(d.Code);
                    _DishesWayBean.Code = sb.ToString();
                    if (!SelectedFlag)
                    {
                        DishesWaySelectedItem = DishesWayBean;
                        SelectedFlag = true;
                    }
                    DishesWayTableItems.Add(_DishesWayBean);
                }
        }
    }
}
