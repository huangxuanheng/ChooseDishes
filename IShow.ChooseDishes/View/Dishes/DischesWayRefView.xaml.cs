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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IShow.ChooseDishes.View.Dishes
{
    /// <summary>
    /// Interaction logic for DischesWayRefView.xaml
    /// </summary>
    public partial class DischesWayRefView :MetroWindow
    {
        public DischesWayRefView()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var model = this.DataContext as DishesWayRefViewModel;
            if (model != null)
            {
                model.LoadWayRefData();
            }
        }

        private void WayRef_SourceUpdated(object sender, DataTransferEventArgs e)
        {

            var model = this.DataContext as DishesWayRefViewModel;
            if (model != null)
            {
                model.SavePrice2WayRef();
            }
        }
    }
}
