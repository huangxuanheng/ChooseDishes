using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Model.bean;
using IShow.ChooseDishes.View.Dishes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IShow.ChooseDishes.ViewModel
{
    public class DishesViewModel : ViewModelBase
    {
        IChooseDishesDataService _DataService;
        IDishService _IDishService;
        
        bool _IsNotEdit;
        public bool IsNotEdit
        {
            get
            {
                return _IsNotEdit;
            }
            set
            {
                Set("IsNotEdit", ref _IsNotEdit, value);
            }
        }
        public DishesViewModel(IChooseDishesDataService dataService , IDishService DishService ,IMessenger messenger)
            : base(messenger)
        {
            _DataService = dataService;
            _IDishService = DishService;
            IsNotEdit = true;
            Init();
            LoadDishBase(0);
            
        }

        private ObservableCollection<DishBean> _DishesList = new ObservableCollection<DishBean>();
        public ObservableCollection<DishBean> DishesList
        {
            get {
                return _DishesList;
            }
            set {
            this._DishesList = value;
            Set("DisheList",ref _DishesList,value);
        } 
        }
        public void LoadDishBase(object DishId)
        {
            int DishIdRault = DishId==null?0:(int)(DishId);
            List<Dish> list = _DataService.FindDishs(DishIdRault);
            DishesList.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                var dishB = (new DishBean()).CreateDishBean(list[i]);
                dishB.InjectBeanPrice();
                TreeNode ttd = GetDishTypeBigName(list[i].DishTypeId, Root);
                if(ttd!=null){
                    dishB.DishTypeName = ttd.Name;
                    if (ttd.Parent != null) { 
                        dishB.DishTypeBigName = ttd.Parent.Name;
                    }
                }
                DishesList.Add(dishB);
            }
        }
        
        //传入 菜品大类id 得到菜品大类的名字
        public TreeNode GetDishTypeBigName(int id, TreeNode root)
        {
            if (root.Id == id)
            {
                return root;
            }
            var childrens = root.Children;
            foreach (var element in childrens)
            {
                if (element.Id == id)
                {
                    return element;
                }
                else {
                    if (element.Children.Count > 0) {
                        TreeNode seStr = GetDishTypeBigName(id, element);
                       if (seStr != null) { return seStr; }
                    }
                }

            }
            return null;
        }

        TreeNode Root
        {
            get;
            set;
        }
        
        /// <summary>
        /// 加载初始化数据
        /// </summary>
        public void Init()
        {
            DishTypeMenu = new ObservableCollection<TreeNode>();
            DishService service = new DishService();
            var dishesMenus = service.LoadFatherType();
            Root = TreeNode.createRoot(0, "全部类型");
            DishTypeMenu.Add(Root);
            foreach (var menu in dishesMenus)
            {
                var child = Root.createChild(menu.DishTypeId, menu.Name);
                Root.Children.Add(child);
            }
            RaisePropertyChanged("DishWin");
        }
        TreeNode selectedLast;
        public void LoadTreeNodeChildren(TreeNode selected)
        {
            if( null==selected){
                return;
            }
            selectedLast = selected;
            if (selected.Parent != null)
            { 
                _DishTypeIdLast = selected.Id;
            }
            DishService service = new DishService();
            var dishesMenus = service.LoadSubTypeById(selected.Id);
            selected.Children.Clear();
            foreach (var menu in dishesMenus)
            {
                var child = selected.createChild(menu.DishTypeId, menu.Name);
                selected.Children.Add(child);
            }
            //SelectedTreeNodeFalse(Root);
            //selected._Selected = true;
            RaisePropertyChanged("DishWin");
        }
        public TreeNode GetSelectedTreeNode(TreeNode treeNode)
        {
            ObservableCollection<TreeNode> children = treeNode.Children;
            foreach (var t in children)
            {
                if (t.Children.Count() > 0)
                {
                    TreeNode td = GetSelectedTreeNode(t);
                   if (td != null) { return td; }
                }
                else
                {
                    if (t._Selected)
                    {
                        return t;
                    }
                }

            }
            return null;
        }
        //设置全部的树属性为false ,当前点击的为true
        public void SelectedTreeNodeFalse(TreeNode treeNode)
        {
            if (treeNode == null) {
                return;
            }
            ObservableCollection<TreeNode> children = treeNode.Children;
            foreach (var t in children)
            {
                if (t.Children.Count() > 0)
                {
                    SelectedTreeNodeFalse(t);
                }
                else
                {
                    t._Selected = false;
                }

            }
        }

        #region 新增菜品
        int? _DishTypeIdLast;
        public int? DishTypeIdLast
        {
            get
            {
                return _DishTypeIdLast;
            }
            set
            {
                Set("DishTypeIdLast", ref _DishTypeIdLast, value);
            }
        }
        //新增菜品窗口
        AddDish AddDishWin { get; set; }
        //显示条数
        int _IndexTiao = 1 ;
        public int IndexTiao
        {
            get
            {
                return _IndexTiao;
            }
            set
            {
                Set("IndexTiao", ref _IndexTiao, value);
            }
        }
        //总条数 IndexAll
        int _IndexAll;
        public int IndexAll
        {
            get
            {
                return _IndexAll;
            }
            set
            {
                Set("IndexAll", ref _IndexAll, value);
            }
        }
        DishBean _DishBean;
        public DishBean DishBean
        {
            get
            {
                return _DishBean;
            }
            set
            {
                Set("DishBean", ref _DishBean, value);
            }
        }
        List<DishUnit> _DishUnitItems;
        public List<DishUnit> DishUnitItems
        {
            get
            {
                return _DishUnitItems ;
            }
            set
            {
                Set("DishUnitItems", ref _DishUnitItems, value);
            }
        }
        //选择的菜品单位

        DishUnit _SelectedItem;
        public DishUnit SelectedItem
        {
            get {
                return _SelectedItem ;
            }
            set {

                Set("SelectedItem", ref _SelectedItem, value);
            }
        }
        DishPrice _SelectedDishPrice ;
        public DishPrice SelectedDishPrice
        {
            get
            {
                return _SelectedDishPrice;
            }
            set
            {
                Set("SelectedDishPrice", ref _SelectedDishPrice, value);
            }
        }
        bool _IsEditDishPrice;
        public bool IsEditDishPrice
        {
            get
            {
                return _IsEditDishPrice;
            }
            set
            {
                Set("IsEditDishPrice", ref _IsEditDishPrice, value);
            }
        }
        int DateTypeObject = 0;
        RelayCommand _OpenAddWin;
        public RelayCommand OpenAddWin
        {
            get {
                return _OpenAddWin ?? (_OpenAddWin = new RelayCommand(() => {
                    if (Root != null && GetSelectedTreeNode(Root) != null
                        && GetSelectedTreeNode(Root).Parent != null && GetSelectedTreeNode(Root).Parent.Parent != null) { 
                        if ((_IndexAll = DishesList.Count)==0)
                        {
                            _IndexTiao = 0 ;
                        }
                        DateTypeObject = 0;
                        _DishBean = new DishBean();
                        _DishBean.DishTypeId = _DishTypeIdLast??1;
                        _DishBean._DishTypeBigName = selectedLast.Parent.Name;
                        _DishBean._DishTypeName = selectedLast.Name;
                        //加载选择框 菜品的单位 
                        _DishUnitItems = _IDishService.QueryAllDishesUnits(); ;
                        //加载菜品价格
                        _DishePriceList.Clear();
                        IsEditDishPrice = true;
                        AddDishWin = new AddDish();
                        AddDishWin.ShangXiaGrid.Visibility = System.Windows.Visibility.Hidden;
                        AddDishWin.RadioButton1.IsChecked = true;
                        bool? bresult = AddDishWin.ShowDialog();
                        if (bresult != null && bresult == true)
                        {
                            //SelectedPersons = aw.CurPerson;
                        }
                    }
                    else
                    {
                        MessageBox.Show("请在左边列表中选择菜品小类!");
                        return;
                    }
                } ));
            }
        }
        
        //保存菜品
        RelayCommand _SaveDish;
        public RelayCommand SaveDish
        {
            get
            {
                return _SaveDish ?? (_SaveDish = new RelayCommand(() =>
                {
                    if (DateTypeObject==0 && _SelectedItem == null)
                    {
                        MessageBox.Show("请选择菜品单位!");
                        return;
                    }
                    //检验数据长度

                    DishPrice dp = _DishBean.CreateDishPrice(_DishBean);
                    _DishePriceList.Add(dp);
                    //如果有 多个菜品规格 多个菜品规格必须取名字 ,
                    //如果只有一个默认菜品主价格,菜品规格不需要取名字
                    //查看是否有重复的规格名字
                    if (!CheckDishPrice())
                    {
                        _DishePriceList.Remove(dp);
                        MessageBox.Show("请设置菜品规格!或者菜品规格有重复!");
                        return;
                    }
                    if (DateTypeObject == 1) 
                    { 
                        //修改逻辑
                        UpdateDishesObject();
                        return;

                    }
                    _DishBean.DishUnitId = _SelectedItem.DishUnitId;
                    Dish dish = _DishBean.CreateDish(_DishBean);
                    dish.CreateDatetime = DateTime.Now;
                    dish.CreateBy = 1;
                    Dish dishNew = _DataService.AddDish(dish);
                    if (dishNew!=null)
                    {
                        //将菜品主 价格  存入数据库
                        if (!IsEditDishPrice) { 
                            foreach (var element in _DishePriceList) {
                                element.DishId = dishNew.DishId;
                                element.CreateBy = 1;
                                element.CreateTime = DateTime.Now;
                            }
                            bool  flag = _DataService.SaveDishPrice(dishNew.DishId, _DishePriceList.ToArray());
                        }
                        // 刷新数据
                        LoadDishBase(_DishTypeIdLast);
                        _DishBean = new DishBean();
                        //关闭页面 
                        AddDishWin.Close();
                    }

                }));
            }
        }
        //修改逻辑
        public void UpdateDishesObject()
        { 
            //修改菜品
            if ( _SelectedItem != null)
            {
                //修改菜品单位
                _DishBean.DishUnitId = _SelectedItem.DishUnitId;
            }
             _DishBean.UpdateDatetime = DateTime.Now;
             _DishBean.UpdateBy = 1;
             bool flag = _DataService.updateDish(_DishBean.CreateDish(_DishBean));
             if (flag)
             {
                 //修改菜品价格
                 DishPrice dp = _DishBean.CreateDishPrice(_DishBean);
                 //修改菜品主价格
                 _DataService.UpdateDishPriceMain(dp);
                 //批量修改菜品价格 
                 if (!IsEditDishPrice)
                 {
                     foreach (var element in _DishePriceList) {
                         element.CreateBy = 1;
                         element.DishId = _DishBean.DishId;
                         element.CreateTime = DateTime.Now;
                     }
                     _DataService.UpdateDishPrice(_DishBean.DishId, _DishePriceList.ToArray());
                 }
                 //重新加载所有数据
                 LoadDishBase(_DishTypeIdLast);
                 //关闭窗口
                 AddDishWin.Close();
             }
             else {
                 MessageBox.Show("修改菜品失败!");
             }
        }

        //如果有 多个菜品规格 多个菜品规格必须取名字 ,
        //如果只有一个默认菜品主价格,菜品规格不需要取名字
        //查看是否有重复的规格名字
        public bool CheckDishPrice() {
            if (_DishePriceList.Count > 0)
            {
                //if (_DishePriceList.Count == 1) {
                //    return true;
                //}
                if (_DishBean.DishFormat == null || "".Equals(_DishBean.DishFormat))
                {
                    return false;
                }
                foreach (var element in _DishePriceList)
                {
                    if (element.DishSpecification == null || "".Equals(element.DishSpecification))
                    {
                        return false;
                    }
                    int count = 0;
                    foreach (var el in _DishePriceList)
                    {
                        if (element.DishSpecification.Equals(el.DishSpecification))
                        {
                            count++;
                            if (count > 1)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true ;
        }
        //选择菜品类型
        RelayCommand _SelectDishType;
        public RelayCommand SelectDishType
        {
            get
            {
                return _SelectDishType ?? (_SelectDishType = new RelayCommand(() =>
                {
                    if (AddDishWin.RadioButton1.IsChecked??false )
                    {
                        _DishBean.DischesType = 1;
                        return;
                    }
                    if (AddDishWin.RadioButton2.IsChecked ?? false)
                    {
                        _DishBean.DischesType = 2;
                        AddDishWin.CheckBoxTaoCai.IsChecked = false ;
                        return;
                    }
                    if (AddDishWin.RadioButton3.IsChecked ?? false)
                    {
                        _DishBean.DischesType = 3;
                        AddDishWin.CheckBoxTaoCai.IsChecked = false;
                        AddDishWin.CheckBoxZhiXiao.IsChecked = false;
                        return;
                    }       
                }));
            }
        }
        //选择套菜
        RelayCommand _ClickTaoCai;
        public RelayCommand ClickTaoCai
        {
            get
            {
                return _ClickTaoCai ?? (_ClickTaoCai = new RelayCommand(() =>
                {
                    if ((AddDishWin.CheckBoxTaoCai.IsChecked ?? false) )
                    {
                        AddDishWin.CheckBoxZhiXiao.IsChecked = false;
                        AddDishWin.RadioButton1.IsChecked = true;
                        _DishBean.DischesType = 1;
                    }
                    
                }));
            }
        }
        //选择直销商品 ChickZhiXiao
        RelayCommand _ChickZhiXiao;
        public RelayCommand ChickZhiXiao
        {
            get
            {
                return _ChickZhiXiao ?? (_ChickZhiXiao = new RelayCommand(() =>
                {
                    if (AddDishWin.CheckBoxZhiXiao.IsChecked ?? false )
                    {
                        AddDishWin.CheckBoxTaoCai.IsChecked = false;
                        if (AddDishWin.RadioButton3.IsChecked ?? false)
                        {
                            AddDishWin.RadioButton1.IsChecked = true;
                            _DishBean.DischesType = 1;
                        }
                    }
                }));
            }
        }
        //菜品价格 集合
        ObservableCollection<DishPrice> _DishePriceList = new ObservableCollection<DishPrice>();
         public ObservableCollection<DishPrice> DishePriceList
        {
            get
            {
                return _DishePriceList;
            }
            set
            {
                Set("DishePriceList", ref _DishePriceList, value);
            }
        }
        //新增菜品规格
        RelayCommand _AddDishPrice;
        public RelayCommand AddDishPrice
        {
            get
            {
                return _AddDishPrice ?? (_AddDishPrice = new RelayCommand(() =>
                {
                    IsEditDishPrice = false;
                    DishePriceList.Add(new DishPrice());
                }));
            }
        }
        //删除菜品规格 DeleteDishPrice
        RelayCommand _DeleteDishPrice;
        public RelayCommand DeleteDishPrice
        {
            get
            {
                return _DeleteDishPrice ?? (_DeleteDishPrice = new RelayCommand(() =>
                {
                    if (_SelectedDishPrice == null)
                    {
                        MessageBox.Show("请选择菜品规格!");
                        return;
                    }
                    _SelectedDishPrice.Update_by = 1+"";
                    _SelectedDishPrice.UpdateTime = DateTime.Now;
                    //删除数据库菜品规格
                    bool flag = _DataService.DeleteDishPrice(_SelectedDishPrice);
                    if (flag)
                    {
                        DishePriceList.Remove(SelectedDishPrice);
                        if (DishePriceList.Count > 1)
                        {
                            _SelectedDishPrice = DishePriceList[_DishePriceList.Count - 1];
                        }
                        else if (DishePriceList.Count == 1)
                        {
                            _SelectedDishPrice = DishePriceList[0];
                        }
                        else
                        {
                            _SelectedDishPrice = null;
                        }
                    }
                    else {
                        MessageBox.Show("删除菜品规格失败 , 请重新尝试 或联系管理员! ");
                    }
                }));
            }
        }
        //OnOneIndex  上一页
        RelayCommand _OnOneIndex;
        public RelayCommand OnOneIndex
        {
            get
            {
                return _OnOneIndex ?? (_OnOneIndex = new RelayCommand(() =>
                {
                    if (_IndexTiao > 1) {
                        IndexTiao--;
                        DishBean = _DishesList[_IndexTiao - 1];
                        SelectedDishes = _DishesList[_IndexTiao - 1];
                        //加载相应的 规格价格  相应属性做修改
                        ChangeDishObject();
                    }
                }));
            }
        }
        //NextIndex 下一页
        RelayCommand _NextIndex;
        public RelayCommand NextIndex
        {
            get
            {
                return _NextIndex ?? (_NextIndex = new RelayCommand(() =>
                {
                    if (_IndexTiao < _IndexAll)
                    {
                        IndexTiao++;
                        DishBean = _DishesList[_IndexTiao-1];
                        SelectedDishes = _DishesList[_IndexTiao - 1];
                        //加载相应的 规格价格  相应属性做修改
                        ChangeDishObject();
                    }
                }));
            }
        }
        public void ChangeDishObject()
        {
            //显示菜品种类
            if (_DishBean.DischesType == 1)
            {
                AddDishWin.RadioButton1.IsChecked = true;
            }
            else if (_DishBean.DischesType == 2)
            {
                AddDishWin.RadioButton2.IsChecked = true;
            }
            else if (_DishBean.DischesType == 3)
            {
                AddDishWin.RadioButton3.IsChecked = true;
            }
            //显现菜品单位
            AddDishWin.UpdateDishComboBox.SelectedItem = _DishUnitItems[0];
            _DishePriceList.Clear();
            //注入菜品主价格
            foreach (var element in _SelectedDishes.DishPrice)
            {
                if (element.IsMainPrice != 1)
                {
                    _DishePriceList.Add(element);
                }
            }
        }
        #endregion 新增菜品
        #region 修改菜品
        DishBean _SelectedDishes;
        public DishBean SelectedDishes
        {
            get
            {
                return _SelectedDishes;
            }
            set
            {
                Set("SelectedDishes", ref _SelectedDishes, value);
            }
        }
        //UpdateDish UpdateDishWin;
        RelayCommand _UpdateDishes;
        public RelayCommand UpdateDishes
        {
            get
            {
                return _UpdateDishes ?? (_UpdateDishes = new RelayCommand(() =>
                {
                    if (_SelectedDishes == null)
                    {
                        MessageBox.Show("请在右边列表中选择的菜品!");
                        return;
                    }
                    DateTypeObject = 1;
                    _DishBean = _SelectedDishes;
                    if ((_IndexAll = DishesList.Count) == 0)
                    {
                        _IndexTiao = 0;
                    }
                    _IndexTiao = DishesList.IndexOf(_SelectedDishes) + 1 ;
                    //加载选择框 菜品的单位 
                    _DishUnitItems = new List<DishUnit>();

                    DishUnit DU =   new DishUnit() { DishUnitId = 1, Name = "ddddd" };
                    _DishUnitItems.Add(new DishUnit() { DishUnitId = 1, Name = "ppppp" });
                    _DishUnitItems.Add(DU);
                    //加载菜品价格
                    IsEditDishPrice = true;
                    AddDishWin = new AddDish();

                    ChangeDishObject();
                    bool? bresult = AddDishWin.ShowDialog();
                    if (bresult != null && bresult == true)
                    {
                        //SelectedPersons = aw.CurPerson;
                    }
                }));
            }
        }
        #endregion 新增菜品
        #region 修改菜品
        //删除菜品
        RelayCommand _DeleteDishes;
        public RelayCommand DeleteDishes
        {
            get
            {
                return _DeleteDishes ?? (_DeleteDishes = new RelayCommand(() =>
                {
                    //删除菜品
                    bool flag = _DataService.deleteDish(_SelectedDishes.DishId ,1 );
                    if (flag)
                    {
                        LoadDishBase(_DishTypeIdLast);
                    }
                    else {
                        MessageBox.Show("删除菜品失败!");
                    }
                }));
            }
        }

        //点击树 SelectedTreeFun
        RelayCommand<TreeNode> _SelectedTreeFun;
        public RelayCommand<TreeNode> SelectedTreeFun
        {
            get
            {
                return _SelectedTreeFun ?? (_SelectedTreeFun = new RelayCommand<TreeNode>(node =>
                {
                    node.Selected = true;
                    //加载子节点
                    LoadTreeNodeChildren(node);
                    //加载菜品
                    LoadDishBase(node.Id);
                }));
            }
        }

        #endregion 修改菜品

        public ObservableCollection<TreeNode> DishTypeMenu { get; set; }


    }
    public class TreeNode : ViewModelBase
    {
        /// <summary>
        /// 节点编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 节点名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 子节点
        /// </summary>
        public ObservableCollection<TreeNode> Children { get; set; }


        /// <summary>
        /// 父节点
        /// </summary>
        public TreeNode Parent { get; set; }

        public bool _Selected;

        public Action<TreeNode> LoadChildreAction;
        public Action SelectedTreeNodeFalseFunAction;
        public Action<object> Action
        {
            get;
            set;
        }

        public bool Selected
        {
            get
            {
                return _Selected;
            }
            set
            {
                try
                {
                    //this._Selected = value;
                    //LoadChildreAction(this);
                    //Action(this.Id);
                    Set("Selected", ref _Selected, value);
                }
                catch (Exception E)
                {

                }

            }
        }
        public TreeNode(int id, string name, TreeNode parent, ObservableCollection<TreeNode> children)
        {
            this.Id = id;
            this.Name = name;
            this.Parent = parent;
            this.Children = children ?? new ObservableCollection<TreeNode>();
        }

        public static TreeNode createRoot(int id, string name)
        {
            return new TreeNode(id, name, null, null);
        }

        public TreeNode createChild(int id, string name)
        {
            return new TreeNode(id, name, this, null);
        }
    }
}
