using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.View.DischesWayView;
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
    public class DishesWayModel : ViewModelBase
    {
        //实例化对象时就给IDischesWayModel对象赋值，方便调用数据持久层操作数据库

        //1.页面传入数据新增时，调用数据持久层的添加方法将做法添加到数据库

        //2.页面操作修改做法时，调用数据持久层的修改方法将做法进行修改

        //3.页面操作删除做法时，调用数据持久层删除对应做法

        //4.提供一个查询做法的功能，根据传入的做法类型id，获取所有的做法

        IDishesWayDataService _DataService;
        #region Binding
        ObservableCollection<TreeNode> _DishesWayNameTree;
        public ObservableCollection<TreeNode> DishesWayNameTree
        {
            get
            {
                return _DishesWayNameTree ?? (_DishesWayNameTree = new ObservableCollection<TreeNode>());
            }
            set
            {
                this._DishesWayNameTree = value;
                Set("DishesWayNameTree", ref _DishesWayNameTree, value);
            }
        }

        ObservableCollection<DishesItem> _DishesWayTableItems;
        public ObservableCollection<DishesItem> DishesWayTableItems
        {
            get
            {
                return _DishesWayTableItems ?? (_DishesWayTableItems = new ObservableCollection<DishesItem>());
            }
            private set { }
        }


        /**-------------------------------以下是关于做法的相关属性定义-------------------------------------------**/
        string _DishesWayCode;
        public string DishesWayCode
        {
            get
            {
                return _DishesWayCode;
            }
            set
            {
                Set("DishesWayCode", ref _DishesWayCode, value);
            }
        }

        string _DischesWayType;
        public string DischesWayType
        {
            get
            {
                return _DischesWayType;
            }
            set
            {
                Set("DischesWayType", ref _DischesWayType, value);
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
        string _PingYing;
        public string PingYing
        {
            get
            {
                return _PingYing;
            }
            set
            {
                Set("PingYing", ref _PingYing, value);
            }
        }
        string _AddPrice;
        public string AddPrice
        {
            get
            {
                return _AddPrice;
            }
            set
            {
                Set("AddPrice", ref _AddPrice, value);
            }
        }
        string _AddPriceByNum;
        public string AddPriceByNum
        {
            get
            {
                return _AddPriceByNum;
            }
            set
            {
                Set("AddPriceByNum", ref _AddPriceByNum, value);
            }
        }
        /**------------------------------------------------做法的相关属性定义结束标志-------------------------------------------------------*/
       
        
        #endregion



        #region Command
        /**--------------------------以下是关于菜品做法界面有关菜单的绑定事件------------------------*/
        RelayCommand _AddDishesWayMenu;
        public RelayCommand AddDishesWayMenu   //新增做法
        {
            get
            {
                return _AddDishesWayMenu ?? (_AddDishesWayMenu = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    //添加做法
                   // MessageBox.Show("添加做法");

                    Logger.Log("添加做法", LOGSEVERITY.Debug);
                    
                    new DishesWaySettingWindow().ShowDialog();
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
                    Logger.LogMethodEntry();
                    //修改做法
                    MessageBox.Show("修改做法");
                    //弹出修改做法界面，从数据库中读取做法表的信息，设置到界面上
                    Logger.Log("修改做法", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }
        
        RelayCommand _DeleteDishesWayMenu;
        public RelayCommand DeleteDishesWayMenu   //删除做法
        {
            get
            {
                return _DeleteDishesWayMenu ?? (_DeleteDishesWayMenu = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    //删除做法
                    MessageBox.Show("删除做法");

                    Logger.Log("删除做法", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }

        RelayCommand _DishesWayTypeMenu;   //新增做法类型
        public RelayCommand DishesWayTypeMenu
        {
            get
            {
                return _DishesWayTypeMenu ?? (_DishesWayTypeMenu = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    //做法类型
                    MessageBox.Show("做法类型");
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
        /**---------------------------菜品做法菜单绑定事件结束标志-------------------------------*/


        /*********************************以下是定义厨打做法设置页面相关绑定事件****************************************/
         RelayCommand _Save;
        public RelayCommand Save   //保存做法
        {
            get
            {
                return _Save ?? (_Save = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    //保存做法，调用数据持久层方法，将数据保存到数据库中
                    SaveDishesWay(0);
                    Logger.Log("保存做法", LOGSEVERITY.Debug);
                    
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
                    //继续添加做法
                    //1.提示用户是否保存数据
                    
                    
                    SaveDishesWay(1);

                    // *否：重新刷新界面，把原有的数据清除，只留下做法类型
                    Logger.Log("继续添加做法", LOGSEVERITY.Debug);
                    DishesWayCode = null;
                    Name = null;
                    PingYing = null;
                    AddPrice = null;
                    AddPriceByNum = null;
                    

                    Logger.LogMethodExit();
                }));
            }
        }
        /**********************************厨打做法设置结束标志****************************************/

        #endregion Command


        //type=0表示保存数据，type=1表示继续添加数据，type=2则修改数据
        private void SaveDishesWay(int type)
        {
            if (string.IsNullOrEmpty(DishesWayCode))
            {
                MessageBox.Show("编码不能为空");
                return;
            }
            if (string.IsNullOrEmpty(Name))
            {
                MessageBox.Show("做法说明不能为空");
                return;
            }
            if (type == 1)    //如果继续添加做法，则提示是否保存数据
            {
                //是：继续往下执行，否，清除数据。取消，关闭对话框·····························································································
                MessageBox.Show("数据有改动，是否保存数据？", "惠员管理系统", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            }
            if (DishesWayCode.Length != 3)
            {
                MessageBox.Show("编码长度不能小于3");
                return;
            }

            try
            {
                int code = Int32.Parse(DishesWayCode);
                // *是：先查询数据库中是否有条记录，如果有，则弹出对话框提示，否则保存数据
                DischesWay d = _DataService.FindDishesWayByCode(code);
                if (d!=null){
                    MessageBox.Show("新增编码系统已存在，不能保存");
                    return;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("编码不能为字母");
                e.ToString();
                return;
            }

            DischesWay dw = new DischesWay();
            try
            {
                if (!string.IsNullOrEmpty(AddPrice))
                    dw.AddPrice = Double.Parse(AddPrice);
                else
                {
                    dw.AddPrice = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("加价只能输入数字!!!");
                return;
            }
            if ("True".Equals(AddPriceByNum))
            {
                MessageBox.Show("按数量加价" + AddPriceByNum);
                dw.AddPriceByNum = 1;
            }
            else
            {
                MessageBox.Show("按数量加价" + AddPriceByNum);
                dw.AddPriceByNum = 0;
            }

            dw.Code = Int32.Parse(DishesWayCode);
            if (type != 2)
            {
                dw.CreateBy = 1;     //需要读取数据库中操作人员的id
                dw.CreateDatetime = DateTime.Now;
            }
            else
            {
                //表示是修改做法
                dw.UpdateBy = 2;   //读取数据库中操作人的id
                dw.UpdateDatetime = DateTime.Now;
            }
            
            dw.Deleted = 0;
            //dw.DischesWayId      //自增长
            dw.DischesWayNameId = 2;   
            dw.Name = Name;
            dw.PingYing = PingYing;
            dw.Status = 0;
            bool b=_DataService.AddDishesWay(dw);
            if (b)
            {
                MessageBox.Show("保存成功");
            }
            else
            {
                MessageBox.Show("由于系统原因保存失败，请稍后再试");
            }
        }

        //初始化
        private void init()
        {
            this.DishesWayNameTree = new ObservableCollection<TreeNode>();
            TreeNode root = TreeNode.createRoot("0000", "全部类型");
            this.DishesWayNameTree.Add(root);

            //new Task(() => { 
            //加载数据库菜牌数据
            // var dishesMenus = _DataService.QueryAllDishesMenu();
            //foreach (var menu in dishesMenus) {
            //    var child = root.createChild(menu.Id, menu.Name);
            //    child.Action = LoadDishesItemsAction;
            //    root.Children.Add(child);
            // }
            RaisePropertyChanged("DishesWayNameTree");
            //  }).Start();
            //new Task(() =>
            //{
            //    LoadDishesItemsAction(null);
            //}).Start();
            //Task.Factory.StartNew(() => LoadDishesItemsAction(null));
        }
        /// <summary>
        /// 回调函数
        /// </summary>
        /// <param name="parameter"></param>
        public void LoadDishesItemsAction(object parameter)
        {
            Random ran = new Random();
           
            DishesWayTableItems.Clear();
            for (int i = 0; i < 100; i++)
            {
                DishesItem d = new DishesItem();
                d.Index = "x" + i;
                //d.Code = "00x" + i;
                //d.DischesWayName = "火候";
                //d.Name = "三分熟" + i;
                //d.PingYing = "SFS";
                //d.AddPrice = "" + i;
                //if (i % 2 == 0)
                //{
                //    d.AddPriceByNum = false;
                //}
                //else
                //{
                //    d.AddPriceByNum = true;
                //}
               
                DishesWayTableItems.Add(d);
            }
        }
        public DishesWayModel(IDishesWayDataService dataService, IMessenger messenger)
            : base(messenger)
        {
            _DataService = dataService;
            //MessageBox.Show("在初始化做法");
            init();
        }
    }


    public class DishesItem
    {
        /// <summary>
        /// 索引
        /// </summary>
        public string Index { get; set; }
        /// <summary>
        /// 做法编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 做法说明
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 所属类型名
        /// </summary>
        public string DischesWayName { get; set; }
        /// <summary>
        /// 拼音简码
        /// </summary>
        public string PingYing { get; set; }
        /// <summary>
        /// 加价
        /// </summary>
        public string AddPrice { get; set; }
        /// <summary>
        /// 是否按照数量加价
        /// </summary>
        public bool AddPriceByNum { get; set; }
    }
}
