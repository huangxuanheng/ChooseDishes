using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IShow.ChooseDishes.ViewModel
{
    public class CompanyModel : ViewModelBase
    {
        IChooseDishesDataService _DataService;

        //子窗口绑定对象
        CompanyBean _Companyxaml;
        public CompanyBean Companyxaml
        {
            get
            {
                return _Companyxaml;
            }
            set
            {
                Set("Companyxaml", ref _Companyxaml, value);
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
                    CompanyBean companBean = new CompanyBean();
                    bool b=companBean.Verification(_Companyxaml);
                    if (b) {
                        Company company = companBean.CreateCompany(_Companyxaml);
                        company.Deleted = 0;
                        company.CreatePerson = "1";
                        company.EditPerson = "1";
                        company.CreateTime = DateTime.Now;
                        company.EditTime = DateTime.Now;
                   
                        int flag = _DataService.editByCompany(company);
                        if (flag > 0)
                        {
                            MessageBox.Show("保存成功！");
                        }
                        else if (flag == 0)
                        {
                            MessageBox.Show("保存失败，请联系管理员");
                        }
                    }
                }));
            }
        }

        public ObservableCollection<DepartmentInfo> Department { get; set; }

        #region Command
        //初始化窗口
        public CompanyModel(IChooseDishesDataService dataService, IMessenger messenger)
            : base(messenger)
        {
            _DataService = dataService;
            Company company=new Company();
            company.CompanyId=10;
            company= _DataService.queryByCompany(company);
            CompanyBean com = new CompanyBean();
            try
            {
                _Companyxaml = com.CreateCompanyBean(company);
                _Companyxaml.CompanyId = company.CompanyId;
            }
            catch (Exception ex) {
                ex.ToString();
            }
        }
        #endregion Command


    }
    }
