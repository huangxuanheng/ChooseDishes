﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.View;
using IShow.Service;
using IShow.ChooseDishes.Api;

namespace IShow.ChooseDishes.ViewModel
{

    /// <summary>
    /// 菜牌ViewModel
    /// </summary>
    public class DishesMenuViewModel : ViewModelBase
    {

        IChooseDishesDataService _DataService;

        #region Binding

        ObservableCollection<TreeNode> _DishesMenu;
        public ObservableCollection<TreeNode> DishesMenu
        {
            get
            {
                return _DishesMenu ?? (_DishesMenu= new ObservableCollection<TreeNode>());
            }
            set
            {
                this._DishesMenu = value;
                Set("DishesMenu", ref _DishesMenu, value);
            }
        }

        ObservableCollection<DishesMenuItem> _DishesMenuItems;
        public ObservableCollection<DishesMenuItem> DishesMenuItems
        {
            get
            {
                return _DishesMenuItems ?? (_DishesMenuItems = new ObservableCollection<DishesMenuItem>());
            }
            private set { }
        }
        #endregion

        #region ICommond
        private RelayCommand _AddCommand;
        //private RelayCommand _SelectDishesCommand;
        //private RelayCommand _DelCommand;

 

        public RelayCommand AddCommand
        {
            get
            {
                return _AddCommand ?? (_AddCommand=new RelayCommand(() =>
                {
                    var addWindow = new AddDishesMenuWindow();
                    bool? bresult = addWindow.ShowDialog();
                    if (bresult != null && bresult == true)
                    {
                      //  _DataService.InsertDishesMenu(addWindow.Name);
                    }

                }));
            }
            private set { }

        }
        #endregion

        /// <summary>
        /// 加载初始化数据
        /// </summary>
        public void Init() {
            this.DishesMenu = new ObservableCollection<TreeNode>();
            TreeNode root = TreeNode.createRoot("0000","全部类型");
            this.DishesMenu.Add(root);

            //new Task(() => { 
                //加载数据库菜牌数据
             // var dishesMenus = _DataService.QueryAllDishesMenu();
             //foreach (var menu in dishesMenus) {
             //    var child = root.createChild(menu.Id, menu.Name);
             //    child.Action = LoadDishesItemsAction;
             //    root.Children.Add(child);
             // }
             RaisePropertyChanged("DishesMenu");
          //  }).Start();
        }

        


        public DishesMenuViewModel(IChooseDishesDataService dataService, IMessenger messenger)
            : base(messenger)
        {
            _DataService = dataService;
            this.Init();
        }

        /// <summary>
        /// 回调函数
        /// </summary>
        /// <param name="parameter"></param>
        public void LoadDishesItemsAction(object parameter) {
            Random ran = new Random();
            int RandKey = ran.Next(100, 999);
            DishesMenuItems.Clear();
            for (int i = RandKey; i <RandKey+ 100; i++)
            {
                DishesMenuItems.Add(new DishesMenuItem("x"+i,"x"+i,"x"+i,"x"+i,"x"+i,"x"+i));
            }
        }



    }


    public class TreeNode{
        /// <summary>
        /// 节点编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 节点名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 子节点
        /// </summary>
        public List<TreeNode> Children { get; set; }

        /// <summary>
        /// 父节点
        /// </summary>
        public TreeNode Parent { get; set; }

        private bool _Selected;

        public Action<object> Action{
            get;
            set;
        }

        public bool Selected
        {
            get {
                return _Selected;
            }
            set {
                this._Selected = value;
                Action(this);
            }
        }

        public TreeNode(string id, string name,TreeNode parent,List<TreeNode> children) {
            this.Id = id;
            this.Name = name;
            this.Parent = parent;
            this.Children = children ?? new List<TreeNode>();
        }

        public static TreeNode createRoot(string id, string name) {
            return new TreeNode(id, name,null,null);
        }

        public TreeNode createChild(string id, string name) {
            return new TreeNode(id, name, this, null);
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
    
    }


    
       
}
