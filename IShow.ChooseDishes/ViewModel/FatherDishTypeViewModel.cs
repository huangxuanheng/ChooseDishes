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
    public class FatherDishTypeViewModel : ViewModelBase
    {
        IDishService _DishService;

        public void Init()
        {
            //初始化时查询所有子类
            this.DishTypes = new ObservableCollection<DishType>(_DishService.LoadType());
        }

        public FatherDishTypeViewModel(IDishService dishService, IMessenger messenger)
            : base(messenger)
        {
            _DishService = dishService;
            this.Init();//
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

        UpdateFatherDishType _UpdateTypeWin;
        public UpdateFatherDishType UpdateTypeWin
        {
            get
            {
                return _UpdateTypeWin;
            }
            set
            {
                Set("UpdateTypeWin", ref _UpdateTypeWin, value);
            }
        }

        #endregion Observable




        #region Binding

        ObservableCollection<DishType> _DishTypes;
        public ObservableCollection<DishType> DishTypes
        {
            get
            {
                return _DishTypes ?? (_DishTypes = new ObservableCollection<DishType>());
            }
            set 
            {
                this._DishTypes = value;
                Set("DishTypes", ref _DishTypes, value);
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
                        MessageBox.Show("请在列表当中选择要删除的类别！");
                        return;
                    }

                    int dishTypeId = this.SelectedType.DishTypeId;
                    bool flag = _DishService.DeleteType(dishTypeId);
                    if (flag)
                    {
                        MessageBox.Show("删除成功！");
                        this.DishTypes.Remove(SelectedType);
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
                    if (Name == null || "".Equals(Name.Trim()) || Code == null || "".Equals(Code.Trim()))
                    {
                        MessageBox.Show("类型编号和名称不能为空");
                    }
                    DishType type = new DishType();
                    type.Name = Name;
                    type.Code = Code;
                    
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
                            this.DishTypes.Add(type);
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

                    AddFatherDishType addType = new AddFatherDishType();
                    addType.Show();
                    
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

                    this.UpdateTypeWin = new UpdateFatherDishType();
                    this.UpdateTypeWin.Show();
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
                    type.Name = this.SelectedType.Name;
                    type.UpdateBy = 2;
                    type.UpdateDatetime = DateTime.Now;
                    bool flag=_DishService.UpdateType(type);
                    if (flag)
                    {
                        MessageBox.Show("修改成功！");
                        this.UpdateTypeWin.Close();
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
}
