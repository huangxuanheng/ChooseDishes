using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.View.Dish;
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
    public class DishTypeViewModel : ViewModelBase
    {
        IDishService _DishService;

        public void Init()
        {
            this.DishType = new ObservableCollection<DishTypeTreeNode>();
            DishTypeTreeNode root = DishTypeTreeNode.createRoot("0", "全部类型", false);
            root.Action = LoadDishesItemsAction;
            this.DishType.Add(root);
            //加载所有大类
            var disheTypes = _DishService.LoadFatherType();
            //MessageBox.Show("disheTypes===" + disheTypes.Count() + disheTypes[0].Name);
            foreach (var disheTyp in disheTypes)
            {
                var child = root.createChild(disheTyp.DishTypeId.ToString(), disheTyp.Name, false);
                child.Action = LoadDishesItemsAction;
                root.Children.Add(child);
            }
        }

        public DishTypeViewModel(IDishService dishService, IMessenger messenger)
            : base(messenger)
        {
            _DishService = dishService;
            this.Init();//构造目录树
            //初始化时查询所有子类
            this.DisheTypeItem = new ObservableCollection<DishType>(_DishService.LoadSubType());

        }
     
        public void LoadDishesItemsAction(object parameter)
        {
            DishTypeTreeNode node = (DishTypeTreeNode)parameter;



            //MessageBox.Show("start");
            this.DisheTypeItem.Clear();
            List<DishType> dishTypeList;
            if (node.Id.Equals("0"))//根结点
            {
                dishTypeList = _DishService.LoadSubType();//查询所有子类
            }
            else//非根结点
            {
                dishTypeList = _DishService.LoadSubTypeById(Convert.ToInt32(node.Id));//查询子类
            }
            foreach (DishType dishType in dishTypeList)
            {
                this.DisheTypeItem.Add(dishType);
            }
        }

        #region Observable
        int _Id;
        public int Id
        {

            get
            {
                return _Id;
            }
            set
            {
                Set("Id", ref _Id, value);
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

        string _Code;
        public string Code
        {

            get
            {
                return _Code;
            }
            set
            {
                Set("Code", ref _Code, value);
            }
        }

        int _Status;
        public int Status
        {

            get
            {
                return _Status;
            }
            set
            {
                Set("Status", ref _Status, value);
            }
        }

        int _ParentId;
        public int ParentId
        {

            get
            {
                return _ParentId;
            }
            set
            {
                Set("ParentId", ref _ParentId, value);
            }
        }

        int _CreateBy;
        public int CreateBy
        {

            get
            {
                return _CreateBy;
            }
            set
            {
                Set("CreateBy", ref _CreateBy, value);
            }
        }

        System.DateTime _CreateDatetime;
        public System.DateTime CreateDatetime
        {

            get
            {
                return _CreateDatetime;
            }
            set
            {
                Set("CreateDatetime", ref _CreateDatetime, value);
            }
        }

        int _UpdateBy;
        public int UpdateBy
        {

            get
            {
                return _UpdateBy;
            }
            set
            {
                Set("UpdateBy", ref _UpdateBy, value);
            }
        }

        System.DateTime _UpdateTime;
        public System.DateTime UpdateTime
        {

            get
            {
                return _UpdateTime;
            }
            set
            {
                Set("UpdateTime", ref _UpdateTime, value);
            }
        }

        int _Deleted;
        public int Deleted
        {

            get
            {
                return _Deleted;
            }
            set
            {
                Set("Deleted", ref _Deleted, value);
            }
        }
        #endregion Observable

        #region Binding

        ObservableCollection<DishTypeTreeNode> _DishType;
        public ObservableCollection<DishTypeTreeNode> DishType
        {
            get
            {
                return _DishType ?? (_DishType = new ObservableCollection<DishTypeTreeNode>());
            }
            set
            {
                this._DishType = value;
                Set("DishType", ref _DishType, value);
            }
        }

        ObservableCollection<DishType> _DisheTypeItem;
        public ObservableCollection<DishType> DisheTypeItem
        {
            get
            {
                return _DisheTypeItem ?? (_DisheTypeItem = new ObservableCollection<DishType>());
            }
            set
            {
                this._DisheTypeItem = value;
                Set("DisheTypeItem", ref _DisheTypeItem, value);
            }
        }

        DishType _SelectedType;
        public DishType SelectedType
        {
            get
            {
                return _SelectedType ?? (_SelectedType = new DishType());
            }
            set
            {
                this._SelectedType = value;
                Set("SelectedType", ref _SelectedType, value);
            }
        }
        #endregion

        #region Command
        RelayCommand _DeleteType;
        public RelayCommand DeleteType
        {
            get
            {
                return _DeleteType ?? (_DeleteType = new RelayCommand(() =>
                {
                    if (SelectedType == null)
                    {
                        MessageBox.Show("请在右边列表当中选择要删除的类别！");
                        return;
                    }

                    int dishTypeId = this.SelectedType.DishTypeId;
                    bool flag = _DishService.DeleteType(dishTypeId);
                    if (flag)
                    {
                        MessageBox.Show("删除成功！");
                        DisheTypeItem.Remove(SelectedType);
                    }
                    else
                    {
                        MessageBox.Show("删除失败！");
                    }

                }));
            }
        }

        RelayCommand _LoadType;
        public RelayCommand LoadType
        {
            get
            {
                return _LoadType ?? (_LoadType = new RelayCommand(() =>
                {
                    DishType type = new DishType();
                    List<DishType> typeList = _DishService.LoadType();
                    if (typeList != null && typeList.Count > 0)
                    {

                        MessageBox.Show("返回数据条数为：" + typeList.Count() + ";" + typeList[0].Name);

                    }
                    else
                    {
                        MessageBox.Show("查询失败！");
                    }

                }));
            }
        }

        RelayCommand _SaveType;
        public RelayCommand SaveType
        {
            get
            {
                return _SaveType ?? (_SaveType = new RelayCommand(() =>
                {
                    if (Name == null || "".Equals(Name.Trim()) || Code == null || "".Equals(Code.Trim()))
                    {
                        MessageBox.Show("类型编号和名称不能为空");
                    }
                    string parentId = "0";
                    for (var index = 0; index < _DishType[0].Children.Count; index++)
                    {
                        if (_DishType[0].Children[index]._Selected == true)//大类是否选中
                        {
                            parentId = _DishType[0].Children[index].Id;
                            break;
                        }
                    }

                    DishType type = new DishType();
                    type.Name = Name;
                    type.Code = Code;
                    if (!parentId.Equals("0"))
                    {
                        type.ParentId = Convert.ToInt32(parentId);
                    }
                    type.Status = 0;
                    type.CreateBy = 002;
                    type.CreateDatetime = DateTime.Now;
                    type.UpdateBy = 002;
                    type.UpdateDatetime = DateTime.Now;
                    type.Deleted = 0;
                    Hashtable result = _DishService.SaveType(type);
                    try
                    {
                        if (Convert.ToInt32(result["code"]) == 0)
                        {
                            MessageBox.Show("新增成功！");
                            this.DisheTypeItem.Add(type);
                            this.Code = "";
                            this.Name = "";
                        }
                        else
                        {
                            MessageBox.Show("新增失败:" + result["message"]);
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }

                }));
            }
        }

        RelayCommand _AddType;
        public RelayCommand AddType
        {
            get
            {
                return _AddType ?? (_AddType = new RelayCommand(() =>
                {
                    bool hasCheck = false;

                    for (var index = 0; index < _DishType[0].Children.Count && hasCheck == false; index++)
                    {
                        if (_DishType[0].Children[index]._Selected == true)//大类是否选中
                        {
                            hasCheck = true;
                            break;
                        }
                    }
                    if (hasCheck)
                    {
                        AddDishType addType = new AddDishType();
                        addType.Show();
                    }
                    else
                    {
                        MessageBox.Show("请先选择大类！");
                    }

                }));
            }
        }

        RelayCommand _ModifyType;
        public RelayCommand ModifyType
        {
            get
            {
                return _ModifyType ?? (_ModifyType = new RelayCommand(() =>
                {
                    if (SelectedType == null)
                    {
                        MessageBox.Show("请在右边列表当中选择要修改的类别！");
                        return;
                    }

                    UpdateDishType updateType = new UpdateDishType();
                    updateType.Show();
                }));
            }
        }

        RelayCommand _UpdateType;
        public RelayCommand UpdateType
        {
            get
            {
                return _UpdateType ?? (_UpdateType = new RelayCommand(() =>
                {
                    DishType type = new DishType();
                    type.DishTypeId = this.SelectedType.DishTypeId;
                    //type.Code = this.Code;
                    type.Name = this.SelectedType.Name;
                    type.UpdateBy = 2;
                    type.UpdateDatetime = DateTime.Now;
                    bool flag = _DishService.UpdateType(type);
                    if (flag)
                    {
                        MessageBox.Show("修改成功！");
                        //this.
                    }
                    else
                    {
                        MessageBox.Show("修改失败！");
                    }
                }));
            }
        }
        #endregion Command
    }




    public class DishTypeTreeNode
    {
        /// <summary>
        /// 节点编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 节点名称
        /// </summary>
        public string Name { get; set; }

        public DishTypeTreeNode Parent { get; set; }

        //public bool isRoot()
        //{
        //    return this.Parent == null;
        //}


        public Action<object> Action
        {
            get;
            set;
        }

        public bool _Selected;

        public bool Selected
        {
            get
            {
                return _Selected;
            }
            set
            {
                this._Selected = value;
                Action(this);
                if (this.Id.Equals("0"))
                {
                    Action(this);
                }
            }
        }

        /// <summary>
        /// 子节点
        /// </summary>
        public List<DishTypeTreeNode> Children { get; set; }

        /// <summary>
        /// 父节点

        public DishTypeTreeNode(string id, string name, DishTypeTreeNode parent, bool selected, List<DishTypeTreeNode> children)
        {
            this.Id = id;
            this.Name = name;
            this.Parent = parent;
            this._Selected = selected;
            this.Children = children ?? new List<DishTypeTreeNode>();
        }

        public static DishTypeTreeNode createRoot(string id, string name, bool selected)
        {
            return new DishTypeTreeNode(id, name, null, selected, null);
        }

        public DishTypeTreeNode createChild(string id, string name, bool selected)
        {
            return new DishTypeTreeNode(id, name, this, selected, null);
        }
    }


}
