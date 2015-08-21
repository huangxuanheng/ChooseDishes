using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Model;

namespace IShow.ChooseDishes.ViewModel.User
{
   public  class SelectEmpForUserViewModel:ViewModelBase
    {

        public EmployeeBean _SelectedEmployee;

        ObservableCollection<EmployeeBean> _Employees;

        IEmployeeService _EmployeeService;

        public SelectEmpForUserViewModel(IEmployeeService _EmployeeService) {
            this._EmployeeService = _EmployeeService;
            this.Initialization();
        }

        public ObservableCollection<EmployeeBean> Employees {
            get {
                return _Employees ?? (_Employees = new ObservableCollection<EmployeeBean>());
            }
            set {
                Set("Employees", ref _Employees, value);
            }
        }

        public EmployeeBean SelectedEmployee
        {
            get {
                return _SelectedEmployee;
            }
            set {
                Set("SelectedEmployee", ref _SelectedEmployee, value);
            }

        }

        public bool HasSelected (){
            return _SelectedEmployee != null;
        }

      


        /// <summary>
        /// 开启线程从后台加载数据
        /// </summary>
        public void Initialization() {
                DispatcherHelper.CheckBeginInvokeOnUI(()=>{
                    List<Employee> employees = _EmployeeService.QueryByEmployee();
                    if (null != employees && employees.Count() > 0)
                    {
                        foreach (var e in employees)
                        {
                            Employees.Add(EmployeeBean.Build(e));
                        }
                    }
                });
        }

  
    }
}
