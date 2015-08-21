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

namespace IShow.ChooseDishes.View.ClearEstimate
{
    /// <summary>
    /// ClearEstimateSettingWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ClearEstimateSettingWindow : MetroWindow
    {
        public ClearEstimateSettingWindow()
        {
            InitializeComponent();
        }

        public void ShowDifferentStyleWin(int ation)
        {
            if (ation == 0)
            {//新增操作，不显示上下记录按钮
                this.Last.Visibility = Visibility.Collapsed;
                this.Next.Visibility = Visibility.Collapsed;
            }
            else if (ation == 1)//修改操作，显示上下记录按钮
            {
                this.Last.Visibility = Visibility.Visible;
                this.Next.Visibility = Visibility.Visible;
            }
        }

        private void EXIT_WIN(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
