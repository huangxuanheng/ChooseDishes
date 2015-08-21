using IShow.ChooseDishes.Model;
using IShow.ChooseDishes.ViewModel;
using IShow.ChooseDishes.ViewModel.BuyDishGiving;
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

namespace IShow.ChooseDishes.View.BuyDishGiving
{
    /// <summary>
    /// AddGivingDishes.xaml 的交互逻辑
    /// </summary>
    public partial class AddGivingDishes : MetroWindow
    {
        GivingSelectedViewModel GivingSelected;
        public AddGivingDishes()
        {
            InitializeComponent();
            GivingSelected = this.DataContext as GivingSelectedViewModel;
            GivingSelected.Init();
        }

        private void EXIT_WIN(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DishBeanUtil a = (DishBeanUtil)this.dataGrid.SelectedItem;
            GivingSelected.OkSelect_Dish(a);
            this.Close();
        }
    }
}
