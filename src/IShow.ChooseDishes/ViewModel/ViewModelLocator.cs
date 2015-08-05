using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Model;
using IShow.ChooseDishes.Service;
using IShow.ChooseDishes.ViewModel.Common;
using IShow.Service;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using IShow.ChooseDishes.ViewModel.Dishes;

namespace IShow.ChooseDishes.ViewModel
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IMessenger, Messenger>();
            SimpleIoc.Default.Register<IChooseDishesDataService>(()=>new ChooseDishesDataService());
            SimpleIoc.Default.Register<IDishService>(() => new DishService());
            SimpleIoc.Default.Register<IDishesMenuService>(() => new DishesMenuService());
            
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<OrgLocatinModel>();

            SimpleIoc.Default.Register<OrgBearingModel>();
            SimpleIoc.Default.Register<CompanyModel>();
            SimpleIoc.Default.Register<CashViewModel>();  
            SimpleIoc.Default.Register<TreeViewModel>();  
            SimpleIoc.Default.Register<DepartViewModel>();
            SimpleIoc.Default.Register<EmployeeViewModel>();  

            SimpleIoc.Default.Register<CashViewModel>();
            SimpleIoc.Default.Register<DishesViewModel>();     

            SimpleIoc.Default.Register<TreeViewModel>();

            SimpleIoc.Default.Register<DishesUnitViewModel>();
            SimpleIoc.Default.Register<DishesMenuViewModel>();


            SimpleIoc.Default.Register<ChooseForDishesMenuViewModel>();
            SimpleIoc.Default.Register<MaterialViewModel>();
        }
        
         public LoginViewModel Login
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }
         public MaterialViewModel Material
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MaterialViewModel>();
            }
        }
        
        //区域管理
        public OrgLocatinModel OrgLocatin
        {
            get
            {
                return ServiceLocator.Current.GetInstance<OrgLocatinModel>();
            }
        }
        //方位管理
        /// <summary>
        /// 樹
        /// </summary>

        public TreeViewModel TreeView {
            get
            {
                return ServiceLocator.Current.GetInstance<TreeViewModel>();
            }
        }
   

        public DishesUnitViewModel DishesUnit
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DishesUnitViewModel>();
            }
        }
        //公司信息
        public ChooseForDishesMenuViewModel ChooseForDishesMenu {
            get {
                return ServiceLocator.Current.GetInstance<ChooseForDishesMenuViewModel>();
            }
        }

        public DishesMenuViewModel DishesMenu
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DishesMenuViewModel>();
            }
        }

        public CashViewModel CashWin
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CashViewModel>();
            }
        }

        //部门管理
        public DepartViewModel Department
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DepartViewModel>();
            }
        }

        //
        public DishesViewModel DishWin
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DishesViewModel>();
            }
        }

        //员工管理
        public EmployeeViewModel Employee
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EmployeeViewModel>();
            }
        }
        

           
        public static void Cleanup()
        {
        }
    }
}
