using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Model;
using IShow.ChooseDishes.Service;
using IShow.Service;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace IShow.ChooseDishes.ViewModel
{
    public class ViewModelLocator
    {
       
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IMessenger, Messenger>();
            SimpleIoc.Default.Register<IChooseDishesDataService>(()=>new ChooseDishesDataService());
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<OrgLocatinModel>();
            SimpleIoc.Default.Register<IDishesWayDataService>(() => new DishesWayDataService());
            SimpleIoc.Default.Register<DishesWayModel>();   //菜品做法
            SimpleIoc.Default.Register<DishesWaySettingModel>();   //厨打做法设置
        }
        
        public LoginViewModel Login
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }

        public DishesWayModel DishesWay
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DishesWayModel>();
            }
        }
        public DishesWaySettingModel DishesWaySet
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DishesWaySettingModel>();
            }
        }
        public OrgLocatinModel OrgLocatin
        {
            get
            {
                return ServiceLocator.Current.GetInstance<OrgLocatinModel>();
            }
        }

        public static void Cleanup()
        {
        }
    }
}
