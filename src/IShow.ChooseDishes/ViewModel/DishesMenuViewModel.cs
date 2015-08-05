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

        //选择菜品时候显示的菜品
        ObservableCollection<Dish> _DishesMenusSelected = new ObservableCollection<Dish>();
        public ObservableCollection<Dish> DishesMenusSelected
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
                    //加载所有的菜品
                    List<Dish> list = _IChooseDishesDataService.FindDishs(0);
                    _DishesMenusSelected.Clear();

                    foreach (var element in list)
                    {
                        DishesMenusSelected.Add(element);
                    }
                    //加载所有大类
                    _DishTypeBig = _IChooseDishesDataService.FindDishTypeByType(0);
                    //加载所有小类
                    _DishTypeSmail = new ObservableCollection<DishType>();
                    List<DishType> listsmail = _IChooseDishesDataService.FindDishTypeByType(-1);
                    foreach (var element in listsmail) {
                        _DishTypeSmail.Add(element);
                    }
                    _AddDishMenusRef = new AddDishMenusRef();
                    _AddDishMenusRef.ShowDialog();



                }));
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
                    DishesMenusSelected.Add(element);
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
               
                //更新菜品
                List<Dish> list = _IChooseDishesDataService.FindDishs(value.DishTypeId);
                _DishesMenusSelected.Clear();

                foreach (var element in list)
                {
                    DishesMenusSelected.Add(element);
                }

                Set("SelectedItemSmail", ref _SelectedItemSmail, value);
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
        ObservableCollection<Dish> _DishItems = new ObservableCollection<Dish>();
        public ObservableCollection<Dish> DishItems {
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
                    _DishItems.Add(element);
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
   
