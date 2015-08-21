using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using IShow.ChooseDishes.Model.Booking;

namespace IShow.ChooseDishes.Helper.Converters
{
    public  class TableStatusConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //下面几种种颜色的写法都可以
            //下面几种种颜色的写法都可以
            if (value is TableStatus)
            {
                switch ((TableStatus)value)
                {
                    case TableStatus.Idle:
                        return "#ffffff";
                    case TableStatus.Using:
                        return "#4ecdc4";
                    case TableStatus.Waiting:
                        return "#5aabe3";
                    case TableStatus.Scheduled:
                        return "#f37835";
                    case TableStatus.Excess:
                        return "#9B58B5";
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
