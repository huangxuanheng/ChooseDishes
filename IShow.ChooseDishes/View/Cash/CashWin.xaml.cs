using IShow.ChooseDishes.ViewModel;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IShow.ChooseDishes.View.CashWindow
{
    /// <summary>
    /// Interaction logic for CashWin.xaml
    /// </summary>
    public partial class CashWin : MetroWindow
    {
        public CashWin()
        {
            InitializeComponent();
        }

        private void Cancel_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CashViewModel model = this.DataContext as CashViewModel;
            if (model != null) {
                model.LoadCashTypeBase(0);
            }
        }
    }
}
