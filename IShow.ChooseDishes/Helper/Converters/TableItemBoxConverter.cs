using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using IShow.ChooseDishes.Model.Booking;

namespace IShow.ChooseDishes.Helper.Converters
{

    public class TableDefaultSeatForeground : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is TableStatus && ((TableStatus)value == TableStatus.Idle)) ? new SolidBrush(Color.Blue) : Brushes.White;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// 默认人数显示
    /// </summary>
    public class TableDefaultPeopleVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is TableStatus && ((TableStatus)value == TableStatus.Idle ||
                                                    (TableStatus)value == TableStatus.Waiting ||
                                                    (TableStatus)value == TableStatus.Scheduled)) ? Visibility.Visible : Visibility.Collapsed;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 消费金额显示控制
    /// </summary>
    public class TableMoneyVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TableStatus) {
                if ((TableStatus)value == TableStatus.Using)
                {
                    return Visibility.Visible;
                }
                else {
                    return Visibility.Collapsed;
                }
            }
            return Visibility.Collapsed;

            
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 背景颜色显示控制
    /// </summary>
    public class TableForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is TableStatus && ((TableStatus)value == TableStatus.Idle)) ? Brushes.Black : Brushes.White;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// 锁图标显示控制
    /// </summary>
    public class TableLockConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return (value is bool) && (bool)value==true ? Visibility.Visible : Visibility.Collapsed;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 格式化显示开始时间
    /// </summary>
    public class TableDateTimeFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is DateTime) {
                return ((DateTime)value).ToString("HH:mm");
            }
            return DateTime.Now.ToString("HH:mm");
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 开始时间
    /// </summary>
    public class TableDateTimeVisiblityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility visibility = (value is TableStatus && ((TableStatus)value == TableStatus.Using)) ? Visibility.Visible : Visibility.Collapsed;

            return visibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
