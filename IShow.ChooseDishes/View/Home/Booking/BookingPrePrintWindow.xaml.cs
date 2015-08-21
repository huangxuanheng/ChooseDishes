using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using IShow.ChooseDishes.ViewModel.Booking;
using MahApps.Metro.Controls;

namespace IShow.ChooseDishes.View.Home.Booking
{
    /// <summary>
    /// BookingPrePrintWindow.xaml 的交互逻辑
    /// </summary>
    public partial class BookingPrePrintWindow : MetroWindow
    {
        public BookingPrePrintWindow()
        {
            InitializeComponent();
            this.DataContext = new BookingPrePrintViewModel();
        }
    }
}
