using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using IShow.ChooseDishes.Model.EnumSet;

namespace IShow.ChooseDishes.Utils.UI.Convert
{
   public  class TableStatusIconConvert:IValueConverter
    {
       public object Convert(object value, Type targetType, object parameter, CultureInfo culture)  
        {
            TableStatus status = (TableStatus)value;
            switch (status) { 
                case TableStatus.FREE:
                    return "/IShow.ChooseDishes;component/Image/Icon/exclamation.gif";
                case TableStatus.LOCKED:
                    return "/IShow.ChooseDishes;component/Image/Icon/lock.gif";
            
            }
            return null;
        }  
  
  
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)  
        {
            throw new Exception();
        }  

    }
}
