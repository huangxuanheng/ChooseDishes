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
    /// Interaction logic for UpdateCashType.xaml
    /// </summary>
    public partial class UpdateCashType : MetroWindow
    {


        public UpdateCashType()
        {
            InitializeComponent();
        }


        private void Exit_Win(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
