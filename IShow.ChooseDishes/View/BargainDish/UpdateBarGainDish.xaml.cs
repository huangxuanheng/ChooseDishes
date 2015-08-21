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

namespace IShow.ChooseDishes.View.BargainDish
{
    /// <summary>
    /// Interaction logic for UpdateBarGainDish.xaml
    /// </summary>
    public partial class UpdateBarGainDish : MetroWindow
    {
        public UpdateBarGainDish()
        {
            InitializeComponent();
        }

        private void EXIT_WIN(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
