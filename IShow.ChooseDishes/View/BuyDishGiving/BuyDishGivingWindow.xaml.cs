using MahApps.Metro.Controls;
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

namespace IShow.ChooseDishes.View.BuyDishGiving
{
    /// <summary>
    /// BuyDishGivingWindow.xaml 的交互逻辑
    /// </summary>
    public partial class BuyDishGivingWindow : MetroWindow
    {
        public BuyDishGivingWindow()
        {
            InitializeComponent();
        }

        private void EXIT_WIN(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.ZhiDingPriceButtom.IsChecked ?? false)
            {
                //BargainDishViewModel model = this.DataContext as BargainDishViewModel;
                //model.SelectedItemChanged(this.DatePickerMyDate.SelectedDate ?? DateTime.Now);
            }
        }
    }
}
