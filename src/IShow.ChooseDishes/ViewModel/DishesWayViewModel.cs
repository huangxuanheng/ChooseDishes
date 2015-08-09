using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using IShow.ChooseDishes.Data;
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
        ObservableCollection<DishesWayTreeNode> _DishesWayNameTree;
        public ObservableCollection<DishesWayTreeNode> DishesWayNameTree   //目录树
        {
            get
            {
                return _DishesWayNameTree ?? (_DishesWayNameTree = new ObservableCollection<DishesWayTreeNode>());
            }
            set
            {
                this._DishesWayNameTree = value;
                Set("DishesWayNameTree", ref _DishesWayNameTree, value);
            }
        }



        DishesWayItem _DishesWaySelectedItem;

        public DishesWayItem DishesWaySelectedItem   //做法列表中被选中的行
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
       

        /**-------------------------------以下是关于做法的相关属性定义-------------------------------------------**/
        ObservableCollection<DishesWayItem> _DishesWayTableItems;
        public ObservableCollection<DishesWayItem> DishesWayTableItems    //做法表格集合
        {
            get
            {
                return _DishesWayTableItems ?? (_DishesWayTableItems = new ObservableCollection<DishesWayItem>());
            }
            private set { }
        }


        Visibility _DishesWayDescriptionVisibility;
        public Visibility DishesWayDescriptionVisibility     //厨打做法设置的文本提示
        {
            get
            {
                return _DishesWayDescriptionVisibility;
            }
            set
            {
                Set("DishesWayDescriptionVisibility", ref _DishesWayDescriptionVisibility, value);
            }
        }

        Visibility _DishesWayContinueButtonVisibility;
        public Visibility DishesWayContinueButtonVisibility     //厨打做法设置的继续按钮的显示---修改和新增时的切换显示
        {
            get
            {
                return _DishesWayContinueButtonVisibility;
            }
            set
            {
                Set("DishesWayContinueButtonVisibility", ref _DishesWayContinueButtonVisibility, value);
            }
        }


        Visibility _DishesWayRecord;
        public Visibility DishesWayRecord     //厨打做法设置的做法记录的显示---修改和新增时的切换显示
        {
            get
            {
                return _DishesWayRecord;
            }
            set
            {
                Set("DishesWayRecord", ref _DishesWayRecord, value);
            }
        }
        public bool _CodeTextReadonly;
        public bool CodeTextReadonly      //厨打做法设置的做法编码是否只读
        {
            get
            {
                return _CodeTextReadonly;
            }
            set
            {
                Set("CodeTextReadonly", ref _CodeTextReadonly, value);
            }

        }

        string _DishesWayCode;
        public string DishesWayCode     //做法编码
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
        public string DischesWayType     //做法类型
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
        public string Name     //做法名称
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
        public string PingYing    //做法拼音简码
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
        public string AddPrice    //加价
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
        public string AddPriceByNum     //按数量加价
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
        /**------------------------------------------------做法的相关属性定义结束标志-------------------------------------------------------*/


        /**---------------------------------以下是做法类型相关属性定义-------------------------------------------*/

        bool _IsReadOnlyDishesWayTypeCode;
        public bool IsReadOnlyDishesWayTypeCode     //编码的单元格是否可以修改
        {
            get
            {
                return _IsReadOnlyDishesWayTypeCode;
            }
            set
            {
                Set("IsReadOnlyDishesWayTypeCode", ref _IsReadOnlyDishesWayTypeCode, value);
            }
        }

        bool _IsReadOnlyDishesWayTypeItem;
        public bool IsReadOnlyDishesWayTypeItem     //编码的单元格是否可以修改
        {
            get
            {
                return _IsReadOnlyDishesWayTypeItem;
            }
            set
            {
                Set("IsReadOnlyDishesWayTypeItem", ref _IsReadOnlyDishesWayTypeItem, value);
            }
        }

        DishesWayTypeItem _DishesWayTypeSelectedItem;

        public DishesWayTypeItem DishesWayTypeSelectedItem   //做法类型列表中被选中的行
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
        ObservableCollection<DishesWayTypeItem> _DishesWayTypeItems;
        public ObservableCollection<DishesWayTypeItem> DishesWayTypeItems    //做法类型表格集合
        {
            get
            {
                return _DishesWayTypeItems ?? (_DishesWayTypeItems = new ObservableCollection<DishesWayTypeItem>());
            }
            private set { }
        }
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
                    _DishesWayRecord = Visibility.Hidden;
                    _DishesWayDescriptionVisibility = Visibility.Visible;
                    _DishesWayContinueButtonVisibility = Visibility.Visible;

                    Logger.Log("添加做法", LOGSEVERITY.Debug);
                    //根据指定的做法类型id 查找数据库对应的做法，赋值给DischesWayType
                    if (GetDishesWayTreeNode != null)
                    {
                        DischesWayName dwn = _DataService.FindDishesWayNameByCode(GetDishesWayTreeNode.Code);
                        if (dwn != null)
                        {
                            //打开新增做法页面
                            DischesWayType = dwn.Name;
                        }
                        //跳出添加做法的页面：厨打做法设置
                    }
                    DishesWaySettingWindow dsw = new DishesWaySettingWindow();
                    dsw.ShowDialog();
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
                    //MessageBox.Show("修改做法");
                    _DishesWayRecord = Visibility.Visible;
                    _DishesWayDescriptionVisibility = Visibility.Hidden;
                    _DishesWayContinueButtonVisibility = Visibility.Hidden;
                    //弹出修改做法界面，从数据库中读取做法表的信息，设置到界面上
                    if (DishesWaySelectedItem != null)
                    {
                        DischesWayType = DishesWaySelectedItem.DischesWayName;
                        DishesWayCode = DishesWaySelectedItem.Code;    //将做法id赋值给DishesWayCode，在界面上显示出来
                        Name = DishesWaySelectedItem.Name;
                        PingYing = DishesWaySelectedItem.PingYing;
                        AddPrice = DishesWaySelectedItem.AddPrice;
                        AddPriceByNum = DishesWaySelectedItem.AddPriceByNum.ToString();
                        CodeTextReadonly = true;
                        DischesWayCurrentItem = current + "/" + DishesWayTableItems.Count;
                        //跳出添加做法的页面：厨打做法设置
                        DishesWaySettingWindow dsw = new DishesWaySettingWindow();
                        dsw.ShowDialog();
                        Logger.Log("修改做法", LOGSEVERITY.Debug);
                    }
                    else
                    {
                        MessageBox.Show("请先选择需要修改做法的记录");
                        return;
                    }
                    

                    Logger.LogMethodExit();
                }));
            }
        }
        DishesWayTypeItem _SelectedDishesWayTypeItem;
        RelayCommand _DeleteDishesWayMenu;
        public RelayCommand DeleteDishesWayMenu   //删除做法
        {
            get
            {
                return _DeleteDishesWayMenu ?? (_DeleteDishesWayMenu = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    //删除做法 
                    if (DishesWaySelectedItem != null)
                    {
                       // _DataService.DeleteDishesWay(DishesWaySelectedItem.Index);
                        bool flag = _DataService.UpdateDishesWayDeletedTypeByCode(int.Parse(DishesWaySelectedItem.Code));
                        if (flag)
                        {
                            LoadingDishesWayTableItem();
                        }
                        else
                        {
                            MessageBox.Show("对不起，操作失败");
                        }
                    }
                    else
                    {
                        //删除做法类型
                        if (GetDishesWayTreeNode != null)
                        {
                            bool flag = _DataService.UpdateDishesWayNameDeletedTypeByCode(GetDishesWayTreeNode.Code);
                            if (flag)
                            {
                                init();
                            }
                            else
                            {
                                MessageBox.Show("对不起，操作失败");
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
                    //做法类型
                    LoadingDishesWayTypeData();
                    new DishesWayTypeWindow().ShowDialog();
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
                    init();
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
                    Task.Factory.StartNew(() =>
                    {
                        if (GetDishesWayTreeNode != null)
                        {
                            DischesWayName dwn = _DataService.FindDishesWayNameByCode(GetDishesWayTreeNode.Code);
                            SaveDishesWay(dwn.DischesWayNameId, 0);
                        }
                        
                    });
                    
                    Logger.Log("保存做法", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
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
                    Task.Factory.StartNew(() =>
                    {
                        if (GetDishesWayTreeNode != null)
                        {
                            DischesWayName dwn = _DataService.FindDishesWayNameByCode(GetDishesWayTreeNode.Code);
                            SaveDishesWay(dwn.DischesWayNameId, 1);
                            // *否：重新刷新界面，把原有的数据清除，只留下做法类型
                            Logger.Log("继续添加做法", LOGSEVERITY.Debug);
                            DishesWayCode = null;
                            Name = null;
                            PingYing = null;
                            AddPrice = null;
                            AddPriceByNum = null;
                        }
                    });
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
                   switchDishesWayItem(0);
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
                    switchDishesWayItem(1);
                    Logger.LogMethodExit();
                }));
            }
        }
        /**********************************厨打做法设置结束标志****************************************/


        /**------------------------------厨打做法类型设置事件绑定----------------------------*/

        RelayCommand _AddDishesWayTypeButton;
        public RelayCommand AddDishesWayTypeButton   //新增做法类型item
        {
            get
            {
                return _AddDishesWayTypeButton ?? (_AddDishesWayTypeButton = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    IsReadOnlyDishesWayTypeCode = false;
                    DishesWayTypeItem dwt = new DishesWayTypeItem()
                    {
                        img = "",
                        Index = DishesWayTypeItems.Count+1,
                        Code = "",
                        DishesWayTypeName = ""

                    };
                    DishesWayTypeItems.Add(dwt);

                    Logger.Log("新增做法类型item", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }

        RelayCommand _DeleteDishesWayTypeButton;
        public RelayCommand DeleteDishesWayTypeButton   //删除做法类型item
        {
            get
            {
                return _DeleteDishesWayTypeButton ?? (_DeleteDishesWayTypeButton = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    Logger.Log("删除做法类型item", LOGSEVERITY.Debug);
                    if (DishesWayTypeSelectedItem != null)
                    {
                        if (_DataService.FindAllDishesWayByTypeCode(DishesWayTypeSelectedItem.Code)!=null)
                        {
                            MessageBox.Show("指定类型已存在做法记录，不能删除！");
                            return;
                        }
                        bool flag = _DataService.UpdateDishesWayNameDeletedTypeByCode(DishesWayTypeSelectedItem.Code);
                        if (flag)
                        {
                            //删除成功
                            LoadingDishesWayTypeData();
                        }
                        else
                        {
                            MessageBox.Show("删除操作失败!");
                        }
                    }
                    //DishesWayTypeItems.Remove();
                    Logger.LogMethodExit();
                }));
            }
        }

        RelayCommand _RefreshDishesWayTypeButton;
        public RelayCommand RefreshDishesWayTypeButton   //刷新做法类型列表
        {
            get
            {
                return _RefreshDishesWayTypeButton ?? (_RefreshDishesWayTypeButton = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    //加载做法类型
                    LoadingDishesWayTypeData();
                    Logger.Log("刷新做法类型列表", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }

        RelayCommand _SaveDishesWayTypeButton;
        public RelayCommand SaveDishesWayTypeButton   //保存做法类型item
        {
            get
            {
                return _SaveDishesWayTypeButton ?? (_SaveDishesWayTypeButton = new RelayCommand(() =>
                {
                    Logger.LogMethodEntry();
                    //获取所有的行对象
                    Task.Factory.StartNew(() =>
                    {
                        SaveDishesWayType();
                    });
                    Logger.Log("保存做法类型item", LOGSEVERITY.Debug);

                    Logger.LogMethodExit();
                }));
            }
        }

       


        #endregion Command
        int current = 0;
        //上下做法记录,direction=0表示上一条记录
        private void switchDishesWayItem(int direction)
        {
            if (DishesWaySelectedItem == null)
            {
                return;
            }
            if (direction == 0)
            {
                current = DishesWayTableItems.IndexOf(DishesWaySelectedItem)-1;
            }
            else
            {
                current = DishesWayTableItems.IndexOf(DishesWaySelectedItem) + 1;
            }
            if (current <= 0)
            {
                current = 0;
            }
            if (current > DishesWayTableItems.Count-1)
            {
                current = DishesWayTableItems.Count-1;
            }
            DishesWaySelectedItem = DishesWayTableItems.ElementAt(current);


            DishesWayCode = DishesWaySelectedItem.Code;    //将做法id赋值给DishesWayCode，在界面上显示出来
            Name = DishesWaySelectedItem.Name;
            PingYing = DishesWaySelectedItem.PingYing;
            AddPrice = DishesWaySelectedItem.AddPrice;
            AddPriceByNum = DishesWaySelectedItem.AddPriceByNum.ToString();
            CodeTextReadonly = true;
            
        }
        //保存做法类型
        private void SaveDishesWayType()
        {
            int count = DishesWayTypeItems.Count;
            for (int i = 0; i < count; i++)
            {
                DishesWayTypeItem d = DishesWayTypeItems.ElementAt(i);
                //查询做法类型表中是否存有记录，如果有，并且字段“deleted”=0则结束本次循环
               var type= _DataService.FindDishesWayNameByCode(d.Code);
               if (type != null &&type.Deleted==0)
                {
                    continue;
                }
                //DischesWayName dwn = new DischesWayName()
                //{
                //    Code = d.Code,
                //    Name = d.DishesWayTypeName,
                //    CreateBy = 0,     //登录的用户id 
                //    CreateDatetime = DateTime.Now,
                //    Deleted = 0
                //};
                if(type==null){
                    type=new DischesWayName();
                }
                type.Code = d.Code;
                type.Name = d.DishesWayTypeName;
                bool flag=false;   //判断是否保存成功的标志
                if (type.Deleted ==1)
                {
                    //表示做过物理删除，这时重新赋值,然后更新数据库
                    type.UpdateBy = 0;   //操作人id
                    type.UpdateDatetime = DateTime.Now;
                    type.Deleted = 0;
                    flag=_DataService.UpdateDishesWayName(type);
                    if (flag)
                    {
                        IsReadOnlyDishesWayTypeCode = true;
                    }
                }
                else
                {
                    type.CreateBy = 0;    //登录的用户id 
                    type.CreateDatetime = DateTime.Now;
                    type.Deleted = 0;
                    flag = _DataService.AddDishesWayName(type);
                    if (flag)
                    {
                        IsReadOnlyDishesWayTypeCode = true;
                    }
                }
                if (flag)
                {
                    MessageBox.Show("保存成功");
                }
                else
                {
                    MessageBox.Show("保存失败");
                }
            }
        }
        //初始化数据
        private void LoadingDishesWayTableItem()
        {
            if (GetDishesWayTreeNode!=null)
                SelectedItemChanged(GetDishesWayTreeNode) ;
        }
        //加载做法类型数据
        private void LoadingDishesWayTypeData()
        {
            new Task(() => {
                IsReadOnlyDishesWayTypeCode = true;
                //查找数据库，显示所有做法类型
                List<DischesWayName> dwns = _DataService.FindAllDishesWayName();
                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    if (dwns != null)
                    {
                        DishesWayTypeItems.Clear();
                        for (int x = 0; x < dwns.Count; x++)
                        {
                            var d = dwns.ElementAt(x);
                            if (d.Deleted != 1)      //如果删除状态不为1，则显示做法列表
                            {
                                DishesWayTypeItem dwt = new DishesWayTypeItem()
                                {
                                    img = "",
                                    Index = (x + 1),
                                    Code = d.Code,
                                    DishesWayTypeName = d.Name
                                };
                                DishesWayTypeItems.Add(dwt);
                            }
                        }
                    }
                });  
            }).Start();
           
        }
        //type=0表示保存数据，type=1表示继续添加数据，type=2则修改数据
        private void SaveDishesWay(int wayId,int type)
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
                DischesWay dw = _DataService.FindDishesWayByCode(code);
                if (dw != null&&dw.Deleted==0)
                {
                    MessageBox.Show("新增编码系统已存在，不能保存");
                    return;
                }
                if (dw == null)
                {
                    dw = new DischesWay();
                }
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
                    // MessageBox.Show("按数量加价" + AddPriceByNum);
                    dw.AddPriceByNum = 1;
                }
                else
                {
                    // MessageBox.Show("按数量加价" + AddPriceByNum);
                    dw.AddPriceByNum = 0;
                }

                dw.Code = Int32.Parse(DishesWayCode);
                dw.DischesWayNameId = wayId;
                dw.Name = Name;
                dw.PingYing = PingYing;
                dw.Status = 0;
                if (string.IsNullOrEmpty(PingYing))
                {
                    PingYing = "-";
                }
                if (type != 2)
                {
                    dw.CreateBy = 1;     //需要读取数据库中操作人员的id
                    dw.CreateDatetime = DateTime.Now;
                }
                else
                {
                    //表示是修改做法
                    dw.UpdateBy = 1;   //读取数据库中操作人的id
                    dw.UpdateDatetime = DateTime.Now;
                }
                if (dw.Deleted == 1)
                {
                    //表示做过物理删除
                    dw.Deleted = 0;
                    bool b = _DataService.UpdateDishesWay(dw);
                    if (b)
                    {
                        CodeTextReadonly = true;
                        MessageBox.Show("保存成功");
                    }
                    else
                    {
                        MessageBox.Show("由于系统原因保存失败，请稍后再试");
                    }
                }
                else
                {
                    dw.Deleted = 0;
                    bool b = type != 2 ? _DataService.AddDishesWay(dw) : _DataService.UpdateDishesWay(dw);
                    if (b)
                    {
                        CodeTextReadonly = true;
                        MessageBox.Show("保存成功");
                    }
                    else
                    {
                        MessageBox.Show("由于系统原因保存失败，请稍后再试");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("编码不能为字母");
                e.ToString();
                return;
            }
        }

        //初始化
        private void init()
        {
            //从数据库中读书所有做法类型，添加到目录树下
            this.DishesWayNameTree = new ObservableCollection<DishesWayTreeNode>();
            DishesWayTreeNode root = DishesWayTreeNode.createRoot("", "全部类型");
            this.DishesWayNameTree.Add(root);
            if (_DataService != null)
            {
                List<DischesWayName> dwns = _DataService.FindAllDishesWayName();
                if (dwns != null)
                {
                    //创建目录树
                    for (int i = 0; i < dwns.Count; i++)
                    {
                        var item = dwns.ElementAt(i);
                        var child = root.createChild(item.Code, item.Name);
                        if (i == 0)
                        {
                            SelectedItemChanged(child);   //初始化时，将做法类型的第一个显示出来
                        }
                        root.Children.Add(child);
                    }
                }
                RaisePropertyChanged("DishesWayNameTree");
            } 
        }
        /// <summary>
        /// 回调函数
        /// </summary>
        /// <param name="parameter"></param>
        public void LoadDishesWayTableItemsAction(object parameter)
        {
            DishesWayTreeNode dwt = (DishesWayTreeNode)parameter;
            if (string.IsNullOrEmpty(dwt.Code))
            {
                return;
            }
            DishesWayTableItems.Clear();
            List<DischesWay> dws = _DataService.FindAllDishesWayByTypeCode(dwt.Code);
            DischesWayName dwn = _DataService.FindDishesWayNameById(int.Parse(dwt.Code));
            if (dws != null)
            {
                int index = 0;
                foreach (var dw in dws)
                {
                    DishesWayItem d = new DishesWayItem();
                    d.Index = index;
                    d.Code = dw.Code.ToString();
                    d.DischesWayName = dwn.Name;
                    d.Name = dw.Name;
                    d.PingYing = dw.PingYing;
                    d.AddPrice = dw.PingYing;
                    if (dw.AddPriceByNum == 0)
                    {
                        d.AddPriceByNum = false;
                    }
                    else
                    {
                        d.AddPriceByNum = true;
                    }

                    DishesWayTableItems.Add(d);
                }
            }

            //for (int i = 0; i < 5; i++)
            //{
            //    DishesWayItem d = new DishesWayItem()
            //    {
            //         Index = (i+1).ToString(),
            //    Code = i.ToString(),
            //    DischesWayName = "huangxuanheng"+i,
            //    Name = "xuanhu"+i,
            //    PingYing = "hsh",
            //    AddPrice = ""+i,
            //    AddPriceByNum = i==0?true:false,
            //    };
            //    DishesWayTableItems.Add(d);
            //}
        }
        public DishesWayTreeNode GetDishesWayTreeNode
        {
            set;
            get;
        }
        public void SelectedItemChanged(DishesWayTreeNode node)   //目录树被选择时触发次事件
        {
            if (node == null)
            {
                return;
            }
            // MessageBox.Show("hello " + node.Name);
            if (string.IsNullOrEmpty(node.Code))
            {
                return;
            }
            GetDishesWayTreeNode = node;
            
            List<DischesWay> dws = _DataService.FindAllDishesWayByTypeCode(node.Code);
            if (dws != null)
            {
                DishesWayTableItems.Clear();
                for (int i = 0; i < dws.Count; i++)
                {
                    var dw = dws.ElementAt(i);
                    if (dw.Deleted == 1)
                    {
                        continue;
                    }
                    DishesWayItem d = new DishesWayItem();
                    d.Index = i+1;
                    d.Code = dw.Code.ToString();
                    d.DischesWayName = node.Name;
                    d.Name = dw.Name;
                    d.PingYing = dw.PingYing;
                    d.AddPrice = dw.PingYing;
                    if (dw.AddPriceByNum == 0)
                    {
                        d.AddPriceByNum = false;
                    }
                    else
                    {
                        d.AddPriceByNum = true;
                    }
                   // if(dw.Deleted!=1)   //如果没有被物理删除，则显示出来
                    DishesWayTableItems.Add(d);
                    if (i == 0)   //默认选择第一行
                    {
                        DishesWaySelectedItem = d;
                    }
                }
            }
        }

        public DishesWayViewModel(IDishesWayDataService dataService, IMessenger messenger)
            : base(messenger)
        {
            _DataService = dataService;
            //MessageBox.Show("在初始化做法");
            init();
        }
    }

    public class DishesWayTreeNode
    {
        /// <summary>
        /// 节点编号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 节点名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 子节点
        /// </summary>
        public List<DishesWayTreeNode> Children { get; set; }

        /// <summary>
        /// 父节点
        /// </summary>
        public DishesWayTreeNode Parent { get; set; }

        private bool _Selected;

        public bool Selected
        {
            get
            {
                return _Selected;
            }
            set
            {
                this._Selected = value;

            }
        }

        public DishesWayTreeNode(string id, string name, DishesWayTreeNode parent, List<DishesWayTreeNode> children)
        {
            this.Code = id;
            this.Name = name;
            this.Parent = parent;
            this.Children = children ?? new List<DishesWayTreeNode>();
        }

        public static DishesWayTreeNode createRoot(string id, string name)
        {
            return new DishesWayTreeNode(id, name, null, null);
        }

        public DishesWayTreeNode createChild(string id, string name)
        {
            return new DishesWayTreeNode(id, name, this, null);
        }
    }
    public class DishesWayItem     //做法item
    {
        /// <summary>
        /// 索引
        /// </summary>
        public int Index { get; set; }
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

    public class DishesWayTypeItem
    {
        /// <summary>
        /// 索引
        /// </summary>
        public string img { get; set; }
        /// <summary>
        /// 索引
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// 做法编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 做法类型名
        /// </summary>
        public string DishesWayTypeName { get; set; }
    }
}
