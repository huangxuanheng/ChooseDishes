using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Model;
using IShow.ChooseDishes.View;
using IShow.ChooseDishes.ViewModel.Common;
using IShow.ChooseDishes.Data;
using System.Diagnostics;
using IShow.ChooseDishes.View.Dishes;

namespace IShow.ChooseDishes.ViewModel
{

    /// <summary>
    /// 菜牌ViewModel
    /// </summary>
    public class DishesMenuViewModel : ViewModelBase
    {

        IDishesMenuService _DishesMenuService;
        IChooseDishesDataService _IChooseDishesDataService;

        TreeNodeModel _RootDishesMenu;
        ObservableCollection<TreeNodeModel> _DishesMenus;

        TreeNodeModel _SelectedDishesMenu;

        public TreeNodeModel SelectedDishesMenu {
            get { return _SelectedDishesMenu; }
            set {
                this._SelectedDishesMenu = value;
            
            }
        }

        public TreeNodeModel RootDishesMenu
        {
            get {
                return _RootDishesMenu ?? (_RootDishesMenu = new TreeNodeModel("全部菜牌"));
            }
        }
        public ObservableCollection<TreeNodeModel> DishesMenus
        {
            get
            {
                return _DishesMenus ?? (_DishesMenus = new ObservableCollection<TreeNodeModel>(new TreeNodeModel[] { RootDishesMenu }));
            }
            set
            {

                Set("DishesMenu", ref _DishesMenus, value);
            }
        }





        #region ICommond
        private RelayCommand _AddCommand;


 

        public RelayCommand AddCommand
        {
            get
            {
                return _AddCommand ?? (_AddCommand=new RelayCommand(() =>
                {
                    SelectedDishesMenu = RootDishesMenu;
                    var addWindow = new AddDishesMenuWindow();
                    bool? bresult = addWindow.ShowDialog();
                    string code = addWindow.Code;
                    string name= addWindow.Name;
                    if (bresult != null && bresult == true)
                    {
                        int id=_DishesMenuService.Add(addWindow.Code, addWindow.Name);
                        //增加
                        if (id > 0)
                        {
                            this.SelectedDishesMenu.createChild(Convert.ToString(id), name);
                        }
                        else {
                            MessageBox.Show("添加菜牌保存失敗，請聯繫管理員！");
                        }
                    }

                }));
            }
            private set { }

        }

        RelayCommand<TreeNodeModel> _SelectedTree;
        public RelayCommand<TreeNodeModel> SelectedTree
        {
            get
            {
                return _SelectedTree ?? (_SelectedTree = new RelayCommand<TreeNodeModel>(node =>
                    {
                        node.Selected = true;
                        SelectedDishesMenu = node;
                        TreeNodeModelFunBase(node);
                    }));
            }
        }

        //选择菜牌时候显示的菜品
        ObservableCollection<DishBean> _DishesMenusSelected = new ObservableCollection<DishBean>();
        public ObservableCollection<DishBean> DishesMenusSelected
        {
            get
            {
                return _DishesMenusSelected ;
            }
            set {
                Set("DishesMenusSelected", ref _DishesMenusSelected, value);
            }
        }
        //选择菜品 UpdateSelectCommand
        RelayCommand _UpdateSelectCommand;
        //选择菜牌页面
        AddDishMenusRef _AddDishMenusRef;
        //菜品大类
        List<DishType> _DishTypeBig;
        public List<DishType> DishTypeBig
        {
            get
            {
                return _DishTypeBig;
            }
            set
            {
                Set("DishTypeBig", ref _DishTypeBig, value);
            }
        }
        //菜品小类
        ObservableCollection<DishType> _DishTypeSmail;
        public ObservableCollection<DishType> DishTypeSmail
        {
            get
            {
                return _DishTypeSmail;
            }
            set
            {
                Set("DishTypeSmail", ref _DishTypeSmail, value);
            }
        }
        public RelayCommand UpdateSelectCommand
        {
            get
            {
                return _UpdateSelectCommand ?? (_UpdateSelectCommand = new RelayCommand(() =>
                {
                    //查看是否选择了 相应菜牌
                    if (SelectedDishesMenu == null || "0".Equals(SelectedDishesMenu.Id))
                    {
                        MessageBox.Show("请选择相应的菜牌!");
                        return;
                    }
                    //加载所有的 菜品 大类 小类 
                    //加载所有大类
                    _DishTypeBig = _IChooseDishesDataService.FindDishTypeByType(0);
                    LoadDishObject();
                    _AddDishMenusRef = new AddDishMenusRef();
                    _AddDishMenusRef.ShowDialog();



                }));
            }
        }
        //加载所有的 菜品 大类 小类 
        public void LoadDishObject() {
            //加载所有小类
            _DishTypeSmail = new ObservableCollection<DishType>();
            List<DishType> listsmail = _IChooseDishesDataService.FindDishTypeByType(-1);
            _DishTypeSmail.Clear();
            foreach (var element in listsmail)
            {
                _DishTypeSmail.Add(element);
            }

            //加载所有的菜品
            List<Dish> list = _IChooseDishesDataService.FindDishs(0);
            _DishesMenusSelected.Clear();

            foreach (var element in list)
            {
                DishBean dishBean = new DishBean().CreateDishBean(element);
                //注入大类,小类
                for (int i = 0; i < _DishTypeSmail.Count; i++)
                {
                    if (element.DishTypeId == _DishTypeSmail[i].DishTypeId) {
                        dishBean.DishTypeName = _DishTypeSmail[i].Name;
                        bool flag = false ;
                        for (int j = 0; j < _DishTypeBig.Count; j++) {
                            if (_DishTypeSmail[i].ParentId == _DishTypeBig[j].DishTypeId)
                            {
                                dishBean.DishTypeBigName = _DishTypeBig[j].Name;
                                flag = true;
                                break ;
                            }
                        }
                        if (flag) break;
                    }
                }
                DishesMenusSelected.Add(dishBean);
            }
            
            
        }

