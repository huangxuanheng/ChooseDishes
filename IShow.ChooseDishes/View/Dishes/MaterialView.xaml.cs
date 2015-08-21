using IShow.ChooseDishes.ViewModel.Common;
using IShow.ChooseDishes.ViewModel.Dishes;
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

namespace IShow.ChooseDishes.View.Dishes
{
    /// <summary>
    /// Interaction logic for OrgLocation.xaml
    /// </summary>
    public partial class MaterialView : MetroWindow
    {
        public MaterialView()
        {
            InitializeComponent();
        }


        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MaterialViewModel mvm = this.DataContext as MaterialViewModel;
            if (mvm != null)
            {
                mvm.ShowUpdateDetail();
            }
        }
    }
}
