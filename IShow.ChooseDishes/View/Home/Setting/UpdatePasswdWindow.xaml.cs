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
using MahApps.Metro.Controls;

namespace IShow.ChooseDishes.View.Home.Setting
{
    /// <summary>
    /// UpdatePasswdWindow.xaml 的交互逻辑
    /// </summary>
    public partial class UpdatePasswdWindow : MetroWindow
    {
        public UpdatePasswdWindow()
        {
            InitializeComponent();
        }

        private void NumericKeypad_ClickedCommand(object sender, Controls.NumericKeypadEventArgs args)
        {

            MessageBox.Show("hello:" + args.Input + ",command:" + args.Back);
        }
    }
}
