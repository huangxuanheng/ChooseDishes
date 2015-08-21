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
    /// ChooseDishesWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ChooseDishesWindow : MetroWindow
    {
        public ChooseDishesWindow()
        {
            InitializeComponent();
            this.DataContext = new ChooseDishesViewModel();
        }


        private void NumericButton_Click(object sender, RoutedEventArgs e)
        {
            NumericTabItem.IsSelected = true;
        }

        private void GroupDishesButton_Click(object sender, RoutedEventArgs e)
        {
            ChooseDishesTabControl.IsSelected = true;
        }

        private void HoldonButton_Click(object sender, RoutedEventArgs e)
        {
            HoldonTabItem.IsSelected = true;

        }

        private void HandupButton_Click(object sender, RoutedEventArgs e)
        {
            HandupTabItem.IsSelected = true;
        }
    }
}
