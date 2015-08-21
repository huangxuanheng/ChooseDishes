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
using IShow.ChooseDishes.ViewModel.Home.Setting;
using MahApps.Metro.Controls;

namespace IShow.ChooseDishes.View.Home.Setting
{
    /// <summary>
    /// ChooseShowTableWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ChooseShowTableWindow : MetroWindow
    {

        public ChooseShowTableWindow()
        {
            InitializeComponent();
            this.DataContext = new ChooseShowTableViewModel();
        }

        private void Selector_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            ChooseShowTableViewModel model = this.DataContext as ChooseShowTableViewModel;
            if (model.Selector == 1)
            {
                ViewTabControl.SelectedIndex=0;
            }
            else {
                ViewTabControl.SelectedIndex = 1;
            }


        }
    }
}
