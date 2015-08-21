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
using IShow.ChooseDishes.View.LockScreen;
using IShow.ChooseDishes.ViewModel;

namespace IShow.ChooseDishes.View.LockScreen
{
    /// <summary>
    /// LockScreenWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LockScreenWindow : Page
    {
        LockScreenViewModel lockScreenViewModel;
        public LockScreenWindow()
        {
            InitializeComponent();
            lockScreenViewModel = this.DataContext as LockScreenViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //this.NavigationService.Navigate(new UnLockScreenWindow());
            bool isLock = lockScreenViewModel.TestAccountInformation();
            if (isLock == true) { NavigationService.Navigate(new UnLockScreenWindow()); } 
            else {
                MessageBox.Show("用户名密码错误！");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //LockScreenNavigationWindow navigationWindow = new LockScreenNavigationWindow();
            Application.Current.Shutdown(-1);
            //Console.WriteLine(string.Format("this.Parent {0}", this.NavigationService.));
            //MetroWindow window = (MetroWindow)this.Parent;
            //window.Close();
        }
    }
}
