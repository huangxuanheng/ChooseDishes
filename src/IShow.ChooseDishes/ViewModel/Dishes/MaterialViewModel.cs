using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using IShow.ChooseDishes.Service;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.ViewModel.Common;
using IShow.Common.Log;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IShow.ChooseDishes.View.Dishes;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Model;
using GalaSoft.MvvmLight.Threading;
using IShow.ChooseDishes.Security;

namespace IShow.ChooseDishes.ViewModel.Dishes
{
    public class MaterialViewModel : ViewModelBase
    {

        IMaterialDataService _MaterialDataService;

        IRawUnitDataService _RawUnitDataService;
        #region Binding
        Visibility _CodeAndTypeVisibility;
        public Visibility CodeAndTypeVisibility   //修改编码和类型可见
        {
            get
            {
                return _CodeAndTypeVisibility;
            }
            set
            {
                Set("CodeAndTypeVisibility", ref _CodeAndTypeVisibility, value);
            }
        }
        Visibility _StatusVisibility;
        public Visibility StatusVisibility   //修改编码和类型可见
        {
            get
            {
                return _StatusVisibility;
            }
            set
            {
                Set("StatusVisibility", ref _StatusVisibility, value);
            }
        }

        Visibility _ParemerterVisibility;
        public Visibility ParemerterVisibility   //修改编码和类型可见
        {
            get
            {
                return _ParemerterVisibility;
            }
            set
            {
                Set("ParemerterVisibility", ref _ParemerterVisibility, value);
            }
        }
        BaseMaterialBean _BaseMaterialBean;
        public BaseMaterialBean BaseMaterialBean   //原料大类和原料单位的页面属性关联
        {
            get
            {
                return _BaseMaterialBean;
            }
            set
            {
                Set("BaseMaterialBean", ref _BaseMaterialBean, value);
            }
        }
        LittleRawMaterialBean _LittleRawMaterialBean;
        public LittleRawMaterialBean LittleRawMaterialBean   //原料小类设置页面绑定
        {
            get
            {
                return _LittleRawMaterialBean;
            }
            set
            {
                Set("LittleRawMaterialBean", ref _LittleRawMaterialBean, value);
            }
        }

        RawMaterialBean _RawMaterialBean;
        public RawMaterialBean RawMaterialBean   //原料资料的属性绑定
        {
            get
            {
                return _RawMaterialBean;
            }
            set
            {
                Set("RawMaterialBean", ref _RawMaterialBean, value);
                DispatcherHelper.CheckBeginInvokeOnUI(
               () =>
               {
                   base.RaisePropertyChanged("RawMaterialBean");
               });
            }
        }

        LittleRawMaterialBean _SelectedLittleMaterialItem;
        public LittleRawMaterialBean SelectedLittleMaterialItem   //小类列表中被选中的行
        {
            get
            {
                return _SelectedLittleMaterialItem;
            }
            set
            {
                Set("SelectedLittleMaterialItem", ref _SelectedLittleMaterialItem, value);
            }
        }
        BaseMaterialBean _BaseSelectedItem;
        public BaseMaterialBean BaseSelectedItem   //大类和单位列表中被选中的行
        {
            get
            {
                return _BaseSelectedItem;
            }
            set
            {
                Set("BaseSelectedItem", ref _BaseSelectedItem, value);
            }
        }

        RawMaterialBean _SelectedMaterialItem;
        public RawMaterialBean SelectedMaterialItem   //原料资料被选中的行
        {
            get
            {
                return _SelectedMaterialItem;
            }
            set
            {
                Set("SelectedMaterialItem", ref _SelectedMaterialItem, value);
            }
        }


        ObservableCollection<TreeNodeModel> _FirstGeneration;
        //树绑定数据源
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

        ObservableCollection<TreeNodeModel> _LittleFirstGeneration;
        //树绑定数据源
        public ObservableCollection<TreeNodeModel> LittleFirstGeneration   //小类页面中显示的目录树
        {
            get
            {
                return _LittleFirstGeneration ?? (_LittleFirstGeneration = new ObservableCollection<TreeNodeModel>());
            }
            set
            {
                this._LittleFirstGeneration = value;
                Set("LittleFirstGeneration", ref _LittleFirstGeneration, value);
            }
        }
        TreeNodeModel _LittleRootTreeNode;
        public TreeNodeModel LittleRootTreeNode
        {
            get
            {
                return _LittleRootTreeNode;
            }

        }

        TreeNodeModel _RootTreeNode;
        public TreeNodeModel RootTreeNode
        {
            get
            {
                return _RootTreeNode;
            }

        }

        ObservableCollection<BaseMaterialBean> _BaseRawMaterialItems;
        //大类和单位griddata的集合
        public ObservableCollection<BaseMaterialBean> BaseRawMaterialItems
        {
            get
            {
                return _BaseRawMaterialItems ?? (_BaseRawMaterialItems = new ObservableCollection<BaseMaterialBean>());
            }
            set
            {
                this._BaseRawMaterialItems = value;
                Set("BaseRawMaterialItems", ref _BaseRawMaterialItems, value);
            }
        }
        ObservableCollection<LittleRawMaterialBean> _LittleMaterialItems;
        //小类的griddata集合
        public ObservableCollection<LittleRawMaterialBean> LittleMaterialItems
        {
            get
            {
                return _LittleMaterialItems ?? (_LittleMaterialItems = new ObservableCollection<LittleRawMaterialBean>());
            }
            set
            {
                this._LittleMaterialItems = value;
                Set("LittleMaterialItems", ref _LittleMaterialItems, value);
            }
        }

