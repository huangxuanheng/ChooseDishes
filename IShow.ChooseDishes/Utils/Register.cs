using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Service;
using Microsoft.Practices.ServiceLocation;

namespace IShow.ChooseDishes.Utils
{
    public class Register
    {
        static Register() {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<ILoggerService>(() => new LoggerService());
        }

        public static ILoggerService GetLogger(){
            return ServiceLocator.Current.GetInstance<ILoggerService>();
        }
    }
}
