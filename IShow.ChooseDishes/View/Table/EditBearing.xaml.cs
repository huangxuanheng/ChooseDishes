using IShow.ChooseDishes.Data;
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

namespace IShow.ChooseDishes.View.Table
{
    /// <summary>
    /// Interaction logic for editLocation.xaml
    /// </summary>
    public partial class EditBearing : MetroWindow
    {
        public EditBearing()
        {
            InitializeComponent();
        }

       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