        ObservableCollection<RawMaterialBean> _MaterialItems;
        //小类的griddata集合
        public ObservableCollection<RawMaterialBean> MaterialItems
        {
            get
            {
                return _MaterialItems ?? (_MaterialItems = new ObservableCollection<RawMaterialBean>());
            }
            set
            {
                this._MaterialItems = value;
                Set("MaterialItems", ref _MaterialItems, value);
            }
        }

        
        #endregion Binding

        #region Command
        //树的选中事件
        RelayCommand<TreeNodeModel> _SelectedTree;
        public RelayCommand<TreeNodeModel> SelectedTree
        {
            get
            {
                return _SelectedTree ?? (_SelectedTree = new RelayCommand<TreeNodeModel>(node =>
                {
                    node.Selected = true;
                    SelectedFlag = false;
                    RefreshRawMaterialData(node);
                }));
            }
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="node"></param>
        private void RefreshRawMaterialData(TreeNodeModel node)
        {
            if (node!=null&&!node.Text.Equals("全部类型"))
            {
                SelectedRawNode = node;
                //如果是小类，则显示该小类下的所有的原料资料，如果是大类，则显示所有小类下的所有的原料资料
                
                if (node.Parent.Equals(RootTreeNode))      //是大类
                {
                    MaterialItems.Clear();
                    //根据其小类的所有成员，去数据表里面查找所有的原料资料
                    ObservableCollection<TreeNodeModel> childrens = node.Children;
                    if (childrens != null)
                        for (int x = 0; x < childrens.Count; x++)
                        {
                            var child = childrens.ElementAt(x);   //小类的树对象
                            
                            List<RawMaterial> rms = _MaterialDataService.FindAllRawMaterialByRawIdAndDeletedStatus(int.Parse(child.Id));
                            if (rms != null)
                            {
                                foreach (var rm in rms)   //遍历该小类下的对应的原料资料
                                {
                                    _RawMaterialBean = new Model.RawMaterialBean();
                                    LoadRawMaterialLineAndCode(rm,node.Id);
                                    _RawMaterialBean.CreateRawMaterialBean(rm);
                                    _RawMaterialBean.BigType = node.Text;
                                    _RawMaterialBean.LittleType = child.Text;
                                    if (!SelectedFlag)
                                    {
                                        SelectedMaterialItem = RawMaterialBean;
                                        SelectedFlag = true;
                                    }
                                    InitComboxData();
                                    MaterialItems.Add(RawMaterialBean);
                                }

                            }
                        }
                }
                else
                {
                    //小类
                    List<RawMaterial> rms = _MaterialDataService.FindAllRawMaterialByRawIdAndDeletedStatus(int.Parse(node.Id));
                    MaterialItems.Clear();
                    if (rms != null)
                    {
                        foreach (var rm in rms)   //遍历该小类下的对应的原料资料
                        {
                            _RawMaterialBean = new Model.RawMaterialBean();
                            LoadRawMaterialLineAndCode(rm,node.Parent.Id);
                            _RawMaterialBean.CreateRawMaterialBean(rm);
                            _RawMaterialBean.BigType = node.Text;
                            _RawMaterialBean.LittleType = node.Text;
                            InitComboxData();
                            if (rm.Equals(rms.ElementAt(0)))
                            {
                                SelectedMaterialItem = _RawMaterialBean;
                            }
                            MaterialItems.Add(RawMaterialBean);
                        }

                    }
                }
            }
            else
            {
                SelectedRawNode = null;
                //显示全部的原料资料
                //LoadTreeAndDataMaterial();
                LoadAllMaterialData();
            }
        }

        //小类树的选中事件
        RelayCommand<TreeNodeModel> _LittleSelectedTree;
        public RelayCommand<TreeNodeModel> LittleSelectedTree
        {
            get
            {
                return _LittleSelectedTree ?? (_LittleSelectedTree = new RelayCommand<TreeNodeModel>(node =>
                {
                    node.Selected = true;
                    if (node!=null&&!node.Text.Equals("全部大类"))
                    {
                        LittleRawViewXaml.Add.IsEnabled = true;
                        SelectedLittleRawNode = node;
                        //显示所有的小类
                        LoadLittleRawMaterial(node);
                    }
                    else
                    {
                        LittleRawViewXaml.Add.IsEnabled = false;
                        SelectedLittleRawNode = null;
                        InitLittleRawMaterial();
                        //显示全部的原料资料
                    }
                }));
            }
        }
        //加载选中项
        private void LoadLittleRawMaterial(TreeNodeModel node)
        {
            new Task(() =>
            {
                List<Raw> raws = _MaterialDataService.FindAllRawByBigRawIdAndDeletedStatus(int.Parse(node.Id));
                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    LittleMaterialItems.Clear();
                    if (raws != null)
                    {
                        foreach (var raw in raws)
                        {
                            _LittleRawMaterialBean = new LittleRawMaterialBean();
                            _LittleRawMaterialBean.Code = (LittleMaterialItems.Count + 1).ToString();
                            _LittleRawMaterialBean.ParentRaw = node.Text;
                            _LittleRawMaterialBean.CreateLittleRawMaterialBean(raw);
                            LittleMaterialItems.Add(LittleRawMaterialBean);
                        }
                    }
                });
            }).Start();
        }

