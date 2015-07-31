using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Data;
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
            this.DishType= new ObservableCollection<DishTypeTreeNode>();
            DishTypeTreeNode root = DishTypeTreeNode.createRoot("0000", "全部类型");
            this.DishType.Add(root);

            root.Children.Add(root.createChild("111", "2222"));

           // new Task(() =>
           // {
                //加载数据库菜牌数据
                var disheTypes = _DishService.LoadTypeById(2);
                //MessageBox.Show("disheTypes===" + disheTypes.Count() + disheTypes[0].Name);
                foreach (var disheTyp in disheTypes)
                {
                    root.Children.Add(root.createChild(disheTyp.DishTypeId.ToString(), disheTyp.Name));
                 }
          //  }).Start();
        }

        public DishTypeViewModel(IDishService dishService, IMessenger messenger):base(messenger)
        {
            _DishService = dishService;
            //this.Init();
        }

       

        #region Observable
        int _Id;
        public int Id{

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
        public ObservableCollection<DishTypeTreeNode> DishType
        {
            get;
            set;
        }
        public ObservableCollection<DishType> DisheTypeItem
        {
            get;
            set;
        }
        #endregion
            
        #region Command
        RelayCommand _Delete;
        public RelayCommand Delete
        {
            get
            {
                return _Delete ?? (_Delete = new RelayCommand(() =>
                {
                    bool flag=_DishService.DeleteType(new DishType());
                    if (flag)
                    {
                        
                        MessageBox.Show("删除成功！");
                        
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
                   List<DishType> typeList = _DishService.LoadType(type);
                    if (typeList != null && typeList.Count>0)
                    {

                        MessageBox.Show("返回数据条数为：" + typeList.Count()+";"+typeList[0].Name);

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
                    DishType type = new DishType();
                    type.Name = Name;
                    type.Code = Code;
                    type.ParentId = null;
                    type.Status = 0;
                    type.CreateBy = 002;
                    type.CreateDatetime = DateTime.Now;
                    type.Deleted = 0;
                    Hashtable result = _DishService.SaveType(type);
                    try
                    {
                        if (Convert.ToInt32(result["code"]) == 0)
                        {
                            MessageBox.Show("新增成功！");
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

        /// <summary>
        /// 子节点
        /// </summary>
        public List<DishTypeTreeNode> Children { get; set; }

        /// <summary>
        /// 父节点
        /// </summary>
        public DishTypeTreeNode Parent { get; set; }

        public DishTypeTreeNode(string id, string name, DishTypeTreeNode parent, List<DishTypeTreeNode> children)
        {
            this.Id = id;
            this.Name = name;
            this.Parent = parent;
            this.Children = children ?? new List<DishTypeTreeNode>();
        }

        public static DishTypeTreeNode createRoot(string id, string name)
        {
            return new DishTypeTreeNode(id, name, null, null);
        }

        public DishTypeTreeNode createChild(string id, string name)
        {
            return new DishTypeTreeNode(id, name, this, null);
        }
    }

    
}
