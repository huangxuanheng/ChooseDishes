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

namespace IShow.ChooseDishes.View.Dishes
{
    /// <summary>
    /// Interaction logic for DishesWayTypeWindow.xaml
    /// </summary>
    public partial class DishesWayTypeWindow : MetroWindow
    {
        public DishesWayTypeWindow()
        {
            InitializeComponent();
        }

        private void Exited(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
