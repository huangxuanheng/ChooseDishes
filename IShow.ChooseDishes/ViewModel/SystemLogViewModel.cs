using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Model;
using IShow.ChooseDishes.View.OrgInfo;
using IShow.ChooseDishes.ViewModel.Common;
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
    public class SystemLogViewModel : ViewModelBase
    {
        ILoggerService _LoggerService;
        IUserService _UserService;
        #region Observable
        System.DateTime _StartDate;
        public System.DateTime StartDate    //选择开始日期
        {
            get
            {
                return _StartDate;
            }
            set
            {
                Set("StartDate", ref _StartDate, value);
            }
        }
        System.DateTime _EndDate;
        public System.DateTime EndDate    //选择结束日期
        {
            get
            {
                return _EndDate;
            }
            set
            {
                Set("EndDate", ref _EndDate, value);
            }
        }
        System.DateTime _EndDateCl;
        public System.DateTime EndDateCl    //选择结束日期
        {
            get
            {
                return _EndDateCl;
            }
            set
            {
                Set("EndDateCl", ref _EndDateCl, value);
            }
        }
        
        string _OperPassword;
        public string OperPassword   //特殊操作密码
        {
            get
            {
                return _OperPassword;
            }
            set
            {
                Set("_OperPassword", ref _OperPassword, value);
            }
        }
        string _Operator;
        public string Operator    //输入操作人编号，进行查询
        {
            get
            {
                return _Operator;
            }
            set
            {
                Set("Operator", ref _Operator, value);
            }
        }

        UserInfo _SelectedOperatorItem;
        public UserInfo SelectedOperatorItem    //下拉选择操作人
        {
            get
            {
                return _SelectedOperatorItem;
            }
            set
            {
                Set("SelectedOperatorItem", ref _SelectedOperatorItem, value);
            }
        }
        List<UserInfo> _OperatorItems;
        public List<UserInfo> OperatorItems    //下拉选择操作人集合
        {
            get
            {
                return _OperatorItems;
            }
            set
            {
                Set("OperatorItems", ref _OperatorItems, value);
            }
        }
        
        SystemLogBean _SystemLogBean;
        public SystemLogBean SystemLogBean   //系统日志对象
        {
            get
            {
                return _SystemLogBean;
            }
            set
            {
                Set("SystemLogBean", ref _SystemLogBean, value);
            }
        }

        SystemLogBean _SelectedSystemLogItem;
        public SystemLogBean SelectedSystemLogItem   //被选中的日志
        {
            get
            {
                return _SelectedSystemLogItem;
            }
            set
            {
                Set("SelectedSystemLogItem", ref _SelectedSystemLogItem, value);
            }
        }
        ObservableCollection<SystemLogBean> _SystemLogItems;
        public ObservableCollection<SystemLogBean> SystemLogItems   //日记grid集合
        {
            get
            {
                return _SystemLogItems ?? (_SystemLogItems = new ObservableCollection<SystemLogBean>());
            }
            set
            {
                this._SystemLogItems = value;
                Set("SystemLogItems", ref _SystemLogItems, value);
            }
        }
        TreeNodeModel _RootTreeNode;
        public TreeNodeModel RootTreeNode
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
        ObservableCollection<TreeNodeModel> _FirstGeneration;
        public ObservableCollection<TreeNodeModel> FirstGeneration   //树
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
        
        #endregion Observable

       
        RelayCommand<TreeNodeModel> _SelectedTree;
        public RelayCommand<TreeNodeModel> SelectedTree      //树的选中事件
        {
            get
            {
                return _SelectedTree ?? (_SelectedTree = new RelayCommand<TreeNodeModel>(node =>
                {
                    node.Selected = true;
                    if(node!=null&&!node.Text.Equals("全部类型"))
                    {
                        //判断是否是大树，如果是，则显示大树下的所有小树对应的日志，否则只显示小树对应的日志
                        if (node.Parent.Equals(RootTreeNode))
                        {
                            //大树
                            ObservableCollection<TreeNodeModel>children=  node.Children;
                            SystemLogItems.Clear();
                            if (children != null && children.Count > 0)
                            {
                                foreach (var c in children)
                                {
                                    LoadTreeItem(c);
                                }
                            }
                        }
                        else
                        {
                            //小树
                            LoadTreeItem(node);
                        }
                    }
                    else
                    {
                        LoadBaseData();
                    }
                }));
            }
        }
        /// <summary>
        /// 加载小树下面的所有日志
        /// </summary>
        /// <param name="c"></param>
        private void LoadTreeItem(TreeNodeModel c)
        {
            List<SystemLog> sls = _LoggerService.FindAllSystemLogByModuleId(c.Id);
            SystemLogItems.Clear();
            if (sls != null)
            {
                for (int x = 0; x < sls.Count; x++)
                {
                    var s = sls.ElementAt(x);
                    SystemLogBean sb = new SystemLogBean();
                    sb.CreateSystemLogBean(s);
                    sb.LineNumber = SystemLogItems.Count + 1 + "";
                    if (x == 0)
                    {
                        SelectedSystemLogItem = sb;
                    }
                    SystemLogItems.Add(sb);
                }
            }
        }
        RelayCommand _OperatedSelected;
        public RelayCommand OperatedSelected   //选择操作人
        {
            get
            {
                return _OperatedSelected ?? (_OperatedSelected = new RelayCommand(() =>
                {
                    MessageBox.Show("选择操作人" + StartDate.Date);
                }));
            }
        }
        RelayCommand _Retrieval;
        public RelayCommand Retrieval   //检索
        {
            get
            {
                return _Retrieval ?? (_Retrieval = new RelayCommand(() =>
                {
                   // MessageBox.Show("检索" + SelectedOperatorItem.CreateBy);
                    List<SystemLog> sls = _LoggerService.FindAllByStartDateAndOperated(StartDate, EndDate, SelectedOperatorItem.CreateBy.ToString());
                    SystemLogItems.Clear();
                    if (sls != null)
                    {
                        for (int x = 0; x < sls.Count; x++)
                        {
                            var s = sls.ElementAt(x);
                            SystemLogBean sb = new SystemLogBean();
                            sb.CreateSystemLogBean(s);
                            sb.LineNumber = SystemLogItems.Count + 1 + "";
                            if (x == 0)
                            {
                                SelectedSystemLogItem = sb;
                            }
                            SystemLogItems.Add(sb);
                        }
                    }
                }));
            }
        }
        RelayCommand _Exam;
        public RelayCommand Exam   //查看
        {
            get
            {
                return _Exam ?? (_Exam = new RelayCommand(() =>
                {
                    ShowDetail();
                }));
            }
        }
        //显示页面详情
        public void ShowDetail()
        {
            _SystemLogBean = SelectedSystemLogItem;
            _SystemLogBean.CurrentScale = (SystemLogItems.IndexOf(SelectedSystemLogItem) + 1) + "/" + SystemLogItems.Count;
            SystemLogXaml = new SystemLogDetail();
            SystemLogXaml.ShowDialog();
        }

        RelayCommand _Deleted;
        public RelayCommand Deleted   //日志清除
        {
            get
            {
                return _Deleted ?? (_Deleted = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    if (StartDate != null)
                    {
                        EndDateCl = StartDate;
                    }
                    else
                    {
                        EndDateCl = DateTime.Today.AddDays(-7);
                    }
                    
                    //将选中的条目删除
                    SystemLogClXaml = new SystemLogClear();
                    SystemLogClXaml.ShowDialog();
                    Logger.Log("日志清除", LOGSEVERITY.Debug);
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
                    MessageBox.Show("打印");
                }));
            }
        }
        RelayCommand _Execute;
        public RelayCommand Execute   //执行
        {
            get
            {
                return _Execute ?? (_Execute = new RelayCommand(() =>
                {
                    //MessageBox.Show("执行" + EndDateCl);
                    if (OperPassword != null)
                    {
                        //检验密码是否正确

                        //弹框提示是否要删除
                       MessageBoxResult result= MessageBox.Show("您确定要删除日期" + EndDateCl.ToLongDateString() + "之前的所有日志吗？","提示",MessageBoxButton.YesNo,MessageBoxImage.Warning);
                       if (result == MessageBoxResult.Yes)
                       {
                           _LoggerService.DeleteByDate(EndDateCl);
                           LoadBaseData();
                       }
                    }
                    else
                    {
                        MessageBox.Show("密码不能为空!");
                    }
                    
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
                    currentItem = SystemLogItems.IndexOf(SelectedSystemLogItem) - 1;
                    break;
                case 1:
                    currentItem = SystemLogItems.IndexOf(SelectedSystemLogItem) + 1;
                    break;
            }
            if (currentItem < 0)
            {
                MessageBox.Show("已经是第一条记录了！");
                currentItem = 0;
                return;
            }
            if (currentItem > SystemLogItems.Count - 1)
            {
                MessageBox.Show("已经是最后一条记录了！");
                currentItem = SystemLogItems.Count - 1;
                return;
            }
            SelectedSystemLogItem = SystemLogItems.ElementAt(currentItem);
            SystemLogBean = SelectedSystemLogItem;
            SystemLogBean.CurrentScale = (currentItem+1) + "/" + SystemLogItems.Count;
        }

        SystemLogDetail SystemLogXaml { set; get; }
        SystemLogClear SystemLogClXaml { get; set; }

        public SystemLogViewModel(ILoggerService service,IUserService userService, IMessenger messenger)
            : base(messenger)
        {
            _LoggerService = service;
            _UserService = userService;


            EndDate = DateTime.Today;
            StartDate=EndDate.AddDays(-7);
            LoadRoot();
            
        }
        /// <summary>
        /// 加载基本数据
        /// </summary>
        private void LoadBaseData()
        {
            
            OperatorItems = _UserService.QueryUsers();
            SelectedOperatorItem = OperatorItems.ElementAt(0);
            
            List<SystemLog> sls = _LoggerService.FindAllSystemLog();
            SystemLogItems.Clear();
            if (sls != null)
            {
                for (int x = 0; x < sls.Count; x++)
                {
                    var s = sls.ElementAt(x);
                    SystemLogBean sb = new SystemLogBean();
                    sb.CreateSystemLogBean(s);
                    sb.LineNumber = SystemLogItems.Count + 1 + "";
                    if (x == 0)
                    {
                        SelectedSystemLogItem = sb;
                    }
                    SystemLogItems.Add(sb);
                }
            }
        }
        //加载根树
        private void LoadRoot()
        {
            _RootTreeNode = new TreeNodeModel("全部类型");
            _RootTreeNode.Expanded = true;

            //获取所有大树
            List<Module> mds = _UserService.QueryModulesParent();
            FirstGeneration.Clear();
            if (mds != null)
            {
                foreach (var m in mds)
                {
                    //根目录中添加大树
                    TreeNodeModel node = _RootTreeNode.createChild(m.Id, m.Name);
                    node.Expanded = true;
                    //根据大树id去查找小树，然后添加到对应的树里面
                   List<Module> subs= _UserService.QueryModulesByParentId(node.Id);
                   foreach (var s in subs)
                   {
                       node.createChild(s.Id, s.Name).Expanded=true;
                   }
                }
            }
            FirstGeneration.Add(_RootTreeNode);
            LoadBaseData();
        }
    }
}
