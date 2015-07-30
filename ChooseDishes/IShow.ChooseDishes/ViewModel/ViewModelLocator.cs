using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using IShow.ChooseDishes.Model;
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
            SimpleIoc.Default.Register<IChooseDishesDataService>(() => new ChooseDishesDataServiceClient(new InstanceContext(new ChooseDishesDataServiceCallback())));

            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<DishesWayModel>();
            SimpleIoc.Default.Register<DishesWayFromModel>();

            
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

        public DishesWayFromModel DishesWayFroms
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DishesWayFromModel>();
            }
        }

        public static void Cleanup()
        {
        }
    }
}