        //点击菜品大类 SelectedItemBig
        DishType _SelectedItemBig;
        public DishType SelectedItemBig
        {
            get {
                return _SelectedItemBig;
            }
            set {
                if (value == null) {
                    LoadDishObject();
                    return;
                }
                
                List<DishType> listsmail = _IChooseDishesDataService.FindDishTypeByType(value.DishTypeId);
                DishTypeSmail.Clear();
                foreach (var element in listsmail)
                {
                    DishTypeSmail.Add(element);
                } 
                //更新菜品
                List<Dish> list = _IChooseDishesDataService.FindDishs(value.DishTypeId);
                _DishesMenusSelected.Clear();

                foreach (var element in list)
                {
                    DishesMenusSelected.Add(new DishBean().CreateDishBean(element));
                }

                Set("SelectedItemBig", ref _SelectedItemBig, value);
            }
        }
        //点击菜品小类 SelectedItemSmail
        DishType _SelectedItemSmail;
        public DishType SelectedItemSmail
        {
            get
            {
                return _SelectedItemSmail;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                //更新菜品
                List<Dish> list = _IChooseDishesDataService.FindDishs(value.DishTypeId);
                _DishesMenusSelected.Clear();

                foreach (var element in list)
                {
                    DishesMenusSelected.Add(new DishBean().CreateDishBean(element));
                }

                Set("SelectedItemSmail", ref _SelectedItemSmail, value);
            }
        }
        //选择的菜品 
        DishBean _SelectedDishes ;
        public DishBean SelectedDishes
        {
            get {

                return _SelectedDishes;
            }
            set {
                Set("SelectedDishes", ref _SelectedDishes, value);
            }
        }
        
        //需要新增的菜牌集合 
        //新增菜牌 菜品关联  OkSelect
        RelayCommand _OkSelect;
        public RelayCommand OkSelect
        {
            get
            {
                return _OkSelect ?? (_OkSelect = new RelayCommand(() =>
                {
                    //保存需要添加的菜品
                    List<int> list = new List<int>();
                    foreach (var element in _DishesMenusSelected)
                    {
                        if (element.IsSelectedMenus) {
                            //查看数据是否已经加入到菜牌中
                            bool flag = true ;
                            foreach (var elem in _DishItems) {
                                if (elem.DishId == element.DishId) {
                                    flag = false;
                                    break;
                                }
                            }
                            if (flag) { 
                                list.Add(element.DishId);
                            }
                        }
                    }
                    if(list.Count>0){
                        //保存数据
                        _DishesMenuService.BatchAddDishes(int.Parse(SelectedDishesMenu.Id), list.ToArray());
                        //刷新数据
                        TreeNodeModelFunBase(SelectedDishesMenu);
                    }
                    //关闭窗口
                    _AddDishMenusRef.Close();
                }));

            }
        }
        //删除菜牌中的菜品
        RelayCommand _DeleteCommand;
        public RelayCommand DeleteCommand {
            get {
                return _DeleteCommand ?? (_DeleteCommand = new RelayCommand(() => { 
                    //删除数据库中的关系数据
                    List<int> list = new List<int>();
                    //foreach (var element in _DishItems)
                    //{
                    //    if (element.IsSelectedMenus) {
                    //        list.Add(element.DishId);
                    //    } 
                    //}
                    if (_SelectedDishes != null) { 
                        list.Add(_SelectedDishes.DishId);
                    }
                    //删除数据
                    if (list.Count > 0) { 
                        _DishesMenuService.BatchRemoveDishes(int.Parse(SelectedDishesMenu.Id), list.ToArray());
                        //刷新数据
                        //foreach (var element in DishItems)
                        //{
                        //    if (element.IsSelectedMenus)
                        //    {
                        //        DishItems.Remove(element);
                        //    }
                        //}
                        DishItems.Remove(_SelectedDishes);
                        if (DishItems.Count>0)
                            SelectedDishes = DishItems.Last();

                    }
                }));
            }
        }

