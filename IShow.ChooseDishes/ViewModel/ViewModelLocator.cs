﻿using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Model;
using IShow.ChooseDishes.Service;
using IShow.ChooseDishes.ViewModel.Common;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using IShow.ChooseDishes.ViewModel.Dishes;
using IShow.ChooseDishes.ViewModel.User;
using IShow.ChooseDishes.ViewModel.Home;
using IShow.Service;
using IShow.ChooseDishes.ViewModel.DisCount;
using IShow.ChooseDishes.ViewModel.BuyDishGiving;
using IShow.ChooseDishes.ViewModel.ClearEstimateM;
using IShow.ChooseDishes.ViewModel.Booking;


namespace IShow.ChooseDishes.ViewModel
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IMessenger, Messenger>();
            SimpleIoc.Default.Register<IChooseDishesDataService>(() => new ChooseDishesDataService());
            SimpleIoc.Default.Register<IDishService>(() => new DishService());
            SimpleIoc.Default.Register<IDishesMenuService>(() => new DishesMenuService());

            SimpleIoc.Default.Register<IConfigurationService>(() => new ConfigurationService());
            SimpleIoc.Default.Register<ITableStatusService>(() => new TableStatusService());

            SimpleIoc.Default.Register<IDiscountDataService>(() => new DiscountDataService());
            SimpleIoc.Default.Register<IEmployeeService>(() => new EmployeeService());
            SimpleIoc.Default.Register<IUserService>(() => new UserService());
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
            SimpleIoc.Default.Register<DishDetailViewModel>();
            SimpleIoc.Default.Register<ChooseForDishesMenuViewModel>();

            SimpleIoc.Default.Register<DishPackagesViewModel>();
            SimpleIoc.Default.Register<DishTypeViewModel>();
            SimpleIoc.Default.Register<FatherDishTypeViewModel>();
            SimpleIoc.Default.Register<ITableService>(() => new TableService());
            SimpleIoc.Default.Register<TableTypeViewModel>();
            SimpleIoc.Default.Register<TableViewModel>();
            SimpleIoc.Default.Register<LockScreenViewModel>();
            SimpleIoc.Default.Register<UnLockScreenViewModel>();

            SimpleIoc.Default.Register<BuyDishGivingViewModel>();
            SimpleIoc.Default.Register<BuyDishesSelectedViewModel>();
            SimpleIoc.Default.Register<GivingDishSettingViewModel>();
            SimpleIoc.Default.Register<GivingSelectedViewModel>();

            SimpleIoc.Default.Register<ClearEstimateViewModel>();
            SimpleIoc.Default.Register<DishesDataViewModel>();
            SimpleIoc.Default.Register<ClearEstimateSettingViewModel>();


            #region 绑定用户
            SimpleIoc.Default.Register<UserMgtViewModel>();
            SimpleIoc.Default.Register<SelectEmpForUserViewModel>();
            SimpleIoc.Default.Register<AddUserViewModel>();
            SimpleIoc.Default.Register<EditUserViewModel>();
            SimpleIoc.Default.Register<AuthzMgtViewModel>();
            #endregion
            SimpleIoc.Default.Register<ListWindowViewModel>();
            SimpleIoc.Default.Register<MainFrameWindowViewModel>();


            SimpleIoc.Default.Register<BaseContentViewModel>();
            SimpleIoc.Default.Register<QianTaiGuanLiViewModel>();
            SimpleIoc.Default.Register<BaoBiaoZhongXinViewModel>();
            SimpleIoc.Default.Register<XiTongSheZhiViewModel>();
            SimpleIoc.Default.Register<ZhuoTaiViewModel>();
            SimpleIoc.Default.Register<BargainDishViewModel>();
            SimpleIoc.Default.Register<PromotionsDishWiewModel>();

            SimpleIoc.Default.Register<IMaterialDataService>(() => new MaterialDataService());
            SimpleIoc.Default.Register<DishesSelectBeanViewModel>();
            SimpleIoc.Default.Register<DisCountViewModel>();
            SimpleIoc.Default.Register<IRawUnitDataService>(() => new RawUnitDataService());
            SimpleIoc.Default.Register<MaterialViewModel>();

            SimpleIoc.Default.Register<IMarketTypeDataService>(() => new MarketTypeDataService());
            SimpleIoc.Default.Register<MarketTypeViewModel>();
            SimpleIoc.Default.Register<EditUserViewModel>();
            SimpleIoc.Default.Register<ILoggerService>(() => new LoggerService());
            SimpleIoc.Default.Register<SystemLogViewModel>();

            SimpleIoc.Default.Register<IDishesWayDataService>(() => new DishesWayDataService());
            SimpleIoc.Default.Register<DishesWayViewModel>();
            SimpleIoc.Default.Register<IDischesWayRefService>(() => new DischesWayRefService());
            SimpleIoc.Default.Register<DishesWayRefViewModel>();
            SimpleIoc.Default.Register<ITableItemService>(() => new TableItemService());
            SimpleIoc.Default.Register<TableLockViewModel>();
            SimpleIoc.Default.Register<HomePageViewModel>();
            SimpleIoc.Default.Register<TableItemViewModel>();
        }

        public DishesWayViewModel DishesWay
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DishesWayViewModel>();
            }
        }

        public ListWindowViewModel ListWindow
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ListWindowViewModel>();
            }
        }

        public MainFrameWindowViewModel MainFrameWindow
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainFrameWindowViewModel>();
            }
        }
        public BaseContentViewModel BaseContent
        {
            get
            {
                return ServiceLocator.Current.GetInstance<BaseContentViewModel>();
            }
        }

        public QianTaiGuanLiViewModel QianTaiGuanLi
        {
            get
            {
                return ServiceLocator.Current.GetInstance<QianTaiGuanLiViewModel>();
            }
        }
        public BaoBiaoZhongXinViewModel BaoBiaoZhongXin
        {
            get
            {
                return ServiceLocator.Current.GetInstance<BaoBiaoZhongXinViewModel>();
            }
        }
        public XiTongSheZhiViewModel XiTongSheZhi
        {
            get
            {
                return ServiceLocator.Current.GetInstance<XiTongSheZhiViewModel>();
            }
        }
        public ZhuoTaiViewModel ZhuoTai
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ZhuoTaiViewModel>();
            }
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
        public MarketTypeViewModel Market
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MarketTypeViewModel>();
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

        public TreeViewModel TreeView
        {
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
        public OrgBearingModel OrgBearing
        {
            get
            {
                return ServiceLocator.Current.GetInstance<OrgBearingModel>();
            }
        }
        //公司信息
        public CompanyModel OrgInfo
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CompanyModel>();
            }
        }

        public ChooseForDishesMenuViewModel ChooseForDishesMenu
        {
            get
            {
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

        public DishDetailViewModel DishDetail
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DishDetailViewModel>();
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
        //套菜管理
        public DishPackagesViewModel DishPackages
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DishPackagesViewModel>();
            }
        }
        public DishTypeViewModel Dish
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DishTypeViewModel>();
            }
        }

        public FatherDishTypeViewModel FatherDishType
        {
            get
            {
                return ServiceLocator.Current.GetInstance<FatherDishTypeViewModel>();
            }
        }

        public TableTypeViewModel TableType
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TableTypeViewModel>();
            }
        }

        #region 用户

        public AuthzMgtViewModel AuthzMgt
        {
            get { return ServiceLocator.Current.GetInstance<AuthzMgtViewModel>(); }
        }
        public SelectEmpForUserViewModel SelectEmpForUser
        {
            get { return ServiceLocator.Current.GetInstance<SelectEmpForUserViewModel>(); }
        }

        public UserMgtViewModel UserMgt
        {
            get { return ServiceLocator.Current.GetInstance<UserMgtViewModel>(); }
        }

        public AddUserViewModel AddUser
        {
            get { return ServiceLocator.Current.GetInstance<AddUserViewModel>(); }
        }
        public EditUserViewModel EditUser
        {
            get { return ServiceLocator.Current.GetInstance<EditUserViewModel>(); }
        }
        #endregion

        public TableViewModel Table
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TableViewModel>();
            }
        }

        //菜品特价管理
        public BargainDishViewModel BargainDishViewFun
        {
            get
            {
                return ServiceLocator.Current.GetInstance<BargainDishViewModel>();
            }
        }

        //参数设置 窗口
        public ConfigSettingViewModel ConfigSetting
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ConfigSettingViewModel>();
            }
        }

        //赠菜 窗口
        public BuyDishGivingViewModel BuyDishGiving
        {
            get
            {
                return ServiceLocator.Current.GetInstance<BuyDishGivingViewModel>();
            }
        }
        //新增买赠菜品选择 窗口
        public BuyDishesSelectedViewModel BuyGivingDishes
        {
            get
            {
                return ServiceLocator.Current.GetInstance<BuyDishesSelectedViewModel>();
            }
        }
        //菜品买赠设置 窗口
        public GivingDishSettingViewModel GivingDishSetting
        {
            get
            {
                return ServiceLocator.Current.GetInstance<GivingDishSettingViewModel>();
            }
        }
        //选择赠品 窗口
        public GivingSelectedViewModel GivingSelected
        {
            get
            {
                return ServiceLocator.Current.GetInstance<GivingSelectedViewModel>();
            }
        }
        //菜品估清管理 窗口
        public ClearEstimateViewModel ClearEstimate
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ClearEstimateViewModel>();
            }
        }
        //菜品资料选择
        public DishesDataViewModel DishesData
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DishesDataViewModel>();
            }
        }
        //菜品估清设置
        public ClearEstimateSettingViewModel ClearEstimateSetting
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ClearEstimateSettingViewModel>();
            }
        }

        //锁定屏幕 窗口
        public LockScreenViewModel LockScreen
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LockScreenViewModel>();
            }
        }

        //解除锁定 窗口
        public UnLockScreenViewModel UnLockScreen
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UnLockScreenViewModel>();
            }
        }

        //选择菜牌基础 窗口
        public DishesSelectBeanViewModel DishesSelectBean
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DishesSelectBeanViewModel>();
            }
        }
        //折扣方案
        public DisCountViewModel DisCountViewBean
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DisCountViewModel>();
            }
        }
        //菜品促销 PromotionsDishWiewModel
        public PromotionsDishWiewModel PromotionsDishRegist
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PromotionsDishWiewModel>();
            }
        }
        public SystemLogViewModel SysLog
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SystemLogViewModel>();
            }
        }
        public DishesWayRefViewModel DishesWayRef
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DishesWayRefViewModel>();
            }
        }
        public TableLockViewModel TableLock
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TableLockViewModel>();
            }
        }
        public HomePageViewModel HomePage
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HomePageViewModel>();
            }
        }
        public TableItemViewModel TableItem
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TableItemViewModel>();
            }
        }
        public static void Cleanup()
        {
        }
    }
}
