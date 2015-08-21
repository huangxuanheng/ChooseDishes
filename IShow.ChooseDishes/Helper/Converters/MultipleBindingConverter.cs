using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace IShow.ChooseDishes.Helper.Converters
{
    public class MultipleBindingConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility visblie = Visibility.Collapsed;

          

                string Id = values[0] as string;
                uint Count = (uint)values[1];

                if (Count == 1 && Id.CompareTo("123") == 0)
                    visblie = Visibility.Visible;

                
            

            return visblie;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
