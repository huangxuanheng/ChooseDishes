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

namespace IShow.ChooseDishes.View.Dishes
{
    /// <summary>
    /// Interaction logic for UpdateDish.xaml
    /// </summary>
    public partial class UpdateDish : Window
    {
        public UpdateDish()
        {
            InitializeComponent();
        }

        private void Exit_Win(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
