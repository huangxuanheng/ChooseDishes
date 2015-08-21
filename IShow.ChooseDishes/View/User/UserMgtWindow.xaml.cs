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
using IShow.ChooseDishes.ViewModel.User;
using MahApps.Metro.Controls;

namespace IShow.ChooseDishes.View.User
{
    /// <summary>
    /// UserMgtWindow.xaml 的交互逻辑
    /// </summary>
    public partial class UserMgtWindow : MetroWindow
    {
        public UserMgtWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           UserMgtViewModel model= this.DataContext as UserMgtViewModel;
           model.Init();
        }
    }
}
