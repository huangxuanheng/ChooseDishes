using IShow.ChooseDishes.ViewModel;
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

namespace IShow.ChooseDishes.View.BargainDish
{
    /// <summary>
    /// Interaction logic for BargainDishWin.xaml
    /// </summary>
    public partial class BargainDishWin : MetroWindow
    {
        public BargainDishWin()
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
                BargainDishViewModel model = this.DataContext as BargainDishViewModel;
                model.SelectedItemChanged(this.DatePickerMyDate.SelectedDate??DateTime.Now);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BargainDishViewModel model = this.DataContext as BargainDishViewModel;
            if (model != null) {
                model.Init();
            }
        }
    }
}
