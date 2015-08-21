using IShow.ChooseDishes.ViewModel.Common;
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

namespace IShow.ChooseDishes.View.Discount
{
    /// <summary>
    /// Interaction logic for OrgLocation.xaml
    /// </summary>
    public partial class EditDiscountView : MetroWindow
    {
        public EditDiscountView()
        {
            InitializeComponent();
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
