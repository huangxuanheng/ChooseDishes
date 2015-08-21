using IShow.ChooseDishes.ViewModel.TakeOut;
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

namespace IShow.ChooseDishes.View.TakeOut
{
    /// <summary>
    /// Interaction logic for TakeawayDeliveryWin.xaml
    /// </summary>
    public partial class TakeawayDeliveryWin : MetroWindow
    {
        public TakeawayDeliveryWin()
        {
            InitializeComponent();
            var a = new TakeawayDeliveryViewModel();
        }
    }
}
