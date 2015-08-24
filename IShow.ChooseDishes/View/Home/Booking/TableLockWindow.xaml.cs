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
    /// TableLockWindow.xaml 的交互逻辑
    /// </summary>
    public partial class TableLockWindow : MetroWindow
    {
        public TableLockWindow()
        {
            InitializeComponent();
        }
        //public TableLockWindow(HomePageViewModel d)
        //{
        //    InitializeComponent();
        //    this.DataContext = new TableLockViewModel(d);
        //}
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SimpleTableListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var viewModel = DataContext as TableLockViewModel;
            viewModel.SelectedItemChange();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var viewModel = DataContext as TableLockViewModel;
            viewModel.SearchByTableCode(Code.Text);
        }
    }
}
