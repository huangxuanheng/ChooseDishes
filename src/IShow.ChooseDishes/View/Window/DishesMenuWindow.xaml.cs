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
using IShow.ChooseDishes.ViewModel;
using IShow.ChooseDishes.ViewModel.Common;

namespace IShow.ChooseDishes.View
{
    /// <summary>
    /// DishesMenuWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DishesMenuWindow : Window
    {
        public DishesMenuWindow()
        {
            InitializeComponent();
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            DishesMenuViewModel model = this.DataContext as DishesMenuViewModel;
            model.SelectedItemChanged(e.NewValue as TreeNodeModel);
        }

        private void EXIT_WIN(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
