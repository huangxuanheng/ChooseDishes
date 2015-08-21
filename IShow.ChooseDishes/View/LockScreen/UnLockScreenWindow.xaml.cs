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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IShow.ChooseDishes.View.LockScreen
{
    /// <summary>
    /// UnLockScreenWindow.xaml 的交互逻辑
    /// </summary>
    public partial class UnLockScreenWindow : Page
    {
        UnLockScreenViewModel unLockScreenViewModel;
        public UnLockScreenWindow()
        {
            InitializeComponent();
            unLockScreenViewModel = this.DataContext as UnLockScreenViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool isLock = unLockScreenViewModel.TestAccountInformation();
            if (isLock == true) { NavigationService.Navigate(new LockScreenWindow()); }
            else
            {
                MessageBox.Show("用户名密码错误！");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