        RelayCommand _Add;
        public RelayCommand Add   //新增
        {
            get
            {
                return _Add ?? (_Add = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                   
                    int index = -1;
                    if (LittleRawViewXaml != null && LittleRawViewXaml.IsActive)
                    {
                        index = 2;   //小类
                    }
                    else if (BaseMaterialXaml != null && BaseMaterialXaml.IsActive && BaseMaterialXaml.WindowTitle.Title.Equals("原料大类设置"))
                    {
                        //大类
                        index = 1;
                        //  MessageBox.Show("原料大类设置");
                    }
                    else if (BaseMaterialXaml != null && BaseMaterialXaml.IsActive && BaseMaterialXaml.WindowTitle.Title.Equals("原料单位设置"))
                    {
                        index = 3;
                    }
                    AddData(index);

                    Logger.LogMethodExit();
                }));
            }
        }
        RelayCommand _Update;
        public RelayCommand Update   //修改
        {
            get
            {
                return _Update ?? (_Update = new RelayCommand(() =>
                {

                    Logger.LogMethodEntry();
                    ShowUpdateDetail();
                    Logger.LogMethodExit();
                    return;
                }));
            }
        }
        /// <summary>
        /// 显示修改详情页面
        /// </summary>
        public  void ShowUpdateDetail()
        {
            if (SelectedMaterialItem == null)
            {
                //弹框
                MessageBox.Show("请选择需要修改的原料!");
                return;
            }
            

            InitComboBoxBaseData();
            
            RawMaterialXaml = new RawMaterialView();
            //隐藏继续按钮
            RawMaterialXaml.Continue.Visibility = Visibility.Hidden;
            RawMaterialXaml.RecordControll.Visibility = Visibility.Visible;

            RawMaterialXaml.ShowDialog();
        }
        private List<RawUnit> rawUtils=null;
        /// <summary>
        /// 初始化详情页的下拉选择框的基本数据
        /// </summary>
        private void InitComboBoxBaseData()
        {
            RawMaterialBean = SelectedMaterialItem;
            rawUtils = _RawUnitDataService.FindRawUnitByDeletedStatus();
            InitComboxData();
            RawMaterialBean.UpdateDatetime = DateTime.Now;
            RawMaterialBean.CurrentScale = (MaterialItems.IndexOf(SelectedMaterialItem) + 1) + "/" + MaterialItems.Count;
        }
        RelayCommand _Deleted;
        public RelayCommand Deleted   //删除
        {
            get
            {
                return _Deleted ?? (_Deleted = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    int index = -1;
                    if (LittleRawViewXaml != null && LittleRawViewXaml.IsActive)
                    {
                        index = 2;   //小类
                    }
                    else if (BaseMaterialXaml != null && BaseMaterialXaml.IsActive && BaseMaterialXaml.WindowTitle.Title.Equals("原料大类设置"))
                    {
                        //大类
                        index = 1;
                    }
                    else if (BaseMaterialXaml != null && BaseMaterialXaml.IsActive && BaseMaterialXaml.WindowTitle.Title.Equals("原料单位设置"))
                    {
                        index = 3;
                    }
                    DeletedDataFromSelected(index);
                    Logger.Log("删除", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }
        //删除
        private void DeletedDataFromSelected(int type)
        {
            switch (type)
            {
                default:  //原料资料
                    if (SelectedMaterialItem == null)
                    {
                        return;
                    }
                   bool kkk= _MaterialDataService.UpdateRawMaterialDeletedStatusById(SelectedMaterialItem.Id,1);
                   if (kkk)
                   {
                       MaterialItems.RemoveAt(MaterialItems.IndexOf( SelectedMaterialItem));
                       SelectedMaterialItem = MaterialItems.ElementAt(MaterialItems.Count - 1);
                   }
                    break;
                case 1:   //大类
                    if (_BaseSelectedItem == null)
                    {
                        MessageBox.Show("请选择需要删除的大类！");
                        return;
                    }
                   
                    //判断是否是新建的，如果是，则BaseSelectedItem.Id=0
                    if (BaseSelectedItem.Id == 0)
                    {
                        _BaseRawMaterialItems.Remove(BaseSelectedItem);
                        return;
                    }
                    new Task(() =>
                    {
                        //先查改大类下面是否还有小类，如果有，但小类状态为删除状态的，则可以删除，否则不可以
                        List<Raw> raws = _MaterialDataService.FindAllRawByBigRawIdAndDeletedStatus(BaseSelectedItem.Id);
                        if (raws != null)
                        {
                            //表示该大类下有小类，不能删除
                            MessageBox.Show("指定原料大类已有小类或者原料资料记录，不能删除");
                            return;
                        }
                        bool flag = _MaterialDataService.UpdateRawDeletedStatusById(BaseSelectedItem.Id, 1);
                        if (flag)
                        {
                            //从新加载界面
                            DispatcherHelper.CheckBeginInvokeOnUI(() =>
                            {
                                LoadBigRaw();
                                LoadTreeAndDataMaterial();
                            });
                            
                        }
                        else
                        {
                            MessageBox.Show("对不起，删除失败！");
                            return;
                        }
                    }).Start();
                    break;
                case 2:  //小类
                    if (_SelectedLittleMaterialItem == null)
                    {
                        MessageBox.Show("请选择需要删除的小类！");
                        return;
                    }
                   
                    if (_SelectedLittleMaterialItem.RawId == 0)
                    {
                        _LittleMaterialItems.Remove(SelectedLittleMaterialItem);
                        return;
                    }
                    new Task(() =>
                    {
                        //先查询在该小类下是否有原料资料记录，如果有，则不能删除
                        List<RawMaterial>rms= _MaterialDataService.FindAllRawMaterialByRawIdAndDeletedStatus(_SelectedLittleMaterialItem.RawId);
                        if (rms == null)
                        {
                            bool flag = _MaterialDataService.UpdateRawDeletedStatusById(_SelectedLittleMaterialItem.RawId, 1);
                            DispatcherHelper.CheckBeginInvokeOnUI(() =>
                            {
                                if (flag)
                                {
                                    if (SelectedLittleRawNode != null)
                                        LoadLittleRawMaterial(SelectedLittleRawNode);
                                    else
                                    {
                                        InitLittleRawMaterial();
                                    }
                                    //主界面数据从新加载
                                    LoadTreeAndDataMaterial();
                                }
                                else
                                {
                                    MessageBox.Show("对不起，删除失败！");
                                    return;
                                }
                            });
                        }
                        else
                        {
                            MessageBox.Show("该小类下有原料记录，不能删除!");
                            return;
                        }
                           
                    }).Start();
                    break;
                case 3:  //单位
                    if (_BaseSelectedItem == null)
                    {
                        MessageBox.Show("请选择需要删除的单位！");
                        return;
                    }
                    else
                    {
                        if (BaseSelectedItem.Id == 0)
                        {
                            _BaseRawMaterialItems.Remove(BaseSelectedItem);
                            return;
                        }
                        new Task(() =>
                        {
                            //先查改大类下面是否还有小类，如果有，但小类状态为删除状态的，则可以删除，否则不可以
                            List<RawMaterial> rms = _MaterialDataService.FindAllRawMaterialByRawUnitId(BaseSelectedItem.Id);
                            if (rms != null)
                            {
                                MessageBox.Show("指定单位有原料资料记录，不能删除");
                                return;
                            }

                            // bool flag = _MaterialDataService.UpdateRawDeletedStatusById(BaseSelectedItem.Id, 1);
                            //先在数据库中查看是否有记录。如果有，则从数据库中删除，否则直接从界面中删除
                            bool flag = _RawUnitDataService.UpdateRawUnitDeletedStatusById(BaseSelectedItem.Id, 1);
                            DispatcherHelper.CheckBeginInvokeOnUI(() =>
                            {
                                if (flag)
                                {
                                    //从新加载界面
                                    LoadRawUnit();
                                }
                                else
                                {
                                    MessageBox.Show("对不起，删除失败！");
                                    return;
                                }
                            });
                            
                        }).Start();

                    }
                    break;
            }
        }
        RelayCommand _BigType;
        public RelayCommand BigType   //大类
        {
            get
            {
                return _BigType ?? (_BigType = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    LoadBigRaw();
                    BaseMaterialXaml = new BaseMaterialView();
                    BaseMaterialXaml.WindowTitle.Title = "原料大类设置";
                    BaseMaterialXaml.Code.Header = "大类编码";
                    BaseMaterialXaml.Name.Header = "大类名称";
                    BaseMaterialXaml.ShowDialog();
                    Logger.Log("大类", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }
        //加载大类
        private void LoadBigRaw()
        {
            new Task(() =>
            {
                List<Raw> raws = _MaterialDataService.FindAllBigRawByDeletedStatus();
                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    if (raws != null)
                    {
                       
                        BaseRawMaterialItems.Clear();
                        foreach (var raw in raws)
                        {
                            _BaseMaterialBean = new BaseMaterialBean();
                            _BaseMaterialBean.CreateBaseMaterialBean(raw);
                            _BaseMaterialBean.Code = (BaseRawMaterialItems.Count + 1).ToString();
                            BaseRawMaterialItems.Add(BaseMaterialBean);
                        }
                    }
                });
            }).Start();

        }
        RelayCommand _LittleType;
        public RelayCommand LittleType   //小类
        {
            get
            {
                return _LittleType ?? (_LittleType = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();

                    InitLittleRawMaterial();
                    LittleRawViewXaml = new LittleRawView();
                    if (_LittleRootTreeNode != null && !_LittleRootTreeNode.Selected)
                    {
                        LittleRawViewXaml.Add.IsEnabled = false;
                    }
                    LittleRawViewXaml.ShowDialog();

                    Logger.Log("小类", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }
        //加载小类树和对应的数据
        private void InitLittleRawMaterial()
        {
            _LittleRootTreeNode = null;
            _LittleRootTreeNode = new TreeNodeModel("全部大类");
            _LittleRootTreeNode.Expanded = true;

            List<Raw> raws = _MaterialDataService.FindAllBigRawByDeletedStatus();
            if (raws != null)
            {
                LittleMaterialItems.Clear();
                foreach (var raw in raws)
                {
                    if (raw.ParentRawId == 0 || raw.ParentRawId == null)
                    {
                        TreeNodeModel node = new TreeNodeModel(raw.Name, _LittleRootTreeNode);
                        _LittleRootTreeNode.Children.Add(node);
                        node.Id = raw.RawId.ToString();
                        //根据大类编号查找全部的小类
                        List<Raw> childrens = _MaterialDataService.FindAllRawByBigRawIdAndDeletedStatus(raw.RawId);
                        if (childrens != null)
                        {
                            foreach (var child in childrens)
                            {
                                _LittleRawMaterialBean = new LittleRawMaterialBean();
                                _LittleRawMaterialBean.CreateLittleRawMaterialBean(child);
                                _LittleRawMaterialBean.Code = (LittleMaterialItems.Count + 1).ToString();
                                _LittleRawMaterialBean.ParentRaw = node.Text;
                                _LittleMaterialItems.Add(LittleRawMaterialBean);
                            }
                        }

                    }

                }
            }

            _LittleFirstGeneration = new ObservableCollection<TreeNodeModel>(new TreeNodeModel[] { _LittleRootTreeNode });
        }
        RelayCommand _Unit;
        public RelayCommand Unit   //单位
        {
            get
            {
                return _Unit ?? (_Unit = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    //从数据库中读书数据
                    LoadRawUnit();
                    BaseMaterialXaml = new BaseMaterialView();
                    BaseMaterialXaml.WindowTitle.Title = "原料单位设置";
                    BaseMaterialXaml.Code.Header = "单位编码";
                    BaseMaterialXaml.Name.Header = "单位名称";
                    BaseMaterialXaml.ShowDialog();

                    Logger.Log("单位", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }
        //加载原料单位
        private void LoadRawUnit()
        {
            new Task(() =>
            {
                List<RawUnit> units = _RawUnitDataService.FindRawUnitByDeletedStatus();
                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    if (units != null)
                    {
                        BaseRawMaterialItems.Clear();
                        foreach (var unit in units)
                        {
                            _BaseMaterialBean = new BaseMaterialBean();
                            _BaseMaterialBean.CreateBaseMaterialBean(unit);
                            _BaseMaterialBean.Code = (BaseRawMaterialItems.Count + 1).ToString();
                            BaseRawMaterialItems.Add(BaseMaterialBean);
                        }
                    }
                });
            }).Start();
        }
        RelayCommand _RefreshMenu;
        public RelayCommand RefreshMenu   //刷新界面
        {
            get
            {
                return _RefreshMenu ?? (_RefreshMenu = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();

                    Logger.Log("刷新页面", LOGSEVERITY.Debug);
                    RefreshRawMaterialData(SelectedRawNode);
                    Logger.LogMethodExit();
                }));
            }
        }
        RelayCommand _PrintedMenu;
        public RelayCommand PrintedMenu   //打印
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

        RelayCommand _Save;
        public RelayCommand Save   //保存
        {
            get
            {
                return _Save ?? (_Save = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    // MessageBox.Show("保存" + LittleRawViewXaml.IsActive);
                    Logger.Log("保存", LOGSEVERITY.Debug);
                    int index = -1;
                    if (RawMaterialXaml != null && RawMaterialXaml.IsActive)
                    {
                        index = 0;
                    }
                    else if (LittleRawViewXaml != null && LittleRawViewXaml.IsActive)
                    {
                        index = 2;   //小类
                    }
                    else if (BaseMaterialXaml != null && BaseMaterialXaml.IsActive && BaseMaterialXaml.WindowTitle.Title.Equals("原料大类设置"))
                    {
                        //大类
                        index = 1;
                    }
                    else if (BaseMaterialXaml != null && BaseMaterialXaml.IsActive && BaseMaterialXaml.WindowTitle.Title.Equals("原料单位设置"))
                    {
                        index = 3;
                    }
                    SaveData(index);
                    Logger.LogMethodExit();
                }));
            }
        }
        RelayCommand _Continue;
        public RelayCommand Continue
        {
            get
            {
                return _Continue ?? (_Continue = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                   // MessageBox.Show("继续");
                    //保存新增数据、保存成功后，把相关数据清空，只留下基本数据，如大类、小类等
                    SaveRawMaterial(2);
                    Logger.LogMethodExit();
                }));
            }
        }
        int current = 0;
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
                    currentItem = MaterialItems.IndexOf(SelectedMaterialItem) - 1;
                    break;
                case 1:
                    currentItem = MaterialItems.IndexOf(SelectedMaterialItem) + 1;
                    break;
            }
            if (currentItem < 0)
            {
                MessageBox.Show("已经是第一条记录了！");
                currentItem = 0;
                return;
            }
            if (currentItem > MaterialItems.Count - 1)
            {
                MessageBox.Show("已经是最后一条记录了！");
                currentItem = MaterialItems.Count - 1;
                return;
            }
            SelectedMaterialItem = MaterialItems.ElementAt(currentItem);

            InitComboBoxBaseData();

        }
        #endregion Command

        LittleRawView LittleRawViewXaml { set; get; }
        BaseMaterialView BaseMaterialXaml { set; get; }
        RawMaterialView RawMaterialXaml { set; get; }

        TreeNodeModel SelectedLittleRawNode;   //被选中的小类页面的树

        TreeNodeModel SelectedRawNode;      //被选中的主页面的树
        //type=0表示保存原料资料，type=1表示保存大类，type=2表示保存小类，type=3表示保存单位
        private void SaveData(int type)
        {
            switch (type)
            {
                case 0:  //原料资料

                    //MessageBox.Show("原料资料名称=" + RawMaterialBean.BigType + RawMaterialBean.SelectedInGoodsUnitItem.Name);
                    //判断该也面对 继续 按钮是否可见，如果可见，则说明是新增页面，否则是修改页面
                    if (RawMaterialXaml != null && RawMaterialXaml.Continue.IsVisible)
                    {
                        SaveRawMaterial(1);
                    }
                    else
                    {
                        SaveRawMaterial(0);
                    }
                    
                    break;
                case 1:   //大类
                    SaveBigRaw();
                    break;
                case 2:  //小类
                    SaveLittleRawMaterial();
                    break;
                case 3:  //单位
                    SaveRawUnit();
                    break;
            }
        }
        /// <summary>
        /// 保存原料资料，
        /// </summary>
        /// <param name="type">1代表是新增、0代表是修改,2继续</param>
        private void SaveRawMaterial(int type)
        {
            bool flag = false;
            RawMaterial rm = null;
          
            switch (type)
            {
                case 0:   //修改
                    _RawMaterialBean.UpdateBy = SubjectUtils.GetAuthenticationId();
                    _RawMaterialBean.UpdateDatetime = DateTime.Now;
                    rm = RawMaterialBean.CreateRawMaterial(_RawMaterialBean);
                    flag = _MaterialDataService.UpdateRawMaterial(rm);
                    break;
                default:   //新增
                    //先判断名称是否为空，如果为空，则弹框提示不能保存
                    if (string.IsNullOrEmpty(RawMaterialBean.MaterialName))
                    {
                        if (type == 2)
                        {
                            //AddRawMaterialBaseData();
                            return;
                        }
                        MessageBox.Show("原料资料不能为空!");
                        return;
                    }
                    //先查找数据表中是否存在此原料
                    List<RawMaterial> rms = _MaterialDataService.FindRawMaterialByName(RawMaterialBean.MaterialName);
                    _RawMaterialBean.CreateDatetime = DateTime.Now;
                    _RawMaterialBean.CreateBy = SubjectUtils.GetAuthenticationId(); 
                    rm = RawMaterialBean.CreateRawMaterial(_RawMaterialBean);
                    if (rms == null)
                    {
                        //说明数据库中不存在此原料资料
                        //直接插入到数据库中
                        flag = _MaterialDataService.AddRawMaterial(rm);
                    }
                    else
                    {
                        MessageBoxResult result = MessageBox.Show("已存在相同名称的原料资料，是否保存？", "提示", MessageBoxButton.YesNo);
                        if (result == MessageBoxResult.Yes)
                        {
                            // MessageBox.Show("原料资料不能为空! Yes" );
                            flag = _MaterialDataService.AddRawMaterial(rm);
                        }
                    }
                    break;   
            }
            if (flag && SelectedRawNode!=null)
            {
                RefreshRawMaterialData(SelectedRawNode);
            }
            if (type == 2 && flag)
            {
                AddRawMaterialBaseData();
                return;
            }
            
            if (flag)
            {
                MessageBox.Show("保存成功");
            }
            else
            {
                MessageBox.Show("对不起，保存失败!");
            }

        }
        //保存单位
        private void SaveRawUnit()
        {
            bool flag = false;
            if (BaseRawMaterialItems != null && BaseRawMaterialItems.Count > 0)
            {
                foreach (var brm in BaseRawMaterialItems)
                {
                    //1.先检查是否存在有空名字，如果有，则弹框，不能保存
                    if (brm.Id != 0&&string.IsNullOrEmpty(brm.Name))
                    {
                        //原有记录中有空名称，弹框提示
                        MessageBox.Show("单位名称不能为空！");
                        return;
                    }
                    if (brm.Id == 0 && string.IsNullOrEmpty(brm.Name))   //无效的单位，不保存
                    {
                        continue;
                    }
                    RawUnit ru = _BaseMaterialBean.CreateRawUnitBean(brm);
                    if (brm.Id != 0)
                    {
                        //修改
                        flag=_RawUnitDataService.UpdateRawUnit(ru);
                        continue;
                    }
                    if (brm.Id == 0)
                    {
                        //2.根据名字去查找数据库，看是否有相同的，如果有，弹框，不能保存
                        if (_RawUnitDataService.FindRawUnitByName(brm.Name) != null)
                        {
                            MessageBox.Show("单位名称有重复，不能保存!");
                            return;
                        }
                        //保存
                        RawUnit  r= _RawUnitDataService.AddRawUnit(ru);
                        if (r!=null)
                        {
                            _BaseMaterialBean.Id = r.UnitId;
                        }
                    }
                    
                }
            }
            if (flag)
            {
                MessageBox.Show("保存成功");
                LoadTreeAndDataMaterial();
            }
            else
            {
                MessageBox.Show("对不起，由于系统原因保存失败，请稍后再试");
            }
        }

        //保存大类
        private void SaveBigRaw()
        {
            bool flag = false;
           
            Raw raw = null;
            if (BaseRawMaterialItems != null && BaseRawMaterialItems.Count > 0)
            {
                foreach (var bean in BaseRawMaterialItems)
                {
                    //名称相同可以保存。如果是新添加的数据，名称为空忽略不弹框，有变动则提示数据有改动，是否要保存
                   
                    if (bean.Id!=0&&string.IsNullOrEmpty(bean.Name))
                    {
                        MessageBox.Show("未指定大类名称，不能保存");
                        return;
                    }
                    
                    if (bean.Id == 0 && string.IsNullOrEmpty(bean.Name))   //表示是新增的，如果名称为空，则不保存
                    {
                        continue;
                    }
                    if (bean.Id == 0)
                    {
                        bean.ParentRawId = 0;
                        raw=bean.CreateRaw(bean);
                        flag = _MaterialDataService.AddRaw(raw);
                        continue;
                    }
                    bean.CreateBy = SubjectUtils.GetAuthenticationId(); 
                    bean.UpdateDatetime = DateTime.Now;
                    raw = bean.CreateRaw(bean);
                    flag=_MaterialDataService.UpdateRaw(raw);
                    
                }
                //从新读取数据，加载数据
                LoadBigRaw();
            }
            if (flag)
            {

                MessageBox.Show("保存成功");
                LoadTreeAndDataMaterial();
            }
            else
            {
                MessageBox.Show("对不起，由于系统原因保存失败，请稍后再试");
            }
        }
        //保存小类
        private void SaveLittleRawMaterial()
        {
            bool flag = false;
            Raw raw = null;
            //遍历所有的小类列表，查找数据库是否存在，如果存在，则修改，否则保存
            if (_LittleMaterialItems != null && _LittleMaterialItems.Count > 0)
            {

                foreach (var bean in LittleMaterialItems)
                {
                    if (bean.RawId != 0 && string.IsNullOrEmpty(bean.Name))
                    {
                        MessageBox.Show("未指定小类名称，不能保存");
                        return;
                    }
                    if (bean.RawId == 0 && string.IsNullOrEmpty(bean.Name))   //表示是新增的，如果名称为空，则不保存
                    {
                        continue;
                    }
                    if (bean.RawId == 0)
                    {
                        raw=bean.CreateRaw(bean);
                        flag=_MaterialDataService.AddRaw(raw);
                        continue;
                    }
                    bean.UpdateBy = SubjectUtils.GetAuthenticationId(); 
                    bean.UpdateDatetime = DateTime.Now;
                    raw = bean.CreateRaw(bean);
                    flag=_MaterialDataService.UpdateRaw(raw);
                }
            }
            if (flag)
            {
                MessageBox.Show("保存成功");
                LoadTreeAndDataMaterial();
            }
        }
        //type=0表示新增原料资料，type=1表示新增大类，type=2表示新增小类，type=3表示新增单位
        private void AddData(int type)
        {
            switch (type)
            {
                case 1:   //新增大类
                    
                    _BaseMaterialBean = new BaseMaterialBean();
                    _BaseMaterialBean.Name = "";
                    _RawMaterialBean.CreateBy = SubjectUtils.GetAuthenticationId();
                    _RawMaterialBean.CreateDatetime = DateTime.Now;
                    _BaseMaterialBean.Code = (BaseRawMaterialItems.Count + 1).ToString();
                    BaseRawMaterialItems.Add(BaseMaterialBean);
                    break;
                case 2:  //小类
                    if (SelectedLittleRawNode != null)
                    {
                        _LittleRawMaterialBean = new LittleRawMaterialBean();
                        _LittleRawMaterialBean.Name = "";
                        _LittleRawMaterialBean.Code = (LittleMaterialItems.Count + 1).ToString();
                        _LittleRawMaterialBean.ParentRawId = int.Parse(SelectedLittleRawNode.Id);
                        _LittleRawMaterialBean.ParentRaw = SelectedLittleRawNode.Text;
                        _LittleRawMaterialBean.CreateBy = SubjectUtils.GetAuthenticationId();
                        _LittleRawMaterialBean.CreateDatetime = DateTime.Now;
                        LittleMaterialItems.Add(LittleRawMaterialBean);
                    }
                    break;
                case 3:  //单位
                    _BaseMaterialBean = new BaseMaterialBean();
                    _BaseMaterialBean.Name = "";
                    _BaseMaterialBean.Code = (BaseRawMaterialItems.Count + 1).ToString();
                    _RawMaterialBean.CreateBy = SubjectUtils.GetAuthenticationId();
                    _RawMaterialBean.CreateDatetime = DateTime.Now;
                    BaseRawMaterialItems.Add(BaseMaterialBean);
                    break;
                default:  //原料资料
                    //把界面上的一下东东隐藏和显示
                    if (SelectedRawNode == null || SelectedRawNode.Parent.Equals(RootTreeNode))
                    {
                        MessageBox.Show("请选择原料小类");
                        return;
                    }
                    else
                    {
                        //是小类，弹出新增原料页面
                        AddRawMaterialBaseData();
                        RawMaterialXaml = new RawMaterialView();
                        RawMaterialXaml.RecordControll.Visibility = Visibility.Hidden;
                        RawMaterialXaml.Continue.Visibility = Visibility.Visible;
                        RawMaterialXaml.ShowDialog();
                    }
                    break;
            }
        }
        /// <summary>
        /// 加载新增原料基本数据
        /// </summary>
        private void AddRawMaterialBaseData()
        {
            RawMaterialBean = new Model.RawMaterialBean();
            //弹出页面
            List<RawUnit> rus = _RawUnitDataService.FindRawUnitByDeletedStatus();
            InitComboxData();

            RawMaterialBean.RawId = int.Parse(SelectedRawNode.Id);
            RawMaterialBean.BigType = SelectedRawNode.Parent.Text;
            RawMaterialBean.LittleType = SelectedRawNode.Text;  //小类
            //查找全部的原料资料，包括物理删除的
            List<RawMaterial> rms = _MaterialDataService.FindAllRawMaterial();
            if (rms != null)
            {
                //编码等于小类id+原表中所有记录+1拼接成的字符串
                StringBuilder sb = new StringBuilder();
                int bigId = int.Parse(SelectedRawNode.Parent.Id);
                int little = int.Parse(SelectedRawNode.Id);
                if (bigId < 10)
                {
                    sb.Append("0").Append(bigId);
                }
                else
                {
                    sb.Append(bigId);
                }
                if (little <= 9)
                {
                    sb.Append("0").Append(little);
                }
                else 
                {
                    sb.Append(little);
                }

                int count = rms.ElementAt(rms.Count-1).Id+1;
                if (count <= 9)
                {
                    sb.Append("0").Append(count);
                }
                else
                {
                    sb.Append(count);
                }
               _RawMaterialBean.Code = sb.ToString();

            }
            _RawMaterialBean.CreateBy = SubjectUtils.GetAuthenticationId();
            _RawMaterialBean.CreateDatetime = DateTime.Now;
        }
        private void InitView()
        {
            CodeAndTypeVisibility = Visibility.Collapsed;
            StatusVisibility = Visibility.Collapsed;
            ParemerterVisibility = Visibility.Collapsed;
        }
        public MaterialViewModel(IMaterialDataService dataService, IRawUnitDataService rawUnitDataService, IMessenger messenger)
            : base(messenger)
        {
            _MaterialDataService = dataService;
            _RawUnitDataService = rawUnitDataService;
            InitView();

            LoadTreeAndDataMaterial();
        }
        /**加载主界面树*/
        private void LoadTreeAndDataMaterial()
        {
            _RootTreeNode = new TreeNodeModel("全部类型");
            _RootTreeNode.Expanded = true;
            FirstGeneration.Clear();
            FirstGeneration.Add(_RootTreeNode);
            new Task(() =>
            {
                List<Raw> raws = _MaterialDataService.FindAllBigRawByDeletedStatus();
                
                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    if (raws != null)
                    {
                        foreach (var raw in raws)
                        {
                            if (raw.ParentRawId == 0 || raw.ParentRawId == null)
                            {
                                TreeNodeModel node = new TreeNodeModel(raw.Name, _RootTreeNode);
                                node.Id = raw.RawId.ToString();

                                List<Raw> childrens = _MaterialDataService.FindAllRawByBigRawIdAndDeletedStatus(raw.RawId);
                                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                                {
                                    _RootTreeNode.Children.Add(node);
                                    if (childrens != null)
                                        foreach (var children in childrens)
                                        {
                                            TreeNodeModel n = new TreeNodeModel(children.Name, node);
                                            n.Id = children.RawId.ToString();
                                            node.Children.Add(n);
                                        }
                                });
                            }

                        }
                    }
                });
                
                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    LoadAllMaterialData();
                });

            }).Start();
            
        }
        /// <summary>
        /// 选择第一个记录的标志
        /// </summary>
        private bool SelectedFlag = false;
        //加载所有的原料数据
        private void LoadAllMaterialData()
        {
                rawUtils = _RawUnitDataService.FindRawUnitByDeletedStatus();
            
                if (_RootTreeNode != null)
                {
                    ObservableCollection<TreeNodeModel>firstChildrens=_RootTreeNode.Children;
                    foreach (var fc in firstChildrens)
                    {
                        MaterialItems.Clear();
                        //根据其小类的所有成员，去数据表里面查找所有的原料资料
                        ObservableCollection<TreeNodeModel> childrens = fc.Children;
                        if (childrens != null)
                            for (int x = 0; x < childrens.Count; x++)
                            {
                                var child = childrens.ElementAt(x);   //小类的树对象
                                new Task(() =>
                                {
                                    List<RawMaterial> rms = _MaterialDataService.FindAllRawMaterialByRawIdAndDeletedStatus(int.Parse(child.Id));
                                    DispatcherHelper.CheckBeginInvokeOnUI(() =>
                                    {
                                        if (rms != null)
                                        {
                                            for (int y = 0; y < rms.Count; y++)   //遍历该小类下的对应的原料资料
                                            {
                                                var rm = rms.ElementAt(y);
                                                _RawMaterialBean = new Model.RawMaterialBean();

                                                LoadRawMaterialLineAndCode(rm,fc.Id);
                                                _RawMaterialBean.CreateRawMaterialBean(rm);
                                                _RawMaterialBean.BigType = fc.Text;
                                                _RawMaterialBean.LittleType = child.Text;

                                                InitComboxData();
                                                if (!SelectedFlag)
                                                {
                                                    SelectedMaterialItem = RawMaterialBean;
                                                    SelectedFlag = true;
                                                }
                                                MaterialItems.Add(RawMaterialBean);
                                            }

                                        }
                                    });
                                    
                                }).Start();
                            }   
                      }
                }
           
        }
        /// <summary>
        /// 加载行号和编码
        /// </summary>
        /// <param name="rm"></param>
        private void LoadRawMaterialLineAndCode(RawMaterial rm,string bigId)
        {
            _RawMaterialBean.LineNumber = MaterialItems.Count + 1;
            StringBuilder sb = new StringBuilder();
            if (int.Parse(bigId) < 10)
            {
                sb.Append("0").Append(int.Parse(bigId));
            }
            else
            {
                sb.Append(int.Parse(bigId));
            }
            if (rm.RawId <= 9)
            {
               // code = "0" + rm.RawId;
                sb.Append("0").Append(rm.RawId);
            }
            else
            {
                sb.Append(rm.RawId);
            }

            if (rm.Id <= 9)
            {
                sb.Append("0").Append(rm.Id);
            }
            else
            {
                sb.Append(rm.Id);
            }
            _RawMaterialBean.Code = sb.ToString();
        }
        /// <summary>
        /// 初始化下拉控件的基本数据
        /// </summary>
        private void InitComboxData()
        {
            _RawMaterialBean.InGoodsUnitItems = rawUtils;

            _RawMaterialBean.StockUnitItems = rawUtils;
            _RawMaterialBean.FormulaUnitItems = rawUtils;
            _RawMaterialBean.SaleUnitItems = rawUtils;

            foreach (var ru in rawUtils)
            {
                if (_RawMaterialBean.FormulaUnit == ru.UnitId)
                {
                    _RawMaterialBean.SelectedFormulaUnitItem = ru;
                }
                if (_RawMaterialBean.InGoodsUnit == ru.UnitId)
                {
                    _RawMaterialBean.SelectedInGoodsUnitItem = ru;
                }
                if (_RawMaterialBean.SaleUnit == ru.UnitId)
                {
                    _RawMaterialBean.SelectedSaleUnitItem = ru;
                }
                if (_RawMaterialBean.StockUnit == ru.UnitId)
                {
                    _RawMaterialBean.SelectedStockUnitItem = ru;
                }
            }
        }
    }

}