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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IShow.ChooseDishes.View.LockScreen
{
    /// <summary>
    /// LockScreenNavigationWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LockScreenNavigationWindow : MetroWindow
    {
        public LockScreenNavigationWindow()
        {
            InitializeComponent();
        }
        #region 隐藏导航栏关闭键
        //private const int GWL_STYLE = -16;
        //private const int WS_SYSMENU = 0x80000;
        //[System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        //private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        //[System.Runtime.InteropServices.DllImport("user32.dll")]
        //private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        //private void LockScreenNavigation_Loaded(object sender, RoutedEventArgs e)
        //{
        //    var hwnd = new WindowInteropHelper(this).Handle;
        //    SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        //}

        //protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        //{
        //    e.Cancel = true;
        //}
        #endregion
    }
}
