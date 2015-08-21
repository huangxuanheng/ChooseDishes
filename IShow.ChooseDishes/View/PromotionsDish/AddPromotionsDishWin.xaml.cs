using IShow.ChooseDishes.ViewModel;
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

namespace IShow.ChooseDishes.View.PromotionsDish
{
    /// <summary>
    /// Interaction logic for AddPromotionsDishWin.xaml
    /// </summary>
    public partial class AddPromotionsDishWin : MetroWindow
    {
        public AddPromotionsDishWin()
        {
            InitializeComponent();
        }

        private void EXIT_WIN(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        //{
        //    PromotionsDishWiewModel model = this.DataContext as PromotionsDishWiewModel;
        //    if (model != null) {
        //        model.InitAddWin();
        //    }
        //}
    }
}
