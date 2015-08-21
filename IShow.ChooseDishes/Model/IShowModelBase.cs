using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace IShow.ChooseDishes.Model
{
    public class IShowModelBase : ObservableObject
    {
        protected virtual void CustomRaisePropertyChanged(string propertyName)
        {
            DispatcherHelper.CheckBeginInvokeOnUI(() => base.RaisePropertyChanged(propertyName));
        }

        protected virtual bool Set<T>(ref T field, T newValue)
        {
            if (EqualityComparer<T>.Default.Equals(field, newValue))
            {
                return false;
            }
            T oldValue = field;
            field = newValue;
            return true;
        }
    }
}
