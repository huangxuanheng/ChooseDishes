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
using IShow.ChooseDishes.ViewModel.Common;

namespace IShow.ChooseDishes.View.Common
{
    /// <summary>
    /// TreeViewWindow.xaml 的交互逻辑
    /// </summary>
    public partial class TreeViewWindow : Window
    {
        public TreeViewWindow()
        {
            InitializeComponent();
            this.DataContext = new TreeViewModel();
 
        }
        /// <summary>
        /// DataContext
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewModel model = this.DataContext as TreeViewModel;
            //TreeNodeModel node = sender as TreeNodeModel;
            model.SelectedItemChanged(e.NewValue as TreeNodeModel);
            //mvvm

        }

      
    }
}
