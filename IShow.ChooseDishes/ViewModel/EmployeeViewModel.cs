using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Model;
using IShow.ChooseDishes.Security;
using IShow.ChooseDishes.View.OrgInfo;
using IShow.ChooseDishes.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace IShow.ChooseDishes.ViewModel
{

    public class EmployeeViewModel : ViewModelBase
    {
        IEmployeeService _DataService;
        readonly TreeNodeModel _RootTreeNode;
        ObservableCollection<TreeNodeModel> _FirstGeneration;
        //主窗体初始化
        public EmployeeViewModel(IEmployeeService dataService)
        {
            _DataService = dataService;
            //查询部门，生成树
            _RootTreeNode = new TreeNodeModel("全部行政部门");

            DepartmentInfo dep = new DepartmentInfo();
            dep.CompanyId = 1;
             List<DepartmentInfo> queryByDepartment=_DataService.QueryByDepartment(dep);

             foreach (var depar in queryByDepartment)
             {
                 _RootTreeNode.Children.Add(new TreeNodeModel("" + depar.DepartmentId, depar.DepartmentName, _RootTreeNode));
            }
            //TreeNodeModel hunan = new TreeNodeModel("1","湖南", _RootTreeNode);
            //TreeNodeModel shaoyan = new TreeNodeModel("3", "邵阳", hunan);
            //TreeNodeModel hengyan = new TreeNodeModel("4", "衡阳", hunan);
            //TreeNodeModel wuhan = new TreeNodeModel("5", "武汉", hubei);
            //_RootTreeNode.Children.Add(hubei);
            //_RootTreeNode.Children.Add(hunan);
            //hunan.Children.Add(shaoyan);
            //hunan.Children.Add(hengyan);
            //hubei.Children.Add(wuhan);
            _FirstGeneration = new ObservableCollection<TreeNodeModel>(new TreeNodeModel[]{ 
                _RootTreeNode
            });

            //查询员工绑定grid
            EmployeeV = new ObservableCollection<EmployeeBean>();
            Employee employee = new Employee();
           
            List<Employee> loooo = _DataService.QueryByEmployee(employee);

            bool a = loooo != null;
            if (a)
            {
                foreach (var loca in loooo)
                {
                    EmployeeV.Add(new EmployeeBean
                    {
                        UserId = loca.UserId,
                                                 DepartmentId = loca.DepartmentId,JobNo = loca.JobNo,Name = loca.Name, 
                                                 Sex = loca.Sex, SexVal = (loca.Sex == 1) ? "男" : "女", Birthday = loca.Birthday,
                                                 Flag = loca.Flag, FlagVal = (loca.Flag == 1) ? "离职" : "在职", Mobile = loca.Mobile,
                                                 Email = loca.Email,Position = loca.Position,Phone = loca.Phone,Code = loca.Code,
                                                 ResidentialAddress = loca.ResidentialAddress,IDAddress = loca.IDAddress,Remark = loca.Remark});
                }
            }
        }

        //树绑定数据源
        public ObservableCollection<TreeNodeModel> FirstGeneration
        {
            get { return _FirstGeneration; }
         }

        ObservableCollection<EmployeeBean> _EmployeeV;
        //主窗口绑定数据
        public ObservableCollection<EmployeeBean> EmployeeV
        {
            get {
                return _EmployeeV ?? (_EmployeeV = new ObservableCollection<EmployeeBean>());
        } set {
            Set("EmployeeV", ref _EmployeeV, value);
        } }

        //grid选中事件
        EmployeeBean _SelectedEmployee;
        public EmployeeBean SelectedEmployee
        {
            get
            {
                return _SelectedEmployee;
            }
            set
            {
                Set("SelectedEmployee", ref _SelectedEmployee, value);
            }
        }

        //树绑定数据
        public DepartmentBean _departmentBean;

        //树的选中事件
        RelayCommand<TreeNodeModel> _SelectedTree;
        public RelayCommand<TreeNodeModel> SelectedTree
        {
            get
            {
                return _SelectedTree ?? (_SelectedTree = new RelayCommand<TreeNodeModel>(node =>
                    {

                        EmployeeV = new ObservableCollection<EmployeeBean>();
                        Employee employee = new Employee();


                        if (!node.Text.Equals("全部行政部门"))
                        {
                            node.Selected = true;
                            String id = node.Id;
                            _departmentBean = new DepartmentBean();
                            _departmentBean._DepartmentId = int.Parse(id);
                            _departmentBean._DepartmentName = node.Text;

                            employee.DepartmentId = int.Parse(id);
                            List<Employee> loooo = _DataService.QueryByEmployee(employee);
                            bool a = loooo != null;
                            if (a)
                            {
                                foreach (var loca in loooo)
                                {
                                    EmployeeV.Add(new EmployeeBean
                                    {
                                        UserId = loca.UserId,
                                        DepartmentId = loca.DepartmentId,
                                        JobNo = loca.JobNo,
                                        Name = loca.Name,
                                        Sex = loca.Sex,
                                        SexVal = (loca.Sex == 1) ? "男" : "女",
                                        Birthday = loca.Birthday,
                                        Flag = loca.Flag,
                                        FlagVal = (loca.Flag == 1) ? "离职" : "在职",
                                        Mobile = loca.Mobile,
                                        Email = loca.Email,
                                        Position = loca.Position,
                                        Phone = loca.Phone,
                                        Code = loca.Code,
                                        ResidentialAddress = loca.ResidentialAddress,
                                        IDAddress = loca.IDAddress,
                                        Remark = loca.Remark
                                    });
                                }
                            }
                        }
                        else {
                            List<Employee> loooo = _DataService.QueryByEmployee(employee);
                            bool a = loooo != null;
                            if (a)
                            {
                                foreach (var loca in loooo)
                                {
                                    EmployeeV.Add(new EmployeeBean
                                    {
                                        UserId = loca.UserId,
                                        DepartmentId = loca.DepartmentId,
                                        JobNo = loca.JobNo,
                                        Name = loca.Name,
                                        Sex = loca.Sex,
                                        SexVal = (loca.Sex == 1) ? "男" : "女",
                                        Birthday = loca.Birthday,
                                        Flag = loca.Flag,
                                        FlagVal = (loca.Flag == 1) ? "离职" : "在职",
                                        Mobile = loca.Mobile,
                                        Email = loca.Email,
                                        Position = loca.Position,
                                        Phone = loca.Phone,
                                        Code = loca.Code,
                                        ResidentialAddress = loca.ResidentialAddress,
                                        IDAddress = loca.IDAddress,
                                        Remark = loca.Remark
                                    });
                                }
                            }
                        }


                    }));
            }
        }
        //删除数据
        RelayCommand _Delete;
        public RelayCommand Delete
        {
            get
            {
                return _Delete ?? (_Delete = new RelayCommand(() =>
                {
                    if (SelectedEmployee != null)
                    {
                        Employee employee = new Employee();
                        employee.UserId = SelectedEmployee.UserId;
                        employee.UpdateBy = 8;
                        employee.Deleted = 1;
                        employee.UpdateDatetime = DateTime.Now;

                        int b = _DataService.DelByEmployee(employee);
                        if (b.Equals(1))
                        {
                            EmployeeV.Remove(SelectedEmployee);
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选中一条数据!");
                    }
                }));
            }
        }

        //离职
        RelayCommand _Turnover;
        public RelayCommand Turnover
        {
            get
            {
                return _Turnover ?? (_Turnover = new RelayCommand(() =>
                {
                    if (SelectedEmployee != null)
                    {
                        if (SelectedEmployee.Flag == 0)
                        {
                            SelectedEmployee.UpdateBy = SubjectUtils.GetAuthenticationId(); 
                            SelectedEmployee.Flag = 1;
                            SelectedEmployee.FlagVal = "离职";
                            SelectedEmployee.UpdateDatetime = DateTime.Now;
                            int b = _DataService.EditEmployeeFlag(SelectedEmployee.CreateEmployee(SelectedEmployee));
                            if (b.Equals(1))
                            {
                                 // EmployeeV[EmployeeV.IndexOf(SelectedEmployee)] = SelectedEmployee;
                                  EmployeeV[EmployeeV.IndexOf(SelectedEmployee)].Flag = 1;
                                  EmployeeV[EmployeeV.IndexOf(SelectedEmployee)].FlagVal = "离职";
                            }
                        }
                        else {
                            MessageBox.Show("该员工为离职状态，不能进行离职操作!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选中一条数据!");
                    }
                }));
            }
        }

        //解除离职
        RelayCommand _RemoveTurnover;
        public RelayCommand RemoveTurnover
        {
            get
            {
                return _RemoveTurnover ?? (_RemoveTurnover = new RelayCommand(() =>
                {
                    if (SelectedEmployee != null)
                    {
                        if (SelectedEmployee.Flag == 1)
                        {
                            SelectedEmployee.UpdateBy = SubjectUtils.GetAuthenticationId(); 
                            SelectedEmployee.Flag = 0;
                            SelectedEmployee.FlagVal = "在职";
                            SelectedEmployee.UpdateDatetime = DateTime.Now;
                            int b = _DataService.EditEmployeeFlag(SelectedEmployee.CreateEmployee(SelectedEmployee));
                            if (b.Equals(1))
                            {
                                EmployeeV[EmployeeV.IndexOf(SelectedEmployee)].Flag = 0;
                                EmployeeV[EmployeeV.IndexOf(SelectedEmployee)].FlagVal = "在职";
                            }
                        }
                        else
                        {
                            MessageBox.Show("该员工为在职状态，不能解除离职!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选中一条数据!");
                    }
                }));
            }
        }
        #region Observable

        //新增子窗口对象
        AddEmployee aw { get; set; }

        //修改子窗口对象
        EditEmployee ew { get; set; }

        //部门窗口对象
        DepartmentView dw { get; set; }

        //添加打开新窗口
        RelayCommand _Add;
        public RelayCommand Add
        {
            get
            {
                return _Add ?? (_Add = new RelayCommand(() =>
                {
                    if (_departmentBean != null)
                    {
                        
                        _Employeexaml = new EmployeeBean();
                        _Employeexaml.DepartmentName = _departmentBean.DepartmentName;
                        _Employeexaml.DepartmentId = _departmentBean.DepartmentId;
                        aw = new AddEmployee();
                        aw.ShowDialog();
                    }
                     else
                     {
                         MessageBox.Show("请选择一个部门!");
                     }
                }));
            }
        }

        //子窗口绑定对象
        EmployeeBean _Employeexaml;
        public EmployeeBean Employeexaml
        {
            get
            {
                return _Employeexaml;
            }
            set
            {
                Set("Employeexaml", ref _Employeexaml, value);
            }
        }

        //部门窗口绑定对象
        ObservableCollection<DepartmentInfo> _DepartmentV;
        //主窗口绑定数据
        public ObservableCollection<DepartmentInfo> DepartmentV
        {
            get
            {
                return _DepartmentV ?? (_DepartmentV = new ObservableCollection<DepartmentInfo>());
            }
            set
            {
                Set("DepartmentV", ref _DepartmentV, value);
            }
        }


        //子窗口新增
        RelayCommand _AddWin;
        public RelayCommand AddWin
        {
            get
            {
                return _AddWin ?? (_AddWin = new RelayCommand(() =>
                {
                    Employee employee = new Employee();
                    //保存数据
                    employee = Employeexaml.CreateEmployee(Employeexaml);
                    employee.Deleted = 0;
                    employee.CreateBy = SubjectUtils.GetAuthenticationId(); 
                    employee.CreateTime = DateTime.Now;

                    int flag = _DataService.AddEmployee(employee);
                    if (flag > 0)
                    {
                        EmployeeV.Add(Employeexaml);
                        aw.Close();
                    }
                    else if (flag == 0)
                    {
                        MessageBox.Show("添加失败，请联系管理员");
                    }
                    else if (flag == -1)
                    {
                        MessageBox.Show("添加失败，编码重复");
                    }
                }));
            }
        }

        //选择性别
        RelayCommand _Sex;
        public RelayCommand Sex
        {
            get
            {
                return _Sex ?? (_Sex = new RelayCommand(() =>
                {
                    if (aw.RadioButton1.IsChecked ?? false)
                    {
                        Employeexaml.Sex = 1;
                        return;
                    }
                    if (aw.RadioButton2.IsChecked ?? false)
                    {
                        Employeexaml.Sex = 0;
                        return;
                    }
                }));
            }
        }

        //选择状态
        RelayCommand _Flag;
        public RelayCommand Flag
        {
            get
            {
                return _Flag ?? (_Flag = new RelayCommand(() =>
                {
                    if (aw.RadioButton3.IsChecked ?? false)
                    {
                        Employeexaml.Flag = 1;
                        return;
                    }
                    if (aw.RadioButton4.IsChecked ?? false)
                    {
                        Employeexaml.Flag = 0;
                        return;
                    }
                }));
            }
        }

        //选择性别
        RelayCommand _EditSex;
        public RelayCommand EditSex
        {
            get
            {
                return _EditSex ?? (_EditSex = new RelayCommand(() =>
                {
                    if (ew.RadioButton1.IsChecked ?? false)
                    {
                        Employeexaml.Sex = 1;
                        return;
                    }
                    if (ew.RadioButton2.IsChecked ?? false)
                    {
                        Employeexaml.Sex = 0;
                        return;
                    }
                }));
            }
        }

        //选择状态
        RelayCommand _EditFlag;
        public RelayCommand EditFlag
        {
            get
            {
                return _EditFlag ?? (_EditFlag = new RelayCommand(() =>
                {
                    if (ew.RadioButton3.IsChecked ?? false)
                    {
                        Employeexaml.Flag = 1;
                        return;
                    }
                    if (ew.RadioButton4.IsChecked ?? false)
                    {
                        Employeexaml.Flag = 0;
                        return;
                    }
                }));
            }
        }

       //打开修改窗口
        RelayCommand _Edit;
        public RelayCommand Edit
        {
            get
            {
                return _Edit ?? (_Edit = new RelayCommand(() =>
                {
                    if (SelectedEmployee != null)
                    {
                        _Employeexaml = new EmployeeBean();
                        
                        //设置数据
                        Employee emp = SelectedEmployee.CreateEmployee(EmployeeV[EmployeeV.IndexOf(SelectedEmployee)]);
                         _Employeexaml = _Employeexaml.CreateEmployeeBean(emp);
                         DepartmentInfo dep = new DepartmentInfo();
                         dep.DepartmentId = _Employeexaml.DepartmentId;
                         List<DepartmentInfo> list=_DataService.QueryByDepartment(dep);
                         _Employeexaml.DepartmentName = list[0].DepartmentName;
                         ew = new EditEmployee();
                         if (_Employeexaml.Flag == 1)
                         {
                             ew.RadioButton3.IsChecked=false;
                             ew.RadioButton4.IsChecked=true;
                         }
                         else { 
                             ew.RadioButton3.IsChecked=true;
                             ew.RadioButton4.IsChecked=false;
                         }
                         if (_Employeexaml.Sex == 1)
                         {
                             ew.RadioButton1.IsChecked=true;
                             ew.RadioButton2.IsChecked=false;
                         }
                         else
                         {
                             ew.RadioButton1.IsChecked = false;
                             ew.RadioButton2.IsChecked = true;
                         }
                            ew.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("请选中一条数据！");
                    }
                }));
            }
        }

        //子窗口修改
        RelayCommand _EditWin;
        public RelayCommand EditWin
        {
            get
            {
                return _EditWin ?? (_EditWin = new RelayCommand(() =>
                {
                    Employee employee = new Employee();
                   //设置数据
                    employee = Employeexaml.CreateEmployee(Employeexaml);
                    employee.Deleted = 0;
                    employee.UpdateBy = SubjectUtils.GetAuthenticationId();
                    employee.UpdateDatetime = DateTime.Now;

                    int flag = _DataService.EditByEmployee(employee);
                    if (flag > 0)
                    {
                        EmployeeV.Clear();
                        List<Employee> loooo = _DataService.QueryByEmployee(employee);
                        foreach (var loca in loooo)
                        {
                            EmployeeV.Add(new EmployeeBean
                            {
                                UserId = loca.UserId,
                                DepartmentId = loca.DepartmentId,
                                JobNo = loca.JobNo,
                                Name = loca.Name,
                                Sex = loca.Sex,
                                SexVal = (loca.Sex == 1) ? "男" : "女",
                                Birthday = loca.Birthday,
                                Flag = loca.Flag,
                                FlagVal = (loca.Flag == 1) ? "离职" : "在职",
                                Mobile = loca.Mobile,
                                Email = loca.Email,
                                Position = loca.Position,
                                Phone = loca.Phone,
                                Code = loca.Code,
                                ResidentialAddress = loca.ResidentialAddress,
                                IDAddress = loca.IDAddress,
                                Remark = loca.Remark
                            });
                        }
                        ew.Close();
                    }
                    else if (flag == 0)
                    {
                        MessageBox.Show("修改失败，请联系管理员");
                    }
                    else if (flag == -1)
                    {
                        MessageBox.Show("修改失败，编码重复");
                    }
                }));
            }
        }
        #endregion Command


        //打开部门窗口
        RelayCommand _AddDep;
        public RelayCommand AddDep
        {
            get
            {
                return _AddDep ?? (_AddDep = new RelayCommand(() =>
                {
                    DepartmentInfo dep = new DepartmentInfo();
                    dep.CompanyId = 1;
                    List<DepartmentInfo> queryByDepartment = _DataService.QueryByDepartment(dep);
                    DepartmentV.Clear();
                    foreach (var depar in queryByDepartment)
                    {
                        DepartmentV.Add(new DepartmentInfo { DepartmentId = depar.DepartmentId, DepartmentName = depar.DepartmentName });
                    }
                    dw = new DepartmentView();
                    dw.ShowDialog();
                }));
            }

        }

         //部门grid选中事件
        DepartmentInfo _SelectedDepart;
        public DepartmentInfo SelectedDepart
        {
            get
            {
                return _SelectedDepart;
            }
            set
            {
                Set("SelectedDepart", ref _SelectedDepart, value);
            }
        }

           
        //新增部门
        RelayCommand _AddDepart;
        public RelayCommand AddDepart
        {
            get
            {
                return _AddDepart ?? (_AddDepart = new RelayCommand(() =>
                {
                     DepartmentV.Add(new DepartmentInfo());
                }));
            }
        }

        //删除部门
        RelayCommand _DeleteDepart;
        public RelayCommand DeleteDepart
        {
            get
            {
                return _DeleteDepart ?? (_DeleteDepart = new RelayCommand(() =>
                {
                    //是否选中条目
                    if (SelectedDepart != null)
                    {
                        //是否存在部门ID，存在删除表数据
                        if (SelectedDepart.DepartmentId > 0)
                        {
                            SelectedDepart.UpdateBy = SubjectUtils.GetAuthenticationId();
                            SelectedDepart.UpdateDatetime = DateTime.Now;
                            SelectedDepart.Deleted = 1;
                            int i = _DataService.DelByDepartment(SelectedDepart);
                            if (i > 0)
                            {
                                DepartmentV.RemoveAt(DepartmentV.IndexOf(SelectedDepart));
                            }
                        }
                        else {
                                DepartmentV.RemoveAt(DepartmentV.IndexOf(SelectedDepart));
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选中一条数据!");
                    }
                }));
            }
        }

        //保存部门
        RelayCommand _SaveDepart;
        public RelayCommand SaveDepart
        {
            get
            {
                return _SaveDepart ?? (_SaveDepart = new RelayCommand(() =>
                {
                   foreach (var depar in DepartmentV)
                    {
                        depar.UpdateBy = SubjectUtils.GetAuthenticationId();
                        depar.UpdateDatetime = DateTime.Now;
                        depar.CreateBy = SubjectUtils.GetAuthenticationId();
                        depar.CreateTime = DateTime.Now;
                        depar.Deleted =0;
                        depar.CompanyId = 1;
                        _DataService.EditByDepartment(depar);
                     }
                }));
            }
        }
    }
                
}
