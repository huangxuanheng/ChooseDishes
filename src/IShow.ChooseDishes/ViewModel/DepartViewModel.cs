using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Model;
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

    public class DepartViewModel : ViewModelBase
    {
        IChooseDishesDataService _DataService;
        //主窗体初始化
        public DepartViewModel(IChooseDishesDataService dataService) {
            _DataService = dataService;
            

            //查询部门绑定grid

         }


       
        //主窗口绑定数据
        public ObservableCollection<DepartmentInfo> department { get; set; }

        //grid选中事件
        DepartmentInfo _SelectedDepartment;
        public DepartmentInfo SelectedDepartment
        {
            get
            {
                return _SelectedDepartment;
            }
            set
            {
                Set("SelectedDepartment", ref _SelectedDepartment, value);
            }
        }

        //添加部门
        RelayCommand _Add;
        public RelayCommand Add
        {
            get
            {
                return _Add ?? (_Add = new RelayCommand(() =>
                {
                    DepartmentInfo depar = new DepartmentInfo();
                    department.Add(depar);
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
                    if (SelectedDepartment != null)
                    {
                        DepartmentInfo departmentInfo = new DepartmentInfo();
                        departmentInfo.DepartmentId = SelectedDepartment.DepartmentId;
                        departmentInfo.UpdateBy = 8;
                        departmentInfo.Deleted = 1;
                        departmentInfo.UpdateDatetime = DateTime.Now;

                        int b = _DataService.delByDepartment(departmentInfo);
                        if (b.Equals(1))
                        {
                            department.Remove(SelectedDepartment);
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选中一条数据!");
                    }
                }));
            }
        }


      



    }
                
}
