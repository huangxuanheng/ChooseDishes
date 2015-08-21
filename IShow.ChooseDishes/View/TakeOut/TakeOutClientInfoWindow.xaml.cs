using IShow.ChooseDishes.ViewModel;
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

namespace IShow.ChooseDishes.View.TakeOut
{
    /// <summary>
    /// Interaction logic for TakeOutClientInfoWindow.xaml
    /// </summary>
    public partial class TakeOutClientInfoWindow : Window
    {
        private static TakeOutClientInfoWindow tc;
        public TakeOutClientInfoWindow()
        {
            InitializeComponent();
            tc = this;
        }

        private void Exited(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        public static void CloseWindow()
        {
            tc.Close();
        }
        public static TakeOutClientInfoWindow getInstance()
        {
            return tc;
        }
    }
}