        //模糊搜索
        string _MoFuSouSuo;
        public string MoFuSouSuo
        {

            get
            {
                return _MoFuSouSuo;
            }
            set
            {
                Set("MoFuSouSuo", ref _MoFuSouSuo, value);
            }
        }

        //条件重置  ResetSelectValue
        RelayCommand _ResetSelectValue;
        public RelayCommand ResetSelectValue {
            get {
                return _ResetSelectValue ?? (_ResetSelectValue = new RelayCommand(() => {
                    MoFuSouSuo = null;
                    _AddDishMenusRef.DishTypeBigComBoBox.SelectedItem = null;
                    _AddDishMenusRef.DishTypeSmailComBoBox.SelectedItem = null;
                
                }));
            
            }
        }
        //运用  进行模糊搜索  YunYongSelectValue
        RelayCommand _YunYongSelectValue;
        public RelayCommand YunYongSelectValue
        {
            get
            {
                return _YunYongSelectValue ?? (_YunYongSelectValue = new RelayCommand(() =>
                {
                    //搜索更新菜品
                    List<Dish> list = _IChooseDishesDataService.FindDishsByDishName(_MoFuSouSuo);
                    _DishesMenusSelected.Clear();

                    foreach (var element in list)
                    {
                        DishesMenusSelected.Add(new DishBean().CreateDishBean(element));
                    }

                }));

            }
        }
        #endregion

        /// <summary>
        /// 加载初始化数据
        /// </summary>
        public void Init() {

            var menuList = _DishesMenuService.QueryAll();
            RootDishesMenu.Id = "0";
            foreach (var menu in menuList)
            {
                RootDishesMenu.createChild(menu.MenusId.ToString(), menu.Name);
            } 
        }




        public DishesMenuViewModel(IDishesMenuService dataService, IChooseDishesDataService ChooseDishesDataService , IMessenger messenger)
            : base(messenger)
        {
            _DishesMenuService = dataService;
            _IChooseDishesDataService = ChooseDishesDataService;
            this.Init();
        }

        //菜品集合
        ObservableCollection<DishBean> _DishItems = new ObservableCollection<DishBean>();
        public ObservableCollection<DishBean> DishItems
        {
            get {
                return _DishItems ;
            }
            set
            {
                this._DishItems = value;
                Set("DishItems", ref _DishItems, value);
            }
        }
        //点击菜牌节点做的事情
        public void TreeNodeModelFunBase(Object bean) {
            if (bean is TreeNodeModel) {
                TreeNodeModel tree = (TreeNodeModel)bean ;
                List<Dish>  dishes = _IChooseDishesDataService.findAllDishByDishMenusId(int.Parse(tree.Id));
                _DishItems.Clear();
                foreach (var element in dishes) {
                    DishBean dishBean   = new DishBean().CreateDishBean(element) ;
                    //注入菜牌名字
                    dishBean.DishMenusName = tree.Text;
                    //注入菜品单位
                    dishBean.DishUnitName = element.DishUnit.Name;
                    _DishItems.Add(dishBean);
                }
            }
        }


        /// <summary>
        /// 回调函数
        /// </summary>
        /// <param name="parameter"></param>
        public void SelectedItemChanged(object parameter)
        {
            //if (null == parameter) {
            //    return;
            //}
            //SelectedDishesMenu = parameter as TreeNodeModel;
            //_DishItems.Clear();
            //List<DishesMenuItemModel> items = _DishesMenuService.FindItemsById(Convert.ToInt16(SelectedDishesMenu.Id));
            //foreach(var item in items){
            //   // DishesMenus.Add(t.createChild(item.));
            //}
        }

    }


  

    public class DishesMenuItem {


        /// <summary>
        /// 索引
        /// </summary>
        public string Index { get; set; }
        /// <summary>
        /// 所属菜牌名称
        /// </summary>
        public string DishesMenuName { get; set; }
        /// <summary>
        /// 菜品编号
        /// </summary>
        public string DishesCode { get; set; }
        /// <summary>
        /// 菜品类型
        /// </summary>
        public string DishesType { get; set; }
        /// <summary>
        /// 菜品单位名称
        /// </summary>
        public string DishesUnitName { get; set; }
        /// <summary>
        /// 规格名称
        /// </summary>
        public string DishesModelName { get; set; }


        public DishesMenuItem(string _Index, string _DishesMenuName, string _DishesCodeName, string _DishesType, string _DishesUnitName, string _DishesModelName)
        {
            this.Index = _Index;
            this.DishesMenuName = _DishesMenuName;
            this.DishesCode = _DishesCodeName;
            this.DishesType = _DishesType;
            this.DishesUnitName = _DishesUnitName;
            this.DishesModelName = _DishesModelName;
        
        }

        public DishesMenuItem(DishesMenuItemModel item):this(null,null,null,null,null,null)
        {
        
        }
    
    }

}
   
