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

namespace IShow.ChooseDishes.View
{
    /// <summary>
    /// Interaction logic for AlertWin.xaml
    /// </summary>
    public partial class AlertWin : MetroWindow
    {
        public AlertWin()
        {
            InitializeComponent();
        }


        private void Button_Click_Ok(object sender, RoutedEventArgs e)
        {
            ViewModelDeliver.Set("1");
            this.Close();
        }

        private void Button_Click_Not(object sender, RoutedEventArgs e)
        {
            ViewModelDeliver.Set("2");
            this.Close();
        }
    }
}
